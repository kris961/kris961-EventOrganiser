namespace EventOrganiser.Web.ViewModels.Home
{
    public class IndexEventViewModel
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Img { get; set; }

        public string Url => $"/c/{this.Name.Replace(' ', '-')}";
    }
}