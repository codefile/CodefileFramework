using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommomObjects
{
    public abstract class BaseEntity : Interfaces.IBaseEntity
    {
        public long id { get; private set; }
        public DateTime AddDate { get; set; }
        public DateTime LastModify { get; private set; }
        public Guid UniqueId { get; private set; }

        public BaseEntity()
        {
            LastModify = DateTime.Now;
            AddDate = DateTime.Now;
            UniqueId = Guid.NewGuid();
        }
    }
}
