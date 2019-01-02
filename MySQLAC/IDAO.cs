using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLAC
{
    interface IDAO <T>
    {
       void Create(T ob);
        DataTable Read();
        void Update(T ob);
        void Delete(int id);

    }
}
