namespace EventOrganiser.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class IndexViewModel
    {
        public IEnumerable<IndexEventViewModel> Events { get; set; }
    }
}
