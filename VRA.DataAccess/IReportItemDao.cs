﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess.Entities;

namespace VRA.DataAccess
{
    public interface IReportItemDao
    {
        IList<Report> getPurchasedPerDays(DateTime start, DateTime end);

        IList<Report> getPurchasedPerMonth(DateTime start, DateTime end);

        IList<Report> getPurchasedPerYear(DateTime start, DateTime end);

        IList<Report> getSalesPerDay(DateTime start, DateTime end);

        IList<Report> getSalesPerMonth(DateTime start, DateTime end);

        IList<Report> getSalesPerYear(DateTime start, DateTime end);
    }
}
