using Microsoft.AspNetCore.Mvc;

namespace bc.modules.account.Controllers
{
    [Route("accounts")]
    public class AccountsController: Controller
    {
        public AccountsController()
        {
            
        }

        [HttpGet("admin")]
        public ViewResult Admin()
        {
            return View();
        }
    }
}
