using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DigitalStickyNoteBoard.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Powiadamia interfejs o zmianie właściwości.
        /// </summary>
        /// <param name="propertyName">Nazwa właściwości.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Ustawia wartość pola i powiadamia interfejs tylko wtedy,
        /// gdy wartość rzeczywiście się zmieniła.
        /// </summary>
        protected bool SetProperty<T>(
            ref T field,
            T value,
            [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
