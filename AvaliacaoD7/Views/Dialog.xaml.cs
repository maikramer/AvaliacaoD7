using System;
using System.Windows;

namespace AvaliacaoD7.Views;

public partial class Dialog : Window
{
    public Dialog() { InitializeComponent(); }

    public void SetMessage(string message) { Message.Content = message; }
}