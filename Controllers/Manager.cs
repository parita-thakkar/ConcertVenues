using AutoMapper;
using PST2231A1.Data;
using PST2231A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// ************************************************************************************
// WEB524 Project Template V1 == 2231-7ec33f27-0329-4194-91e4-da3916b2c5fd
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************
// Name: Parita Sunilbhai Thakkar
// Student ID: 160107199
// Email: psthakkar1@myseneca.ca
// WEB 524 NSA - Assignment 1
// ************************************************************************************

namespace PST2231A1.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                cfg.CreateMap<Venue, VenueBaseViewModel>();
                cfg.CreateMap<VenueAddViewModel, Venue>();
                cfg.CreateMap<VenueBaseViewModel, Venue>();
                cfg.CreateMap<VenueBaseViewModel, VenueEditFormViewModel>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        //Get All:
        public IEnumerable<VenueBaseViewModel> VenueGetAll()
        {
            var sortedVenues = ds.Venues.OrderBy(v => v.Company); //fetch the data from ds and sort in ascending order by Company
            return mapper.Map<IEnumerable<Venue>, IEnumerable<VenueBaseViewModel>>(sortedVenues); //map Venue objects to the ViewModel objects using automapper
                                                                                                  //used IEnumerable because we are fetching 'many' venues
        }

        //Get One:
        public VenueBaseViewModel VenueGetById(int id)
        {
            var v = ds.Venues.Find(id); //find the venue with 'id'
            return v == null ? null : mapper.Map<Venue, VenueBaseViewModel>(v); //if found, map it to ViewModel object, else return null
        }

        //Add New:
        public VenueBaseViewModel AddNewVenue(VenueAddViewModel newObj)
        {
            var v = ds.Venues.Add(mapper.Map<VenueAddViewModel, Venue>(newObj)); //add new Venue object
            ds.SaveChanges();

            return v == null ? null : mapper.Map<Venue, VenueBaseViewModel>(v); //map the added object to ViewModel object
        }

        //Edit Existing:
        public VenueBaseViewModel EditVenue(VenueEditViewModel v)
        {
            var venueObj = ds.Venues.Find(v.VenueId); //find if the id exists

            if (venueObj == null) //id doesn't exist
            {
                return null;
            }
            else
            {
                ds.Entry(venueObj).CurrentValues.SetValues(v); //id exists, change the values for this id in datastore
                                                               //set the values passed through the parameter
                ds.SaveChanges();

                return mapper.Map<Venue, VenueBaseViewModel>(venueObj);
            }
        }

        //Delete Existing:
        public bool DeleteVenue(int? id) //int? - id can be null
        {
            var venueObj = ds.Venues.Find(id); //locate the id

            if (venueObj == null)
            {
                return false;
            }
            else
            {
                ds.Venues.Remove(venueObj); //if found, remove the venue object
                ds.SaveChanges();

                return true;
            }
        }
    }
}