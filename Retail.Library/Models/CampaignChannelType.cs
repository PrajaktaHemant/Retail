using System;
namespace Retail.Infrastructure.Models
{
    public partial class CampaignChannelType
    {
        public int CampaignChannelTypeId { get; set; }
        public int CampaignMasterId { get; set; }
        public int NotificationChannelTypeId { get; set; }

        public virtual CampaignMaster CampaignMaster { get; set; }
        public virtual NotificationChannelType NotificationChannelType { get; set; }
    }
}
