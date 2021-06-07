using System;
namespace Retail.Infrastructure.Models
{
    public partial class CampaignCountry
    {
        public int CampaignCountryId { get; set; }
        public int CampaignMasterId { get; set; }
        public int CountryId { get; set; }

        public virtual CampaignMaster CampaignMaster { get; set; }
        public virtual Country Country { get; set; }
    }
}
