using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PingPongScoreboard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PingPongScoreboard.Client.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private PingPongGame _game;

        private RelayCommand _goToFirstCommand;
        private RelayCommand _goToPreviousCommand;
        private RelayCommand _goToNextCommand;
        private RelayCommand _goToLastCommand;

        public MainWindowViewModel()
        {
            _game = new PingPongGame();

            _game.GenerateSets(11);
            _game.Start();
        }

        public ICommand GoToFirstCommand
        {
            get
            {
                if (_goToFirstCommand == null)
                {
                    _goToFirstCommand = new RelayCommand(() => GoToFirstSet(), () => CanGoToFirstSet());
                }

                return _goToFirstCommand;
            }
        }

        public ICommand GoToPreviousCommand
        {
            get
            {
                if (_goToPreviousCommand == null)
                {
                    _goToPreviousCommand = new RelayCommand(() => GoToPreviousSet(), () => CanGoToPreviousSet());
                }

                return _goToPreviousCommand;
            }
        }

        public ICommand GoToNextCommand
        {
            get
            {
                if (_goToNextCommand == null)
                {
                    _goToNextCommand = new RelayCommand(() => GoToNextSet(), () => CanGoToNextSet());
                }

                return _goToNextCommand;
            }
        }

        public ICommand GoToLastCommand
        {
            get
            {
                if (_goToLastCommand == null)
                {
                    _goToLastCommand = new RelayCommand(() => GoToLastSet(), () => CanGoToLastSet());
                }

                return _goToLastCommand;
            }
        }

        private bool CanGoToNextSet()
        {
            return _game.CanGoToNextSet();
        }

        public bool CanGoToLastSet()
        {
            return _game.CanGoToLastSet();
        }

        public bool CanGoToPreviousSet()
        {
            return _game.CanGoToPreviousSet();
        }

        public bool CanGoToFirstSet()
        {
            return _game.CanGoToFirstSet();
        }

        public Set CurrentSet
        {
            get
            {
                if (_game != null)
                {
                    return _game.CurrentSet;
                }

                return null;
            }
        }

        public void GoToFirstSet()
        {
            _game.GoToFirstSet();

            RaisePropertyChanged("CurrentSet");
        }

        public void GoToPreviousSet()
        {
            _game.GoToPreviousSet();

            RaisePropertyChanged("CurrentSet");
        }

        public void GoToNextSet()
        {
            _game.GoToNextSet();

            RaisePropertyChanged("CurrentSet");
        }

        public void GoToLastSet()
        {
            _game.GoToLastSet();

            RaisePropertyChanged("CurrentSet");
        }
    }
}
