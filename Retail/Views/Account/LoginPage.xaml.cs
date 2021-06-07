using System;
using System.Collections.Generic;
using Retail.Hepler;
using Retail.Models;
using Retail.ViewModels.Account;
using Xamarin.Forms;

namespace Retail.Views.Account
{
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel viewModel { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            CommonAttribute.selectedLang = new LanguageModel() { LongName = "English", LongCode = "en", lid = 1 };
            BindingContext = viewModel = new LoginViewModel(Navigation);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

            Picker langPicker = sender as Picker;
            var selectedItem = langPicker.SelectedItem as LanguageModel;
            CommonAttribute.selectedLang = selectedItem;
            lblLong.Text = selectedItem.LongName;
            viewModel.ChangeLangugeCommand.Execute(selectedItem.LongCode);
            
            if (CommonAttribute.selectedLang.LongCode == "ur")
            {
                viewModel.flowDirection = FlowDirection.RightToLeft;
                //  Device.FlowDirection
                // Application.Current.MainPage.FlowDirection = FlowDirection.RightToLeft;
                // Application.Current.MainPage =new  LoginPage();
            }
            else
                viewModel.flowDirection = FlowDirection.LeftToRight;


            CommonAttribute.flowDirection = viewModel.flowDirection;
            // Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
        protected async override void OnAppearing()
        {
            if (Application.Current.Properties.ContainsKey("email"))
                viewModel.Email = Application.Current.Properties["email"].ToString();
            base.OnAppearing();


        }
        private void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {

            Device.InvokeOnMainThreadAsync(() => {
                if (pkLong.IsFocused)
                    pkLong.Unfocus();

                pkLong.Focus();
            });


        }

    }
}
