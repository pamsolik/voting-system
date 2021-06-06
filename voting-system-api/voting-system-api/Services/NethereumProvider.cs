using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Numerics;
using VotingSystemApi.Contracts.VotingSystem;

namespace VotingSystemApi.Services
{
    public class NethereumProvider
    {
        private static readonly string _contractAdress = "0x443E168658a4788c6CeE6bEb4Df7ccAdBff5D90b";

        public static BigInteger GetTimeStamp(DateTime dateTime)
        {
            return dateTime.Ticks;
        }

        public static VotingSystemService GetVotingSystemService(string accountAdress, string password)
        {
            var account = new ManagedAccount(accountAdress, password);
            var web3 = new Web3(account, "HTTP://localhost:7545");
            return new VotingSystemService(web3, _contractAdress);
        }
    }
}