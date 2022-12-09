using Bogus;
using DevopsAPI.Data.Entities;

namespace DevopsAPI.Data.Seeders
{
    public class CategorySeeder
    {
       public List<Category> Categories { get; set; }
        public CategorySeeder()
        {
            var ids = 1;
            var titles = new[] { "Docker", "Kubernetes", "Web API", "Database", "JavaScript", "ReactJS", "Angular", "Java", "NetworkAdmin", "Python", "OOP", "Microservices" };
            var categoryFaker = new Faker<Category>()
                .RuleFor(c=>c.Id, f=>ids++)
                .RuleFor(c => c.Title,  (f, c) => f.PickRandom(titles))
                .RuleFor(c => c.IsActive, f => true);

            Categories = categoryFaker.Generate(10);
        }
    }
}
