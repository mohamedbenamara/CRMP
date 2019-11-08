
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        CRMContext DataContext { get; }
    }

}
