using Lab0726_Petouchv2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Metrics;
using System.Linq;

namespace Lab0726_Petouchv2.Controllers
{
    public class MemberController : Controller
    {
        private readonly PetouchContext _context;

        public MemberController(PetouchContext context)
        {
            _context = context;
        }
		// GET: RobotMember
		public async Task<IActionResult> Index()
		{
            //ViewBag.user = HttpContext.Session.GetString("UserName");
			var MemberID = Convert.ToInt32(HttpContext.Session.GetString("UserID")) ;
            //ViewBag.apple =_context.Memberships.Where(x=>x.UserId == MemberID).Select(x=>x.UserName).FirstOrDefault();
            ViewBag.NickName = _context.Memberships.Where(x=>x.UserId == MemberID).Select(x=>x.NickNameV2).FirstOrDefault();

            return _context.Memberships != null ?
						View(await _context.Memberships.Where(x=>x.UserId == MemberID).ToListAsync()) :
						Problem("Entity set 'PetouchContext.Memberships' is null.");
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
                return Redirect("/Member/Index");
            }
            return View(membership);
        }



        public IActionResult selfAdopt(Adoption adoption)
        {
            var MemberID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            ViewBag.PetName = _context.Adoptions.Select(x => x.PetName).FirstOrDefault();
            ViewBag.kjj = MemberID;

            var flower = _context.Adoptions
                .GroupJoin(_context.AdoptCaseStatuses, x => x.AdId, y => y.AdId,
                (adoption, statuses) => new {
                    Adoption = adoption,
                    CaseStatuses = statuses.ToList()
                }).Where(x => x.CaseStatuses.Any(cs => cs.UserId == MemberID)).ToList();

            ViewBag.selfAdoption = flower;
            return View();
            //var MemberID = Convert.ToInt32(HttpContext.Session.GetString("UserID")) ;
            //         ViewBag.PetName = _context.Adoptions.Select(x => x.PetName).FirstOrDefault();
            //         ViewBag.kjj = MemberID;

            //var flower = _context.Adoptions.Where(x => x.MemberId == MemberID).ToList();
            //         ViewBag.selfAdoption = flower;
            //         return View();

        }
		[HttpPost]
		public IActionResult UnfollowAdoption(int adID)
		{
			
				// 取得目前登入使用者的ID
				var userId = HttpContext.Session.GetString("UserID");

				// 根據adID和使用者ID找到對應的追蹤狀態記錄
				var adoptStatus = _context.AdoptCaseStatuses.Where(a => a.AdId == adID && a.UserId.Equals(userId)).FirstOrDefault();

				if (adoptStatus != null)
				{
					// 將追蹤狀態更新為false
					adoptStatus.Collection = false;
					_context.SaveChanges();
				}

				return Ok(); // 返回成功的回應
			
		}

		public IActionResult selfLost(PetLost petLost)
        {
            var MemberID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            ViewBag.PetName = _context.PetLosts.Select(x => x.PetName).FirstOrDefault();
            ViewBag.kjj = MemberID;

            var bee = _context.PetLosts.Where(x => x.UserId == MemberID).ToList();
            ViewBag.selfFind = bee;
            return View();
        }















        //====不會用到====
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

		private bool MembershipExists(int userId)
		{
			throw new NotImplementedException();
		}
	}
}

