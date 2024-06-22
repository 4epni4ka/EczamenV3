using EczamenV3.Context;
using EczamenV3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EczamenV3.Controllers
{
    public class ReisesController:Controller
    {
        ///<summary>
        /// Список рейсов
        /// </summary>
        /// <remarks>Метод создан для вывода списка рейсов</remarks>
        /// <responses code="200">Список успешно выведен</responses>
        /// <responses code="500">Ошибка в подключении к базе данных</responses>
        [Route("ListReises")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Reises>), 200)]
        [ProducesResponseType(500)]
        public ActionResult ListReises()
        {
            try
            {
                return Json(new ReisesContext().Reises);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        ///<summary>
        /// Создание рейса
        /// </summary>
        /// <remarks>Метод для создания рейса</remarks>
        /// <returns name="Plain">Модель рейса</returns>
        /// <returns name="Token">Токен пользователя</returns>
        /// <responses code="200">Рейс успешно добавлен</responses>
        /// <responses code="400">Самолёт не найден</responses>
        /// <responses code="401">Токен не верен</responses>
        /// <responses code="500">Ошибка в подключении к базе данных</responses>
        [Route("AddReises")]
        [ApiExplorerSettings(GroupName = "v2")]
        [HttpPost]
        [ProducesResponseType(typeof(Reises), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult AddReises(Reises Reises, string Token)
        {
            try
            {
                UsersContext usersContext = new UsersContext();
                Users user = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                if (user != null)
                {
                    ReisesContext reisesContext = new ReisesContext();
                    Reises newReises = new Reises();
                    newReises.TimeVilet = Reises.TimeVilet;
                    newReises.TimePrilet = Reises.TimePrilet;
                    newReises.TimeOnFly = Reises.TimeOnFly;
                    newReises.DateVilet = Reises.DateVilet;
                    newReises.DatePrilet = Reises.DatePrilet;
                    newReises.PunktVilet = Reises.PunktVilet;
                    newReises.PunktPrilet = Reises.PunktPrilet;
                    PlainsContext plainsContext = new PlainsContext();
                    Plains plain = plainsContext.Plains.FirstOrDefault(x => x.Id == Reises.IdPlain);
                    if (plain != null)
                    {
                        newReises.IdPlain = Reises.IdPlain;
                        reisesContext.Reises.Add(newReises);
                        reisesContext.SaveChanges();
                        return Json(newReises);
                    }
                    else
                    {
                        return StatusCode(400);
                    }
                }
                else return StatusCode(401);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        ///<summary>
        /// Обновление рейса
        /// </summary>
        /// <remarks>Метод для обновления рейса</remarks>
        /// <returns name="Plain">Модель рейса</returns>
        /// <returns name="Token">Токен пользователя</returns>
        /// <response code="200">Рейс успешно добавлен</response>
        /// <response code="400">Самолёт не найден</response>
        /// <response code="401">Токен не верен</response>
        /// <response code="402">Рейс не найден</response>
        /// <response code="500">Ошибка в подключении к базе данных</response>
        [Route("UpdateReises")]
        [ApiExplorerSettings(GroupName = "v3")]
        [HttpPut]
        [ProducesResponseType(typeof(Reises), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(402)]
        [ProducesResponseType(500)]
        public ActionResult UpdateReises(Reises Reises, string Token)
        {
            try
            {
                UsersContext usersContext = new UsersContext();
                Users user = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                if (user != null)
                {
                    ReisesContext reisesContext = new ReisesContext();
                    Reises updateReises = reisesContext.Reises.FirstOrDefault(x => x.Id == Reises.Id);
                    if (updateReises != null)
                    {
                        updateReises.TimeVilet = Reises.TimeVilet;
                        updateReises.TimePrilet = Reises.TimePrilet;
                        updateReises.TimeOnFly = Reises.TimeOnFly;
                        updateReises.DateVilet = Reises.DateVilet;
                        updateReises.DatePrilet = Reises.DatePrilet;
                        updateReises.PunktVilet = Reises.PunktVilet;
                        updateReises.PunktPrilet = Reises.PunktPrilet;
                        PlainsContext plainsContext = new PlainsContext();
                        Plains plain = plainsContext.Plains.FirstOrDefault(x => x.Id == Reises.IdPlain);
                        if (plain != null)
                        {
                            updateReises.IdPlain = Reises.IdPlain;
                            reisesContext.Reises.Update(updateReises);
                            reisesContext.SaveChanges();
                            return Json(updateReises);
                        }
                        else
                        {
                            return StatusCode(400);
                        }
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

        ///<summary>
        /// Удаление рейса
        /// </summary>
        /// <remarks>Метод для удаления самолёта</remarks>
        /// <returns name="Id">Идентификатор рейса</returns>
        /// <returns name="Token">Токен пользователя</returns>
        /// <responses code="200">Рейс успешно удалён</responses>
        /// <responses code="401">Токен не верен</responses>
        /// <responses code="402">Такой рейс не найден</responses>
        /// <responses code="500">Ошибка в подключении к базе данных</responses>
        [Route("RemoveReises")]
        [ApiExplorerSettings(GroupName = "v4")]
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(402)]
        [ProducesResponseType(500)]
        public ActionResult RemoveReises(int Id, string Token)
        {
            try
            {
                UsersContext usersContext = new UsersContext();
                Users user = usersContext.Users.FirstOrDefault(x => x.Token == Token);
                if (user != null)
                {
                    ReisesContext reisesContext = new ReisesContext();
                    Reises removeReises = reisesContext.Reises.FirstOrDefault(x => x.Id == Id);
                    if (removeReises != null)
                    {
                        reisesContext.Reises.Remove(removeReises);
                        reisesContext.SaveChanges();
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
