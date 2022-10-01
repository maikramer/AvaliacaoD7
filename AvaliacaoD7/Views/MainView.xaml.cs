using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using AvaliacaoD7.DataContext;
using AvaliacaoD7.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoD7.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        private readonly UserContext _context = new();
        public MainView() { InitializeComponent(); }
        private ObservableCollection<User> _users = new();

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            CenterWindowOnScreen();
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Users.Load();
            _context.Users.Add(new User { UserName = "Maikeu", Password = "senha" });
            _context.SaveChanges();
            // bind to the source
            _users = _context.Users.Local.ToObservableCollection();
        }

        private void CenterWindowOnScreen()
        {
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            var screenHeight = SystemParameters.PrimaryScreenHeight;
            var windowWidth = Width;
            var windowHeight = Height;
            Left = screenWidth / 2 - windowWidth / 2;
            Top = screenHeight / 2 - windowHeight / 2;
        }


        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            var user = _users.FirstOrDefault(user => user.UserName == UserNameBox.Text);
            var messageBox = new Dialog { Owner = this };
            if (user == null || user.Password != PasswordBox.Text)
            {
                messageBox.SetMessage("Credenciais Inválidas");
            } else
            {
                messageBox.SetMessage("Entrou com Sucesso"); 
            }
            messageBox.ShowDialog();
        }
    }
}