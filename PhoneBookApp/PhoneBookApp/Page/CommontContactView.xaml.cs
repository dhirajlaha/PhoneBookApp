using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneBookApp.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommontContactView : ContentView
    {
        public CommontContactView()
        {
            InitializeComponent();
        }

        //    private async void Button_Clicked(object sender, EventArgs e)
        //    {
        //        await MediaPicker.PickPhotoAsync();
        //    }
    }
    
}