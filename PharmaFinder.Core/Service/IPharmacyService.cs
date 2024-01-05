﻿using PharmaFinder.Core.Data;
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
        int GetPharmacyCount();
        public List<GetAllMedicineInPharmacy> GetAllMedcineInPharmmacy(decimal id);
        public List<Order> GetAllOrdersInPharmmacy(decimal id);
        public int GetMedicineCountInPharmacy(decimal id);
        public int SalesPharmacy(decimal id);
        public List<GetAllOrderMedsByOrderIdInPharmacy> GetAllOrderMedsByOrderIdInPharmacy(decimal pharmacyId, decimal orderId);
        public List<SalesSearchInPharmacy> SalesSearch(SalesSearch2 search);
        public List<Pharmacy> GetAllPharmaciess();
        List<Pharmacy> GetAllPharmacies();
        Pharmacy GetPharmacyById(decimal id);
        void CreatePharmacy(Pharmacy pharmacyData);
        void UpdatePharmacy(Pharmacy pharmacyData);
        void DeletePharmacy(decimal id);
        List<PharmacyNameSearch> SearchPharmacyName(PharmacyNameSearch search);
    }
}
