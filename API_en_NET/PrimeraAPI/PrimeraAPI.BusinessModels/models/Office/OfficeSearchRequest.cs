using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraAPI.BusinessModels.models.Office
{
    public class OfficeSearchRequest : PaginatedBaseRequest
    {
        public string Country { get; set; }
    }
}
