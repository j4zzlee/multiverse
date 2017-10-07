using bc.cores.repositories.Models.Exams;
using Microsoft.Extensions.Configuration;

namespace bc.cores.repositories.Repositories
{
    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository(IConfiguration conf) : base(conf)
        {
        }
    }
}