using Galytix.WebApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galytix.WebApi.Data.Interfaces
{
    public interface IGrossWeightPremiumDataService
    {
        List<GwpModel> GetCountryData(GrossWrittenPremiumRequest request);
    }
}
