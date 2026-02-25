using System;

namespace EduTrack
{
    public class Enrollment
    {
        public Student Student { get; private set; }
        public Course Course { get; private set; }

        public double Marks { get; private set; }
        public string Grade { get; private set; }

        public Enrollment(Student student, Course course)
        {
            Student = student ?? throw new ArgumentNullException(nameof(student));
            Course = course ?? throw new ArgumentNullException(nameof(course));

            Marks = 0;
            Grade = "N/A";
        }

        public void AssignMarks(double marks)
        {
            if (marks < 0 || marks > 100)
                throw new ArgumentException("Marks must be between 0 and 100.");

            Marks = marks;
            Grade = CalculateGrade(marks);
        }

        private string CalculateGrade(double marks)
        {
            if (marks >= 85) return "A";
            if (marks >= 70) return "B";
            if (marks >= 50) return "C";
            return "F";
        }

        public string GetEnrollmentInfo()
        {
            return $"Student: {Student.Name}, Course: {Course.Title}, Marks: {Marks}, Grade: {Grade}";
        }
    }
}