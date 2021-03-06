﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Models.ViewModels;

namespace WebProject.Models
{
    public class PlaceModel
    {
        [Key]
        public int PlaceId { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Photo_URI { get; set; }

        public int CountryId { get; set; }

        public int UserId { get; set; }

        public bool IsAccepted { get; set; }

        public CreatePlaceViewModel GetCountriesForCreate()
        {
            CreatePlaceViewModel model = new CreatePlaceViewModel();
            model.Countries = new List<CountryModel>();
            using (var db = new DBEntitiesProxy())
            {
                model.Countries = db.Country.Select(x => new CountryModel { Code = x.Code, CountryId = x.CountryId, Name = x.Name }).ToList();
            }

            return model;
        }

        public void Create(CreatePlaceViewModel model)
        {
            var userModel = new UserModel();
            using (var db = new DBEntitiesProxy())
            {
                var userid = userModel.GetUserID(model.UserEmail);
                db.Place.Add(new Place()
                {
                    Name = model.Name,
                    Content = model.Content,
                    Photo_URI = model.Photo_URI,
                    CountryId = model.CountryId,
                    IsAccepted = false,
                    UserId = userid,
                    AddDate = System.DateTime.Now,
                    Ranking = 1,
                    ContentPL = model.ContentPL,
                    ContentPT = model.ContentPT,

                });
                db.SaveChanges();
            }
        }
        public void Accept(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                var place = db.Place.Where(x => x.PlaceId == id).SingleOrDefault();
                if (place != null)
                {
                    place.IsAccepted = true;
                }

                db.SaveChanges();
            }
        }
        public PlaceViewModel GetPlace(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                return db.Place.Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, ContentPL = x.ContentPL, ContentPT = x.ContentPT,
                    UserEmail = x.User.Email, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI, Score = (int)x.Ranking, IsAccepted = x.IsAccepted }).Where(x => x.PlaceId == id).SingleOrDefault();
            }

        }
        public EditPlaceViewModel GetPlaceToEdit(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                var place = db.Place.Select(x => new EditPlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, ContentPL = x.ContentPL, ContentPT = x.ContentPT, CountryId = x.Country.CountryId, Photo_URI = x.Photo_URI }).Where(x => x.PlaceId == id).SingleOrDefault();
                place.Countries = new List<CountryModel>();
                place.Countries = db.Country.Select(x => new CountryModel { Code = x.Code, CountryId = x.CountryId, Name = x.Name }).ToList();

                return place;
            }
        }
        public void EditPlace(EditPlaceViewModel model)
        {
            using (var db = new DBEntitiesProxy())
            {
                var place = db.Place.Where(x => x.PlaceId == model.PlaceId).Single();

                place.Name = model.Name;
                place.Content = model.Content;
                place.Photo_URI = model.Photo_URI;
                place.CountryId = model.CountryId;
                place.ContentPL = model.ContentPL;
                place.ContentPT = model.ContentPT;

                db.Entry(place).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public List<PlaceViewModel> GetPlaces()
        {
            var db = new DBEntitiesProxy();
            return db.Place.Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI, IsAccepted = x.IsAccepted }).ToList();
        }
        public List<PlaceViewModel> GetPlacesByAdds()
        {
            var db = new DBEntitiesProxy();
            return db.Place.Where(x => x.IsAccepted == true).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI, IsAccepted = x.IsAccepted }).Take(4).ToList();
        }
        public List<PlaceViewModel> GetPlacesByPopularDesc()
        {
            var db = new DBEntitiesProxy();
            return db.Place.Where(x => x.IsAccepted == true).OrderByDescending(x => x.Travels.Count).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).Take(4).ToList();
        }
        public List<PlaceViewModel> GetPlacesByRanking()
        {
            var db = new DBEntitiesProxy();
            return db.Place.Where(x => x.IsAccepted == true).OrderByDescending(x => x.Ranking.Value).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).Take(4).ToList();
        }
        public List<PlaceViewModel> GetPlacesByPopularASC()
        {
            var db = new DBEntitiesProxy();
            return db.Place.Where(x => x.IsAccepted == true).OrderBy(x => x.Travels.Count).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).Take(4).ToList();
        }
        public List<PlaceViewModel> GetAccpetedPlaces()
        {
            var db = new DBEntitiesProxy();
            return db.Place.Where(x => x.IsAccepted == true).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).ToList();
        }
        public List<PlaceViewModel> GetNotAccpetedPlaces()
        {
            var db = new DBEntitiesProxy();
            return db.Place.Where(x => x.IsAccepted == false).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).ToList();
        }
        public List<PlaceViewModel> GetPlacesAddedByUser(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                return db.Place.Where(x => x.UserId == id).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).ToList();
            }
        }
        public List<PlaceViewModel> GetPlacesAddedByUser(string email)
        {
            using (var db = new DBEntitiesProxy())
            {
                return db.Place.Where(x => x.User.Email == email).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).ToList();
            }
        }
        public PlaceListViewModel GetListOfPlaces()
        {
            using (var db = new DBEntitiesProxy())
            {
                var places = new PlaceListViewModel();
                places.Places = db.Place.Where(x => x.IsAccepted == true).OrderByDescending(x => x.AddDate).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Country = x.Country.Name }).ToList();
                places.Countries = new List<CountryModel>();
                places.Countries = db.Country.Select(x => new CountryModel { Code = x.Code, CountryId = x.CountryId, Name = x.Name }).ToList();
                return places;
            }
        }
        public PlaceListViewModel GetListOfPlaces(int coutryId)
        {
            using (var db = new DBEntitiesProxy())
            {
                var places = new PlaceListViewModel();
                places.Places = db.Place.Where(x => x.IsAccepted == true && x.CountryId == coutryId).OrderByDescending(x => x.AddDate).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Country = x.Country.Name }).ToList();
                places.Countries = new List<CountryModel>();
                places.Countries = db.Country.Select(x => new CountryModel { Code = x.Code, CountryId = x.CountryId, Name = x.Name }).ToList();
                return places;
            }
        }
    }
}
