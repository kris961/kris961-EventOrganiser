namespace EventOrganiser.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AllViewModel
    {
        public IEnumerable<SingleEventViewModel> Events { get; set; }
    }
}
