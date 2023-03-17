using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UploadForm.Application.Common;

namespace UploadForm.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            PersonDTO personDTO = new PersonDTO() { Name = Name.Text, SurName = SurName.Text, MiddleName = MiddleNameBox.Text };

            if (FileName.Text != null)
            {
                personDTO.Image = File.ReadAllBytes(FileName.Text);
                personDTO.FileName = System.IO.Path.GetFileName(FileName.Text);
            }

            using (HttpClient client = new HttpClient())
            {
                var respunce = await client.PostAsJsonAsync("https://localhost:7227/api/UploadForm", personDTO);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog() { CheckFileExists = true };

            if (dialog.ShowDialog() == true)
            {
                FileName.Text = dialog.FileName;                
            }
        }
    }
}
