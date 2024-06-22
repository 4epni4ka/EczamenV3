using EczamenV3.Context;
using EczamenV3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczamenV3.Controllers
{
    public class UsersController:Controller
    {
        ///<summary>
        /// Авторизация пользователя
        /// </summary>
        /// <remarks>Метод создан для авторизации пользователя</remarks>
        /// <returns name="Login">Логин пользователя</returns>
        /// <returns name="Password">Пароль пользователя</returns>
        /// <responses code="200">Авторизация успешна</responses>
        /// <responses code="400">Пользователь не найден</responses>
        /// <responses code="500">Ошибка в подключении к базе данных</responses>
        [Route("SingIn")]
        [ApiExplorerSettings(GroupName ="v2")]
        [HttpPost]
        public ActionResult SingIn(string Login, string Password)
        {
            try
            {
                UsersContext usersContext = new UsersContext();
                Users user = usersContext.Users.FirstOrDefault(x => x.Login == Login && x.Password == Password);
                if (user != null)
                {
                    user.Token = GetToken();
                    usersContext.SaveChanges();
                    return Json(User);
                }
                else return StatusCode(400);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        private string text = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
        private string GetToken()
        {
            StringBuilder s = new StringBuilder();
            Random rnd = new Random();
            for(int i = 0; i < 10; i++)
            {
                s.Append(text[rnd.Next(text.Length)]);
            }
            return s.ToString();
        }
    }
}
