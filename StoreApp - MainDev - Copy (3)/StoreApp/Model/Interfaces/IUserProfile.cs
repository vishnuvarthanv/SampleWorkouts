using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.Interfaces
{
    public interface IUserProfile
    {
        string Name { get; set; }
        string Email { get; set; }

        string Mobile { get; set; }
        string Address { get; set; }
        string Location { get; set; }
    }
}
