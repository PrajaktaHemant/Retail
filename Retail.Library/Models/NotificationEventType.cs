using System;
using System.Collections.Generic;

namespace Retail.Infrastructure.Models
{
    public partial class NotificationEventType
    {
        public NotificationEventType()
        {
            Notifications = new HashSet<Notification>();
        }

        public int NotificationEventTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
