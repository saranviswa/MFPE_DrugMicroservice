using DrugsMicroservice.Models;
using System;
using System.Collections.Generic;

namespace DrugsMicroservice.Repository
{
    public class DrugRepository : IRepository
    {
        List<DrugList> drugList = new List<DrugList>()
        {
            new DrugList()
            {
                Id = 1001,
                Name = "Paracetamol",
                Manufacturer = "Sun Pharma",
                ManufacturedDate = Convert.ToDateTime("2022-01-05"),
                ExpiryDate = Convert.ToDateTime("2023-02-05"),
                UnitsPerPackage = 10,
                Cost = 100,
                LocationWiseQty = new Dictionary<string, int>
                {
                    {"Chennai",10 },
                    {"Bangalore",20 },
                    {"Delhi",15 }

                }
            },
            new DrugList()
            {
                Id = 1002,
                Name = "Crocin",
                Manufacturer = "Star Pharma",
                ManufacturedDate = Convert.ToDateTime("2022-10-05"),
                ExpiryDate = Convert.ToDateTime("2023-12-05"),
                UnitsPerPackage = 10,
                Cost = 50,
                LocationWiseQty = new Dictionary<string, int>
                {
                    {"Chennai",09 },
                    {"Bangalore",11 },
                    {"Delhi",13 }

                }
            },
            new DrugList()
            {
                Id = 1003,
                Name = "Covaxin",
                Manufacturer = "Bharat Biotech",
                ManufacturedDate = Convert.ToDateTime("2022-11-15"),
                ExpiryDate = Convert.ToDateTime("2023-01-06"),
                UnitsPerPackage = 1,
                Cost = 500,
                LocationWiseQty = new Dictionary<string, int>
                {
                    {"Chennai",05 },
                    {"Bangalore",1 },
                    {"Delhi",3 }

                }
            },
            new DrugList()
            {
                Id = 1004,
                Name = "CoviShield",
                Manufacturer = "Pfizer",
                ManufacturedDate = Convert.ToDateTime("2022-08-07"),
                ExpiryDate = Convert.ToDateTime("2023-01-06"),
                UnitsPerPackage = 1,
                Cost = 600,
                LocationWiseQty = new Dictionary<string, int>
                {
                    {"Chennai",7 },
                    {"Bangalore",4 },
                    {"Delhi",6 }

                }
            },
            new DrugList()
            {
                Id = 1005,
                Name = "Zintac",
                Manufacturer = "Merck",
                ManufacturedDate = Convert.ToDateTime("2021-05-17"),
                ExpiryDate = Convert.ToDateTime("2023-11-06"),
                UnitsPerPackage = 10,
                Cost = 90,
                LocationWiseQty = new Dictionary<string, int>
                {
                    {"Chennai",34 },
                    {"Bangalore",41 },
                    {"Delhi",60 }

                }
            }


        };


        public DrugList GetDrugById(int id)
        {
            foreach (var item in drugList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public DrugList GetDrugByName(string name)
        {
            foreach (var item in drugList)
            {
                if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        public DrugLocationWise GetDrugByLocation(int id, string location)
        {
            DrugLocationWise drugLocationWise = new DrugLocationWise();
            foreach (var item in drugList)
            {
                if (item.Id == id)
                {
                    if (item.LocationWiseQty.ContainsKey(location))
                    {
                        item.LocationWiseQty.TryGetValue(location, out int drugQuantity);


                        drugLocationWise.Id = item.Id;
                        drugLocationWise.DrugName = item.Name;
                        drugLocationWise.ExpiryDate = item.ExpiryDate;
                        drugLocationWise.Location = location;
                        drugLocationWise.Quantity = drugQuantity;
                        return drugLocationWise;
                    }
                }
            }
            return null;
        }





    }
}
