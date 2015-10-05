using BancoDados.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BancoDados.Entity
{
    public class Usuario : Base
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}