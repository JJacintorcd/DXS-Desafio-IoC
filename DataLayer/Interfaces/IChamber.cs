using System;
using System.Collections.Generic;

namespace Recodme.Dxs.DesafioDXS.DataLayer.Interface
{
    public interface IChamber
    {
        IPyramid Pyramid { get; set; }
        Guid PyramidId { get; set; }
        ICollection<ISarcophagus> Sarcophagi { get; set; }
    }
}