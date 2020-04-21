using Microsoft.Extensions.DependencyInjection;
using RiseSync.Logic.Config;
using RiseSync.Logic.Services;
using RiseSync.UI.Models;
using RiseSync.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RiseSync.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
                       
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddScoped<RemoteDatabase>();
            services.AddScoped<ILocalDatabaseService, LocalDatabaseService>();
            services.AddScoped<IRemoteDatabaseService, RemoteDatabaseService>();

            MappersResolve.ResolveMappers();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }
    }
}
