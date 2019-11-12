using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ClassTracker2.Dto
{
    public struct StudentDto
    {
        private StudentDto(int id, string firstName, string lastName,
            ImmutableList<CourseSectionDto> courseSections)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            this.courseSections = courseSections;
        }
        public StudentDto(int id, string firstName, string lastName,
            params CourseSectionDto[] courseSections)
            : this(id, firstName, lastName,
            ImmutableList<CourseSectionDto>.Empty.AddRange(courseSections))
        { }

        private readonly ImmutableList<CourseSectionDto> courseSections;
        public IEnumerable<CourseSectionDto> CourseSectionDtos => courseSections.Select(x => x);

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }


        public StudentDto With(int? id = null, string firstName = null, string lastName = null,
                    params CourseSectionDto[] courseSections)
            => new StudentDto(
                id ?? Id,
                firstName ?? FirstName,
                lastName ?? LastName,
                courseSections.Length == 0
                    ? this.courseSections
                    : ImmutableList<CourseSectionDto>.Empty.AddRange(courseSections)
                );

        public StudentDto WithResetcourseSections()
            => new StudentDto(
                Id,
                FirstName,
                LastName,
                ImmutableList<CourseSectionDto>.Empty
                );

        public bool Equals(StudentDto other)
            => Equals(other, this);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var objectToCompareWith = (StudentDto)obj;

            return objectToCompareWith.Id == Id &&
                   objectToCompareWith.FirstName == FirstName &&
                   objectToCompareWith.LastName == LastName;
        }

        public override int GetHashCode()
           => Id + ((FirstName?.GetHashCode() * 17) + LastName?.GetHashCode()).GetValueOrDefault();
        public static bool operator ==(StudentDto c1, StudentDto c2)
            => c1.Equals(c2);
        public static bool operator !=(StudentDto c1, StudentDto c2)
            => !c1.Equals(c2);

        public void Deconstruct(out int id, out string firstName, out string lastName)
        {
            id = Id;
            firstName = FirstName;
            lastName = LastName;
        }

    }
}
