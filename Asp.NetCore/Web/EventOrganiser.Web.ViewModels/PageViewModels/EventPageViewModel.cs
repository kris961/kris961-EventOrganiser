using EventOrganiser.Web.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventOrganiser.Web.ViewModels.PageViewModels
{
    public class EventPageViewModel
    {
        public EventViewModel EventViewModel { get; set; }

        public JoinInputModel JoinInputModel { get; set; }
    }
}
