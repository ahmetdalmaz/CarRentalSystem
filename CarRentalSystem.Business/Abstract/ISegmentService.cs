using CarRentalSystem.Business.Responses;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Abstract
{
    public interface ISegmentService
    {
        void Add(Segment segment);
        void Update(Segment segment);
        void Delete(Segment segment);
        List<Segment> GetSegments();
        Task<IDataResponse<List<Segment>>> GetAllAsync();
        Task<Segment> GetSegmentById(int id);
    }
}
