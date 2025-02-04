using AmmanClinic.data;
using AmmanClinic.Models;
using AutoMapper;
using System.Collections.Generic;


namespace AmmanClinic.Services
{
    public class CountryService : ICountryService
    {
        ClinicContext context;
        IMapper mapper;
        public CountryService(ClinicContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public void Insert(CountryDTO countryDTO)
        {
            
            Country newCountry = mapper.Map<Country>(countryDTO);
            context.countries.Add(newCountry);
            context.SaveChanges();
        }

        public List<CountryDTO> GetAll()
        {
            List<Country> allcountries = context.countries.ToList();
            List<CountryDTO> countries = new List<CountryDTO>();
            countries = mapper.Map<List<CountryDTO>>(allcountries);

            return countries;
        }

        public void Delete(int Id)
        {
            Country country = context.countries.Find(Id);
            context.countries.Remove(country);
            context.SaveChanges();
        }

    }
}
