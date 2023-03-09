using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
   public interface IMailService
    {
        public bool SendMessage(string message);
    }

    public class CloudMailsService: IMailService
    {
        public bool SendMessage(string message)
        {
            Console.WriteLine($"Message \"{message}\" sent via {nameof(CloudMailsService)}");
            return true;
        }
    }
    public class OnPremiseService : IMailService
    {
        public bool SendMessage(string message)
        {
            Console.WriteLine($"Message \"{message}\" sent via {nameof(OnPremiseService)}");
            return true;
        }
    }

    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }
        public virtual  bool SendMessage(string message)
        {
            return _mailService.SendMessage(message);
        }

    }

    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService)
        {
        }

        public override bool SendMessage(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(OnPremiseService)}");
            return base.SendMessage(message);
        }
    }

    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        public List<string> SentMessages { get; private set; } = new List<string>();
        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        {
        }

        public override bool SendMessage(string message)
        {
            if (base.SendMessage(message))
            {
                SentMessages.Add(message);
                return true;
            }
            return false;
        }
    }
}
