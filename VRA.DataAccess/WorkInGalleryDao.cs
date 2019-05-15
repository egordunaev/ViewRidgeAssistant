using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace VRA.DataAccess
{
    class WorkInGalleryDao : BaseDao, IWorkInGalleryDao
    {
        private static WorkInGallery LoadWork(SqlDataReader reader)
        {
            WorkInGallery workInGallery = new WorkInGallery();
            workInGallery.Id = reader.GetInt32(reader.GetOrdinal("WorkID"));
            workInGallery.Name = reader.GetString(reader.GetOrdinal("Name"));
            workInGallery.Title = reader.GetString(reader.GetOrdinal("Title"));
            workInGallery.Copy = reader.GetString(reader.GetOrdinal("Copy"));
            workInGallery.Description = reader.GetString(reader.GetOrdinal("Description"));
            object askingprice = reader["AskingPrice"];
            if (askingprice != DBNull.Value)
                workInGallery.AskingPrice = Convert.ToDecimal(askingprice);

            return workInGallery;

        }
        public IList<WorkInGallery> GetAll()
        {
            IList<WorkInGallery> works = new List<WorkInGallery>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select WorkID, Title, Copy, Description, Name, AskingPrice From WorksInGallery";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                            works.Add(LoadWork(dataReader));
                    }
                }
            }
            return works;
        }
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["vradb"].ConnectionString;
        }
        /// <summary>
        /// Возвращает объект подключения к базе
        /// </summary>
        /// <returns></returns>
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
    }
}
