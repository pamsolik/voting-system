namespace VotingSystemApi.Models.Views
{
    public class TokenView
    {
        public TokenView(string message, string val)
        {
            Message = message;
            AuthToken = val;
        }

        public string Message { get; }
        public string AuthToken { get; }
    }
}