using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial1.Dtoa
{
    public class role_info_create
    {
        public string Name { get; set; }
        public ulong IsDeleted { get; set; }
    }
}
