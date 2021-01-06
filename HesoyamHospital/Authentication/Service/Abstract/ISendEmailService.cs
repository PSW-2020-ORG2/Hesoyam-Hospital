namespace Authentication.Service.Abstract
{
    public interface ISendEmailService
    {
        public void SendActivationEmail(long id, string patientEmailAddress);
        public long TokenToId(string token);
    }
}
