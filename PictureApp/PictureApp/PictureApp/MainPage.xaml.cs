using PictureApp.Models;
using PictureApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace PictureApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
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
         void DoubleTapped(object sender, EventArgs args)
        {
            var SelectedImage = sender as Image;

            var selectedItem = SelectedImage.BindingContext as Picture;

            var PictureViewModel = new PicturesViewModel();
            PictureViewModel.Like(selectedItem);
        }
    }
}
