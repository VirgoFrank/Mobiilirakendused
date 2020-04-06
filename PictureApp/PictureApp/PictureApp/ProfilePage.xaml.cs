using PictureApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PictureApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var onAppearingLifeCycleEvents = BindingContext as IPageAppearingEvent;
            if (onAppearingLifeCycleEvents != null)
            {
                var lifecycleHandler = onAppearingLifeCycleEvents;

                base.Appearing += (object sender, EventArgs e) => lifecycleHandler.OnAppearing();
            }
        }
    }
}