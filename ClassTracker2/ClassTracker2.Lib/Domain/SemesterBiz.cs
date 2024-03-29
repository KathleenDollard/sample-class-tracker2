﻿using ClassTracker2.Dto;
using ClassTracker2.Repo;
using Common;
using thisResult = Common.Result<System.Int32, ClassTracker2.Dto.SemesterDto>;

namespace ClassTracker2.Lib
{
    public class SemesterBiz : IDomain<int, SemesterDto >
    {
        private readonly SemesterRepo repo = new SemesterRepo();

        public thisResult StartGetById(int key)
            => new Result<int, SemesterDto>(key);

        public IResult GetById(int key)
           =>
            // Validation is repeated to show two approaches. I prefer the second
            StartGetById(key)
                .Apply(Helpers.ValidateInputAsKey)
                .Validate(Helpers.ValidateKey)
                .BindOutput<int, SemesterDto>(repo.GetById);
    }
}
