﻿using System.Windows;
using System.Windows.Input;
using tweetz.core.Interfaces;

namespace tweetz.core.Commands
{
    public class MinimizeCommand : ICommandBinding
    {
        public static readonly RoutedCommand Command = new RoutedUICommand();

        public CommandBinding CommandBinding()
        {
            return new CommandBinding(Command, CommandHandler);
        }

        private static void CommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (Application.Current.MainWindow is not null) Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}