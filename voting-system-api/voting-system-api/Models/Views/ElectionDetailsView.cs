using System;
using System.Collections.Generic;
using VotingSystemApi.Contracts.VotingSystem.ContractDefinition;

namespace VotingSystemApi.Models.Views
{
    public class ElectionDetailsView
    {
        public ElectionDetailsView(GetDetailsOutputDTO election)
        {
            ElectionId = election.Value.ElectionId.ToString();
            Title = election.Value.Title;
            DateFrom = new DateTime((long)election.Value.DateFrom);
            DateTo = new DateTime((long)election.Value.DateTo);
            Results = election.Value.Results;
            
        }

        public string ElectionId { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<Result> Results { get; set; }
    }
}