using MailSenderLib.Entities.Base;

namespace MailSenderLib.Entities
{
    public class Mail : BaseEntity
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        //public ICollection Attachments { get; set; } = new List<MailAttachment>();
    }

    //public class MailAttachment : BaseEntity
    //{
    //    //...
    //}
}
