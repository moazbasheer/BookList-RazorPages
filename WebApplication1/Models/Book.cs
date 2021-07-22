using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Book
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        public string Author { set; get; }
        public string ISBN { set; get; }

    }
}
