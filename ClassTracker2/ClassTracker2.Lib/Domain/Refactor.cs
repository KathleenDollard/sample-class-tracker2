using ClassTracker2.Dto;
using ClassTracker2.Repo;
using Common;
using System;

namespace ClassTracker2.Lib
{
    public class BizBaseRefactor<TPKey, TDto, TRepo> 
        : IDomain<int, TDto>
        where TRepo: IRepo<int, TDto>, new()
    {
        private readonly TRepo repo = new TRepo();

        public Result<int, TDto> StartGetById(int key)
            => new Result<int, TDto>(key);

        public IResult GetById(int key)
            => StartGetById(key)
                    .Validate(Helpers.ValidateKey)
                    .BindOutput<int, TDto>(repo.GetById);
    }

