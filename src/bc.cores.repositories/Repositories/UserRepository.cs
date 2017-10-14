using System.Linq;
using bc.cores.models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace bc.cores.repositories.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>
    {
        private const string TableName = "AspNetUsers";
        public UserRepository(IConfiguration conf) : base(conf)
        {
        }

        public ApplicationUser GetByEmail(string email)
        {
            var sql = $"SELECT * FROM [{TableName}] WHERE Email = @Email";
            return Connection
                .Query<ApplicationUser>(
                    sql,
                    param: new
                    {
                        Email = email
                    },
                    transaction: Transaction)
                .FirstOrDefault();
        }
    }
}
