using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Edu
{
    interface IMessage
    {
        public void Send();
    }

    class SMS : IMessage
    {
        public string Body { get; set; }
        public string Phone { get; set; }

        public void Send()
        {
            SendSms();
        }

        public void SendSms()
        {
            Console.WriteLine($"Wysyłanie wiadomości \"{Body}\" na numer {Phone}");
        }
    }

    class Email : IMessage
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string TargetEmail { get; set; }

        public void Send()
        {
            SendEmail();
        }

        public void SendEmail()
        {
            Console.WriteLine($"Wysyłanie wiadomości \"{Subject}\" na numer {TargetEmail}");
        }
    }

    class Messanger
    {
        //public SMS Sms { get; set; }
        //public Email Email { get; set; }
        IEnumerable<IMessage> Messages { get; set; }

        public Messanger(IEnumerable<IMessage> messages)
        {
            Messages = messages;
        }
        public void Execute(IEnumerable<IMessage> messages)
        {
            //Sms?.SendSms();
            //Email?.SendEmail();
            foreach (var item in messages)
            {
                item.Send();
            }
        }

        public void Execute()
        {
            Execute(Messages);
        }
    }
}
