using System;
using System.Collections.Generic;

namespace Retail.Infrastructure.Models
{
    public partial class FileInfo
    {
        public FileInfo()
        {
            MessageTemplateFileInfoes = new HashSet<MessageTemplateFileInfo>();            
        }

        public int FileInfoId { get; set; }
        public string FileName { get; set; }
        public int? FileTypeId { get; set; }
        public string MimeType { get; set; }
        public string Path { get; set; }

        public virtual FileType FileType { get; set; }
        public virtual ICollection<MessageTemplateFileInfo> MessageTemplateFileInfoes { get; set; }
        
    }
}
