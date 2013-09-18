using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommomObjects.Interfaces
{
    public interface IBaseEntity
    {
        long id { get; }
        DateTime AddDate { get; set; }
        DateTime LastModify { get; }
        Guid UniqueId { get; }
    }
}
