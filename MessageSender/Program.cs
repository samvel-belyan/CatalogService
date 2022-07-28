//this application should be hosted separately 

using Application.Implementations;

var messageService = new MessageService();

while (true)
{
    while (MessageService.UnsentMessages.Any())
    {
        MessageService.UnsentMessages.TryPeek(out string? message);
        if(!string.IsNullOrEmpty(message))
        {
            messageService.Send(message);
            MessageService.UnsentMessages.Dequeue();
        }
    }

    Thread.Sleep(2000);
}