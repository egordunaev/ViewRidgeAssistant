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
    public class CustomerDao: BaseDao, ICustomerDao
    {
        private static IDictionary<int, Customer> Customers;
        private IList<Customer> LoadInternal()
        {
            IList<Customer> customers = new List<Customer>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CustomerID, Name, Email, AreaCode, HouseNumber, Street, City, Region, ZipPostalCode, Country, PhoneNumber FROM CUSTOMER";
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(LoadCustomer(reader));
                        }
                    }
                }
                return customers;
            }
        }
        /// <summary>
        /// Получить определенного клиента
        /// </summary>
        /// <param name="id">Номер клиента</param>
        /// <returns></returns>
        public Customer Get(int? id)
        {
            if (Customers == null)
                Load();
            return Customers.ContainsKey(id.Value) ? Customers[id.Value] : null;
        }
        /// <summary>
        /// Получить всех клиентов.
        /// </summary>
        /// <returns></returns>
        public IList<Customer> GetAll()
        {
            IList<Customer> customers = new List<Customer>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CustomerID, Name, Email, AreaCode, HouseNumber, Street, City, Region, ZipPostalCode, Country, PhoneNumber FROM CUSTOMER";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customers.Add(LoadCustomer(dataReader));
                        }
                    }
                }
            }
            return customers;

        }
        /// <summary>
        /// Добавить нового клиента
        /// </summary>
        /// <param name="customer">Клиент</param>
        public void Add(Customer customer)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO CUSTOMER(Name, Email, AreaCode, HouseNumber, Street, City, Region, ZipPostalCode, Country, PhoneNumber)VALUES(@Name, @Email, @AreaCode, @HouseNumber, @Street,@City, @Region, @ZipPostalCode, @Country, @PhoneNumber)";
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@AreaCode", customer.AreaCode);
                    object housenumber = (string.IsNullOrEmpty(customer.HouseNumber)) ? (object)customer.HouseNumber.ToString() : DBNull.Value;
                    cmd.Parameters.AddWithValue("@HouseNumber", housenumber);
                    //cmd.Parameters.AddWithValue("@HouseNumber", customer.HouseNumber);
                    cmd.Parameters.AddWithValue("@Street", customer.Street);
                    cmd.Parameters.AddWithValue("@City", customer.City);
                    cmd.Parameters.AddWithValue("@Region", customer.Region);
                    cmd.Parameters.AddWithValue("@ZipPostalCode", customer.ZipPostalCode);
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Обновить информацию о клиенте
        /// </summary>
        /// <param name="customer">Клиент</param>
        public void Update(Customer customer)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE CUSTOMER SET Name=@Name, Email=@Email, AreaCode=@AreaCode, HouseNumber=@HouseNumber, Street=@Street, City=@City, Region=@Region, ZipPostalCode=@ZipPostalCode, Country=@Country, PhoneNumber=@PhoneNumber WHERE CustomerID = @CustomerID";
                    cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@AreaCode", customer.AreaCode);
                    cmd.Parameters.AddWithValue("@HouseNumber", customer.HouseNumber);
                    cmd.Parameters.AddWithValue("@Street", customer.Street);
                    cmd.Parameters.AddWithValue("@City", customer.City);
                    cmd.Parameters.AddWithValue("@Region", customer.Region);
                    cmd.Parameters.AddWithValue("@ZipPostalCode", customer.ZipPostalCode);
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="id">Номер клиента</param>
        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM CUSTOMER WHERE CustomerID = @ID";
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
        private static Customer LoadCustomer(SqlDataReader reader)
        {
            //Создаём пустой объект
            Customer customer = new Customer();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            customer.CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID"));
            customer.Name = reader.GetString(reader.GetOrdinal("Name"));
            customer.Email = reader.GetString(reader.GetOrdinal("Email"));
            customer.AreaCode = reader.GetString(reader.GetOrdinal("AreaCode"));
            object housenumber = reader["HouseNumber"];
            if (housenumber != DBNull.Value)
                customer.HouseNumber = Convert.ToString(housenumber);
            //customer.HouseNumber = reader.GetString(reader.GetOrdinal("HouseNumber"));
            customer.Street = reader.GetString(reader.GetOrdinal("Street"));
            customer.City = reader.GetString(reader.GetOrdinal("City"));
            customer.Region = reader.GetString(reader.GetOrdinal("Region"));
            customer.ZipPostalCode = reader.GetString(reader.GetOrdinal("ZipPostalCode"));
            customer.Country = reader.GetString(reader.GetOrdinal("Country"));
            customer.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
            return customer;
        }

        public IList<Customer> Load()
        {
            Customers = new Dictionary<int, Customer>();
            var customers = LoadInternal();
            foreach(var customer in customers)
            {
                Customers.Add(customer.CustomerID.Value, customer);
            }
            return Customers.Values.ToList();
        }
        public void Reset()
        {
            if (Customers == null)
                return;
            Customers.Clear();
        }

        public IList<Customer> SearchCustomers(string Name, string Email)
        {
            IList<Customer> customers = new List<Customer>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CustomerID, Email, Name, AreaCode, HouseNumber, Street, City, Region, ZipPostalCode, Country, PhoneNumber FROM CUSTOMER WHERE Email like @Email AND Name like @Name";
                    cmd.Parameters.AddWithValue("@Name", "%" + Name + "%");
                    cmd.Parameters.AddWithValue("@Email", "%" + Email + "%");
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customers.Add(LoadCustomer(dataReader));
                        }
                    }
                }
            }
            return customers;
        }
    }
}
