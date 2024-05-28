using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Ro_VideoGameCatalogue.Models
{
    // Would like to add a constructor here to make things less tedious
    // Just not familiar with what changes can effect the database
    public class Videogame
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
    }
}
