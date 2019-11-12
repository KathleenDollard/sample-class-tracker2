using ClassTracker2.Dto;
using Common;
using System;

namespace ClassTracker2.Repo
{
    public class StudentRepo : IRepo
    {
        public StudentDto GetById(int key)
          => key switch
          {
              141 => throw new Exception("Test"),
              16 => new StudentDto(key, "John","Smith"),
              _ => default
          };
    }
}
