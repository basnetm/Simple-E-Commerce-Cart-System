using System;
using System.Collections.Generic;

namespace EduTrack
{
    public class Teacher : Person
    {
        public List<Course> AssignedCourses { get; private set; }

        public Teacher(int id, string name, string email)
            : base(id, name, email)
        {
            AssignedCourses = new List<Course>();
        }

        public void AssignCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");

            // Prevent duplicate assignment
            for (int i = 0; i < AssignedCourses.Count; i++)
            {
                if (AssignedCourses[i].Code.Equals(course.Code, StringComparison.OrdinalIgnoreCase))
                    return;
            }

            AssignedCourses.Add(course);
            course.AssignTeacher(this);
        }

        public void MarkStudentAttendance(Student student, bool isPresent)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");

            student.MarkAttendance(isPresent);
        }

        public void EnterMarks(Student student, string courseCode, double marks)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");

            if (string.IsNullOrWhiteSpace(courseCode))
                throw new ArgumentException("Course code cannot be empty.");

            // Check if teacher is assigned to that course
            bool teachesCourse = false;
            for (int i = 0; i < AssignedCourses.Count; i++)
            {
                if (AssignedCourses[i].Code.Equals(courseCode, StringComparison.OrdinalIgnoreCase))
                {
                    teachesCourse = true;
                    break;
                }
            }

            if (!teachesCourse)
                throw new InvalidOperationException("You are not assigned to this course.");

            // Check student's enrollment
            Enrollment enrollment = student.GetEnrollment(courseCode);
            if (enrollment == null)
                throw new InvalidOperationException("Student is not enrolled in this course.");

            enrollment.AssignMarks(marks);
        }

        public string GetAssignedCoursesInfo()
        {
            if (AssignedCourses.Count == 0)
                return "No courses assigned.";

            string result = "Assigned Courses:\n";
            for (int i = 0; i < AssignedCourses.Count; i++)
            {
                result += $"- {AssignedCourses[i].Code}: {AssignedCourses[i].Title}\n";
            }

            return result;
        }
    }
}