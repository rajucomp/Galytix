using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Galytix.WebApi.Data.Models
{
    public class GrowthWeightPremiumMap : ClassMap<GrossWeightPremiumModel>
    {
        public GrowthWeightPremiumMap()
        {
            Map(m => m.CountryCode).Name("country");
            Map(m => m.VariableId).Name("variableId");
            Map(m => m.VariableName).Name("variableName");
            Map(m => m.LineOFBusiness).Name("lineOfBusiness");
            Map(m => m.Y2000).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2000");
            Map(m => m.Y2001).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2001");
            Map(m => m.Y2002).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2002");
            Map(m => m.Y2003).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2003");
            Map(m => m.Y2004).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2004");
            Map(m => m.Y2005).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2005");
            Map(m => m.Y2006).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2006"); 
            Map(m => m.Y2007).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2007");
            Map(m => m.Y2008).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2008");
            Map(m => m.Y2009).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2009");
            Map(m => m.Y2010).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2010");
            Map(m => m.Y2011).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2011");
            Map(m => m.Y2012).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2012");
            Map(m => m.Y2013).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2013");
            Map(m => m.Y2014).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2014");
            Map(m => m.Y2015).TypeConverterOption.NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent).Name("Y2015");

        }
    }
}
