using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Сonnection
{
    class ConnectionString
    {
        private const string _connectionString = "server=10.207.106.12;uid=user62;pwd=cb58;database=db62;charset=utf8;sslmode=0";

        public string connectionString
        {
            get { return _connectionString; }
        }

    }
}
