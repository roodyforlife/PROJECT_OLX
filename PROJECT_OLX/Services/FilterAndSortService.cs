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
                    new CategoryViewModel {Name = "Дитячий світ", Id = 1},
                    new CategoryViewModel {Name = "Нерухомість", Id = 1},
                    new CategoryViewModel {Name = "Авто", Id = 1},
                    new CategoryViewModel {Name = "Запчастини для транспорту", Id = 1},
                    new CategoryViewModel {Name = "Робота", Id = 1},
                    new CategoryViewModel {Name = "Тварини", Id = 1},
                    new CategoryViewModel {Name = "Дім та сад", Id = 1},
                    new CategoryViewModel {Name = "Електроніка", Id = 1},
                    new CategoryViewModel {Name = "Бізнес послуги", Id = 1},
                    new CategoryViewModel {Name = "Мода та стиль", Id = 1},
                    new CategoryViewModel {Name = "Хоббі, відпочинок та спорт", Id = 1},
                    new CategoryViewModel {Name = "Обмін", Id = 1}
                };
            }
        }

        public IEnumerable<SortViewModel> AllSort
        {
            get
            {
                return new List<SortViewModel>
                {
                    new SortViewModel { Name = "За назвою a-z", Value = "NameAsc"},
                    new SortViewModel { Name = "За назвою z-a", Value = "NameDesc"},
                    new SortViewModel { Name = "Найдорожчі", Value = "CostDesc"},
                    new SortViewModel { Name = "Найдешевші", Value = "CostAsc"},
                    new SortViewModel { Name = "Найновіші", Value = "DateDesc"},
                    new SortViewModel { Name = "Найстаріші", Value = "DateAsc"},
                };
            }
        }
    }
}
