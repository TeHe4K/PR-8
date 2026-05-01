using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_8_Konevskii.Interfaces
{
    public interface IContext
    {
        List<object> All();
        void Save(bool Update = false);

        void Delete();
    }
}
