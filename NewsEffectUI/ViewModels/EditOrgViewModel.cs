using NewsEffectDatabaseConn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewsEffectUI.ViewModels
{
    public class EditOrgViewModel : BaseViewModel
    {
        DatabaseRepository datarep = new DatabaseRepository();

        private List<string> _locales;

        public List<string> locales
        {
            get { return _locales = datarep.readloc(); }
            set 
{
    _locales = value;
            OnPropertyChanged("locales");
            }
        }

        private bool _isVisible;

        public bool isVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged("isVisible");
            }
        }


        private ICommand _toggleVisibilityCommand;

        public ICommand toggleVisibilityCommand
        {
            get
            {
                if (_toggleVisibilityCommand == null)
                {
                    _toggleVisibilityCommand = new Command(toggleVisibility, canToggleVisibility);
                }
                return _toggleVisibilityCommand;
            }

            set { _toggleVisibilityCommand = value; }
        }
        
        //public List<string> locationlist()
        //{
            
        //        List<string> localelist = datarep.readloc();
        //    return localelist;
        //    }
        //List<string> lnames = localelist;

        //private ObservableCollection<EditOptions> _listOfOptions;
        //public ObservableCollection<EditOptions> listOfOptions
        //{
        //    get { return _listOfOptions; }
        //    set 
        //    {
        //        _listOfOptions = value;
        //        OnPropertyChanged("listOfOptions");
        //    }
        //}
        

        private string _currentcompname;
        public string currentcompname
        {
            get { return _currentcompname; }
            set
            {
                _currentcompname = value;
                //OnPropertyChanged("incompname");
            }
        }

        private ICommand _buttonUpdateRB;

        public ICommand buttonUpdateRB
        {
            get
            {
                if (_buttonUpdateRB == null)
                {
                    _buttonUpdateRB = new Command(UpdateRB, CanUpdateRB);
                }
                return _buttonUpdateRB;
            }
            set { _buttonUpdateRB = value; }
        }

        private bool CanUpdateRB()
        {
            return true;
        }

        private void UpdateRB()
        {

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

        //public EditOrgViewModel()

        private void toggleVisibility()
        {
            isVisible = !isVisible;
        }

        private bool canToggleVisibility()
        {
            return true;
        }
    }
    }
