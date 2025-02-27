using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.Model;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace WarehouseAccountingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthorizationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public UserAuthorizationController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        //V1

        [HttpPost("AuthorizationV1")]
        public async Task<IActionResult> AuthorizationV1LoginPassword(string login, string password, string keyWord)
        {
            Console.WriteLine($"Received request: login={login}, password={password}, keyWord={keyWord}");


        var userData = await (
                from employee in _context.Employee
                join authorizationEmployee in _context.AuthorizationEmployee on employee.IdEmployee equals authorizationEmployee.IdEmployee
                where
                (authorizationEmployee.Password == password && authorizationEmployee.Login == login && authorizationEmployee.KeyWord == keyWord)
                select employee
                ).FirstOrDefaultAsync();

            if (userData == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(userData);
            }
        }

        // V2

        [HttpPost("AuthorizationV2_Send_Code")]
        public async Task<IActionResult> AuthorizationV2SendCode(string email)
        {
            var userData = await (
                from employee in _context.Employee
                join authorizationEmployee in _context.AuthorizationEmployee on employee.IdEmployee equals authorizationEmployee.IdEmployee
                where
                (employee.Email == email)
                select new
                { 
                    employee.IdEmployee,
                    employee.Surname, 
                    employee.Name, 
                    employee.Patronymic,
                    employee.Phone, 
                    employee.Email,
                    authorizationEmployee.Login,
                    authorizationEmployee.Password,
                    authorizationEmployee.KeyWord
                }
                ).FirstOrDefaultAsync();
            if (userData == null)
            {
                return NotFound();
            }

            var authorizationEmployeeData = _context.AuthorizationEmployee.FirstOrDefaultAsync(x=>x.IdEmployee == userData.IdEmployee);
            var verificationCode = new Random().Next(1000, 9999).ToString();
            authorizationEmployeeData.Result.KeyWord = verificationCode;
            await _context.SaveChangesAsync();

            await _emailSender.SendEmailAsync(userData.Email, "Код верефикации", $"Ваш код верефикации {verificationCode}");

            return Ok(new { message = "Код верификации отправлен" });
        }

        [HttpPost("AuthorizationV2_Verify_Code")]
        public async Task<IActionResult> AuthorizationV2VerifyCode(string email, string verificationCode)
        {
            var userData = await (
                from employee in _context.Employee
                join authorizationEmployee in _context.AuthorizationEmployee on employee.IdEmployee equals authorizationEmployee.IdEmployee
                where
                (employee.Email == email && authorizationEmployee.KeyWord == verificationCode)
                select employee
                ).FirstOrDefaultAsync();
            if (userData == null)
            {
                return Unauthorized();
            }

            return Ok(userData);
        }
    }
}
