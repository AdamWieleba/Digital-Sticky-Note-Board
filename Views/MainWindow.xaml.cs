using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        private void Note_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border &&
                border.DataContext is NoteViewModel note)
            {
                if (DataContext is MainViewModel viewModel)
                {
                    viewModel.SelectNote(note);
                }

                e.Handled = true;
            }
        }

        private void Board_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.ClearSelection();
            }
        }
    }
}
