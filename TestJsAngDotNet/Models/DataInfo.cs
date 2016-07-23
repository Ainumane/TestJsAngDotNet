namespace TestJsAngDotNet.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("data_info", Schema = "public")]
    public class DataInfo
    {
        [Key]
        //[Column("id")]
        public long Id { get; set; }
        //[Column("list_data_id")]
        public long ListDataId { get; set; }
        //[Column("text1")]
        public string Text1 { get; set; }
        //[Column("text2")]
        public string Text2 { get; set; }
        //[Column("int_field1")]
        public int IntField1 { get; set; }
    }
}