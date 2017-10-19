using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bc.cores.models;
using bc.cores.repositories.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bc.services.accounts.api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ILogger _logger;
        private readonly UserRepository _userRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="userRepository">The user repository.</param>
        public AccountsController(ILogger<AccountsController> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Gets list of accounts.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Users found</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ApplicationUser>), 200)]
        public IActionResult Get([FromQuery] int? limit, [FromQuery] int? offset)
        {
            var users = _userRepository.All(limit, offset);
            return Ok(users);
        }

        /// <summary>
        /// Gets account by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <response code="200">User found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApplicationUser), 200)]
        public IActionResult Get(Guid id)
        {
            var user = _userRepository.Get(id);

            return Ok(user);
        }

        /// <summary>
        /// Create new account.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Update specific account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <response code="200">Success update the account</response>
        /// <response code="404">Could not find account</response>     
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        [Authorize]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Deletes account by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <response code="404">Could not find account</response>
        /// <response code="204">Deleted</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize]
        public void Delete(int id)
        {
        }
    }
}
