using System.Collections.Generic;
using System.Linq;
using VotingSystemApi.Contracts.VotingSystem;
using VotingSystemApi.Models;
using VotingSystemApi.Models.DTOs;
using VotingSystemApi.Models.Views;

namespace VotingSystemApi.Services
{
    public class AuthService : IAuthService
    {
        public List<Session> ActiveSessions { get; } = new List<Session>();

        public Token Authenticate(AuthDto authDto)
        {
            //ActiveSessions.RemoveAll(session => session.UserAdress == authDto.AccountAddress);
            var session = new Session(authDto);
            ActiveSessions.Add(session);
            return new Token(session.Token);
        }

        public VotingSystemService GetSession(string token)
        {
            //ActiveSessions.RemoveAll(session => session.ExpirationDate < DateTime.Now);
            var session = ActiveSessions.FirstOrDefault(session => session.Token == token);
            if (session == null) return null;
            return session.UtilizeSession();
        }
    }
}