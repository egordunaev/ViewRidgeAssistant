﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess.Entities;
using System.Configuration;

namespace VRA.DataAccess
{
    /// <summary>
    /// Описание действий с объектом художника в базе
    /// </summary>
    public interface IArtistDao
    {
        /// <summary>
        /// Получить художника по id
        /// </summary>
        /// <param name=«id»>id художника</param>
        /// <returns>художник</returns>
        Artist Get(int id);
        /// <summary>
        /// Получить список всех художников в базе
        /// </summary>
        /// <returns>список всех художников в базе</returns>
        IList<Artist> GetAll();
        /// <summary>
        /// Добавить художника в базу
        /// </summary>
        /// <param name="artist">Новый художник</param>
        void Add(Artist artist);
        /// <summary>
        /// Обновить художника
        /// </summary>
        /// <param name=«artist»>обновленный художник</param>
        void Update(Artist artist);
        /// <summary>
        /// Удалить художника
        /// </summary>
        /// <param name=«id»>id удаляемого художника</param>
        void Delete(int id);
        IList<Artist> Load();
        IList<Artist> SearchArtists(string Name, string Nation);
    }
}
