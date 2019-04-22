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
        }        public static ICustomerProcess GetCustomerProcess()
        {
            return new CustomerProcessDb();
        }
        public static ICustomerArtistIntProcess GetCustomerArtistIntProcess()
        {
            return new CustomerArtistIntDb();
        }
        public static IWorkProcess GetWorkProcess()
        {
            return new WorkProcessDb();
        }
        public static ITransProcess GetTransProcess()
        {
            return new TransProcessDb();
        }
        public static INationProcess GetNationProcess()
        {
            return new NationProcess();
        }
    }
}
