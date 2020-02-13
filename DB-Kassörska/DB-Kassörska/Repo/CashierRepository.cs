using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food;
using static DB_Kassörska.Order;
using Npgsql;

namespace DB_Kassörska
{
    public class CashierRepository
    {
        private string ConnectionString { get; }
        private IDbConnection connection { get; }
        public static int Backend { get; set; }
        private IDbConnection Connection
        {
            get
            {
                IDbConnection con;
                if (Backend == 1)
                {
                    con = new SqlConnection(ConnectionString);
                }
                else
                {
                    con = new NpgsqlConnection(ConnectionString);
                }
                con.Open();
                return con;
            }
        }
        public CashierRepository()
        {

            if (Backend == 1)//Backend == MSSQL
            {
                ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
                connection = new SqlConnection(ConnectionString);
            }
            else//Backend == PostgreSQL
            {
                ConnectionString = "Host=weboholics-demo.dyndns-ip.com;Port=5433;Username=grupp1;Password=grupp1;Database=grupp1";
                connection = new NpgsqlConnection(ConnectionString);
            }
        }
        public async Task<IEnumerable<Order>> ShowOrderByStatusAsync(eStatus status)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> orders = await connection.QueryAsync<Order>("\"ShowOrderByStatus\"", new { status = (int)status }, commandType: CommandType.StoredProcedure);
                return orders;
            }
        }
        public async Task UpdateOrderStatus(int orderNumber) //Uppdatera orderns status
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Pizza>("\"UpdateOrderStatus\"",
                new { @inid = orderNumber }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task DeleteOrder(int orderNumber)
        {
            using (IDbConnection con = Connection)
            {
               await connection.QueryAsync<Pizza>("\"DeleteOrder\"",
               new { @inid = orderNumber }, commandType: CommandType.StoredProcedure);
            }    
        } //Ta bort order
        public async Task<IEnumerable<Order>> ShowAllOrdersAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> allOrders = (await connection.QueryAsync<Order>("\"ShowOrders\"", commandType: CommandType.StoredProcedure));
                return allOrders;
            }
                
        } //Visa alla ordrar
    } 
}
