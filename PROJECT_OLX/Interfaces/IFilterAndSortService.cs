using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Interfaces
{
    public interface IFilterAndSortService
    {
        public IEnumerable<CategoryViewModel> AllCategories { get; }
        public IEnumerable<SortViewModel> AllSort { get; }
    }
}
