namespace EventOrganiser.Web.ViewModels.Event
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using EventOrganiser.Data.Models;

    public class EventCreateViewModel
    {

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile Img { get; set; }

        [Required]
        public Entry Entry { get; set; }
    }
}
