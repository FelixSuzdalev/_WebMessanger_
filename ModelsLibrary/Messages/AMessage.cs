namespace ModelsLibrary.Messages
{
    public abstract class AMessage
    {
        public string Content { get; set; }
        public string Username { get; set; }


        public AMessage()
        {
            Content = "";
            Username = "";
        }

        public AMessage(string Content, string Username)
        {
            this.Content = Content;
            this.Username = Username;
        }
    }
}
