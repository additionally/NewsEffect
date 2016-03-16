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
        public EditOrg()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
           if (UCN.Visibility == System.Windows.Visibility.Hidden)
           {
               UCN.Visibility = System.Windows.Visibility.Visible;
           }

            //string visstatus = UCN.Visibility.ToString();
            //if (visstatus == "Hidden")
            //{
            //    UCN.Visibility = System.Windows.Visibility.Visible;
            //}

        //    //List<RadioButton> rblist = new List<RadioButton>();
        //    //RadioButton rb = 
        //    //if (rb.GroupName == "UpdateGroup")
        //    //{
        //    //    rblist.Add(rb);
        //    //}

        }

        private void U_Unchecked(object sender, RoutedEventArgs e)
        {
            if (UCN.Visibility == System.Windows.Visibility.Visible)
            {
                UCN.Visibility = System.Windows.Visibility.Hidden;
            }
        }

    }
}

