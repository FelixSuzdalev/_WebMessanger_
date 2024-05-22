using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Messages;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        public static List<MessageResponse> messages = new ();
        // GET: api/messages 
        [HttpGet]
        public ActionResult<IEnumerable<MessageResponse>> Get()
        {
            return Ok(messages);
        }
        // POST: api/messages 
        [HttpPost]
        public ActionResult Post([FromBody] MessageRequest message)
        {
            
            messages.Add(new MessageResponse(message, messages.Count));
            return Ok();
        }
    }
}