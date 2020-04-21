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
    /// Interaction logic for RemoteDatabaseView.xaml
    /// </summary>
    public partial class RemoteDatabaseView : UserControl
    {
        private RemoteDatabaseViewModel _remoteDatabaseViewModel;
        public RemoteDatabaseView()
        {
            InitializeComponent();
        }

        public RemoteDatabaseView(RemoteDatabaseViewModel remoteDatabaseViewModel)
        {
            _remoteDatabaseViewModel = remoteDatabaseViewModel;
            DataContext = _remoteDatabaseViewModel;
        }
    }
}
