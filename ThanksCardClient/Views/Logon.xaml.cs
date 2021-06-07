using System.Windows.Controls;

namespace ThanksCardClient.Views
{
    /// <summary>
    /// Interaction logic for Logon
    /// </summary>
    public partial class Logon : UserControl
    {
        public Logon()
        {
            InitializeComponent();
        }

        private void SignUp1(object sender, System.Windows.RoutedEventArgs e)
        {
            Name.Content = new SignUp();
        }
    }
}
