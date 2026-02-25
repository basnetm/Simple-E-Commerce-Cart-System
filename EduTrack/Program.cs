using EduTrack;
using System;
using System.Collections.Generic;


  
       
            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();
            List<Course> courses = new List<Course>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== EduTrack (Mini ERP) ======");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Teacher");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                    AdminMenu(students, teachers, courses);
                else if (choice == "2")
                    TeacherMenu(students, teachers, courses);
                else if (choice == "3")
                    break;
                else
                {
                    Console.WriteLine("Invalid option. Press any key...");
                    Console.ReadKey();
                }
            }
        

        // -------------------- ADMIN --------------------
        static void AdminMenu(List<Student> students, List<Teacher> teachers, List<Course> courses)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== Admin Menu ======");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Teacher");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Assign Teacher to Course");
                Console.WriteLine("6. View Students");
                Console.WriteLine("7. View Teachers");
                Console.WriteLine("8. View Courses");
                Console.WriteLine("9. Back");
                Console.Write("Select option: ");
                string choice = Console.ReadLine();

                try
                {
                    if (choice == "1") AddStudent(students);
                    else if (choice == "2") AddTeacher(teachers);
                    else if (choice == "3") AddCourse(courses);
                    else if (choice == "4") EnrollStudent(students, courses);
                    else if (choice == "5") AssignTeacherToCourse(teachers, courses);
                    else if (choice == "6") ViewStudents(students);
                    else if (choice == "7") ViewTeachers(teachers);
                    else if (choice == "8") ViewCourses(courses);
                    else if (choice == "9") return;
                    else
                    {
                        Console.WriteLine("Invalid option.");
                        Pause();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Pause();
                }
            }
        }

        static void AddStudent(List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("---- Add Student ----");

            int id = ReadInt("Enter Student ID: ");
            string name = ReadString("Enter Student Name: ");
            string email = ReadString("Enter Student Email: ");

            // Prevent duplicate IDs
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                    throw new InvalidOperationException("Student ID already exists.");
            }

            students.Add(new Student(id, name, email));
            Console.WriteLine("Student added successfully.");
            Pause();
        }

        static void AddTeacher(List<Teacher> teachers)
        {
            Console.Clear();
            Console.WriteLine("---- Add Teacher ----");

            int id = ReadInt("Enter Teacher ID: ");
            string name = ReadString("Enter Teacher Name: ");
            string email = ReadString("Enter Teacher Email: ");

            // Prevent duplicate IDs
            for (int i = 0; i < teachers.Count; i++)
            {
                if (teachers[i].Id == id)
                    throw new InvalidOperationException("Teacher ID already exists.");
            }

            teachers.Add(new Teacher(id, name, email));
            Console.WriteLine("Teacher added successfully.");
            Pause();
        }

        static void AddCourse(List<Course> courses)
        {
            Console.Clear();
            Console.WriteLine("---- Add Course ----");

            string code = ReadString("Enter Course Code (e.g., CS101): ");
            string title = ReadString("Enter Course Title: ");

            // Prevent duplicate course codes
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Code.Equals(code, StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("Course code already exists.");
            }

            courses.Add(new Course(code, title));
            Console.WriteLine("Course added successfully.");
            Pause();
        }

        static void EnrollStudent(List<Student> students, List<Course> courses)
        {
            Console.Clear();
            Console.WriteLine("---- Enroll Student ----");

            Student student = SelectStudent(students);
            Course course = SelectCourse(courses);

            // Student creates Enrollment
            student.EnrollInCourse(course);

            // Keep Course enrollment list consistent:
            Enrollment enrollment = student.GetEnrollment(course.Code);
            course.AddEnrollment(enrollment);

            Console.WriteLine("Student enrolled successfully.");
            Pause();
        }

        static void AssignTeacherToCourse(List<Teacher> teachers, List<Course> courses)
        {
            Console.Clear();
            Console.WriteLine("---- Assign Teacher to Course ----");

            Teacher teacher = SelectTeacher(teachers);
            Course course = SelectCourse(courses);

            teacher.AssignCourse(course);

            Console.WriteLine($"Teacher {teacher.Name} assigned to {course.Code}.");
            Pause();
        }

        static void ViewStudents(List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("---- Students ----");

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                Pause();
                return;
            }

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].GetBasicInfo());
            }

            Pause();
        }

        static void ViewTeachers(List<Teacher> teachers)
        {
            Console.Clear();
            Console.WriteLine("---- Teachers ----");

            if (teachers.Count == 0)
            {
                Console.WriteLine("No teachers found.");
                Pause();
                return;
            }

            for (int i = 0; i < teachers.Count; i++)
            {
                Console.WriteLine(teachers[i].GetBasicInfo());
            }

            Pause();
        }

        static void ViewCourses(List<Course> courses)
        {
            Console.Clear();
            Console.WriteLine("---- Courses ----");

            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found.");
                Pause();
                return;
            }

            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine(courses[i].GetCourseInfo());
            }

            Pause();
        }

        // -------------------- TEACHER --------------------
        static void TeacherMenu(List<Student> students, List<Teacher> teachers, List<Course> courses)
        {
            if (teachers.Count == 0)
            {
                Console.WriteLine("No teachers available. Admin must add teachers first.");
                Pause();
                return;
            }

            Teacher teacher = SelectTeacher(teachers);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"====== Teacher Menu ({teacher.Name}) ======");
                Console.WriteLine("1. View My Courses");
                Console.WriteLine("2. Mark Attendance");
                Console.WriteLine("3. Enter Marks");
                Console.WriteLine("4. Generate Report Card");
                Console.WriteLine("5. Back");
                Console.Write("Select option: ");
                string choice = Console.ReadLine();

                try
                {
                    if (choice == "1")
                    {
                        Console.Clear();
                        Console.WriteLine(teacher.GetAssignedCoursesInfo());
                        Pause();
                    }
                    else if (choice == "2")
                        TeacherMarkAttendance(teacher, students);
                    else if (choice == "3")
                        TeacherEnterMarks(teacher, students);
                    else if (choice == "4")
                        GenerateReportCard(students);
                    else if (choice == "5")
                        return;
                    else
                    {
                        Console.WriteLine("Invalid option.");
                        Pause();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Pause();
                }
            }
        }

        static void TeacherMarkAttendance(Teacher teacher, List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("---- Mark Attendance ----");

            Student student = SelectStudent(students);

            Console.Write("Present? (Y/N): ");
            string input = Console.ReadLine();
            bool isPresent = input != null && input.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase);

            teacher.MarkStudentAttendance(student, isPresent);

            Console.WriteLine("Attendance marked.");
            Console.WriteLine($"Attendance now: {student.GetAttendancePercentage():0.##}%");
            Pause();
        }

        static void TeacherEnterMarks(Teacher teacher, List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("---- Enter Marks ----");

            if (teacher.AssignedCourses.Count == 0)
                throw new InvalidOperationException("You have no assigned courses. Admin must assign courses first.");

            Student student = SelectStudent(students);

            Console.WriteLine("Select Course Code from your assigned courses:");
            for (int i = 0; i < teacher.AssignedCourses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {teacher.AssignedCourses[i].Code} - {teacher.AssignedCourses[i].Title}");
            }

            int courseIndex = ReadInt("Choose course number: ") - 1;
            if (courseIndex < 0 || courseIndex >= teacher.AssignedCourses.Count)
                throw new ArgumentException("Invalid course selection.");

            string courseCode = teacher.AssignedCourses[courseIndex].Code;
            double marks = ReadDouble("Enter marks (0-100): ");

            teacher.EnterMarks(student, courseCode, marks);

            Console.WriteLine("Marks entered successfully.");
            Pause();
        }

        static void GenerateReportCard(List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("---- Generate Report Card ----");

            Student student = SelectStudent(students);

            Console.WriteLine("===== REPORT CARD =====");
            Console.WriteLine(student.GetBasicInfo());
            Console.WriteLine();

            if (student.Enrollments.Count == 0)
            {
                Console.WriteLine("No enrollments found.");
            }
            else
            {
                for (int i = 0; i < student.Enrollments.Count; i++)
                {
                    Enrollment e = student.Enrollments[i];
                    Console.WriteLine($"Course: {e.Course.Code} - {e.Course.Title} | Marks: {e.Marks} | Grade: {e.Grade}");
                }
            }

            double attendance = student.GetAttendancePercentage();
            Console.WriteLine();
            Console.WriteLine($"Attendance: {attendance:0.##}%");

            if (student.IsBelowAttendanceThreshold())
            {
                Console.WriteLine("⚠ WARNING: Attendance below 75%.");
            }
            else
            {
                Console.WriteLine("Status: Good Standing");
            }

            Console.WriteLine("=======================");
            Pause();
        }

        // -------------------- SELECT HELPERS --------------------
        static Student SelectStudent(List<Student> students)
        {
            if (students.Count == 0)
                throw new InvalidOperationException("No students available. Admin must add students first.");

            Console.WriteLine("Select Student:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].Id} - {students[i].Name}");
            }

            int index = ReadInt("Choose student number: ") - 1;
            if (index < 0 || index >= students.Count)
                throw new ArgumentException("Invalid student selection.");

            return students[index];
        }

        static Teacher SelectTeacher(List<Teacher> teachers)
        {
            if (teachers.Count == 0)
                throw new InvalidOperationException("No teachers available. Admin must add teachers first.");

            Console.WriteLine("Select Teacher:");
            for (int i = 0; i < teachers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {teachers[i].Id} - {teachers[i].Name}");
            }

            int index = ReadInt("Choose teacher number: ") - 1;
            if (index < 0 || index >= teachers.Count)
                throw new ArgumentException("Invalid teacher selection.");

            return teachers[index];
        }

        static Course SelectCourse(List<Course> courses)
        {
            if (courses.Count == 0)
                throw new InvalidOperationException("No courses available. Admin must add courses first.");

            Console.WriteLine("Select Course:");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {courses[i].Code} - {courses[i].Title}");
            }

            int index = ReadInt("Choose course number: ") - 1;
            if (index < 0 || index >= courses.Count)
                throw new ArgumentException("Invalid course selection.");

            return courses[index];
        }

        // -------------------- INPUT HELPERS --------------------
        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                int value;
                if (int.TryParse(input, out value))
                    return value;

                Console.WriteLine("Please enter a valid number.");
            }
        }

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                double value;
                if (double.TryParse(input, out value))
                    return value;

                Console.WriteLine("Please enter a valid number.");
            }
        }

        static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("Input cannot be empty.");
            }
        }

        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
