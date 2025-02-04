using AmmanClinic.Models;

namespace AmmanClinic.Services
{
    public interface ICountryService
    {
        void Insert(CountryDTO countryDTO);

        List<CountryDTO> GetAll();

        void Delete(int Id);
    }
}
