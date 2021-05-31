using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Numerics;
using VotingSystemApi.Contracts.VotingSystem;

namespace VotingSystemApi.Services
{
    public class NethereumProvider
    {
        //public const string TestAccountAdress = "0x3bCCC4134165893283C8df486C7Ee662EBd6257F";

        private static readonly string _contractAdress = "0x49b8C94c9b137333dc74241B6711fE37251A50c0";

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