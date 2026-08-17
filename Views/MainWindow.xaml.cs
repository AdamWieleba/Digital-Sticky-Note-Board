using System.Windows;
using DigitalStickyNoteBoard.ViewModels;

namespace DigitalStickyNoteBoard.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }
    }
}
