using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ClassTracker2.Dto
{
    public struct CourseSectionDto
    {
        public CourseSectionDto(int id, int courseId, int semesterId, int studentId)
        {
            Id = id;
            CourseId = courseId;
            SemesterId = semesterId;
            StudentId = studentId;
        }

        public int Id { get; }
        public int CourseId { get; }
        public int SemesterId { get; }
        public int StudentId { get; }

        public CourseSectionDto With(int? id = null, int? courseId = null,
            int? semesterId = null, int? studentId = null)
            => new CourseSectionDto(
                id ?? Id,
                courseId ?? CourseId,
                semesterId ?? SemesterId,
                studentId ?? StudentId
                );

        public bool Equals(CourseSectionDto other)
            => Equals(other, this);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var objectToCompareWith = (CourseSectionDto)obj;

            return objectToCompareWith.Id == Id &&
                   objectToCompareWith.CourseId == CourseId &&
                   objectToCompareWith.SemesterId == SemesterId &&
                   objectToCompareWith.StudentId == StudentId;
        }

        public override int GetHashCode()
           => Id + (CourseId * 17) + SemesterId + StudentId;
        public static bool operator ==(CourseSectionDto c1, CourseSectionDto c2)
            => c1.Equals(c2);
        public static bool operator !=(CourseSectionDto c1, CourseSectionDto c2)
            => !c1.Equals(c2);

        public void Deconstruct(out int id, out int courseId, out int semesterId, out int studentId)
        {
            id = Id;
            courseId = CourseId;
            semesterId = SemesterId;
            studentId = StudentId;
        }

    }
}
