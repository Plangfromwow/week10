using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using Dapper;

namespace Businessv2Demo.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string department { get; set; }
        public DateTime hiredate { get; set; }
    }
}
