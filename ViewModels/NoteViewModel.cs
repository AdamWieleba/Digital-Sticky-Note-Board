using DigitalStickyNoteBoard.Models;
using System;

namespace DigitalStickyNoteBoard.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        private readonly Note _note;
        private bool _isSelected;

        public NoteViewModel(Note note)
        {
            _note = note;
        }

        /// <summary>
        /// Zwraca model notatki.
        /// </summary>
        public Note Model => _note;

        public Guid Id => _note.Id;

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public string Title
        {
            get => _note.Title;
            set
            {
                if (_note.Title != value)
                {
                    _note.Title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Content
        {
            get => _note.Content;
            set
            {
                if (_note.Content != value)
                {
                    _note.Content = value;
                    OnPropertyChanged();
                }
            }
        }

        public double X
        {
            get => _note.X;
            set
            {
                if (_note.X != value)
                {
                    _note.X = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Y
        {
            get => _note.Y;
            set
            {
                if (_note.Y != value)
                {
                    _note.Y = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Color
        {
            get => _note.Color;
            set
            {
                if (_note.Color != value)
                {
                    _note.Color = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
