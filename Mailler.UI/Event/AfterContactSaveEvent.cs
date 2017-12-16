using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.UI.Event
{
    public class AfterContactSaveEvent: PubSubEvent<AfterContactSaveEventArgs>
    {

    }

    public class AfterContactSaveEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
