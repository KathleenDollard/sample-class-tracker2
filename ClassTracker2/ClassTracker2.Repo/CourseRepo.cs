using ClassTracker2.Dto;
using Common;
using System;

namespace ClassTracker2.Repo
{
    public class CourseRepo : IRepo
    {
        public CourseDto GetById(int key)
            => key switch
            {
                341 => throw new Exception("Test"),
                36 => new CourseDto(key, "CS405", "Memory"),
                37 => new CourseDto(key, "CS506", "Async"),
                38 => new CourseDto(key, "S304", "Become a better C# programmer"),
                _ => default
            };
    }
}
