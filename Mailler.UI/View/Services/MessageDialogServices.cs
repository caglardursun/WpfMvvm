using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mailler.UI.View.Services
{
    public class MessageDialogServices : IMessageDialogServices
    {
        public MessageDialogResult ShowOkCancelDialog(string test,string title)
        {
            var result = MessageBox.Show(test, title, MessageBoxButton.OKCancel);
            return result == MessageBoxResult.OK ? MessageDialogResult.Ok : MessageDialogResult.Cancel;
        }
    }

    public enum MessageDialogResult { Ok, Cancel };
}
