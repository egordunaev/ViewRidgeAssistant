using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        /// номер клиента
        /// </summary>
        public int? CustomerID { get; set; }
        /// <summary>
        /// Email клиента
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Имя клиента (полное)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Код города
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        public string HouseNumber { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Регион
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string ZipPostalCode { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
