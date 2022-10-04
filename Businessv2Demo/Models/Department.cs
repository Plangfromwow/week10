using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using Dapper;

namespace Businessv2Demo.Models
{
    [Table("department")]
    public class Department
    {
        [ExplicitKey]
        public string id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
    }
}
