using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinstarApp.Data
{
    public interface IApplicationRepository
    {
        Task PostData(IEnumerable<DataObject> data);
        Task<IEnumerable<DataObject>> GetData(DataFilter dataFilter);
    }
}
