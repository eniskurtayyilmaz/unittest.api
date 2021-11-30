namespace Unittest.Api.Services
{
    public interface INotificationSender
    {
        void SendNotification(string message);
    }

    
    
    public class EmailSender : INotificationSender
    {
        public void SendNotification(string message)
        {
            
            //Mail gitti.
        }
    }
    
    //SMSSender
}