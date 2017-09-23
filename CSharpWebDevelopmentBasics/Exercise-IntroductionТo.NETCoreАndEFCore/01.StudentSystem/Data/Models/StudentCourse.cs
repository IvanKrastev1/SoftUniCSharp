namespace _01.StudentSystem.Data
{
    using System.Dynamic;

    public class StudentCourse
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

    }
}