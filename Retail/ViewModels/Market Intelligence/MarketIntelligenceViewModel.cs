using System;
using Retail.Views.DemoControls;
using Retail.Views.MarketIntelligence;
using Retail.Views.ProductCatalogue;
using Xamarin.Forms;

namespace Retail.ViewModels.MarketIntelligence
{
    public class MarketIntelligenceViewModel : BaseViewModel
    {
        public MarketIntelligenceViewModel(INavigation navigation):base(navigation)
        {
            
        }

        public Command MarketInsightsCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new MarketInsights());
                });
            }
        }

        public Command QuestionnaireCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new Questionnaire());
                });
            }
        }

        public Command ProductTestCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new ProductTest());
                });
            }
        }

        public Command SurveyCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new Survey());
                });
            }
        }

        public Command ScanBarcodeCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new Barcode());
                });
            }
        }

        public Command ScanQRCodeCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new QRCode());
                });
            }
        }

    }
}

