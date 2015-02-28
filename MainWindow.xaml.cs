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
using Un4seen.Bass;
using Un4seen.BassWasapi;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;
using System.IO;
using FirstFloor.ModernUI.Windows.Controls;


namespace VKAll
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {   
        public MainWindow()
        {
            InitializeComponent();
            txtEMail.Text = Properties.Settings.Default.eMail_set;
            txtPass.Text = Properties.Settings.Default.pass_set;
            
        }

        private void btnAutorizet_Click(object sender, RoutedEventArgs e)
        {
            int appID = 4804605;
            string email = txtEMail.Text;
            string pass = txtPass.Text;
            Settings scope = Settings.Friends;

            var VK = new VkApi();
            
            try
            {
                VK.Authorize(appID, email, pass, scope);
                var MainWind = new frmMainWind();
                MainWind.Show();
                Close();
            }
            catch (VkApiAuthorizationException)
            {
                
                //TypeInitializationException ex
                MessageBox.Show("Не верный логин или пароль!");
            }
            //if (chkPassSave.IsChecked.Value)
            //{
            //    Properties.Settings.Default.pass_set = txtPass.Text;
            //    Properties.Settings.Default.Save();
            //}
            //else
            //{
            //    Properties.Settings.Default.pass_set = "";
            //    Properties.Settings.Default.Save();
            //}
        }
    }
}
