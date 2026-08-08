using System.Collections.ObjectModel;
using System.Windows.Input;
using DigitalStickyNoteBoard.Helpers;
using DigitalStickyNoteBoard.Models;

namespace DigitalStickyNoteBoard.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private NoteViewModel? _selectedNote;

        public ObservableCollection<NoteViewModel> Notes { get; }

        public NoteViewModel? SelectedNote
        {
            get => _selectedNote;
            set => SetProperty(ref _selectedNote, value);
        }

        public ICommand AddNoteCommand { get; }

        public ICommand DeleteNoteCommand { get; }

        public MainViewModel()
        {
            Notes = new ObservableCollection<NoteViewModel>();

            AddNoteCommand = new RelayCommand(_ => AddNote());

            DeleteNoteCommand = new RelayCommand(
                _ => DeleteNote(),
                _ => SelectedNote != null);
        }

        private void AddNote()
        {
            var note = new Note
            {
                Title = "Nowa notatka",
                Content = "Treœæ notatki..."
            };

            var noteViewModel = new NoteViewModel(note);

            Notes.Add(noteViewModel);

            SelectedNote = noteViewModel;
        }

        private void DeleteNote()
        {
            if (SelectedNote == null)
                return;

            Notes.Remove(SelectedNote);
            SelectedNote = null;
        }
    }
}
