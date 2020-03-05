using MvvmTutorial.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmTutorial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pictures : ContentPage
    {
        public Pictures()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as PicturesViewModel)?.RefreshList();
        }


        //private async void takephotobutton_onclicked(object sender, eventargs e)
        //{
        //    await crossmedia.current.initialize();

        //    //if(!crossmedia.current.iscameraavailable || !crossmedia.current.ispickphotosupported)
        //    //{
        //    //    await si
        //    //}

        //    var file = await crossmedia.current.takephotoasync(
        //        new storecameramediaoptions
        //        {
        //            savetoalbum = true
        //        }
        //    );

        //    // pathlabel.text = file.albumpath;

        //    mainimage.source = imagesource.fromstream(() =>
        //    {
        //        var stream = file.getstream();
        //        file.dispose();
        //        return stream;
        //    });

        //}
        //private async void PickPhotoButton_OnClicked(object sender, EventArgs e)
        //{
        //    await CrossMedia.Current.Initialize();

        //    var file = await CrossMedia.Current.PickPhotoAsync();
        //    MainImage.Source = ImageSource.FromStream(() =>
        //    {
        //        var stream = file.GetStream();
        //        file.Dispose();
        //        return stream;
        //    });


        //}
    }
}