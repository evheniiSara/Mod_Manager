using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_Manager.Interfaces
{
    internal interface IStorage<T>
    {
        ICollection<T> users { get; set; }
    }
}
