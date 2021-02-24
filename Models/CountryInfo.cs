using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.Models
{
    internal class CountryInfo : PlaceInfo

    {
        //В каждой стране будет содержаться информация о каждой ее провинции

        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }




    }
}
