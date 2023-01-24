using Microsoft.Extensions.DependencyInjection;
using Skua.Core.Interfaces;
using System.Windows;
using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace ExamplePlugin
{
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
            if (MainWindow.Instance.IsVisible)
            {
                MainWindow.Instance.Hide();
                Bot?.Log($"{Name} hidden");
            }
            else
            {
                MainWindow.Instance.Show();
                MainWindow.Instance.BringIntoView();
                Bot?.Log($"{Name} shown");
            }
        }

        public void Unload()
        {
            Bot?.Log($"{Name} Unloaded.");
            Helper?.RemoveMenuButton("test");
        }
    }
}
