using System.Collections.Generic;
using VotingSystemApi.Contracts.VotingSystem.ContractDefinition;

namespace VotingSystemApi.Models.Views
{
    public class ElectionsView
    {
        public ElectionsView(GetElectionsOutputDTO getElectionsOutputDTO)
        {
            if (getElectionsOutputDTO != null)
            {
                foreach (var election in getElectionsOutputDTO.ElectionList)
                {
                    Elections.Add(new ElectionView(election));
                }
            }
        }

        public List<ElectionView> Elections { get; set; } = new List<ElectionView>();
    }
}