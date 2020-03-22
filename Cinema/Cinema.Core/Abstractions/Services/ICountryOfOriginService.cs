using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface ICountryOfOriginService
    {
        public List<CountryOfOrigin> Get();

        public CountryOfOrigin GetById(int id);

        public CountryOfOrigin Add(CountryOfOrigin countryOfOrigin);

        public CountryOfOrigin Update(CountryOfOrigin countryOfOrigin);

        public void Delete(int id);
    }

}
