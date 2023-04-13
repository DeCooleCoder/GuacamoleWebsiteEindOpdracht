using System.ComponentModel.DataAnnotations;

namespace WebsiteEindOpdracht.Models
{
    public class PersonBase
    {
        [Required(ErrorMessage = "Gelieve uw voornaam in te voeren")]
        public string FirstName { get; set; }
    }
}