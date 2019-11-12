using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ClassTracker2.Dto
{
    public struct TeacherDto
    {
        private TeacherDto(int id, string firstName, string lastName,
            ImmutableList<CourseSectionDto> courseSections)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            this.courseSections = courseSections;
        }
        public TeacherDto(int id, string firstName, string lastName,
            params CourseSectionDto[] courseSections)
            : this(id, firstName, lastName,
            ImmutableList<CourseSectionDto>.Empty.AddRange(courseSections))
        { }

        private readonly ImmutableList<CourseSectionDto> courseSections;
        public IEnumerable<CourseSectionDto> CourseSections => courseSections.Select(x => x);

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }


        public TeacherDto With(int? id = null, string firstName = null, string lastName = null,
                    params CourseSectionDto[] courseSections)
            => new TeacherDto(
                id ?? Id,
                firstName ?? FirstName,
                lastName ?? LastName,
                courseSections.Length == 0
                    ? this.courseSections
                    : ImmutableList<CourseSectionDto>.Empty.AddRange(courseSections)
                );

        public TeacherDto WithResetcourseSections()
            => new TeacherDto(
                Id,
                FirstName,
                LastName,
                ImmutableList<CourseSectionDto>.Empty
                );

        public bool Equals(TeacherDto other)
            => Equals(other, this);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var objectToCompareWith = (TeacherDto)obj;

            return objectToCompareWith.Id == Id &&
                   objectToCompareWith.FirstName == FirstName &&
                   objectToCompareWith.LastName == LastName;
        }

        public override int GetHashCode()
           => Id + ((FirstName?.GetHashCode() * 17) + LastName?.GetHashCode()).GetValueOrDefault();
        public static bool operator ==(TeacherDto c1, TeacherDto c2)
            => c1.Equals(c2);
        public static bool operator !=(TeacherDto c1, TeacherDto c2)
            => !c1.Equals(c2);

        public void Deconstruct(out int id, out string firstName, out string lastName)
        {
            id = Id;
            firstName = FirstName;
            lastName = LastName;
        }

    }
}
