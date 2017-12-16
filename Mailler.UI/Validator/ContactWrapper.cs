using Mailler.Model;
using Mailler.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Mailler.UI.Validator
{
    public class ContactWrapper : ViewModelBase, INotifyDataErrorInfo
    {
        public ContactWrapper(Contact model)
        {
            Model = model;
        }

        public Contact Model { get; }
        public int Id { get{ return Model.Id; } }

        public string Name
        {
            get {
                return Model.Name;
            } set {
                Model.Name = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Name));
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(Name):
                    if (string.Equals(Name,"Error",StringComparison.OrdinalIgnoreCase))
                    {
                        AddError(propertyName, "Error, cannot be a real name !!!");
                    }
                    break;
                default:
                    break;
            }
        }

        public string Surname
        {
            get {
                return Model.Surname;
            }
            set {
                Model.Name = value;
                OnPropertyChanged();
            }
        }


        public string EMail
        {
            get
            {
                return Model.EMail;
            }
            set
            {
                Model.EMail = value;
                OnPropertyChanged();
            }
        }

        private Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();


        public bool HasErrors
        {
            get
            {
                return _errorsByPropertyName.Any();
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsByPropertyName.ContainsKey(propertyName) ? _errorsByPropertyName[propertyName] : null;
        }
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void AddError(string propertyName, string error)
        {

            if (!_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName] = new List<string>();
            }
            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }

        }

        private void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

    }
}
