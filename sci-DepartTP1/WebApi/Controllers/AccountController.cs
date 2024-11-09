using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Super_Cartes_Infinies.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.DTOs;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private PlayersService _playersService;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, PlayersService playersService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _playersService = playersService;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO registerDTO)
        {

            if (registerDTO.Password != registerDTO.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Le mot de passe et la confirmation ne sont pas identique" });
            }

            IdentityUser user = new IdentityUser()
            {
                UserName = registerDTO.Username,
                Email = registerDTO.Email
            };
            IdentityResult identityResult = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = identityResult.Errors });
            }

            _playersService.CreatePlayer(user);

            return await Login(new LoginDTO() { Username = registerDTO.Username, Password = registerDTO.Password });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                Claim? nameIdentifierClaim = User.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                List<Claim> authClaims = new List<Claim>();
                authClaims.Add(nameIdentifierClaim);

                SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("C'est tellement la meilleure cle qui a jamais ete cree dans l'histoire de l'humanite (doit etre longue)"));

                string issuer = this.Request.Scheme + "://" + this.Request.Host;

                DateTime expirationTime = DateTime.Now.AddMinutes(30);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: null,
                    claims: authClaims,
                    expires: expirationTime,
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                );

                string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                // On ne veut JAMAIS retouner une string directement lorsque l'on utilise Angular.
                // Angular assume que l'on retourne un objet et donne une erreur lorsque le résultat obtenu est une simple string!
                return Ok(new LoginSuccessDTO() { 
                    Token = tokenString, 
                    Username = loginDTO.Username, 
                    PlayerId = _playersService.GetPlayerFromUserName(loginDTO.Username).Id, 
                    PlayerMoney = _playersService.GetPlayerFromUserName(loginDTO.Username).Money});
            }

            return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe ne concorde pas" });
        }

        [HttpGet]
        [Authorize]
        public ActionResult Test()
        {
            return Ok(new { message = "Success" });
        }
    }
}
