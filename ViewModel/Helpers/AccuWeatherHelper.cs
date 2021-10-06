using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPAWEATHERAPP.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        //the class has to be made public because it obviously will be used from different namespaces.
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey=cgR1NRAcWK52h1rNVC2ARxGfgt7ADZ1X";
        public const string API_KEY = "cgR1NRAcWK52h1rNVC2ARxGfgt7ADZ1X";

    }
}
