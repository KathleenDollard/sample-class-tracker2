using ClassTracker2.Dto;
using ClassTracker2.Repo;
using Common;
using thisResult = Common.Result<System.Int32, ClassTracker2.Dto.CourseDto>;

namespace ClassTracker2.Lib
{
    public class CourseBiz : IDomain<int, CourseDto>
    {
        private readonly CourseRepo repo = new CourseRepo();

        public thisResult StartGetById(int key)
            => new Result<int, CourseDto>(key);

        public IResult GetById(int key)
           =>
            // Validation is repeated to show two approaches. I prefer the second
            StartGetById(key)
                .Apply(Helpers.ValidateInputAsKey)
                .Validate(Helpers.ValidateKey)
                .BindOutput<int, CourseDto>(repo.GetById);
    }
}
