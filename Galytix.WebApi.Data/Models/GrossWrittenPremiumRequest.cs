using System;
using System.Collections.Generic;
using System.Text;

namespace Galytix.WebApi.Data.Models
{
    public class GrossWrittenPremiumRequest
    {
        public string Country { get; set; }

        public IEnumerable<string> LineOfBusinesses { get; set; }
    }
}
