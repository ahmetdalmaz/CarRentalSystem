using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Responses
{
    public interface IDataResponse<T>:IResponse
    {
        T Data { get;}

    }
}
