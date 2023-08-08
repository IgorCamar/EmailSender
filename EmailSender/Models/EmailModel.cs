namespace EmailSender.Models
{
    public class EmailModel
    {
        public string ToEmail { get; set; }
        public string Password { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
    }

}
