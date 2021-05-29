using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VotingSystemApi.Contracts.VotingSystem.ContractDefinition
{
    public partial class Election : ElectionBase { }

    public class ElectionBase 
    {
        [Parameter("uint256", "ElectionId", 1)]
        public virtual BigInteger ElectionId { get; set; }
        [Parameter("string", "Title", 2)]
        public virtual string Title { get; set; }
        [Parameter("uint64", "DateFrom", 3)]
        public virtual ulong DateFrom { get; set; }
        [Parameter("uint64", "DateTo", 4)]
        public virtual ulong DateTo { get; set; }
        [Parameter("uint8", "KeysPerVoter", 5)]
        public virtual byte KeysPerVoter { get; set; }
        [Parameter("string[]", "Candidates", 6)]
        public virtual List<string> Candidates { get; set; }
    }
}
