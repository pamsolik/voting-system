using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using VotingSystemApi.Contracts.VotingSystem;
using VotingSystemApi.Models.DTOs;
using VotingSystemApi.Services;

namespace VotingSystemApi.Models
{
    public class NethereumSession
    {
        public string GenerateToken(string userId)
        {
            var mySecret = "afa234256srywer44234$Q#%*(42342*&@(dafbn../1436dfg5437yxj/..';[o23442342";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = "https://localhost:5001";
            var myAudience = "https://localhost:3000";

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserRole", "Administrator"),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public NethereumSession(AuthDto authDto)
        {
            ExpirationDate = DateTime.Now.AddMinutes(30);
            Token = GenerateToken(authDto.AccountAddress);
            UserAdress = authDto.AccountAddress;
            Pass = authDto.Password;
        }

        [JsonConstructor]
        public NethereumSession(DateTime expirationDate, string token, string userAdress, string pass)
        {
            ExpirationDate = expirationDate;
            Token = token;
            UserAdress = userAdress;
            Pass = pass;
        }

        public VotingSystemService UtilizeSession()
        {
            if (ExpirationDate < DateTime.Now) return null;
            ExpirationDate = DateTime.Now.AddMinutes(15);

            return NethereumProvider.GetVotingSystemService(UserAdress, Pass); ;
        }

        public DateTime ExpirationDate { get; set; }
        public string Token { get; set; }
        public string UserAdress { get; set; }
        public string Pass { get; set; }
    }
}