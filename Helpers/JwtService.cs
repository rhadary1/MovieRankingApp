using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RankingApp.Helpers
{
    public class JwtService
    {
        private string _secureKey = "This is a very secure key indeed.";    

        public string Generate(int id)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secureKey));
            var creds = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(creds);

            var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Now.AddDays(1)); 
            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken); 
        }

        public JwtSecurityToken Verify(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secureKey);

            tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,    
                ValidateIssuer = false,
                ValidateAudience = false
            },
            out SecurityToken validatedToken);

            return (JwtSecurityToken) validatedToken; 
        }
    }
}
