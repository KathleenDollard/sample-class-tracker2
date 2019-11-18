//using Common;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ClassTracker2.Lib
//{
//   public class BizBase<TKey, TDto, TRepo> : IDomain<TKey, TDto>
//        where TDto : struct
//        where TRepo : IRepo<TKey, TDto>, new()
//    {
//        private readonly TRepo repo = new TRepo();

//        public Result<TKey, TDto> StartGetById(TKey key)
//            => new Result<TKey, TDto>(key);

//        public IResult GetById(TKey key)
//           =>
//            StartGetById(key)
//                .Validate(Helpers.ValidateKey<TKey>)
//                .BindOutput(repo.GetById);
//    }
//}
