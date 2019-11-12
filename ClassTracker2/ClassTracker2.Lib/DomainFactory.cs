using ClassTracker2.Dto;
using ClassTracker2.Lib;
using Common;

namespace ClassTracker2.Lib
{
    internal class DomainFactory: FactoryBase<IDomain>
    {
        public DomainFactory() 
        {
            AddMaker<TeacherDto>(() => new TeacherBiz());
            AddMaker<StudentDto>(() => new StudentBiz());
            AddMaker<CourseDto >(() => new CourseBiz());
            AddMaker<SemesterDto>(() => new SemesterBiz());
        }
    }
}