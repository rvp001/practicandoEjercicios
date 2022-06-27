using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraAPI.BusinessModels.models.Office
{
    public class UpdateOfficeRequest
    {
        public string City { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public string? State { get; set; }
        public string Country { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Territory { get; set; } = null!;
    }
}
