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

namespace WarehouseAccountingWPF
{
    /// <summary>
    /// Логика взаимодействия для VerificationCode.xaml
    /// </summary>
    using WarehouseAccountingDLL;
    
    public partial class VerificationCode : Window
    {
        private int _verificationMethod;

        public VerificationCode(int VerificationMethod)
        {
            InitializeComponent();
            _verificationMethod = VerificationMethod;
        }

        private async void VerificationButton_Click(object sender, RoutedEventArgs e)
        {
            switch (_verificationMethod)
            { 
                case 0:
                    Employee userDataV1 = await WarehouseAccountingDLL.UserAuthorization.SetAuthorizationLoginPassword("https://localhost:7284/api/UserAuthorization/AuthorizationV1", StorageData.login, StorageData.password, VerificationCodeText.Text);
                    if (userDataV1 != null)
                    {
                        this.DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный код авторизации", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;

                case 1:
                    Employee userDataV2 = await WarehouseAccountingDLL.UserAuthorization.SetAuthorizationVerifyCode("https://localhost:7284/api/UserAuthorization/AuthorizationV1", StorageData.email, VerificationCodeText.Text);
                    if (userDataV2 != null)
                    {
                        this.DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный код авторизации", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
            }
            
        }
    }
}
