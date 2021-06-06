using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VotingSystemApi.Contracts.VotingSystem.ContractDefinition
{
    public partial class Result : ResultBase { }

    public class ResultBase 
    {
        [Parameter("string", "Candidate", 1)]
        public virtual string Candidate { get; set; }
        [Parameter("uint64", "Votes", 2)]
        public virtual ulong Votes { get; set; }
    }
}
