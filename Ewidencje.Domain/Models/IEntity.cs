using System;

namespace Ewidencje.Domain.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime LastUpdate { get; set; }
        int LastEditorId { get; set; }
    }
}
