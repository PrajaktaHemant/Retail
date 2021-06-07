using System;
using System.Collections.Generic;

namespace Retail.Infrastructure.Models
{
    public partial class NotificationChannelType
    {
        public NotificationChannelType()
        {
            CampaignChannelTypes = new HashSet<CampaignChannelType>();
            Notifications = new HashSet<Notification>();
        }

        public int NotificationChannelTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CampaignChannelType> CampaignChannelTypes { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
