using RiseSync.Logic.Services;
using RiseSync.UI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace RiseSync.UI.ViewModels
{
    public class LocalDatabaseViewModel : BaseViewModel
    {
        private LocalDatabase _localDatabaseSettings = new LocalDatabase { 
			Server = "localhost",
			Port = 3306,
			Database = "",
			User = "root",
			Password = ""
		};

		private readonly ILocalDatabaseService _locaDatabaseService;

		public LocalDatabaseViewModel()
		{

			ConnectCmd = new RelayCommand(OnConnect, CanConnect);
			_locaDatabaseService = new LocalDatabaseService();
		}
		
		



		#region Commands
		public RelayCommand ConnectCmd { get; private set; }
		private bool CanConnect()
		{
			return true;
		}

		private void OnConnect()
		{
			var connectionString = _localDatabaseSettings.GenerateConnectionString();
			var status = _locaDatabaseService.GetStatusConnectDatabase(connectionString);
			if (status)
			{
				MessageBox.Show("Banco conectado com sucesso.", "RiseSync", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				MessageBox.Show("Banco não conectado", "RiseSync", MessageBoxButton.OK, MessageBoxImage.Error);
			}


		}
        #endregion

        #region Properties

        public string Server
		{
			get { return _localDatabaseSettings.Server; }
			set 
			{ 
				_localDatabaseSettings.Server = value;
				OnPropertyChanged();
			}
		}

		public int Port
		{
			get { return _localDatabaseSettings.Port; }
			set
			{
				_localDatabaseSettings.Port = value;
				OnPropertyChanged();
			}
		}

		public string Database
		{
			get { return _localDatabaseSettings.Database; }
			set
			{
				_localDatabaseSettings.Database = value;
				OnPropertyChanged();
			}
		}

		public string User
		{
			get { return _localDatabaseSettings.User; }
			set
			{
				_localDatabaseSettings.User = value;
				OnPropertyChanged();
			}
		}

		public string Password
		{
			get { return  _localDatabaseSettings.Password; }
			set
			{
				_localDatabaseSettings.Password = value;
				OnPropertyChanged();
			}
		}

        #endregion

    }
}
