using RiseSync.Logic;
using RiseSync.Logic.Services;
using RiseSync.UI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace RiseSync.UI.ViewModels
{
    public  class MainViewModel : BaseViewModel
    {
		private LocalDatabase _localDatabaseSettings = new LocalDatabase
		{
			Server = "localhost",
			Port = 3306,
			Database = "",
			User = "root",
			Password = ""
		};
		private string _items;
		private RemoteDbType _radioBtnCheck;
		private RemoteDatabase _remoteDatabase;
		private ILocalDatabaseService _localDatabaseService;
		private IRemoteDatabaseService _remoteDatabaseService;
		private ICollection<Supply> _supplies = new List<Supply>();

		public MainViewModel(RemoteDatabase remoteDatabase,
			ILocalDatabaseService localDatabaseService,
			IRemoteDatabaseService remoteDatabaseService)
		{
			ConnectCmd = new RelayCommand(OnConnect, CanConnect);
			SyncCmd = new RelayCommand(OnSync, CanSync);
			_remoteDatabase = remoteDatabase;
			_localDatabaseService = localDatabaseService;
			_remoteDatabaseService = remoteDatabaseService;
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
			var status = _localDatabaseService.GetStatusConnectDatabase(connectionString);
			if (status)
			{
				MessageBox.Show("Banco conectado com sucesso.", "RiseSync", MessageBoxButton.OK, MessageBoxImage.Information);
				_supplies =(ICollection<Supply>) _localDatabaseService.GetAllSupplies(connectionString, Database).Result;
				Items = $"{_supplies.Count} items.";
			}
			else
			{
				MessageBox.Show("Banco não conectado", "RiseSync", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public RelayCommand SyncCmd { get; private set; }

		private bool CanSync()
		{
			return true;
		}

		private void OnSync()
		{
			var connectionString = CreateStringConnectRemoteDb(RadioBtnCheck);
			_remoteDatabaseService.SaveManySupplies(connectionString, RemoteDatabase, _supplies);
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
			get { return _localDatabaseSettings.Password; }
			set
			{
				_localDatabaseSettings.Password = value;
				OnPropertyChanged();
			}
		}

		public string RemoteDatabase
		{
			get => _remoteDatabase.Database;
			set
			{
				_remoteDatabase.Database = value;
				OnPropertyChanged();
			}
		}
		public string RemoteUser
		{
			get => _remoteDatabase.User;
			set
			{
				_remoteDatabase.User = value;
				OnPropertyChanged();
			}
		}

		public string RemotePassword
		{
			get => _remoteDatabase.Password;
			set
			{
				_remoteDatabase.Password = value;
				OnPropertyChanged();
			}
		}

		public string Items
		{
			get => _items;
			set
			{
				_items = value;
				OnPropertyChanged();
			}
		}

		public RemoteDbType RadioBtnCheck
		{
			get => _radioBtnCheck;
			set
			{
				_radioBtnCheck = value;
				OnPropertyChanged();
			}
		}

		#endregion


		private string CreateStringConnectRemoteDb(RemoteDbType dbType) =>
			dbType switch
			{
				RemoteDbType.MongoAtlas => $"mongodb+srv://{RemoteUser}:{RemotePassword}@cluster0-cyux5.mongodb.net/{RemoteDatabase}?retryWrites=true&w=majority",
				RemoteDbType.MLab => $"ongodb://{RemoteUser}:{RemotePassword}@ds018538.mlab.com:18538/{RemoteDatabase}",
				RemoteDbType.MongoLocal => $"mongodb://localhost:27017/{RemoteDatabase}",
				_ => $"mongodb://localhost:27017/{Database}"
			};
	}
}
