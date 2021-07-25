using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace tutorial1.Models
{
    [Table("user_info")]
    [Index(nameof(role_id), Name = "user_role_id")]
    public partial class user_info
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string email { get; set; }
        [Required]
        [StringLength(1000)]
        public string password_hash { get; set; }
        [StringLength(150)]
        public string firstname { get; set; }
        [StringLength(150)]
        public string lastname { get; set; }
        [StringLength(15)]
        public string mobile { get; set; }
        [Column(TypeName = "int(11)")]
        public int role_id { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong is_deleted { get; set; }

        [ForeignKey(nameof(role_id))]
        [InverseProperty(nameof(role_info.user_infos))]
        public virtual role_info role { get; set; }
    }
}
