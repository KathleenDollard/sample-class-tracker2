using ClassTracker2.Dto;
using ClassTracker2.Lib;
using ClassTracker2.Repo;
using Common;

namespace ClassTracker2.Lib
{
    internal class DomainFactory<TDto, TBiz> : FactoryBase<IDomain>
    {
    }
        internal class DomainFactory: FactoryBase<IDomain>
    {
        public DomainFactory() 
        {
            AddMaker<TeacherDto>(() => new TeacherBiz());
            AddMaker<StudentDto>(() => new StudentBiz());
            AddMaker<BizBaseRefactor<int, CourseDto, CourseRepo>>(() 
                    => new BizBaseRefactor<int, CourseDto, CourseRepo>);
            AddMaker<SemesterDto>(() => new SemesterBiz());
        }
    }
}