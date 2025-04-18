using DomainObject;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        protected DataAccessContext _context;

        public CustomerDataAccess(DataAccessContext context)
        {
            _context = context;
        }
        public Customer Create(CustomerCreateRequest customer)
        {
            var sql = @"
            INSERT INTO [Customer] (
                [CustomerCode], 
                [CustomerName], 
                [CustomerAddress], 
                [CreatedBy], 
                [CreatedAt]
            )
            OUTPUT INSERTED.*
            VALUES ({0}, {1}, {2}, {3}, {4});
            ";
            try
            {
                var result = _context.Customers
                    .FromSqlRaw(sql,
                        customer.CustomerCode,
                        customer.CustomerName,
                        customer.CustomerAddress,
                        customer.CreatedBy,
                        DateTime.UtcNow)
                    .AsEnumerable()
                    .FirstOrDefault();

                if (result == null)
                    throw new InvalidOperationException("Insert returned no result. Check constraints or data.");

                return result;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Failed to insert Customer due to DB constraint.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error occurred while inserting Customer.", ex);
            }
        }

        public Customer Update(CustomerUpdateRequest customer)
        {
            var sql = @"
            UPDATE [Customer]
            SET
                [CustomerCode] = {0}, 
                [CustomerName] = {1}, 
                [CustomerAddress] = {2}, 
                [ModifiedBy] = {3}, 
                [ModifiedAt] = {4}
            OUTPUT INSERTED.*
            WHERE
            [CustomerID] = {5}
            ";
            try
            {
                var result = _context.Customers
                    .FromSqlRaw(sql,
                        customer.CustomerCode,
                        customer.CustomerName,
                        customer.CustomerAddress,
                        customer.ModifiedBy,
                        DateTime.UtcNow,
                        customer.CustomerId)
                    .AsEnumerable()
                    .FirstOrDefault();

                if (result == null)
                    throw new InvalidOperationException("Update failed. Check constraints or data.");

                return result;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Failed to update Customer due to DB constraint.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error occurred while updating Customer.", ex);
            }
        }

        public bool Delete(CustomerDeleteRequest customer)
        {
            var sql = @"
            DELETE FROM [Customer]
            WHERE
            [CustomerID] = {0}
            ";
            try
            {
                var result = _context.Database.ExecuteSqlRaw(sql, customer.CustomerId);
                return result > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Failed to update Customer due to DB constraint.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error occurred while updating Customer.", ex);
            }
        }

        public IEnumerable<Customer> Select(CustomerRequest filter)
        {
            var conditions = new List<string>();
            var parameters = new List<object>();

            int paramIndex = 0;

            if (!string.IsNullOrEmpty(filter.CustomerId.ToString()))
            {
                conditions.Add(@"""CustomerId"" = {" + paramIndex++ + "}");
                parameters.Add(filter.CustomerId);
            }

            if (!string.IsNullOrEmpty(filter.CustomerCode))
            {
                conditions.Add(@"""CustomerCode"" = {" + paramIndex++ + "}");
                parameters.Add(filter.CustomerCode);
            }

            if (!string.IsNullOrEmpty(filter.CustomerName))
            {
                conditions.Add(@"""CustomerName"" LIKE {" + paramIndex++ + "}");
                parameters.Add($"%{filter.CustomerName}%");
            }

            if (!string.IsNullOrEmpty(filter.CustomerAddress))
            {
                conditions.Add(@"""CustomerAddress"" LIKE {" + paramIndex++ + "}");
                parameters.Add($"%{filter.CustomerAddress}%");
            }

            var whereClause = conditions.Any()
                ? "WHERE " + string.Join(" AND ", conditions)
                : "";

            var sql = $@"
                SELECT * FROM ""Customer""
                {whereClause}
                ;
            ";

            var result = _context.Customers
                .FromSqlRaw(sql, parameters.ToArray())
                .AsNoTracking()
                .ToList();

            return result;
        }


    }
}
