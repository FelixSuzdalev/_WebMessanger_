namespace ModelsLibrary.Messages
{
    public class MessageRequest : AMessage
    {
        public MessageRequest():base()
        {

        }
        public MessageRequest(string Content,string Username) : base(Content,Username)
        {

        }
    }
}
