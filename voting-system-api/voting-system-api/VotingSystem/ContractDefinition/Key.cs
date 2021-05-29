using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace VotingSystemApi.Contracts.VotingSystem.ContractDefinition
{
    public partial class Key : KeyBase { }

    public class KeyBase 
    {
        [Parameter("address", "KeyValue", 1)]
        public virtual string KeyValue { get; set; }
        [Parameter("uint256", "ElectionId", 2)]
        public virtual BigInteger ElectionId { get; set; }
        [Parameter("string", "Voter", 3)]
        public virtual string Voter { get; set; }
        [Parameter("address", "VoterAddress", 4)]
        public virtual string VoterAddress { get; set; }
        [Parameter("bool", "ValidKey", 5)]
        public virtual bool ValidKey { get; set; }
    }
}
