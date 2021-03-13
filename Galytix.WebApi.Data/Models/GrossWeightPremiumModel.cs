using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Galytix.WebApi.Data.Models
{
    public class GrossWeightPremiumModel
    {
        public string CountryCode { get; set; }
        public string VariableId { get; set; }
        public string VariableName { get; set; }
        public string LineOFBusiness { get; set; }

        public decimal? Y2000 { get; set; }
        public decimal? Y2001 { get; set; }
        public decimal? Y2002 { get; set; }
        public decimal? Y2003 { get; set; }
        public decimal? Y2004 { get; set; }
        public decimal? Y2005 { get; set; }
        public decimal? Y2006 { get; set; }
        public decimal? Y2007 { get; set; }
        public decimal? Y2008 { get; set; }
        public decimal? Y2009 { get; set; }
        public decimal? Y2010 { get; set; }
        public decimal? Y2011 { get; set; }
        public decimal? Y2012 { get; set; }
        public decimal? Y2013 { get; set; }
        public decimal? Y2014 { get; set; }
        public decimal? Y2015 { get; set; }
    }
}
