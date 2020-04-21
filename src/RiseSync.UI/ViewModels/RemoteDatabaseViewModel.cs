using RiseSync.Logic.Services;
using RiseSync.UI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace RiseSync.UI.ViewModels
{
    public class RemoteDatabaseViewModel : BaseViewModel
    {
        private RemoteDatabase _remoteDatabase;
        private LocalDatabaseViewModel _localDatabaseViewModel;
        private IRemoteDatabaseService _remoteDatabaseService;
       

        public RemoteDatabaseViewModel()
        {
            SyncCommand = new RelayCommand(OnConnect, CanConnect);
            _remoteDatabase = new RemoteDatabase();
            _remoteDatabaseService = new RemoteDatabaseService();
            _localDatabaseViewModel = new LocalDatabaseViewModel();
        }

        #region Commands

        public RelayCommand SyncCommand { get; private set; }
        private bool CanConnect()
        {
            return true;
        }

        private void OnConnect()
        {
            MessageBox.Show(_localDatabaseViewModel.Database);
        }
        #endregion


        #region Properties
        public string Database
        {
            get => _remoteDatabase.ConnectionString;
            set
            {
                _remoteDatabase.ConnectionString = value;
                OnPropertyChanged();
            }
        }

        public string RemoteconnectionString
        {
            get => _remoteDatabase.ConnectionString;
            set
            {
                _remoteDatabase.ConnectionString = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
