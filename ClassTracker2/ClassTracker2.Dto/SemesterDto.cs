using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ClassTracker2.Dto
{
    public struct SemesterDto
    {
        private SemesterDto(int id, DateTime startDate, DateTime endDate,
            ImmutableList<CourseSectionDto> courseSections)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            this.courseSections = courseSections;
        }
        public SemesterDto(int id, DateTime startDate, DateTime endDate,
            params CourseSectionDto[] courseSections)
            : this(id, startDate, endDate,
            ImmutableList<CourseSectionDto>.Empty.AddRange(courseSections))
        { }

        private readonly ImmutableList<CourseSectionDto> courseSections;
        public IEnumerable<CourseSectionDto> CourseSectionDtos => courseSections.Select(x => x);

        public int Id { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public SemesterDto With(int? id = null, DateTime? startDate = null,
                    DateTime? endDate = null,
                    params CourseSectionDto[] courseSections)
            => new SemesterDto(
                id ?? Id,
                startDate ?? StartDate,
                endDate ?? EndDate,
                courseSections.Length == 0
                    ? this.courseSections
                    : ImmutableList<CourseSectionDto>.Empty.AddRange(courseSections)
                );

        public SemesterDto WithResetcourseSections()
            => new SemesterDto(
                Id,
                StartDate,
                EndDate,
                ImmutableList<CourseSectionDto>.Empty
                );

        public bool Equals(SemesterDto other)
            => Equals(other, this);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var objectToCompareWith = (SemesterDto)obj;

            return objectToCompareWith.Id == Id &&
                   objectToCompareWith.StartDate == StartDate &&
                   objectToCompareWith.EndDate == EndDate;
        }

        public override int GetHashCode()
           => Id + (StartDate.GetHashCode() * 17) + EndDate.GetHashCode();
        public static bool operator ==(SemesterDto c1, SemesterDto c2)
            => c1.Equals(c2);
        public static bool operator !=(SemesterDto c1, SemesterDto c2)
            => !c1.Equals(c2);

        public void Deconstruct(out int id, out DateTime? startDate,
                    out DateTime? endDate)
        {
            id = Id;
            startDate = StartDate;
            endDate = EndDate;
        }

    }
}
