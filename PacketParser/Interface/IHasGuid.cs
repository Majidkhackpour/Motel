using System;

namespace PacketParser.Interface
{
    public interface IHasGuid
    {
        Guid Guid { get; set; }
        DateTime Modified { get; set; }
    }
}
