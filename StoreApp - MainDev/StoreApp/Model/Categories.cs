using StoreApp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class Categories: ICategory
    {
        public string CategoryName { get; set; }

        public string CategoryId { get; set; }
    }
}
