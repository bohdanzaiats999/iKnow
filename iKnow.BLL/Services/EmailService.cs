using AutoMapper;
using iKnow.BLL.Models;
using iKnow.DAL.Entityes;
using iKnow.DAL.Interfaces;
using iKnow.DAL.Repositories;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace iKnow.BLL.Services
{
    public class EmailService
    {
        IUnitOfWork Database { get; set; }
        public EmailService()
        {
            Database = new UnitOfWork();
        }
        private CancellationTokenSource CancellationToken { get; set; }

        // Cansell all tasks
        public void CansellTask()
        {
            if (CancellationToken != null)
            {
                CancellationToken.Cancel();
            }
        }

        public IList<EmailModel> GetEmailList()
        {
            IList<EmailEntity> emailEntities = Database.Repository<EmailEntity>().Include(e => e.Users).ToList();

            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<EmailEntity, EmailModel>());
            return new Mapper(config).Map<IList<EmailModel>>(emailEntities);
        }

        // Send Email using timer
        public async void TimerSendEmail()
        {
            CancellationToken = new CancellationTokenSource();

            // Get all email objects
            var emailModelList = GetEmailList();

            foreach (var emailModel in emailModelList)
            {

                DateTime sendingTime = (DateTime)emailModel.SendingTime;
                // Get intervar for timer
                TimeSpan interval = sendingTime - DateTime.Now;
                // When there is some interval
                if (interval > TimeSpan.Zero)
                {
                    await Task.Run(() =>
                    {
                        Thread.Sleep(interval);
                        emailModel.SendingTime = DateTime.MinValue;
                        SendEmail(emailModel);

                        IList<EmailEntity> emailEntities = Database.Repository<EmailEntity>().Include(e => e.Users).ToList();

                        MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<EmailModel, EmailEntity>());
                        var emailEntity = new Mapper(config).Map<EmailModel, EmailEntity>(emailModel);

                        Database.Repository<EmailEntity>().Update(emailEntity);
                        Database.SaveChanges();
                    });
                }
            }
        }

        public void SendEmail(EmailModel emailModel)
        {

            string fromAddress = "bohdan2131@gmail.com";
            string smtpServer = "smtp.gmail.com";
            int smtpPortNumber = 587;

            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(emailModel.FromAdressTitle, fromAddress));
                mimeMessage.To.Add(new MailboxAddress(emailModel.ToAddress, emailModel.ToAddress));
                mimeMessage.Subject = emailModel.Subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = emailModel.BodyContent
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(smtpServer, smtpPortNumber, false);
                    client.Authenticate("bohdan2131@gmail.com", "bohdan123");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
