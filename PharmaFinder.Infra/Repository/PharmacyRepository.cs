using Dapper;
using PharmaFinder.Core.Common;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Repository
{
    public class PharmacyRepository:IPharmacyRepository
    {
        private readonly IDbContext dbContext;

        public PharmacyRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Pharmacy> GetAllPharmacies()
        {
            IEnumerable<Pharmacy> result = dbContext.Connection.Query<Pharmacy>("Pharmacy_Package.GetAllPharmacies", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Pharmacy GetPharmacyById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Pharmacy>("Pharmacy_Package.GetPharmacyById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreatePharmacy(Pharmacy pharmacyData)
        {
            var p = new DynamicParameters();
            p.Add("PharmacyName", pharmacyData.Pharmacyname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Location", pharmacyData.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Address", pharmacyData.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Lng", pharmacyData.Lng, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Lat", pharmacyData.Lat, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Email", pharmacyData.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PhoneNumber", pharmacyData.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Pharmacy_Package.CreatePharmacy", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdatePharmacy(Pharmacy pharmacyData)
        {
            var p = new DynamicParameters();
            p.Add("ID", pharmacyData.Pharmacyid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("PharmacyName", pharmacyData.Pharmacyname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Location", pharmacyData.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Address", pharmacyData.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Lng", pharmacyData.Lng, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Lat", pharmacyData.Lat, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Email", pharmacyData.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PhoneNumber", pharmacyData.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Pharmacy_Package.UpdatePharmacy", p, commandType: CommandType.StoredProcedure);
        }

        public void DeletePharmacy(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Pharmacy_Package.DeletePharmacy", p, commandType: CommandType.StoredProcedure);
        }

        public List<PharmacyNameSearch> SearchPharmacyName(PharmacyNameSearch search)
        {
            var p = new DynamicParameters();
            p.Add("PhName", search.Pharmacyname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<PharmacyNameSearch>("Pharmacy_Package.SearchPharmacyName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


    }
}
