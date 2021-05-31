using System;
using System.Linq;
using VotingSystemApi.Contracts.VotingSystem;
using VotingSystemApi.Models.DTOs;
using VotingSystemApi.Services;

namespace VotingSystemApi.Models
{
    public class Session
    {
        public Session(AuthDto authDto)
        {
            VService = NethereumProvider.GetVotingSystemService(authDto.AccountAddress, authDto.Password);
            ExpirationDate = DateTime.Now.AddMinutes(15);
            Random random = new Random();
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=/'][;.,<>?:{}";
            Token = new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(64).ToArray());
            UserAdress = authDto.AccountAddress;
        }

        public VotingSystemService UtilizeSession()
        {
            if (ExpirationDate < DateTime.Now) return null;
            ExpirationDate = DateTime.Now.AddMinutes(15);

            return VService;
        }

        public VotingSystemService VService;
        public DateTime ExpirationDate { get; set; }
        public string Token { get; }
        public string UserAdress { get; }
    }
}