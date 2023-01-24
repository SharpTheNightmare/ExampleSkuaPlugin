using Microsoft.Extensions.DependencyInjection;
using Skua.Core.Interfaces;
using System.Windows;
using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace ExamplePlugin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Loader : ISkuaPlugin
    {
        public IScriptInterface? Bot { get; private set; }

        public string Name => "Example Plugin";
        public string Author => "SharpTheNightmare";
        public string Description => "Gives an example of ISkuaPlugin";

        public List<IOption>? Options { get; } = new();

        public IPluginHelper? Helper { get; private set; }

        public void Load(IServiceProvider provider, IPluginHelper helper)
        {
            Helper = helper;
            Bot = provider.GetRequiredService<IScriptInterface>();
            Bot?.Log($"{Name} Loaded.");
            helper.AddMenuButton("test", MenuButton_Click);
        }

        private void MenuButton_Click()
        {
            // This will show/hide the example window when the button is click
            if (IsVisible)
            {
                Hide();
                Bot?.Log($"{Name} hidden");
            }
            else
            {
                Show();
                BringIntoView();
                Bot?.Log($"{Name} shown");
            }
        }

        public void Unload()
        {
            Bot?.Log($"{Name} Unloaded.");
            Helper?.RemoveMenuButton("test");
        }

        public Loader()
        {
            InitializeComponent();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Bot?.Log($"{Name} hidden");
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
