using DrugsMicroservice.Models;

namespace DrugsMicroservice.Repository
{
    public interface IRepository
    {
        public DrugList GetDrugById(int id);

        public DrugList GetDrugByName(string name);
        public DrugLocationWise GetDrugByLocation(int id, string location);

    }
}
