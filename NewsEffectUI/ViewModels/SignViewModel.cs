using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NewsEffectDatabaseConn;

namespace NewsEffectUI.ViewModels
{
    public class SignViewModel : BaseViewModel
    {
        private string _incompname;
        public string incompname
        {
            get { return _incompname; }
            set 
            {
                _incompname = value;
            OnPropertyChanged("incompname");
            }
        }

        private ICommand _buttonEditOrgPage;

        public ICommand buttonEditOrgPage
        {
            get
            {
                if (_buttonEditOrgPage == null)
                {
                    _buttonEditOrgPage = new Command(EditOrgPage, CanEditOrgPage);
                }
                return _buttonEditOrgPage;
            }
            set { _buttonEditOrgPage = value; }
        }

        private ICommand _buttonGoHome;

        public ICommand buttonGoHome
        {
            get
            {
                if (_buttonGoHome == null)
                {
                    _buttonGoHome = new Command(GoHome, CanGoHome);
                }
                return _buttonGoHome;
            }
            set { _buttonGoHome = value; }
        }

        private ICommand _buttonRegisterComp;

        public ICommand buttonRegisterComp
        {
            get
            {
                if (_buttonRegisterComp == null)
                {
                    _buttonRegisterComp = new Command(RegisterComp, CanRegisterComp);
                }
                return _buttonRegisterComp;
            }
            set { _buttonRegisterComp = value; }
        }

        private bool CanGoHome()
        {
            return true;
        }

        private void GoHome()
        {
            WindowViewModel windowViewModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowViewModel.page = "Home.xaml";
        }

        private bool CanEditOrgPage()
        {
            return true;
        }

        private void EditOrgPage()
        {
            WindowViewModel windowViewModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowViewModel.page = "EditOrg.xaml";
        }

        private bool CanRegisterComp()
        {
            return true;
        }

        private void RegisterComp()
        {
            DatabaseRepository datarep = new DatabaseRepository();
            try
            {
                datarep.registercomp(incompname);
                EditOrgPage();
            }
            catch (Exception eregfail)
            {
                string err = "Unable to register. Please make sure you have correctly input a unique comany name.";
                GoHome();
                throw eregfail;
                

                //throw enocomptoregister;
            }
            

        }

    }
}
