using VotingSystemApi.Contracts.VotingSystem;
using VotingSystemApi.Models.DTOs;
using VotingSystemApi.Models.Views;

namespace VotingSystemApi.Services
{
    public interface IAuthService
    {
        public Token Authenticate(AuthDto authDto);

        public VotingSystemService GetSession(string token);
    }
}