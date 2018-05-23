using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Tracker.WpfToolkit.Core
{
    abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <see cref="INotifyPropertyChanged.PropertyChanged" />
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool ThrowOnInvalidPropertyName { get; set; }

        protected virtual void InvokePropertyChanged([CallerMemberName] string propertyName = "")
        {
            VerifyPropertyName(propertyName);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                var msg = "Invalid property name: " + propertyName;
                if (ThrowOnInvalidPropertyName)
                {
                    throw new ArgumentException(msg);
                }

                Debug.Fail(msg);
            }
        }
    }
}
