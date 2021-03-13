using System;
using System.Collections.Generic;
using System.Text;

namespace Galytix.WebApi.Data.Models
{
    public class GwpData
    {
        public string CountryCode { get; set; }

        public IDictionary<string, IEnumerable<decimal>> LobData { get; set; }
    }
}
