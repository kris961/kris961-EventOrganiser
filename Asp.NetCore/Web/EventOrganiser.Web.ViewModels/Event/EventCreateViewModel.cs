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

        [Required(ErrorMessage = "The title must be between 3 nad 20 symbols")]
        [MaxLength(20), MinLength(3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description must be between 3 nad 100 symbols")]
        [MaxLength(100), MinLength(3)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The location must be between 3 nad 50 symbols")]
        [MaxLength(50), MinLength(3)]
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
