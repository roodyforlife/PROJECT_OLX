using Microsoft.EntityFrameworkCore;
using PROJECT_OLX.Interfaces;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Services
{
    public class DbApplicationService : IDbApplicationService
    {
        private readonly ApplicationContext db;
        public DbApplicationService(ApplicationContext db)
        {
            this.db = db;
        }
        public void Add(Add add)
        {
            db.Adding.Add(add);
            db.SaveChanges();
        }
        public void Del(Add add)
        {
            db.Adding.Remove(add);
            db.SaveChanges();
        }

        public Add Get(int addId)
        {
            return db.Adding.Include(x => x.Photos).FirstOrDefault(x => x.Id == addId);
        }

        public List<Add> GetAll()
        {
            return db.Adding.Include(x => x.Photos).ToList();
        }

        public List<Add> GetSomeBySearch(SearchViewModel searchResult)
        {
            searchResult.Input = String.IsNullOrEmpty(searchResult.Input) ? "" : searchResult.Input;
            var category = "";
            if (searchResult.Category is not null && searchResult.Category.Name is not null)
            {
                category = searchResult.Category.Name;
            }
            var filteredADS = db.Adding.Include(x => x.Photos).Where(x => x.Category.Contains(category) && (x.Title + x.Desc).ToLower().Contains(searchResult.Input.ToLower()));
            switch (searchResult.Sort)
            {
                case "NameDesc":
                    filteredADS = filteredADS.OrderByDescending(x => x.Title);
                    break;
                case "NameAsc":
                    filteredADS = filteredADS.OrderBy(x => x.Title);
                    break;
                case "CostDesc":
                    filteredADS = filteredADS.OrderByDescending(x => x.Cost);
                    break;
                case "CostAsc":
                    filteredADS = filteredADS.OrderBy(x => x.Cost);
                    break;
                case "DateDesc":
                    filteredADS = filteredADS.OrderByDescending(x => x.Data);
                    break;
                case "DateAsc":
                    filteredADS = filteredADS.OrderBy(x => x.Data);
                    break;
            }
            return filteredADS.ToList();
        }

        public List<Add> GetSomeByUserName(string userId)
        {
            return db.Adding.Include(x => x.Photos).ToList().FindAll(x => x.userName == userId);
        }
    }
}
