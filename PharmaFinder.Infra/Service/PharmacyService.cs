using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Service
{
    public class PharmacyService:IPharmacyService
    {
        private readonly IPharmacyRepository _pharmacyRepository;

        public int GetPharmacyCount()
        {
            return _pharmacyRepository.GetPharmacyCount();
        }
        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public List<Pharmacy> GetAllPharmacies()
        {
            return _pharmacyRepository.GetAllPharmacies();
        }

        public Pharmacy GetPharmacyById(decimal id)
        {
            return _pharmacyRepository.GetPharmacyById(id);
        }

        public void CreatePharmacy(Pharmacy pharmacyData)
        {
            _pharmacyRepository.CreatePharmacy(pharmacyData);
        }

        public void UpdatePharmacy(Pharmacy pharmacyData)
        {
            _pharmacyRepository.UpdatePharmacy(pharmacyData);
        }

        public void DeletePharmacy(decimal id)
        {
            _pharmacyRepository.DeletePharmacy(id);
        }

        public List<PharmacyNameSearch> SearchPharmacyName(PharmacyNameSearch search)
        {
            return _pharmacyRepository.SearchPharmacyName(search);
        }
       
    }
}
