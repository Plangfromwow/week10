using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using Dapper;
namespace BookClubLab.Models
{
    [Table("presentation")]
    public class Presentation
    {
        [Key]
        public int id { get; set; }
        public int personid { get; set; }
        public DateTime presentationdate { get; set; }
        public string booktitle { get; set; }
        public string bookauthor { get; set; }
        public string genre { get; set; }
    }
}
