using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess.Entities;
using System.Data.SqlClient;
using System.Configuration;

namespace VRA.DataAccess
{
    public class ArtistDao: BaseDao, IArtistDao
    {
        private static IDictionary<int, Artist> Artists;
        private IList<Artist> LoadInternal()
        {
            IList<Artist> artists = new List<Artist>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ArtistID, Name, BirthYear, DeceaseYear, NatID FROM ARTIST";
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            artists.Add(LoadArtist(reader));
                        }
                    }
                }
            }
            return artists;
        }
        /// <summary>
        /// Получить определенного художника
        /// </summary>
        /// <param name="id">Номер художника</param>
        /// <returns></returns>
        public Artist Get(int id)
        {
            if (Artists == null)
                Load();
            return Artists.ContainsKey(id) ? Artists[id] : null;
        }
        /// <summary>
        /// Получить всех художников.
        /// </summary>
        /// <returns></returns>
        public IList<Artist> GetAll()
        {
            IList<Artist> artists = new List<Artist>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ArtistID, Name, BirthYear, DeceaseYear, NatID FROM ARTIST";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            artists.Add(LoadArtist(dataReader));
                        }
                    }
                }
            }
            return artists;

        }
        /// <summary>
        /// Добавить нового художника
        /// </summary>
        /// <param name="artist">Художник</param>
        public void Add(Artist artist)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText ="INSERT INTO ARTIST(Name, BirthYear, DeceaseYear, NatID)VALUES(@Name, @BirthYear, @DeceaseYear, @NatID)";
                    cmd.Parameters.AddWithValue("@Name", artist.Name);
                    cmd.Parameters.AddWithValue("@BirthYear", artist.BirthYear);
                    cmd.Parameters.AddWithValue("@NatID", artist.NationID);
                    object decease = artist.DeceaseYear.HasValue ? (object)artist.DeceaseYear.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@DeceaseYear", decease);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Обновить информацию о художнике
        /// </summary>
        /// <param name="artist">Художник</param>
        public void Update(Artist artist)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE ARTIST SET Name = @Name, BirthYear = @BirthYear, DeceaseYear = @DeceaseYear, NatID = @NatID WHERE ArtistID = @ID";
                    cmd.Parameters.AddWithValue("@Name", artist.Name);
                    cmd.Parameters.AddWithValue("@BirthYear", artist.BirthYear);
                    cmd.Parameters.AddWithValue("@ID", artist.ArtistId);
                    cmd.Parameters.AddWithValue("@NatID", artist.NationID);
                    object decease = artist.DeceaseYear.HasValue ?
                     (object)artist.DeceaseYear.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@DeceaseYear", decease);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Удалить художника
        /// </summary>
        /// <param name="id">Номер художника</param>
        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM ARTIST WHERE ArtistID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Возвращает строку подключения к базе
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Загрузка художника
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Artist LoadArtist(SqlDataReader reader)
        {
            //Создаём пустой объект
            Artist artist = new Artist();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            artist.ArtistId = reader.GetInt32(reader.GetOrdinal("ArtistID"));
            artist.BirthYear = Convert.ToInt32(reader["BirthYear"]);
            //
            //
            object decease = reader["DeceaseYear"];
            if (decease != DBNull.Value)
                artist.DeceaseYear = Convert.ToInt32(decease);
            artist.Name = reader.GetString(reader.GetOrdinal("Name"));
            int pos = reader.GetOrdinal("NatID");
            artist.NationID = reader[pos] == DBNull.Value ? -1 : reader.GetInt32(pos);
            return artist;
        }

        public IList<Artist> Load()
        {
            Artists = new Dictionary<int, Artist>();
            var artists = LoadInternal();
            foreach(var artist in artists)
            {
                Artists.Add(artist.ArtistId, artist);
            }
            return Artists.Values.ToList();
        }
        public void Reset()
        {
            if (Artists == null)
                return;
            Artists.Clear();
        }

        public IList<Artist> SearchArtists(string Name, string Nation)
        {
            IList<Artist> artists = new List<Artist>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ArtistID, Name, BirthYear, DeceaseYear, Artist.NatID FROM ARTIST JOIN Nation on Artist.NatID = Nation.NatID WHERE Name like @Name AND Value like @Nation";
                    cmd.Parameters.AddWithValue("@Name", "%" + Name + "%");
                    cmd.Parameters.AddWithValue("@Nation", "%" + Nation);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            artists.Add(LoadArtist(dataReader));
                        }
                    }
                }
            }
            return artists;
        }
    }
}
