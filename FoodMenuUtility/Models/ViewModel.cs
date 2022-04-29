using System.ComponentModel;

namespace FoodMenuUtility.Models
{
    public abstract class ViewModel<T> : INotifyPropertyChanged
    {
        /// <summary>
        /// Reference model used by getters and setters.
        /// </summary>
        protected readonly T model;

        /// <summary>
        /// Create a ViewModel using a model.
        /// </summary>
        public ViewModel(T model)
        {
            this.model = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Used to notify UI of changes in a property.
        /// </summary>
        // <param name="propertyName">Name of the property changed.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}