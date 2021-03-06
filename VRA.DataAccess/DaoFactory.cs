﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.DataAccess
{
    public class DaoFactory
    {
        public static IArtistDao GetArtistDao()
        {
            return new ArtistDao();
        }
        public static SettingsDao GetSettingsDao()
        {
            return new SettingsDao();
        }        public static ICustomerDao GetCustomerDao()
        {
            return new CustomerDao();
        }
        public static ICustomerArtistIntDao GetCustomerArtistIntDao()
        {
            return new CustomerArtistIntDao();
        }
        public static ITransDao GetTransDao()
        {
            return new TransDao();
        }
        public static IWorkDao GetWorkDao()
        {
            return new WorkDao();
        }
        public static INationDao GetNationDao()
        {
            return new NationDao();
        }
        public static IWorkInGalleryDao GetWorkInGalleryDao()
        {
            return new WorkInGalleryDao();
        }
    }
}
