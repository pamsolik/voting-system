namespace VotingSystemApi.Models.Views
{
    public class MessageView
    {
        public MessageView(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}