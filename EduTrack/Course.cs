using System;
using System.Collections.Generic;

namespace EduTrack
{
    public class Course
    {
        public string Code { get; private set; }
        public string Title { get; private set; }

        public Teacher AssignedTeacher { get; private set; }

        public List<Enrollment> Enrollments { get; private set; }

        public Course(string code, string title)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Course code cannot be empty.");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Course title cannot be empty.");

            Code = code;
            Title = title;
            Enrollments = new List<Enrollment>();
        }

        public void AssignTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            AssignedTeacher = teacher;
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            if (enrollment == null)
                throw new ArgumentNullException(nameof(enrollment));

            Enrollments.Add(enrollment);
        }

        public double GetAverageMarks()
        {
            if (Enrollments.Count == 0)
                return 0;

            double total = 0;

            foreach (var enrollment in Enrollments)
            {
                total += enrollment.Marks;
            }

            return total / Enrollments.Count;
        }

        public string GetCourseInfo()
        {
            return $"Code: {Code}, Title: {Title}, Teacher: {AssignedTeacher?.Name ?? "Not Assigned"}";
        }
    }
}