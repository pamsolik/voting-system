using System;
using System.Collections.Generic;

namespace VotingSystemApi.Models.DTOs
{
    public class CreateElectionDto
    {
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<string> Candidates { get; set; }
        public byte KeysPerVoter { get; set; }
    }
}