using NewsEffectService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewsEffectUI.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        EndpointAddress endpoint = new EndpointAddress("http://TRNLON11566:8081/");

        public HomeViewModel()
        {
            IWelcomeService proxy = ChannelFactory<IWelcomeService>.CreateChannel(new BasicHttpBinding(), endpoint);
            string wilk = proxy.GetWelcome();
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
        
        
        private ICommand _buttonLogPageCommand;     

        public ICommand buttonLogPageCommand
        {
            get 
            {
                if (_buttonLogPageCommand == null)
                {
                    _buttonLogPageCommand = new Command(GoToLogIn, CanGoToLogIn);
                }

                return _buttonLogPageCommand; 
            }
            set 
            {
                _buttonLogPageCommand = value; 
            }
        }
        

        private ICommand _buttonSignPageommand;

        public ICommand buttonSignPageCommand
        {
            get
            {
                if (_buttonSignPageommand == null)
                {
                    _buttonSignPageommand = new Command(GoToSignUp, CanGoToSignUp);
                }
                return _buttonSignPageommand;
            }

            set 
            {
                _buttonSignPageommand = value; 
            }
        }

        private bool CanGoToSignUp()
        {
            return true;
        }

        private void GoToSignUp()
        {
            WindowViewModel windowViewModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowViewModel.page = "Sign.xaml";
        }

        private bool CanGoToLogIn()
        {
            return true;
        }

        private void GoToLogIn()
        {
            WindowViewModel windowViewModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowViewModel.page = "Log.xaml";
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
    }
}
