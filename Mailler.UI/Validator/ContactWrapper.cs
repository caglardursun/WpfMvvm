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
    public class ContactWrapper : NotifyDataErrorInfoBase
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

       

    }

  

}
