using Microsoft.AspNetCore.Mvc;
using UserAdministration.Application.Models.User;
using UserAdministration.Application.Services;

namespace UserAdministration.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: User
        public IActionResult Index()
        {
            return View();
        }

        // GET: User/UserTable
        public async Task<IActionResult> UserTable()
        {
            return View(await _userService.GetUsers());
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public async Task<IActionResult> Create(UserEditDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userService.AddUser(user);

                    return Ok(new { message = "Success." });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            ViewBag.UserId = id;

            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UserEditDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userService.EditUser(id, user);

                    return Ok(new { message = "Success." });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            ViewBag.UserId = id;

            return View(user);
        }

        // DELETE: User/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUser(id);

            return Ok(new { message = "Success." });
        }

        // GET: User/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            try
            {
                user.Browser = Request.Headers.UserAgent.ToString();
                ModelState.ClearValidationState(nameof(user.Browser));

                if (TryValidateModel(user, nameof(user.Browser)) && ModelState.IsValid)
                {
                    await _userService.LoginUser(user);

                    return Ok(new { message = "Success." });

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(user);
        }
    }
}
