using bc.cores.models.Exams;
using Microsoft.Extensions.Configuration;

namespace bc.cores.repositories.Repositories
{
    public class ExamRepository: BaseRepository<Exam>
    {
        public ExamRepository(IConfiguration conf) : base(conf)
        {
        }
    }
}
