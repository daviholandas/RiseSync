using RiseSync.Logic.Services;
using RiseSync.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RiseSync.UI.Views
{
    /// <summary>
    /// Interaction logic for LocalDatabaseView.xaml
    /// </summary>
    public partial class LocalDatabaseView : UserControl
    {
        private LocalDatabaseViewModel _localDatabaseViewModel;

        public LocalDatabaseView()
        {
            InitializeComponent();
        }

        public LocalDatabaseView(LocalDatabaseViewModel localDatabaseViewModel)
        {
            _localDatabaseViewModel = localDatabaseViewModel;
            DataContext = _localDatabaseViewModel;
        }
    }
}
