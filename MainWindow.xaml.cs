using loginwpfK020.negocio;
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

namespace loginwpfK020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
        private Loginservice login = new Loginservice();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextbox.Text ;
           string password = PasswordTextbox.Password;

            if (login.checkContraBaseDatos( username,  password))
           
            {
                // SalidaLabel.Content = "Usuario logeado";
                // MessageBox.Show("EXITO!!", "Usuario Logeado");

                VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
                ventanaPrincipal.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error de Login ", "Usuario o Password incorrectos");
                //SalidaLabel.Content = "Usuario o Password incorrectos";
            }
        }
    }
}
