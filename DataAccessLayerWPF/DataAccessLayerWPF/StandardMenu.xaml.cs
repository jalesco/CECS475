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

namespace DataAccessLayerWPF
{
    /// <summary>
    /// Interaction logic for StandardMenu.xaml
    /// </summary>
    public partial class StandardMenu : Window
    {
        public StandardMenu()
        {
            InitializeComponent();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            int standardID = 0;

            IDTextBox.Visibility = Visibility.Visible;
            IDLabel.Visibility = Visibility.Visible;
            NameLabel.Visibility = Visibility.Visible;
            NameTextBox.Visibility = Visibility.Visible;
            DescriptionLabel.Visibility = Visibility.Visible;
            DescriptionTextBox.Visibility = Visibility.Visible;

            standardID = Convert.ToInt32(IDTextBox.Text);


        }

    }//end class
}
