using ClassTracker2.Dto;
using Common;
using System;

namespace ClassTracker2.Repo
{
    public class SemesterRepo : IRepo
    {
        public SemesterDto GetById(int key)
          => key switch
          {
              241 => throw new Exception("Test"),
              26 => new SemesterDto(key, DateTime.Parse("2019-03-01"), DateTime.Parse("2019-06-15")),
              _ => default
          };
    }
}
