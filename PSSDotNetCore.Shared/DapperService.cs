using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace PSSDotNetCore.Shared
{
    public class DapperService
    {
        private readonly string _connectionString;
        public DapperService(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public List<M> Query<M>(string query, object? pararm = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            //if (pararm != null)
            //{
            //    var lst = db.Query<T>(query, param).ToList();
            //}
            //else
            //{
            //    var lst = db.Query<T>(query).ToList();

            //}
            var lst = db.Query<M>(query, pararm).ToList();
            return lst;
        }

        public M QueryFirstOrDefault<M>(string query, object? pararm = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            //if (pararm != null)
            //{
            //    var lst = db.Query<T>(query, param).ToList();
            //}
            //else
            //{
            //    var lst = db.Query<T>(query).ToList();

            //}
            var item = db.Query<M>(query, pararm).FirstOrDefault();
            return item!;
        }
        public int Execute(string query, object? pararm = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Execute(query, pararm);
            return result;
        }
    }
}
