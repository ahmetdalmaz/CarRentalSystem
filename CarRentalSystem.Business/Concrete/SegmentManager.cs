using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Responses;
using CarRentalSystem.Business.Utilities;
using CarRentalSystem.Business.ValidationRules;
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

        public IResponse Add(Segment segment)
        {
            var validationResult = ValidationTool.Validate<SegmentValidator>(segment);
            if (validationResult.Count > 0)
            {
                return Response.Fail("Segment Eklenemedi", validationResult);
            }

            _segmentDal.Add(segment);
            return Response.Success();
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

        public IResponse Update(Segment segment)
        {
            var validationResult = ValidationTool.Validate<SegmentValidator>(segment);
            if (validationResult.Count > 0)
            {
                return Response.Fail("Segment Güncellenemedi", validationResult);
            }
            _segmentDal.Update(segment);
            return Response.Success();
        }
    }
}
