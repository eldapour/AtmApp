using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApp.entities
{
    class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required]
        public int Code { get; set; }

        [Required]
        public int Password { get; set; }

        public int Money { get; set; }

        [Required]
        public bool Status { get; set; }
        

    }
}
