using CsvHelper;
using CsvHelper.Configuration;
using Galytix.WebApi.Data.Interfaces;
using Galytix.WebApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Galytix.WebApi.Data.DataServices
{
    public class GwpDataService : IGrossWeightPremiumDataService
    {
        public GwpDataService()
        {

        }

        public IEnumerable<GrossWeightPremiumModel> GetAllCountryData()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Galytix.WebApi.Data\\DataRepository\\gwpByCountry.csv");

                IEnumerable<GrossWeightPremiumModel> records;

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    MissingFieldFound = null,
                    TrimOptions = TrimOptions.Trim,
                    BadDataFound = (context) =>
                    {
                        Console.WriteLine(context.RawRecord);
                        ConfigurationFunctions.BadDataFound(context); // let CsvHelper throw this.
                    }
            };

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<GrowthWeightPremiumMap>();
                    var csvRecords = csv.GetRecords<GrossWeightPremiumModel>();
                    records = csvRecords.ToList();
                }

                return records;
            }
            catch (Exception ex)
            {
                string exception = ex.Message.ToString();

                return new List<GrossWeightPremiumModel>();
            }


        }

        public List<GwpModel> GetCountryData(IEnumerable<GrossWeightPremiumModel> allCountryData, GrossWrittenPremiumRequest request)
        {
            try
            {


                var res1 = allCountryData.Where(x => x.CountryCode.Equals(request.Country))
                    .Select(y => new GwpModel
                    {
                        LineOfBusiness = y.LineOFBusiness,
                        Premium = y.Y2008 ?? 0.00M + y.Y2009 ?? 0.00M +  y.Y2010 ?? 0.00M + y.Y2011 ?? 0.00M + y.Y2012 ?? 0.00M
                        + y.Y2013 ?? 0.00M + y.Y2014 ?? 0.00M + y.Y2015 ?? 0.00M
                    }).ToList();

                var finalResult = res1.Where(x => request.LineOfBusinesses.Contains(x.LineOfBusiness)).ToList();

                return finalResult;
            }
            catch (Exception ex)
            {
                string exception = ex.Message.ToString();

                return new List<GwpModel>();
            }

        }
        
    }
}
