using bc.cores.models.Exams;
using Microsoft.Extensions.Configuration;

namespace bc.cores.repositories.Repositories
{
    public class QuestionRepository : BaseRepository<Question>
    {
        public QuestionRepository(IConfiguration conf) : base(conf)
        {
        }
    }
}