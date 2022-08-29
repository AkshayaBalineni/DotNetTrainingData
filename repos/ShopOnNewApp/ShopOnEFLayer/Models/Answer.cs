using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnEFLayer.Models
{
    [Table("CustomerQueryAnswer")]
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        [MaxLength(250)]
        public string AnswerDescription { get; set; }
        public int QuestionForeignKey { get; set; }
        public Question Question { get; set; }
    }
}
