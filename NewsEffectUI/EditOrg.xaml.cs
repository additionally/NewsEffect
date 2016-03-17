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

namespace NewsEffectUI
{
    /// <summary>
    /// Interaction logic for EditOrg.xaml
    /// </summary>
    public partial class EditOrg : Page
    {
        List<RadioButton> rbuplist = new List<RadioButton>();
        List<RadioButton> rbadlist = new List<RadioButton>();
        List<RadioButton> rbremlist = new List<RadioButton>();
        
        public EditOrg()
        {
            InitializeComponent();
            rbuplist = null;
            rbadlist = null;
            rbremlist = null;
            rbuplist.Add(UCN);
            rbuplist.Add(UDL);
            rbuplist.Add(UED);
            rbuplist.Add(UDN);
            rbuplist.Add(UEM);
            rbuplist.Add(UEN);
            rbuplist.Add(UEP);
            rbadlist.Add(AD);
            rbadlist.Add(AE);
            rbremlist.Add(RD);
            rbremlist.Add(RE);
        }

        private void U_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var rb in rbuplist)
            {
                if (rb.Visibility == System.Windows.Visibility.Hidden)
                {
                    rb.Visibility = System.Windows.Visibility.Visible;
                }
            } 
        }

        private void U_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var rb in rbuplist)
            {
                if (rb.Visibility == System.Windows.Visibility.Visible)
                {
                    rb.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        private void A_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var rb in rbuplist)
            {
                if (rb.Visibility == System.Windows.Visibility.Hidden)
                {
                    rb.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void A_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var rb in rbuplist)
            {
                if (rb.Visibility == System.Windows.Visibility.Visible)
                {
                    rb.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        private void R_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var rb in rbuplist)
            {
                if (rb.Visibility == System.Windows.Visibility.Hidden)
                {
                    rb.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void R_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var rb in rbuplist)
            {
                if (rb.Visibility == System.Windows.Visibility.Visible)
                {
                    rb.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }
    }
}

