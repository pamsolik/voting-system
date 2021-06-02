using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Numerics;
using VotingSystemApi.Contracts.VotingSystem;

namespace VotingSystemApi.Services
{
    public class NethereumProvider
    {
        private static readonly string _contractAdress = "0x99B5A1527C7a53c32041E051047b71593a70E407";

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