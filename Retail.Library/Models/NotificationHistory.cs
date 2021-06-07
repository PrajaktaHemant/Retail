using System;
namespace Retail.Infrastructure.Models
{
    public partial class NotificationHistory
    {
        public int NotificationHistoryId { get; set; }
        public int PersonId { get; set; }
        public int NotificationEventTypeId { get; set; }
        public DateTime? Created { get; set; }
        public int? MessageTemplateId { get; set; }
        public int? NotificationId { get; set; }

        public virtual Notification Notification { get; set; }
    }
}
