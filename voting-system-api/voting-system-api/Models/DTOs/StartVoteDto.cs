namespace VotingSystemApi.Models.DTOs
{
    public class StartVoteDto
    {
        public AuthDto Auth { get; set; }
        public string KeyAdr { get; set; }
        public string Voter { get; set; }
    }
}