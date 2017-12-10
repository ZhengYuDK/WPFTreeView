using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WpfBasicTreeView1.DiretoryService.ViewModels;
using WpfBasicTreeView1.ViewModels;

namespace WpfBasicTreeView1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new DirectoryStructureViewModel();

            //For testing
            //var item1 = d.Items[0];
            //d.Items[0].ExpandCommand.Execute(null);

        }        
    }
}
