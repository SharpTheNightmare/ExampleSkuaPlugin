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

        public void Load(IServiceProvider provider, IPluginHelper helper)
        {
            Bot = provider.GetRequiredService<IScriptInterface>();
            Bot?.Log($"{Name} Loaded.");
            helper.AddMenuButton("test", MenuStripItem_Click);
        }

        private void MenuStripItem_Click()
        {
            // This will show/hide the example form when the menu strip button is click
            if (IsVisible)
            {
                Hide();
                Bot?.Log($"{Name} hidden");
            }
            else
            {
                Show();
                Bot?.Log($"{Name} shown");
                BringIntoView();
            }
        }

        public void Unload()
        {
            Bot?.Log($"{Name} Unloaded.");
        }

        public Loader()
        {
            InitializeComponent();
        }

        private void nameChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Bot != null && nameChangeTxt.Text.Length != 0)
            {
                Bot.Options.CustomName = nameChangeTxt.Text;
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Bot?.Log($"{Name} hidden");
        }
    }
}
