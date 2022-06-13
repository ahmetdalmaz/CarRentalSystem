using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Responses;
using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Concrete
{
    public class SegmentManager : ISegmentService
    {
        private readonly ISegmentDal _segmentDal;

        public SegmentManager(ISegmentDal segmentDal)
        {
            _segmentDal = segmentDal;
        }

        public void Add(Segment segment)
        {
          _segmentDal.Add(segment);
        }

        public void Delete(Segment segment)
        {
            _segmentDal.Delete(segment);
        }

        public async Task<IDataResponse<List<Segment>>> GetAllAsync()
        {
            var segmentList = await _segmentDal.GetListAsync();
            return Response<List<Segment>>.Success(segmentList);
        }

        public async Task<Segment> GetSegmentById(int id)
        {
           return await _segmentDal.GetAsync(s => s.SegmentId == id);
        }

        public List<Segment> GetSegments()
        {
            return _segmentDal.GetAll();
        }

        public void Update(Segment segment)
        {
            _segmentDal.Update(segment);
        }
    }
}
