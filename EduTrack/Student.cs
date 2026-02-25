using System;
using System.Collections.Generic;

namespace EduTrack
{
    public class Student : Person
    {
        public List<Enrollment> Enrollments { get; private set; }

       
        public int TotalClasses { get; private set; }
        public int AttendedClasses { get; private set; }

        public Student(int id, string name, string email)
            : base(id, name, email)
        {
            Enrollments = new List<Enrollment>();
            TotalClasses = 0;
            AttendedClasses = 0;
        }

        public void EnrollInCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");

            bool alreadyEnrolled = false;

            for (int i = 0; i < Enrollments.Count; i++)
            {
                if (Enrollments[i].Course.Code.Equals(course.Code, StringComparison.OrdinalIgnoreCase))
                {
                    alreadyEnrolled = true;
                    break;
                }
            }

            if (alreadyEnrolled)
                throw new InvalidOperationException($"Student is already enrolled in course: {course.Code}");

            Enrollments.Add(new Enrollment(this, course));
        }

        public Enrollment GetEnrollment(string courseCode)
        {
            if (string.IsNullOrWhiteSpace(courseCode))
                throw new ArgumentException("Course code cannot be empty.");

            for (int i = 0; i < Enrollments.Count; i++)
            {
                if (Enrollments[i].Course.Code.Equals(courseCode, StringComparison.OrdinalIgnoreCase))
                    return Enrollments[i];
            }

            return null;
        }

      
        public void MarkAttendance(bool isPresent)
        {
            TotalClasses++;

            if (isPresent)
                AttendedClasses++;
        }

        public double GetAttendancePercentage()
        {
            if (TotalClasses == 0) return 0;
            return (double)AttendedClasses / TotalClasses * 100.0;
        }

        public bool IsBelowAttendanceThreshold(double threshold = 75.0)
        {
            return GetAttendancePercentage() < threshold;
        }

        public override string GetBasicInfo()
        {
            return $"{base.GetBasicInfo()}, Attendance: {GetAttendancePercentage():0.##}%";
        }
    }
}