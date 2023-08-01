using Lab0726_Petouchv2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab0726_Petouchv2.Controllers
{
	public class UserController : Controller
	{
		private readonly PetouchContext _context;
		private readonly ILogger<UserController> _logger;
		public UserController(PetouchContext context, ILogger<UserController> logger)
		{
			_context = context;
			_logger = logger;
		}

		//建立接收前端登入post的資料模型，參數名稱要跟前端表單名稱相同才能對接
		public class MemberModel
		{
			public string? Email { get; set; }
			public string? Password { get; set; }
		}

		public IActionResult Login(string returnUrl)
		{
			
            //比對重複註冊，請直接登入。
            ViewBag.LoginDirectly = HttpContext.Session.GetString("LoginDirectly");

			//註冊成功，導到登入。
			//ViewBag.RegistrationSuccess = HttpContext.Session.GetString("RegistrationSuccess");\

			// 將 returnUrl 存入 TempData，讓 Post 登入動作方法可以取得
			TempData["ReturnUrl"] = returnUrl;

			return View();
		}

		//會員登入：登入處理機制
		[HttpPost]
		//把前端接收的表單存到這裡(formData)
		public IActionResult Login(MemberModel formData)
		{
			var formDatas = formData;

			//檢查使用者登入表單的資料→去跟資料庫做比對(這裡是比對信箱跟密碼)
			var checkEmail = _context.Memberships.Where(
				x => x.Email == formDatas.Email).FirstOrDefault();
			var checkPWD = checkEmail.Password == formDatas.Password;

			//開始進行身分驗證
			if (checkEmail != null && checkPWD == true)
			{

				//通過驗證然後建立可以"跨網頁"存取的session，這邊建立然後存取userID、UserName跟UserPassword
				HttpContext.Session.SetString("UserID", checkEmail.UserId.ToString());
				HttpContext.Session.SetString("UserEmail", checkEmail.Email.ToString());
				HttpContext.Session.SetString("UserName", checkEmail.UserName.ToString());
				HttpContext.Session.SetString("UserPassword", checkEmail.Password.ToString());

				ViewBag.user = HttpContext.Session.GetString("UserName");
				//若驗證沒問題，則進入指定頁面
				//之後改成進會員中心
				// 取得先前的頁面URL
				string? returnUrl = TempData["ReturnUrl"] as string;

				// 如果 returnUrl 不為空且是本站內的URL，則導回先前的頁面
				if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
				{
					return Redirect(returnUrl);
				}
				else
				{
					// 若 returnUrl 無效或為其他網站的URL，則導向指定頁面，這裡是 /Member/Index
					return RedirectToAction("Index", "Member");
				}
			}
			else
			{
				HttpContext.Session.SetString("WrongAns", "帳號或密碼有誤，請重新輸入");
				ViewBag.WrongWarning = HttpContext.Session.GetString("WrongAns");
				//ViewBag.WrongWarning = "帳號或密碼有誤，請重新輸入";
				return View();
			}
		}


		

		// GET: RobotMember/Create
		public IActionResult Register()
        {
            return View();
        }

        // POST: RobotMember/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserId,Password,Email,Phone,UserName,TraceCount,AdoptCount,Sex,Birth,Address,NickName,NickNameV2")] Membership membership)
        {
			var checkEmail = _context.Memberships.Where(x => x.Email == membership.Email).FirstOrDefault();
			var checkPWD = _context.Memberships.Where(x => x.Password == membership.Password).FirstOrDefault();
            //判斷是否使用過此帳號註冊

            if (checkEmail == null && checkPWD == null)
			{
                
                _context.Add(membership);
				await _context.SaveChangesAsync();
                HttpContext.Session.SetString("LoginDirectly", "註冊成功！請重新登入以繼續使用。");
				return Redirect("Login");
			}
			else {
				HttpContext.Session.SetString("LoginDirectly", "此帳號已註冊，請直接登入");
				return Redirect("Login");
			}
			//try
			//{
			//	if (ModelState.IsValid)
			//	{
			//		_context.Add(membership);
			//		await _context.SaveChangesAsync();

			//		// 註冊成功，輸出除錯訊息到輸出視窗
			//		System.Diagnostics.Debug.WriteLine("註冊成功！");

			//		return RedirectToAction("RegistrationSuccess");
			//	}
			//}
			//catch (Exception ex)
			//{
			//	// 發生例外，輸出例外訊息到輸出視窗
			//	System.Diagnostics.Debug.WriteLine("註冊失敗：" + ex.Message);
			//}

			//// 如果註冊失敗或有其他問題，返回註冊頁面
			//return View(membership);


			//if (ModelState.IsValid)
			//         {
			//             _context.Add(membership);
			//	var result = await _context.SaveChangesAsync();
			//	if (result > 0)
			//	{
			//		Console.WriteLine("資料儲存成功");
			//	}
			//	else
			//	{
			//		// 資料儲存失敗
			//		_logger.LogError("資料儲存失敗");
			//	}
			//	return RedirectToAction("RegistrationSuccess");
			//         }
			//return View(membership);
		}






		//public IActionResult RegistrationSuccess()
		//{
		//	HttpContext.Session.SetString("RegistrationSuccess", "註冊成功！請重新登入以繼續使用。");
		//	return RedirectToAction("Login", "User");
		//}

	}
}
