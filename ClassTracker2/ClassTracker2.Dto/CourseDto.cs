using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ClassTracker2.Dto
{
    public struct CourseDto
    {
        private CourseDto(int id, string classCode, string className,
            ImmutableList<CourseSectionDto> courseSections)
        {
            Id = id;
            ClassCode = classCode;
            ClassName = className;
            this.courseSections = courseSections;
        }
        public CourseDto(int id, string classCode, string className,
            params CourseSectionDto[] courseSections)
            : this(id, classCode, className,
            ImmutableList<CourseSectionDto>.Empty.AddRange(courseSections))
        { }

        private readonly ImmutableList<CourseSectionDto> courseSections;
        public IEnumerable<CourseSectionDto> CourseSections => courseSections.Select(x => x);

        public int Id { get; }
        public string ClassCode { get; }
        public string ClassName { get; }

        public CourseDto With(int? id = null, string firstName = null, string lastName = null,
                    params CourseSectionDto[] courseSections)
            => new CourseDto(
                id ?? Id,
                firstName ?? ClassCode,
                lastName ?? ClassName,
                courseSections.Length == 0
                    ? this.courseSections
                    : ImmutableList<CourseSectionDto>.Empty.AddRange(courseSections)
                );

        public CourseDto WithResetcourseSections()
            => new CourseDto(
                Id,
                ClassCode,
                ClassName,
                ImmutableList<CourseSectionDto>.Empty
                );

        public bool Equals(CourseDto other)
            => Equals(other, this);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var objectToCompareWith = (CourseDto)obj;

            return objectToCompareWith.Id == Id &&
                   objectToCompareWith.ClassCode == ClassCode &&
                   objectToCompareWith.ClassName == ClassName;
        }

        public override int GetHashCode()
           => Id + ((ClassCode?.GetHashCode() * 17) + ClassName?.GetHashCode()).GetValueOrDefault();
        public static bool operator ==(CourseDto c1, CourseDto c2)
            => c1.Equals(c2);
        public static bool operator !=(CourseDto c1, CourseDto c2)
            => !c1.Equals(c2);

        public void Deconstruct(out int id, out string firstName, out string lastName)
        {
            id = Id;
            firstName = ClassCode;
            lastName = ClassName;
        }

    }
}
