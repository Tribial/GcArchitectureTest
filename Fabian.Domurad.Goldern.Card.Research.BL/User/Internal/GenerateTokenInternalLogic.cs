using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Fabian.Domurad.Golden.Card.Research.BL.User.Internal
{
    public class GenerateTokenInternalLogic : IInternalLogic<UserDto, TokenDto>
    {
        private readonly IConfiguration _configuration;
        public GenerateTokenInternalLogic(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Obsolete(DevelopmentMessageConst.UseSyncMethod, false)]
        public async Task<TokenDto> ExecuteAsync(UserDto param)
        {
            return await new Task<TokenDto>(() => Execute(param));
        }

        public TokenDto Execute(UserDto param)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[SettingsConst.JwtKeyRoot]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, param.Email),
                new Claim(ClaimTypes.Role, param.Role.GetRoleName()),
                new Claim(ClaimTypes.Name, param.Username),
                new Claim(ClaimTypes.GivenName, $"{param.Firstname} {param.Lastname}")
            };
            var token = new JwtSecurityToken(_configuration[SettingsConst.JwtIssuerRoot],
                _configuration[SettingsConst.JwtIssuerRoot],
                claims,
                expires: DateTime.Now.AddHours(int.Parse(_configuration[SettingsConst.JwtExpireHoursRoot])),
                signingCredentials: credentials);

            return new TokenDto
            {
                JwtToken = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
