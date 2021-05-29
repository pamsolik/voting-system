namespace VotingSystemApi.Models.Views
{
    public class Token
    {
        public Token(string val)
        {
            Value = val;
        }

        public string Value { get; }
    }
}