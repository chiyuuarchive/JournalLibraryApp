﻿using JLWPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for AdminLibraryPanel.xaml
    /// </summary>
    public partial class AdminLibraryPanel : UserControl
    {
        LibraryViewModel _vm;

        public AdminLibraryPanel()
        {
            InitializeComponent();
        }

        private void btnRemoveArticle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditArticle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewArticle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is LibraryViewModel)
            {
                _vm = (LibraryViewModel)DataContext;
                if (_vm == null)
                    throw new Exception("DataContext not type of LibraryViewModel");
            }
        }
    }
}
