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
using FastX.Core.Authenticator;
using FastX.Core.Launch;
using FastX.Core.Helpers;
using FastX.Class.Models;
namespace MyLauncher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        SettingHelper setting = new SettingHelper();
        public MainWindow()
        {
            InitializeComponent();
            game.ItemsSource = setting.FindAllGame(@"C:\Users\w\Desktop\总整包\MC\mc启动器\LauncherX\.minecraft");
            java.ItemsSource = setting.GetJavaPath();
        }
        List<string> uuid = new List<string>();
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var v = setting.GenerateParameterofYggdrasil(@"C:\Users\w\Desktop\authlib-injector.jar", uri.Text);
            //Launch
            LaunchAsyncs launchAsyncs = new LaunchAsyncs();
            LaunchModel launch = new LaunchModel()
            {
                //AddJVMparameters=v,
                JavaExecutable = java.Text,
                Version = game.Text,
                Maxmemory = Convert.ToInt32(zdnc.Text),
                Authenticator = new MicrosoftAuthenticator() 
                {
                    Name = ,//ygg.SelectedItem.ToString(),
                    Uuid = ,//uuid[ygg.SelectedIndex],
                    Token = 
                },    
            };
            await launchAsyncs.LaunchTaskAsync(launch);
        }
        YggdrasilModels models =new YggdrasilModels();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Login
            YggdrasilAuthenticator authenticator = new YggdrasilAuthenticator(uri.Text,email.Text,password.Password);
            models = authenticator.YggdrasilLogin();
            for (int i = 0; i < models.UserAccount.Length; i++)
            {
                ygg.Items.Add(models.UserAccount[i].Name);
                uuid.Add(models.UserAccount[i].Uuid);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        }
    }
}
