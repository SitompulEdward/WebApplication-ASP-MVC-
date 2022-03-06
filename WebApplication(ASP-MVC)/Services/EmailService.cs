using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Models;

namespace WebApplication_ASP_MVC_.Services
{
    public class EmailService
    {
        private readonly IOptions<Email> _dariJson;

        public EmailService(IOptions<Email> em)
        {
            _dariJson = em;
        }

        public bool KirimEmail(string tujuan, string judulEmail, string isiEmail)
        {
            try
            {
                //dapatkan data dari appsetting.json
                // tampung di variabel

                Email e = new();

                e.NamaClientnya = _dariJson.Value.NamaClientnya;
                e.Portnya = _dariJson.Value.Portnya;
                e.EmailKita = _dariJson.Value.EmailKita;
                e.PasswordEmailKita = _dariJson.Value.PasswordEmailKita;

                //atur Email
                MailMessage m = new();

                m.From = new MailAddress(e.EmailKita);
                m.Subject = judulEmail;
                m.Body = isiEmail;
                m.IsBodyHtml = true;
                m.To.Add(tujuan);

                //atur server
                SmtpClient s = new SmtpClient(e.NamaClientnya);

                s.Port = e.Portnya;
                s.Credentials = new System.Net.NetworkCredential(e.EmailKita, e.PasswordEmailKita);
                s.EnableSsl = true;
                s.Send(m);

                //kalau berhasil
                return true;
            }
            catch
            {
                //kalau gagal
                return false;
            }
        }
    }
}
