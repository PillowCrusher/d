namespace ICT4_Participation_MVC.Models
{
    public class Review
    {
        public int HelpRequestId { get; private set; }
        public int VolunteerId { get; private set; }
        public string Message { get; private set; }

        public Review(int helpRequestId, int volunteerId, string message)
        {
            HelpRequestId = helpRequestId;
            VolunteerId = volunteerId;
            Message = message;
        }

        public override string ToString()
        {
            return "Helprequest: " + HelpRequestId;
        }
    }
}
