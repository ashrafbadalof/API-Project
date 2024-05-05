using System.ComponentModel.DataAnnotations;

namespace WebAPIProject.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public string ContactNumber { get; set; }

    }
}
