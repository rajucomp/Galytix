using ExcelDataReader;
using Galytix.WebApi.Data.Interfaces;
using Galytix.WebApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Galytix.WebApi.Data.DataServices
{
    public class GwpDataService : IGrossWeightPremiumDataService
    {
        private DataTable allCountryDataSet;

        public GwpDataService()
        {

        }

        private DataTable GetAllCountryData()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Galytix.WebApi.Data\\DataRepository\\gwpByCountry.csv");
                using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                using var reader = ExcelReaderFactory.CreateCsvReader(stream);
                do
                {
                    while (reader.Read())
                    {
                        // reader.GetDouble(0);
                    }
                } while (reader.NextResult());

                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });


                return result.Tables[0];

            }
            catch (Exception ex)
            {
                string exception = ex.Message.ToString();

                return new DataTable();
            }


        }

        public List<GwpModel> GetCountryData(GrossWrittenPremiumRequest request)
        {
            try
            {
                allCountryDataSet = GetAllCountryData();

                var query = allCountryDataSet.AsEnumerable().
                               Select(product => new
                               {
                                   CountryName = product.Field<string>("country"),
                                   LineOfBusiness = product.Field<string>("lineOfBusiness"),
                                   Y2008 = product.Field<string>("Y2008"),
                                   Y2009 = product.Field<string>("Y2009"),
                                   Y2010 = product.Field<string>("Y2010"),
                                   Y2011 = product.Field<string>("Y2011"),
                                   Y2012 = product.Field<string>("Y2012"),
                                   Y2013 = product.Field<string>("Y2013"),
                                   Y2014 = product.Field<string>("Y2014"),
                                   Y2015 = product.Field<string>("Y2015"),
                               });


                var res1 = query.Where(x => x.CountryName.Equals(request.Country))
                    .Select(y => new GwpModel
                    {
                        LineOfBusiness = y.LineOfBusiness,
                        Premium = SanitiseStringToDateTime(y.Y2008) +
                                    SanitiseStringToDateTime(y.Y2009) +
                                    SanitiseStringToDateTime(y.Y2010) +
                                    SanitiseStringToDateTime(y.Y2011) +
                                    SanitiseStringToDateTime(y.Y2012) +
                                    SanitiseStringToDateTime(y.Y2013) +
                                    SanitiseStringToDateTime(y.Y2014) +
                                    SanitiseStringToDateTime(y.Y2015)
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

        private decimal SanitiseStringToDateTime(string str)
        {
            try
            {
                return Convert.ToDecimal(str);
            }
            catch (Exception ex)
            {
                string exception = ex.Message.ToString();
                return 0.0M;
            }
        }
    }
}
