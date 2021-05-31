namespace VotingSystemApi.Models.DTOs
{
    public class AddVoteDto
    {
        public AuthDto Auth { get; set; }
        public string Voter { get; set; }
        public string KeyAdr { get; set; }
        public byte CandidateId { get; set; }
    }
}