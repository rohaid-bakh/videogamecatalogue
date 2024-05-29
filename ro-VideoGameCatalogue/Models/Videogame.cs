using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Ro_VideoGameCatalogue.Models
{
    // I was following a tutorial here and placed Genre instead of rating
    // I want to rework this but decided to focus my time on getting the functionality to work
    public class Videogame
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
    }
}
