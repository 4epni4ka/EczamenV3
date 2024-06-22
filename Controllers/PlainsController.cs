using EczamenV3.Context;
using EczamenV3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EczamenV3.Controllers
{
    public class PlainsController:Controller
    {
        ///<summary>
        /// Список самолётов
        /// </summary>
        /// <remarks>Метод создан для вывода списка самолётов</remarks>
        /// <responses code="200">Список успешно выведен</responses>
        /// <responses code="500">Ошибка в подключении к базе данных</responses>
        [Route("ListPlains")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Plains>), 200)]
        [ProducesResponseType(500)]
        public ActionResult ListPlains()
        {
            try
            {
                    return Json(new PlainsContext().Plains);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        ///<summary>
        /// Создание самолёта
        /// </summary>
        /// <remarks>Метод для создания самолёта</remarks>
        /// <returns name="Plain">Модель самолёта</returns>
        /// <returns name="Token">Токен пользователя</returns>
        /// <responses code="200">Самолёт успешно добавлен</responses>
        /// <responses code="401">Токен не верен</responses>
        /// <responses code="500">Ошибка в подключении к базе данных</responses>
        [Route("AddPlain")]
        [ApiExplorerSettings(GroupName = "v2")]
        [HttpPost]
        [ProducesResponseType(typeof(Plains), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult AddPlain(Plains Plain, string Token)
        {
            try
            {
                UsersContext usersContext = new UsersContext();
                Users user = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                if (user != null)
                {
                    PlainsContext plainsContext = new PlainsContext();
                    Plains newPlain = new Plains();
                    newPlain.Name = Plain.Name;
                    newPlain.Number = Plain.Number;
                    newPlain.Description = Plain.Description;
                    plainsContext.Plains.Add(newPlain);
                    plainsContext.SaveChanges();

                    return Json(newPlain);
                }
                else return StatusCode(400);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        ///<summary>
        /// Изменение самолёта
        /// </summary>
        /// <remarks>Метод для изменения самолёта</remarks>
        /// <returns name="Plain">Модель самолёта</returns>
        /// <returns name="Token">Токен пользователя</returns>
        /// <responses code="200">Самолёт успешно добавлен</responses>
        /// <responses code="401">Токен не верен</responses>
        /// <responses code="402">Такой самолёт не найден</responses>
        /// <responses code="500">Ошибка в подключении к базе данных</responses>
        [Route("UpdatePlain")]
        [ApiExplorerSettings(GroupName = "v3")]
        [HttpPut]
        [ProducesResponseType(typeof(Plains), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(402)]
        [ProducesResponseType(500)]
        public ActionResult UpdatePlain(Plains Plain, string Token)
        {
            try
            {
                UsersContext usersContext = new UsersContext();
                Users user = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                if (user != null)
                {
                    PlainsContext plainsContext = new PlainsContext();
                    Plains updatePlain = plainsContext.Plains.FirstOrDefault(x => x.Id == Plain.Id);
                    if (updatePlain != null)
                    {
                        updatePlain.Number = Plain.Number;
                        updatePlain.Name = Plain.Name;
                        updatePlain.Description = Plain.Description;
                        plainsContext.Plains.Update(updatePlain);
                        plainsContext.SaveChanges();
                        return Json(updatePlain);
                    }
                    else return StatusCode(402);
                }
                else return StatusCode(400);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        ///<summary>
        /// Удаление самолёта
        /// </summary>
        /// <remarks>Метод для удаления самолёта</remarks>
        /// <returns name="Id">Идентификатор самолёта</returns>
        /// <returns name="Token">Токен пользователя</returns>
        /// <responses code="200">Самолёт успешно удалён</responses>
        /// <responses code="401">Токен не верен</responses>
        /// <responses code="402">Такой самолёт не найден</responses>
        /// <responses code="500">Ошибка в подключении к базе данных</responses>
        [Route("RemovePlain")]
        [ApiExplorerSettings(GroupName = "v4")]
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(402)]
        [ProducesResponseType(500)]
        public ActionResult RemovePlain(int Id, string Token)
        {
            try
            {
                UsersContext usersContext = new UsersContext();
                Users user = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                if (user != null)
                {
                    PlainsContext plainsContext = new PlainsContext();
                    Plains removePlain = plainsContext.Plains.FirstOrDefault(x => x.Id == Id);
                    if (removePlain != null)
                    {
                        plainsContext.Plains.Remove(removePlain);
                        plainsContext.SaveChanges();
                        return StatusCode(200);
                    }
                    else return StatusCode(402);
                }
                else return StatusCode(401);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
