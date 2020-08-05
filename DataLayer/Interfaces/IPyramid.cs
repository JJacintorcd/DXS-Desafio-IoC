using System.Collections.Generic;

namespace Recodme.Dxs.DesafioDXS.DataLayer.Interface
{
    public interface IPyramid
    {
        double Base { get; set; }
        string BuildingMaterial { get; set; }
        ICollection<IChamber> Chambers { get; set; }
        double Height { get; set; }
    }
}