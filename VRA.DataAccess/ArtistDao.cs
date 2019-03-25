﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess.Entities;
using System.Data.SqlClient;
using System.Configuration;

namespace VRA.DataAccess
{
    public class ArtistDao: IArtistDao
    {
        /// <summary>
        /// Получить определенного художника
        /// </summary>
        /// <param name="id">Номер художника</param>
        /// <returns></returns>
        public Artist Get(int id)
        {
            //Получаем объект подключения к базе
            using (var conn = GetConnection())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "SELECT ArtistID, Name, BirthYear, DeceaseYear, Nationality FROM ARTIST WHERE ArtistID = @id";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@id", id);
                    //Открываем SqlDataReader для чтения полученных в результате
                    //выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        //Если есть запись, то работаем с ней
                        if (dataReader.Read())
                        {
                            return !dataReader.Read() ? null : LoadArtist(dataReader);
                        }
                        return null;
                    }
                }
            }
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
                    cmd.CommandText = "SELECT ArtistID, Name, BirthYear, DeceaseYear, Nationality FROM ARTIST";
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
                    cmd.CommandText ="INSERT INTO ARTIST(Name, BirthYear, DeceaseYear, Nationality)VALUES(@Name, @BirthYear, @DeceaseYear, @Nationality)";
                    cmd.Parameters.AddWithValue("@Name", artist.Name);
                    cmd.Parameters.AddWithValue("@BirthYear", artist.BirthYear);
                    cmd.Parameters.AddWithValue("@Nationality", artist.Nationality);
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
                    cmd.CommandText = "UPDATE ARTIST SET Name = @Name, BirthYear = @BirthYear, DeceaseYear = @DeceaseYear, Nationality = @Nationality WHERE ArtistID = @ID";
                    cmd.Parameters.AddWithValue("@Name", artist.Name);
                    cmd.Parameters.AddWithValue("@BirthYear", artist.BirthYear);
                    cmd.Parameters.AddWithValue("@ID", artist.ArtistId);
                    cmd.Parameters.AddWithValue("@Nationality", artist.Nationality);
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
            //Помните, что у нас поле DeceaseYear может иметь значение NULL?
            //Следующие 3 строки корректно обрабатывают этот случай
            object decease = reader["DeceaseYear"];
            if (decease != DBNull.Value)
                artist.DeceaseYear = Convert.ToInt32(decease);
            artist.Name = reader.GetString(reader.GetOrdinal("Name"));
            artist.Nationality = reader.GetString(reader.GetOrdinal("Nationality"));
            return artist;
        }
    }
}