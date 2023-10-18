using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApp.entities
{
    class Trans
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AccId")]
        public int AccountId { get; set; }

        public Account Account { get; set; }

        public int Money { get; set; }

        public int Opration { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

    }
}
