using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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

namespace dododo
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

            public static string Encrypt_Password(string password, int salt)
            {
                using (SHA256 sha256Hash = SHA256.Create())

                {

                    //convert the given password and the computed salt to SHA256, byte for byte
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password + salt));

                    //afterwards, inorder to construct the hash we pass off the bytes to a stringbuilder to get it in one line
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }

                    //return the encrypted password
                    return sb.ToString();
                }
            }
            public static int saltify(string password)
            {
                //Inorder to salt the password, we take each char in the given password, add it together in a sum

                int charAsDecimal = 0;
                foreach (char character in password)
                {
                    charAsDecimal = Convert.ToInt32(character);
                    Console.WriteLine(charAsDecimal);
                }
                //after computing the sum we take the passwords length and calculate that passwords sum, such as a password with length 3 becomes 3+2+1 = 6.
                int total = charAsDecimal + ((password.Length * password.Length / 2) + (password.Length / 2));
                //lastly take the computed sum and return it to be used as a salt.
                return total;
            }

        private void uhg_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            Test.Text = Encrypt_Password(uhg.Text, saltify(uhg.Text));
            Debug.WriteLine(uhg.Text);
        }
    }
    }
