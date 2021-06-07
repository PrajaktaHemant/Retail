using System;
namespace Retail.Infrastructure.Models
{
    public partial class MessageTemplate
    {
        public int MessageTemplateId { get; set; }
        public int NotificationEventType { get; set; }
        public string ChannelTypeId { get; set; }
        public int LanguageId { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public string Recipient { get; set; }

        public virtual Language Language { get; set; }
        public virtual MessageTemplateFileInfo MessageTemplateFileInfo { get; set; }
    }
}
