using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess.Entities;
using System.Data;
using System.Data.SqlClient;

namespace VRA.DataAccess
{
    public class NationDao : BaseDao, INationDao
    {
        /// <summary>
        /// Делаем своего рода кэш с национальностями
        /// </summary>
        private static IDictionary<int, Nation> Nations;
        private IList<Nation> LoadInternal()
        {
            IList<Nation> nations = new List<Nation>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT NatID, Value FROM Nation";
                    cmd.CommandType = CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nations.Add(LoadNation(reader));
                        }
                    }
                }
            }
            return nations;
        }        private static Nation LoadNation(SqlDataReader reader)
        {
            Nation nation = new Nation();
            nation.NationID = reader.GetInt32(reader.GetOrdinal("NatID"));
            nation.Name = reader.GetString(reader.GetOrdinal("Value"));
            return nation;
        }
        public void Add(Nation nation)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Nation (Value) VALUES (@Nation)";
                    cmd.Parameters.AddWithValue("@Nation", nation.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int NationID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Nation WHERE NatID = @ID";
                    cmd.Parameters.AddWithValue("@ID", NationID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Nation Get(int NationID)
        {
            if (Nations == null)
                Load();
            return Nations.ContainsKey(NationID) ? Nations[NationID] : null;
        }

        public IList<Nation> Load()
        {
            Nations = new Dictionary<int, Nation>();
            var nations = LoadInternal();
            foreach (var nation in nations)
            {
                Nations.Add(nation.NationID, nation);
            }
            return Nations.Values.ToList();
        }
        public void Reset()
        {
            if (Nations == null)
                return;
            Nations.Clear();
        }
    }
}
