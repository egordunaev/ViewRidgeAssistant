using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.BusinessLayer
{
    /// <summary>
    /// Фабрика классов бизнес-логики
    /// </summary>
    public class ProcessFactory
    {
        /// <summary>
        /// Возвращает объект, реализующий <seealso cref=«IArtistProcess»/>
        /// </summary>
        /// <returns></returns>
        public static IArtistProcess GetArtistProcess()
        {
            return new ArtistProcessDb();
        }        public static ISettingsProcess GetSettingsProcess()
        {
            return new SettingsProcess();
        }
    }
}
