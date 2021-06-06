using System;
using System.Collections.Generic;
using VotingSystemApi.Contracts.VotingSystem.ContractDefinition;

namespace VotingSystemApi.Models.Views
{
    public class StartElectionView
    {
        public StartElectionView(StartVoteOutputDTO election)
        {
            ElectionId = election.El.ElectionId.ToString();
            Title = election.El.Title;
            DateFrom = new DateTime((long)election.El.DateFrom);
            DateTo = new DateTime((long)election.El.DateTo);
            Candidates = election.El.Candidates;
            KeysPerVoter = election.El.KeysPerVoter;
        }

        public string ElectionId { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public virtual byte KeysPerVoter { get; set; }
        public List<string> Candidates { get; set; }
    }
}