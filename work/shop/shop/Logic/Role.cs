using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Logic
{
    static class Role
    {
        static int role = -1;
        static public void setRole(int rolee)
        {
            role=rolee;
        }
        static public int getRole()
        {
            return role;
        }
    }
}
