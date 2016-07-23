namespace TestJsAngDotNet.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("list_data", Schema = "public")]
    public class ListData
    {
        [Key]
        //[Column("id")]
        public long Id { get; set; }
        //[Column("name")]
        public string Name { get; set; }
    }
}