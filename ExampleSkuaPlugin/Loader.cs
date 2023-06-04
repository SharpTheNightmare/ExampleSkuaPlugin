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
            
            helper.AddMenuButton(Name, () =>
            {
                MainWindow.Instance.Show();
                MainWindow.Instance.BringIntoView();
                MainWindow.Instance.Activate();
            });
            
            Bot?.Log($"{Name} Loaded.");
        }

        public void Unload()
        {
            Bot?.Log($"{Name} Unloaded.");
            Helper?.RemoveMenuButton(Name);
        }
    }
}
