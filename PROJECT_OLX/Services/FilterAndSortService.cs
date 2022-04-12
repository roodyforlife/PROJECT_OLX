using PROJECT_OLX.Interfaces;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Services
{
    public class FilterAndSortService : IFilterAndSortService
    {
        public IEnumerable<CategoryViewModel> AllCategories
        {
            get
            {
                return new List<CategoryViewModel>
                {
                    new CategoryViewModel {Name = "Всі", Id = 0},
                    new CategoryViewModel {Name = "Допомога", Id = 1},
                    new CategoryViewModel {Name = "Дитячий світ", Id = 2},
                    new CategoryViewModel {Name = "Нерухомість", Id = 3},
                    new CategoryViewModel {Name = "Авто", Id = 4},
                    new CategoryViewModel {Name = "Запчастини для транспорту", Id = 5},
                    new CategoryViewModel {Name = "Робота", Id = 6},
                    new CategoryViewModel {Name = "Тварини", Id = 7},
                    new CategoryViewModel {Name = "Дім та сад", Id = 8},
                    new CategoryViewModel {Name = "Електроніка", Id = 9},
                    new CategoryViewModel {Name = "Бізнес послуги", Id = 10},
                    new CategoryViewModel {Name = "Мода та стиль", Id = 11},
                    new CategoryViewModel {Name = "Хоббі, відпочинок та спорт", Id = 12},
                    new CategoryViewModel {Name = "Обмін", Id = 13}
                };
            }
        }
    }
}
