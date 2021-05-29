namespace VotingSystemApi.Models.Views
{
    public class VotedView
    {
        public VotedView(bool val)
        {
            Voted = val;
        }

        public bool Voted { get; }
    }
}