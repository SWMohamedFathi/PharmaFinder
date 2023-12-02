﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using PharmaFinder.Core.Common;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PharmaFinder.Infra.Repository
{
    public class OrdersRepository:IOrdersRepository
    {
        private readonly IDbContext dbContext;

        public OrdersRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Order> GetAllOrders()
        {
            IEnumerable<Order> result = dbContext.Connection.Query<Order>("orders_package.GetAllOrders", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Order GetOrderById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("OrderID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Order>("orders_package.GetOrderById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateOrder(Order orderData)
        {
            var p = new DynamicParameters();
            p.Add("UserID", orderData.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PharmacyID", orderData.Pharmacyid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("OrderDate", orderData.Orderdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("Approval", orderData.Approval, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("OrderPrice", orderData.Orderprice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("orders_package.CreateOrder", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateOrder(Order orderData)
        {
            var p = new DynamicParameters();
            p.Add("OrderID", orderData.Orderid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserID", orderData.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PharmacyID", orderData.Pharmacyid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("OrderDate", orderData.Orderdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("Approval", orderData.Approval, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("OrderPrice", orderData.Orderprice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("orders_package.UpdateOrder", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrder(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("OrderID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("orders_package.DeleteOrder", p, commandType: CommandType.StoredProcedure);
        }
        public void AcceptOrRejectOrders( Order order)
        {
            var p = new DynamicParameters();
            p.Add("ordersID", order.Orderid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("approvalOrders", order.Approval, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("orders_package.AcceptOrRejectOrders", p, commandType: CommandType.StoredProcedure);

        }


        public List<PharmacySalesSearch> SalesSearch(PharmacySalesSearch search)
        {
            var p = new DynamicParameters();
            p.Add("DateFrom", search.DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DateTo", search.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<PharmacySalesSearch>("orders_package.SalesSearch", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<MonthlySalesReport>> GetMonthlySalesReport(int month, int year)
        {
           
                var p = new DynamicParameters();
                p.Add("p_month", month, DbType.Int32, ParameterDirection.Input);
                p.Add("p_year", year, DbType.Int32, ParameterDirection.Input);

                var result = await dbContext.Connection.QueryAsync<MonthlySalesReport>("orders_package.MonthlySalesReport", p, commandType: CommandType.StoredProcedure);

            return result;
         
        }

        public async Task<IEnumerable<AnnualSalesReport>> GetAnnualSalesReport(int year)
        {

            var p = new DynamicParameters();
            p.Add("p_year", year, DbType.Int32, ParameterDirection.Input);

            var result = await dbContext.Connection.QueryAsync<AnnualSalesReport>("orders_package.AnnualSalesReport", p, commandType: CommandType.StoredProcedure);

            return result;

        }
    }

    
}
