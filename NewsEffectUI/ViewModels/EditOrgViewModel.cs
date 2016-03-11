﻿using NewsEffectDatabaseConn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewsEffectUI.ViewModels
{
    public class EditOrgViewModel : BaseViewModel
    {
        private List<string> _locales;

        public List<string> locales
        {
            get { return _locales; }
            set 
{
                _locales = value;
            OnPropertyChanged("locales");
            }
        }
        
        public List<string> locationlist()
        {
            DatabaseRepository datarep = new DatabaseRepository();
                List<string> localelist = datarep.readloc();
            return localelist;
            }
        List<string> lnames = new List<string>();
        lnames = locationslist();
        

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

    }
}
