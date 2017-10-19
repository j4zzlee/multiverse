using System.Linq;
using bc.cores.models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace bc.cores.repositories.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>
    {
        public UserRepository(IConfiguration conf) : base(conf)
        {
        }

        public ApplicationUser GetByEmail(string email)
        {
            var tableName = GetTableName();
            var sql = $"SELECT * FROM [{tableName}] WHERE Email = @Email";
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
