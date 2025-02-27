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
using System.Windows.Shapes;
using WarehouseAccountingDLL;

namespace WarehouseAccountingWPF
{
    /// <summary>
    /// Логика взаимодействия для UserAuthorization.xaml
    /// </summary>
    public partial class UserAuthorization : Window
    {
        public UserAuthorization()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            switch (LoginMethod.SelectedIndex)
            { 
                case 0:
                    VerificationCode verificationCodeV1 = new VerificationCode(0);
                    StorageData.login = Login.Text;
                    StorageData.password = Password.Text;

                    if (verificationCodeV1.ShowDialog() == true)
                    { 
                        MainWin mainWin = new MainWin();
                        mainWin.Show();
                        this.Hide();
                    }
                    break;

                case 1:
                    WarehouseAccountingDLL.UserAuthorization.SetAuthorizationEmail("https://localhost:7284/api/UserAuthorization/AuthorizationV2_Send_Code", Email.Text);
                    VerificationCode verificationCodeV2 = new VerificationCode(1);
                    StorageData.email = Email.Text;

                    if (verificationCodeV2.ShowDialog() == true)
                    {
                        MainWin mainWin = new MainWin();
                        mainWin.Show();
                        mainWin.Hide();
                    }
                    break;
            }
        }
    }
}
