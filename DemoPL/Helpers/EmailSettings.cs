using DemoDAL.Entities;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace DemoPL.Helpers
{
	public static class EmailSettings
	{
		public static void SendEmail(Email email)
		{
			var client = new SmtpClient("smtp.gmail.com", 587);
			client .EnableSsl = true; //encrypted
			client.Credentials = new NetworkCredential("morabea1111111@gmail.com", "pwgkicpgaklnwiul");
			client.Send("morabea1111111@gmail.com", email.To, email.Subject, email.Body);

        }
	}
}
