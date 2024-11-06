using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManageApp.Data.Entities.Base
{
    public class SoftDelete : BaseEntity
    {
        public DateTime? DeletedAt { get; set; }
    }
}