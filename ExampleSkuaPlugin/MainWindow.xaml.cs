using Microsoft.Extensions.DependencyInjection;
using Skua.Core.Interfaces;
using System.Windows;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using Skua.WPF;

namespace ExamplePlugin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : CustomWindow
    {
        public static MainWindow Instance { get; } = new();
        public IScriptInterface? Bot { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NameChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Bot != null && NameChangeTxt.Text.Length != 0)
            {
                Bot.Options.CustomName = NameChangeTxt.Text;
            }
        }
    }
}
