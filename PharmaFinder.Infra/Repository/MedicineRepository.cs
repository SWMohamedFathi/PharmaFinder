using Dapper;
using PharmaFinder.Core.Common;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Repository
{
    public class MedicineRepository:IMedicineRepository
    {
        private readonly IDbContext dbContext;

        public MedicineRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Medicine> GetAllMedicines()
        {
            IEnumerable<Medicine> result = dbContext.Connection.Query<Medicine>("Medicine_Package.GetAllMedicines", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Medicine GetMedicineById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Medicine>("Medicine_Package.GetMedicineById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateMedicine(Medicine medicineData)
        {
            var p = new DynamicParameters();
            p.Add("MedicineName", medicineData.Medicinename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MedicinePrice", medicineData.Medicineprice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("MedicineType", medicineData.Medicinetype, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MedicineDescription", medicineData.Medicinedescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ExpireDate", medicineData.Expiredate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("ActiveSubstance", medicineData.Activesubstance, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Medicine_Package.CreateMedicine", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateMedicine(Medicine medicineData)
        {
            var p = new DynamicParameters();
            p.Add("ID", medicineData.Medicineid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("MedicineName", medicineData.Medicinename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MedicinePrice", medicineData.Medicineprice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("MedicineType", medicineData.Medicinetype, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MedicineDescription", medicineData.Medicinedescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ExpireDate", medicineData.Expiredate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("ActiveSubstance", medicineData.Activesubstance, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Medicine_Package.UpdateMedicine", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteMedicine(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Medicine_Package.DeleteMedicine", p, commandType: CommandType.StoredProcedure);
        }
    }
}

