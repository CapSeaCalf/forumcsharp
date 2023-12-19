using System.IO;
using System.Windows.Controls;

namespace forumcsharp
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            string[] dataBase;
            string login

            if (LoginTextBox.Text != "" && PasswordTextBox.Password != "")
            {
                login = isSignedUp();
                if(login != null) NavigationService.Navigate(page2, Login);
            }
        }

        private void SignUpButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (LoginTextBox.Text != "" && PasswordTextBox.Password != "")
            {
                login = isSignedUp();
                if(login == null) 
                {
                    File.AppendAllText("database.txt", LoginTextBox.Text + " " + PasswordTextBox.Password + "\n");
                    Page2 page2 = new Page2(); // Create an instance of Page2
                    NavigationService.Navigate(page2, LoginTextBox.Text);
                }
                else{
                    PasswordTextBox.Password = "";
                    
                }
            }
        }

        string isSignedUp()
        {
            string[] LoginAndPassword;
            string[] dataBase = File.ReadAllText("database.txt").Split("\n");
            foreach (var user in dataBase)
    `       {
                LoginAndPassword = user.Split(" ");
                if (LoginAndPassword[0].CompareTo(LoginTextBox.Text) == 0 && LoginAndPassword[1].CompareTo(PasswordTextBox.Password) == 0)
                {
                    return LoginAndPassword[0];
                }
            }
            return null;
        }
    }
}

