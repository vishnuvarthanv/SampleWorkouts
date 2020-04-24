using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.Interfaces
{
    public interface ICategory
    {
         string CategoryName { get; set; }

        string CategoryId { get; set; }
    }
}
