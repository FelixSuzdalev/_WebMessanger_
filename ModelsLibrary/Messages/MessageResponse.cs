namespace ModelsLibrary.Messages
{
    public class MessageResponse : AMessage
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }


        public MessageResponse() : base()
        {
            DateTime= DateTime.Now;
        }


        public MessageResponse(MessageRequest messageRequest)
            : base(messageRequest.Content,messageRequest.Username)
        {
            DateTime = DateTime.Now;
        }



        public MessageResponse(MessageRequest messageRequest,int id): this(messageRequest)
        {
            this.Id = id;
        }
    }
}
