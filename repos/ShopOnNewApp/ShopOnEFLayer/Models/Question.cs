using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnEFLayer.Models
{
    [Table("CustomerQueries")]
    public class Question
    {
        [Key]
        [Column("CustomerQueryId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        [MaxLength(200)]
        public string QuestionDescription { get; set; }
        public DateTime DateOfQuery { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
