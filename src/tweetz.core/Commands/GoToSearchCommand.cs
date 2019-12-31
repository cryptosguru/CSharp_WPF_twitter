﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using tweetz.core.Infrastructure;
using tweetz.core.Infrastructure.Extensions;

namespace tweetz.core.Commands
{
    public class GoToSearchCommand : ICommandBinding
    {
        public static readonly RoutedCommand Command = new RoutedUICommand();

        public CommandBinding CommandBinding()
        {
            return new CommandBinding(Command, CommandHandler);
        }

        private void CommandHandler(object sender, ExecutedRoutedEventArgs ea)
        {
            var dp = sender as DependencyObject;
            if (dp == null) return;

            var tabControl = dp.GetChildrenOfType<TabControl>().FirstOrDefault();
            if (tabControl == null) return;

            var SearchTab = 2;
            tabControl.SelectedIndex = SearchTab;
        }
    }
}