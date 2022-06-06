using System;

namespace e_widencje.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime LastUpdate { get; set; }
        int LastEditorId { get; set; }
    }
}
