using ClassTracker2.Dto;
using ClassTracker2.Repo;
using Common;
using thisResult = Common.Result<System.Int32, ClassTracker2.Dto.StudentDto>;

namespace ClassTracker2.Lib
{
    public class StudentBiz : IDomain<int, StudentDto>
    {
        private readonly StudentRepo repo = new StudentRepo();

        public thisResult StartGetById(int key)
            => new Result<int, StudentDto>(key);

        public IResult GetById(int key)
           =>
            StartGetById(key)
                .Validate(Helpers.ValidateKey)
                .BindOutput<int, StudentDto>(repo.GetById);
    }
}
