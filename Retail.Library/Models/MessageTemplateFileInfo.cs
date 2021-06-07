using System;
namespace Retail.Infrastructure.Models
{
    public partial class MessageTemplateFileInfo
    {
        public int MessageTemplateId { get; set; }
        public int FileInfoId { get; set; }

        public virtual FileInfo FileInfo { get; set; }
        public virtual MessageTemplate MessageTemplate { get; set; }
    }
}
