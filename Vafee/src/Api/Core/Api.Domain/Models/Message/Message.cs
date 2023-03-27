namespace Api.Domain.Models.Message;

public class Message
{
    public string SenderId { get; set; }

    
    // ReceiverId sadece 2 kişi olanlarda
    public string? ReceiverId { get; set; }
    
    public DateTime Date { get; set; }
    public string Context { get; set; }
}