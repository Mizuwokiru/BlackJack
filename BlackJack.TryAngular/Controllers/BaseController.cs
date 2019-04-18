using Microsoft.AspNetCore.Mvc;
using System;

namespace BlackJack.TryAngular.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult StatusResult<T>(Func<T> func)
        {
            try
            {
                T result = func();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        protected IActionResult StatusResult(Action action)
        {
            try
            {
                action();
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}