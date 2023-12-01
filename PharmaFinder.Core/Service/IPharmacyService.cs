using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Service
{
    public interface IPharmacyService
    {
        List<Pharmacy> GetAllPharmacies();
        Pharmacy GetPharmacyById(decimal id);
        void CreatePharmacy(Pharmacy pharmacyData);
        void UpdatePharmacy(Pharmacy pharmacyData);
        void DeletePharmacy(decimal id);

        List<PharmacyNameSearch> SearchPharmacyName(PharmacyNameSearch search);
    }
}
