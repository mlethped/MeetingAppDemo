using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public interface IEntity
    {
        /// <summary>
        /// Unique id for entity
        /// </summary>
        Guid Id { get; set; }
    }
}
