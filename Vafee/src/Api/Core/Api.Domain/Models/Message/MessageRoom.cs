using Api.Domain.Models.Identity;

namespace Api.Domain.Models.Message;

public class MessageRoom
{
    public string Id { get; set; }
    public bool IsGroup => Users.Count > 2 ? true : false;
    
    public List<User> Users { get; set; }
    public List<Message> Messages { get; set; }
}