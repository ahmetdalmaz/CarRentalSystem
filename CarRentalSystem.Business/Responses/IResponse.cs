using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Responses
{
    public interface IResponse
    {
        bool IsSuccesful { get; }
        string Message { get; }
        List<string> Errors { get; set; }
    }
}
