using System.Collections.Generic;
using VotingSystemApi.Contracts.VotingSystem;
using VotingSystemApi.Models;
using System;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace VotingSystemApi.Services
{
    public class AuthService : IAuthService
    {
        public List<NethereumSession> ActiveSessions { get; } = new List<NethereumSession>();

        public byte[] ConvertSession(NethereumSession obj)
        {
            return JsonSerializer.SerializeToUtf8Bytes(obj);
        }

        public VotingSystemService GetSession(byte[] arrBytes)
        {
            if (arrBytes == null) throw new UnauthorizedAccessException("Session expired or doesn't exist.");
            var session = JsonSerializer.Deserialize<NethereumSession>(arrBytes);
            if (session == null || session.ExpirationDate < DateTime.Now) throw new UnauthorizedAccessException("Session expired or doesn't exist.");
            return session.UtilizeSession();
        }

		public bool ValidateCurrentToken(string token)
		{
			var mySecret = "afa234256srywer44234$Q#%*(42342*&@(dafbn../1436dfg5437yxj/..';[o23442342";
			var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

			var myIssuer = "https://localhost:5001";
			var myAudience = "https://localhost:3000";

			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = myIssuer,
					ValidAudience = myAudience,
					IssuerSigningKey = mySecurityKey
				}, out SecurityToken validatedToken);
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
}