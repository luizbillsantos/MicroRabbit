using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroRabbit.Transfer.Domain.Models
{
    [Table("TransferLog")]
    public class TransferLog
    {
        [Key]
        public int Id { get; set; }
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }

        public decimal TransferAmount { get; set; }
    }
}
