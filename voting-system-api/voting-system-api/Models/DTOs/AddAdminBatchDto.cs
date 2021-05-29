using System.Collections.Generic;

namespace VotingSystemApi.Models.DTOs
{
    public class AddAdminBatchDto
    {
        public AuthDto Auth { get; set; }
        public List<string> Admins { get; set; }
    }
}