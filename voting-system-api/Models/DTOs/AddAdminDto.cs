namespace VotingSystemApi.Models.DTOs
{
    public class AddAdminDto
    {
        public AuthDto Auth { get; set; }
        public string Admin { get; set; }
    }
}