namespace MailSenderLib.Entities.Base
{
    public abstract class NamedEntity : BaseEntity
    {
        public virtual string Name { get; set; }
    }
}
