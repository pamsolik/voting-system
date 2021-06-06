using System;
using VotingSystemApi.Contracts.VotingSystem;
using VotingSystemApi.Models;
using VotingSystemApi.Models.DTOs;
using VotingSystemApi.Models.Views;

namespace VotingSystemApi.Services
{
    public interface IAuthService
    {

        public VotingSystemService GetSession(byte[] arrBytes);

        byte[] ConvertSession(NethereumSession obj);

        bool ValidateCurrentToken(string token);
    }
}