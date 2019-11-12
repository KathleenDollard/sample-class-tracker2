using ClassTracker2.Dto;
using Common;
using System;
using thisResult = Common.Result<System.Int32, ClassTracker2.Dto.TeacherDto>;

namespace ClassTracker2.Repo
{
    public class TeacherRepo : IRepo<int, TeacherDto>
    {
        public TeacherDto GetById(int key)
            => key switch
            {
                41 => throw new Exception("Test"),
                6 => new TeacherDto(key, "Apple", "Pie"),
                7 => new TeacherDto(key, "Berry", "Cobbler"),
                8 => new TeacherDto(key, "Coconut", "Swirl"),
                _ => default
            };
    }
}
