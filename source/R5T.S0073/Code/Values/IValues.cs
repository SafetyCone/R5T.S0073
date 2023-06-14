using System;

using R5T.T0131;
using R5T.T0175;
using R5T.T0175.Extensions;


namespace R5T.S0073
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker,
        Z0046.IValues
    {
        public IApplicationName ApplicationName => "R5T.S0073".ToApplicationName();
    }
}
