using Bogus;

namespace GraphqlDemo.API.Schema
{
    public class Query
    {
        public IEnumerable<CourseType> GetCourses()
        {
            Faker<InstructorType> instructorFaker = new Faker<InstructorType>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Salary, f => f.Random.Double(0, 100000));

            Faker<StudentType> studentFaker = new Faker<StudentType>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.GPA, f => f.Random.Double(1.4));

            Faker<CourseType> courseFaker = new Faker<CourseType>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Name.JobArea())
                .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
                .RuleFor(c => c.Instructor, f => instructorFaker.Generate())
                .RuleFor(c => c.Students, f => studentFaker.Generate(3));

            List<CourseType> courses = courseFaker.Generate(5);
            return courses;
        }

        public string Example => "Test Query By Amine !";
    }
}
