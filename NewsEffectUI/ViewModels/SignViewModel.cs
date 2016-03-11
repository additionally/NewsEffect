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

        private bool CanGoHome()
        {
            return true;
        }

        private void GoHome()
        {
            WindowViewModel windowViewModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowViewModel.page = "Home.xaml";
        }

        private bool CanRegisterComp()
        {
            return true;
        }

        private void RegisterComp()
        {
            DatabaseRepository datarep = new DatabaseRepository();
            datarep.registercomp(incompname);
            //WindowViewModel windowViewModel = App.Current.MainWindow.DataContext as WindowViewModel;
            //windowViewModel.page = "SignDept.xaml";
        }
        



    }
}
