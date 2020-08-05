using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Dxs.DesafioDXS.BusinessLayer.OperationResults
{
    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }

    }
}
