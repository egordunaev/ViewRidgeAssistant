﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Класс - художник
    /// </summary>
    public class ArtistDto
    {
        /// <summary>
        /// id художника
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Год рождения
        /// </summary>
        public int BirthYear { get; set; }
        /// <summary>
        /// Год смерти
        /// </summary>
        public int? DeceaseYear { get; set; }
        /// <summary>
        /// Национальность
        /// </summary>
        public NationDto Nation { get; set; }
    }
}
