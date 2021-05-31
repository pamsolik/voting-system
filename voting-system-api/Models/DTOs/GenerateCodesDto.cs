namespace VotingSystemApi.Models.DTOs
{
    public class GenerateCodesDto
    {
        public AuthDto Auth { get; set; }
        public string ElectionId { get; set; }
        public string VoterAdress { get; set; }
        public string Voter { get; set; }
    }
}