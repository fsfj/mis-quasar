using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MIS_API.Data
{
    public interface IConnectionFactory
    {
        IDbConnection Connection { get; }
    }
}
