namespace EventOrganiser.Web.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using EventOrganiser.Data.Models;
    using EventOrganiser.Services.Mapping;
    using EventOrganiser.Web.ViewModels.Event;
    using Microsoft.AspNetCore.Http;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Username { get; set; }

        public string Id { get; set; }

        [Required]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile Img { get; set; }

        public List<EventViewModel> Events { get; set; }
    }
}
