using Landon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Landon.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //public IEnumerable<Customer> Customers { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void MyButton_Clicked(object sender, EventArgs e)
        {
            using (var client = new HttpClient()
            {
                BaseAddress = new Uri("https://landonapi.azurewebsites.net")
            })
            {
                var json = client.GetStringAsync("Countries").Result;
                var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
                MyCustomers.ItemsSource = countries;
            }
        }
    }
}
