using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace tutorial1.Models
{
    [Table("role_info")]
    public partial class role_info
    {
        public role_info()
        {
            user_infos = new HashSet<user_info>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong is_deleted { get; set; }

        [InverseProperty(nameof(user_info.role))]
        public virtual ICollection<user_info> user_infos { get; set; }
    }
}
