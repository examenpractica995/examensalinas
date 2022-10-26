using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace examen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // HttpClient  cliente = new HttpClient();
        public MainWindow()
        {
            
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.obtenerApi();
            // Show message box when button is clicked.
           
        }
         
         private async void obtenerApi()
         {
           btnObtener.IsEnabled = false;
           btnObtener.Background = Brushes.Red;
            
         using (HttpClient client = new HttpClient())
            {
                try{
                HttpResponseMessage response = await client.GetAsync("https://pokeapi.co/api/v2/pokemon/ditto");
                  //HttpResponseMessage response = await client.GetAsync("https://api.github.com/users");
                    response.EnsureSuccessStatusCode();
                    if(response.IsSuccessStatusCode)
                    {
                    txtmicaja.Text= await response.Content.ReadAsStringAsync();
                    btnObtener.IsEnabled = true;
                    }
                  }
                   catch(WebException e)
                   {

                    Console.WriteLine("\nThe following Exception was raised : {0}",e.Message);
                   }
                    
            }
                
                    
        }

        private void btnObtener_MouseEnter(object sender, MouseEventArgs e)
         {
         btnObtener.Background = Brushes.Aqua;
        }
         private void btnObtener_MouseLeave(object sender, MouseEventArgs e)
         {
         btnObtener.Background =Brushes.Transparent ;
        }
    }
}
