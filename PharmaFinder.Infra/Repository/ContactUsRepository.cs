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
   

    public class ContactUsRepository : IContactUsRepository
    {
        private readonly IDbContext dbContext;

        public ContactUsRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Contactu> GetAllContactus()
        {
            IEnumerable<Contactu> result = dbContext.Connection.Query<Contactu>("CONTACT_US_PACKAGE.GetAllContactUsMessages", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        
        public Contactu GetContactusById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Contactu>("CONTACT_US_PACKAGE.GetContactusMessagesById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateContactus(Contactu contactusData)
        {
            var p = new DynamicParameters();
            p.Add("Name", contactusData.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Email", contactusData.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Subject", contactusData.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Message", contactusData.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("CONTACT_US_PACKAGE.CreateContactusMessage", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateContactus(Contactu contactusData)
        {
            var p = new DynamicParameters();
            p.Add("ID", contactusData.Contactusid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Name", contactusData.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Email", contactusData.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Subject", contactusData.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Message", contactusData.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("CONTACT_US_PACKAGE.UpdateContactusMessage", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteContactus(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("CONTACT_US_PACKAGE.DeleteContactusMessage", p, commandType: CommandType.StoredProcedure);
        }
    }
}
