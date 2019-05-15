using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess.Entities;
using VRA.DataAccess;

namespace VRA.BusinessLayer.Converters
{
    public class DtoConverter
    {
        //
        // ARTIST
        //
        public static ArtistDto Convert(Artist artist)
        {
            if (artist == null)
                return null;
            ArtistDto artistDto = new ArtistDto();
            artistDto.Id = artist.ArtistId;
            artistDto.BirthYear = artist.BirthYear;
            artistDto.DeceaseYear = artist.DeceaseYear;
            artistDto.Name = artist.Name;
            artistDto.Nation = Convert(DaoFactory.GetNationDao().Get(artist.NationID));
            return artistDto;
        }
        public static Artist Convert(ArtistDto artistDto)
        {
            if (artistDto == null)
                return null;
            Artist artist = new Artist();
            artist.ArtistId = artistDto.Id;
            artist.BirthYear = artistDto.BirthYear;
            artist.DeceaseYear = artistDto.DeceaseYear;
            artist.Name = artistDto.Name;
            artist.NationID = artistDto.Nation.NationID;
            return artist;
        }
        public static IList<ArtistDto> Convert(IList<Artist> artists)
        {
            if (artists == null)
                return null;
            IList<ArtistDto> artistDtos = new List<ArtistDto>();
            foreach (var artist in artists)
            {
                artistDtos.Add(Convert(artist));
            }
            return artistDtos;
        }
        //
        // CUSTOMER
        //
        public static CustomerDto Convert(Customer customer)
        {
            if (customer == null)
                return null;
            CustomerDto customerDto = new CustomerDto();
            customerDto.CustomerID = customer.CustomerID;
            customerDto.Email = customer.Email;
            customerDto.Name = customer.Name;
            customerDto.AreaCode = customer.AreaCode;
            customerDto.HouseNumber = customer.HouseNumber;
            customerDto.Street = customer.Street;
            customerDto.City = customer.City;
            customerDto.Region = customer.Region;
            customerDto.ZipPostalCode = customer.ZipPostalCode;
            customerDto.Country = customer.Country;
            customerDto.PhoneNumber = customer.PhoneNumber;
            return customerDto;
        }
        public static Customer Convert(CustomerDto customerDto)
        {
            if (customerDto == null)
                return null;
            Customer customer = new Customer();
            customer.CustomerID = customerDto.CustomerID;
            customer.Email = customerDto.Email;
            customer.Name = customerDto.Name;
            customer.AreaCode = customerDto.AreaCode;
            customer.HouseNumber = customerDto.HouseNumber;
            customer.Street = customerDto.Street;
            customer.City = customerDto.City;
            customer.Region = customerDto.Region;
            customer.ZipPostalCode = customerDto.ZipPostalCode;
            customer.Country = customerDto.Country;
            customer.PhoneNumber = customerDto.PhoneNumber;
            return customer;
        }
        public static IList<CustomerDto> Convert(IList<Customer> customers)
        {
            if (customers == null)
                return null;
            IList<CustomerDto> customerDtos = new List<CustomerDto>();
            foreach (var customer in customers)
            {
                customerDtos.Add(Convert(customer));
            }
            return customerDtos;
        }
        //
        // TRANS
        //
        public static TransDto Convert(Trans trans)
        {
            if (trans == null)
                return null;
            TransDto transDto = new TransDto();
            transDto.TransactionID = trans.TransactionID;
            transDto.Customer = Convert(DaoFactory.GetCustomerDao().Get(trans.CustomerID.Value));
            transDto.DateAcquired = trans.DateAcquired;
            transDto.AcquisitionPrice = trans.AcquisitionPrice;
            transDto.PurchaseDate = trans.PurchaseDate;
            transDto.SalesPrice = trans.SalesPrice;
            transDto.AskingPrice = trans.AskingPrice;
            transDto.Work = Convert(DaoFactory.GetWorkDao().Get(trans.WorkID)); ;
            return transDto;
        }
        public static Trans Convert(TransDto transDto)
        {
            if (transDto == null)
                return null;
            Trans trans = new Trans();
            trans.TransactionID = transDto.TransactionID;
            if(transDto.Customer.CustomerID.HasValue)
                trans.CustomerID = transDto.Customer.CustomerID.Value;
            trans.DateAcquired = transDto.DateAcquired;
            trans.AcquisitionPrice = transDto.AcquisitionPrice;
            trans.PurchaseDate = transDto.PurchaseDate;
            trans.SalesPrice = transDto.SalesPrice;
            trans.AskingPrice = transDto.AskingPrice;
            trans.WorkID = transDto.Work.WorkID;
            return trans;

        }
        public static IList<TransDto> Convert(IList<Trans> transactions)
        {
            if (transactions == null)
                return null;
            IList<TransDto> transDtos = new List<TransDto>();
            foreach (var trans in transactions)
            {
                transDtos.Add(Convert(trans));
            }
            return transDtos;
        }
        //
        // WORK
        //
        public static WorkDto Convert(Work work)
        {
            if (work == null)
                return null;
            WorkDto workDto = new WorkDto();
            workDto.WorkID = work.WorkID;
            workDto.Artist = Convert(DaoFactory.GetArtistDao().Get(work.ArtistID));
            workDto.Title = work.Title;
            workDto.Copy = work.Copy;
            workDto.Description = work.Description;
            return workDto;
        }
        public static Work Convert(WorkDto workDto)
        {
            if (workDto == null)
                return null;
            Work work = new Work();
            work.WorkID = workDto.WorkID;
            work.ArtistID = workDto.Artist.Id;
            work.Title = workDto.Title;
            work.Copy = workDto.Copy;
            work.Description = workDto.Description;
            return work;
        }
        public static IList<WorkDto> Convert(IList<Work> works)
        {
            if (works == null)
                return null;
            IList<WorkDto> workDtos = new List<WorkDto>();
            foreach (var work in works)
            {
                workDtos.Add(Convert(work));
            }
            return workDtos;
        }
        public static IList<WorkDto> Convert(IEnumerable<Work> works)
        {
            if (works == null)
                return null;
            IList<WorkDto> workDtos = new List<WorkDto>();
            foreach(var work in works)
            {
                workDtos.Add(Convert(work));
            }
            return workDtos;
        }
        //
        // CUSTOMER_ARTIST_INT
        //
        public static CustomerArtistIntDto Convert(CustomerArtistInt customerArtistInt)
        {
            if (customerArtistInt == null)
                return null;
            CustomerArtistIntDto customerArtistIntDto = new CustomerArtistIntDto();
            customerArtistIntDto.Customer = Convert(DaoFactory.GetCustomerDao().Get(customerArtistInt.CustomerID));
            customerArtistIntDto.Artist = Convert(DaoFactory.GetArtistDao().Get(customerArtistInt.ArtistID));
            return customerArtistIntDto;
        }
        public static CustomerArtistInt Convert(CustomerArtistIntDto customerArtistIntDto)
        {
            if (customerArtistIntDto == null)
                return null;
            CustomerArtistInt customerArtistInt = new CustomerArtistInt();
            customerArtistInt.CustomerID = customerArtistIntDto.Customer.CustomerID.Value;
            customerArtistInt.ArtistID = customerArtistIntDto.Artist.Id;
            return customerArtistInt;
        }
        public static IList<CustomerArtistIntDto> Convert(IList<CustomerArtistInt> customerArtistInts)
        {
            if (customerArtistInts == null)
                return null;
            IList<CustomerArtistIntDto> customerArtistIntDtos = new List<CustomerArtistIntDto>();
            foreach(var customerartistInt in customerArtistInts)
            {
                customerArtistIntDtos.Add(Convert(customerartistInt));
            }
            return customerArtistIntDtos;
        }
        //
        //   NATIONS
        //
        public static NationDto Convert(Nation nation)
        {
            if (nation == null)
                return null;
            NationDto nationDto = new NationDto();
            nationDto.NationID = nation.NationID;
            nationDto.Nationality = nation.Name;
            return nationDto;
        }
        public static Nation Convert(NationDto nationDto)
        {
            if (nationDto == null)
                return null;
            Nation nation = new Nation();
            nation.NationID = nationDto.NationID;
            nation.Name = nationDto.Nationality;
            return nation;
        }
        internal static IList<NationDto> Convert(IList<Nation> nationList)
        {
            var nations = new List<NationDto>();
            foreach (var nation in nationList)
            {
                nations.Add(Convert(nation));
            }
            return nations;
        }
        // 
        // REPORT
        //
        private static ReportItemDto Convert(Report report)
        {
            if (report == null) { return null; }
            ReportItemDto reportdto = new ReportItemDto
            {
                date = report.date.ToString(),
                count =
           report.count,
                price = report.price
            };
            return reportdto;
        }
        public static IList<ReportItemDto> Convert(IEnumerable<Report> reports)
        {
            if (reports == null) { return null; }
            IList<ReportItemDto> ReportsDto = new List<ReportItemDto>();
            foreach (var r in reports)
            {
                ReportsDto.Add(Convert(r));
            }
            return ReportsDto;
        }
        //
        // WORKS IN GALLERY
        //
        private static WorkInGalleryDto Convert(WorkInGallery workInGallery)
        {
            if (workInGallery == null)
                return null;
            WorkInGalleryDto workInGalleryDto = new WorkInGalleryDto();
            workInGalleryDto.Id = workInGallery.Id;
            workInGalleryDto.Title = workInGallery.Title;
            workInGalleryDto.Copy = workInGallery.Copy;
            workInGalleryDto.Name = workInGallery.Name;
            workInGalleryDto.AskingPrice = workInGallery.AskingPrice;
            workInGalleryDto.Description = workInGallery.Description;
            return workInGalleryDto;
        }
        public static IList<WorkInGalleryDto> Convert(IList<WorkInGallery> workInGalleries)
        {
            var worksInGallery = new List<WorkInGalleryDto>();
            foreach(var work in workInGalleries)
            {
                worksInGallery.Add(Convert(work));
            }
            return worksInGallery;
        }
    }
}
