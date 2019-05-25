using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using System.Text;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PictureApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page

    {
        public class ImageItem
        {
            public BitmapImage ImageData { get; set; }
            public string ImageName { get; set; }
        }
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void AddImage_Click(object sender, RoutedEventArgs e)
        {
            //trigger dialogue box to enable the user to select an image
            {
                var picker = new FileOpenPicker();

                //WHen the Browse dialog opens show files in List mode
                picker.ViewMode = PickerViewMode.List;

                //Start location for browsing
                picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                picker.FileTypeFilter.Add(".jpg");
                picker.FileTypeFilter.Add(".jpeg");
                picker.FileTypeFilter.Add(".png");
                picker.FileTypeFilter.Add(".bmp");

                //StorageFile file = await picker.PickSingleFileAsync();
                //pick multiple files and store in files
                var files = await picker.PickMultipleFilesAsync();
            

            }
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ImagePage));
        }
    }
}
