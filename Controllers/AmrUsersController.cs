using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jed_amr.Data;
using jed_amr.Models;
using Microsoft.AspNetCore.Identity;

namespace jed_amr.Controllers
{
    public class AmrUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AmrUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public AmrUsersController(ApplicationDbContext context, UserManager<AmrUser> userManager/*, RoleManager<IdentityRole> roleManager*/)
        {
            _context = context;
            _userManager = userManager;
            //_roleManager = roleManager;
        }

        // GET: AmrUsers
        public async Task<IActionResult> Index()
        {
            if (_userManager.Users == null)
            {
                return NotFound();
            }

            return View(await _userManager.Users.ToListAsync());
        }

        // GET: AmrUsers/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amrUser = await _userManager.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amrUser == null)
            {
                return NotFound();
            }

            return View(amrUser);
        }

        // GET: AmrUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AmrUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,FirstName,LastName")] AmrUser amrUser)
        {
            if (ModelState.IsValid)
            {
                var password = new PasswordGenerator.Password(6).IncludeNumeric()
                .IncludeLowercase().IncludeUppercase()
                .IncludeSpecial("!@#$%&");

                amrUser.Recovery = password.Next();

                var result = await _userManager.CreateAsync(amrUser, amrUser.Recovery);

                return RedirectToAction(nameof(Index));
            }
            return View(amrUser);
        }

        // GET: AmrUsers/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amrUser = await _userManager.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amrUser == null)
            {
                return NotFound();
            }
            return View(amrUser);
        }

        // POST: AmrUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName")] AmrUser amrUser)
        {
            if (id != amrUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userManager.UpdateAsync(amrUser);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmrUserExists(amrUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(amrUser);
        }

        // GET: AmrUsers/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amrUser = await _userManager.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amrUser == null)
            {
                return NotFound();
            }

            return View(amrUser);
        }

        // POST: AmrUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var amrUser = await _userManager.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amrUser != null)
            {
                await _userManager.DeleteAsync(amrUser);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AmrUserExists(string id)
        {
            return _userManager.Users.Any(e => e.Id == id);
        }
    }
}
