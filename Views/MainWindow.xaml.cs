using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DigitalStickyNoteBoard.ViewModels;

namespace DigitalStickyNoteBoard.Views
{
    public partial class MainWindow : Window
    {
        private NoteViewModel? _draggedNote;
        private Point _dragStartPoint;
        private double _noteStartX;
        private double _noteStartY;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void Note_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is TextBox)
                return;

            if (sender is Border border &&
                border.DataContext is NoteViewModel note &&
                DataContext is MainViewModel viewModel)
            {
                viewModel.SelectNote(note);

                _draggedNote = note;
                _dragStartPoint = e.GetPosition(BoardCanvas);
                _noteStartX = note.X;
                _noteStartY = note.Y;

                border.CaptureMouse();

                e.Handled = true;
            }
        }

        private void BoardCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_draggedNote == null)
                return;

            if (e.LeftButton != MouseButtonState.Pressed)
                return;

            Point currentPoint = e.GetPosition(BoardCanvas);

            double deltaX = currentPoint.X - _dragStartPoint.X;
            double deltaY = currentPoint.Y - _dragStartPoint.Y;

            _draggedNote.X = Math.Max(0, _noteStartX + deltaX);
            _draggedNote.Y = Math.Max(0, _noteStartY + deltaY);
        }

        private void BoardCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_draggedNote == null)
                return;

            if (Mouse.Captured is UIElement element)
            {
                element.ReleaseMouseCapture();
            }

            _draggedNote = null;
        }

        private void Board_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.ClearSelection();
            }
        }

        private void TitleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Keyboard.ClearFocus();
                e.Handled = true;
            }
        }

        private void ContentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Keyboard.ClearFocus();
                e.Handled = true;
            }
        }
    }
}
