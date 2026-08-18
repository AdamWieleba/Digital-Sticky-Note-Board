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
                Content = "Treœæ notatki...",
                X = 50 + (Notes.Count % 5) * 240,
                Y = 50 + (Notes.Count / 5) * 200
            };

            var noteViewModel = new NoteViewModel(note);

            Notes.Add(noteViewModel);

            SelectNote(noteViewModel);
        }

        private void DeleteNote()
        {
            if (SelectedNote == null)
                return;

            SelectedNote.IsSelected = false;

            Notes.Remove(SelectedNote);

            SelectedNote = null;
        }

        public void SelectNote(NoteViewModel note)
        {
            if (SelectedNote == note)
                return;

            if (SelectedNote != null)
            {
                SelectedNote.IsSelected = false;
            }

            SelectedNote = note;
            SelectedNote.IsSelected = true;
        }

        public void ClearSelection()
        {
            if (SelectedNote == null)
                return;

            SelectedNote.IsSelected = false;
            SelectedNote = null;
        }
    }
}
