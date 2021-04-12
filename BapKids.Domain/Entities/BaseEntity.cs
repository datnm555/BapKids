using System;

namespace BapKids.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual DateTime DeletedDate { get; set; }
    }
}
