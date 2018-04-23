using Newtonsoft.Json;

namespace RestSharpTestApp.Models
{
    public class Face
    {
        public int Id { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
