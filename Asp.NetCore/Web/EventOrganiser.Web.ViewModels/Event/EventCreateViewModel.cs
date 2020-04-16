namespace EventOrganiser.Web.ViewModels.Event
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using EventOrganiser.Data.Models;

    public class EventCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Img { get; set; }

        [Required]
        public Entry Entry { get; set; }
    }
}
