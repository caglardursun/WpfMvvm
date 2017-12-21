using Mailler.Model;
using Mailler.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Mailler.UI.Wrapper
{
    
    public class ContactWrapper : ModelWrapper<Contact>
    {
        public ContactWrapper(Contact model):base(model)
        {            
        }

        
        public int Id { get{ return Model.Id; } }
        
        //private void ValidateProperty(string propertyName)
        //{
        //    ClearErrors(propertyName);
        //    switch (propertyName)
        //    {
        //        case nameof(Name):
        //            if (string.Equals(Name,"Error",StringComparison.OrdinalIgnoreCase))
        //            {
        //                AddError(propertyName, "Error, cannot be a real name !!!");
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}
        
        public string Name { get { return GetValue<string>(nameof(Name)); } set { SetValue(value); } }

        public string Surname{ get { return GetValue<string>(nameof(Surname)); } set { SetValue(value); } }

        public string EMail { get { return GetValue<string>(nameof(EMail)); } set { SetValue(value);} }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Name):
                    if (string.Equals(Name, "Error", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Error, cannot be a real name !!!";
                    }
                    break;
                default:
                    break;
            }
        }

        }

  

}
