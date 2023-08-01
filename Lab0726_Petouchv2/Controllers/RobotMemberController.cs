using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab0726_Petouchv2.Models;

namespace Lab0726_Petouchv2.Controllers
{
    public class RobotMemberController : Controller
    {
        private readonly PetouchContext _context;

        public RobotMemberController(PetouchContext context)
        {
            _context = context;
        }

        // GET: RobotMember
        public async Task<IActionResult> Index()
        {
              return _context.Memberships != null ? 
                          View(await _context.Memberships.ToListAsync()) :
                          Problem("Entity set 'PetouchContext.Memberships'  is null.");
        }

        // GET: RobotMember/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Memberships == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // GET: RobotMember/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RobotMember/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Password,Email,Phone,UserName,TraceCount,AdoptCount,Sex,Birth,Address,NickName,NickNameV2")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membership);
        }

        // GET: RobotMember/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Memberships == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships.FindAsync(id);
            if (membership == null)
            {
                return NotFound();
            }
            return View(membership);
        }

        // POST: RobotMember/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Password,Email,Phone,UserName,TraceCount,AdoptCount,Sex,Birth,Address,NickName,NickNameV2")] Membership membership)
        {
            if (id != membership.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipExists(membership.UserId))
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
            return View(membership);
        }

        // GET: RobotMember/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Memberships == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // POST: RobotMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Memberships == null)
            {
                return Problem("Entity set 'PetouchContext.Memberships'  is null.");
            }
            var membership = await _context.Memberships.FindAsync(id);
            if (membership != null)
            {
                _context.Memberships.Remove(membership);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershipExists(int id)
        {
          return (_context.Memberships?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
