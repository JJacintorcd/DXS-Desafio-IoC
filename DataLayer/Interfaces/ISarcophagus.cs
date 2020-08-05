using System;

namespace Recodme.Dxs.DesafioDXS.DataLayer.Interface
{
    public interface ISarcophagus
    {
        IChamber Chamber { get; set; }
        Guid ChamberId { get; set; }
    }
}