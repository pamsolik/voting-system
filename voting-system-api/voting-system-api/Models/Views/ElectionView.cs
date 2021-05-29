using System;
using System.Collections.Generic;
using VotingSystemApi.Contracts.VotingSystem.ContractDefinition;

namespace VotingSystemApi.Models.Views
{
    public class ElectionView
    {
        public ElectionView(Election election)
        {
            ElectionId = election.ElectionId.ToString();
            Title = election.Title;
            DateFrom = new DateTime((long)election.DateFrom);
            DateTo = new DateTime((long)election.DateTo);
            Candidates = election.Candidates;
        }

        public string ElectionId { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<string> Candidates { get; set; }
    }
}