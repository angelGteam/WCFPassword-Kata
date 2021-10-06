using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WCFPassword_Kata.Domain.Models;
using WCFPassword_Kata.Services.Services;

public class MailService : IMailService {
    SmtpClient _smtpClient;
    public MailService() {
        _smtpClient = new SmtpClient("smtp.gmail.com") {
            Port = 587,
            Credentials = new NetworkCredential("smtptesting0610@gmail.com", "Aa.12345"),
            EnableSsl = true,
        };
    }

    public void SendResetEmail(User user) {
        MailMessage mailMessage = BuildMailMessage(user);
        mailMessage.To.Add("smtptesting0610@gmail.com");
        _smtpClient.Send(mailMessage);
    }

    private static MailMessage BuildMailMessage(User user) {
        ITokenService tokenService = new TokenService();
        return new MailMessage {
            From = new MailAddress(user.Email),
            Subject = "Password Change",
            Body = $@"Your sent an email to reset your password, go to the link below, to change it:
www.google/{tokenService.GenerateToken(user)}.com",
            IsBodyHtml = true,
        };
    }
}
