using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DnDBuilderLinux.Handlers;
using Newtonsoft.Json.Linq;

namespace DnDBuilderLinux.Controllers
{
    [RoutePrefix("dnd")]
    public class Dnd5EController : ApiController
    {
        private readonly Dnd5EHandler _dndHandler;

        /// <inheritdoc />
        /// <summary>
        ///     Store and retrieve DnD race data
        /// </summary>
        public Dnd5EController()
        {
            _dndHandler = new Dnd5EHandler();
        }

        /// <summary>
        ///     CachedGet the names and DnD5eapi urls for all races
        /// </summary>
        /// <returns>JSON containing all DnD 5e race names</returns>
        /// <exception cref="HttpResponseException"></exception>
        [HttpGet]
        [Route("races")]
        public JToken GetRaces()
        {
            try
            {
                return _dndHandler.GetAllRaces();
            }
            catch (DndException e)
            {
                Console.WriteLine(e);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError,
                    e.Message + " If the problem persists, contact a server administrator"));
            }
        }

        /// <summary>
        ///     CachedGet the names and DnD5eapi urls for all races
        /// </summary>
        /// <returns>JSON containing all DnD 5e class names and urls</returns>
        /// <exception cref="HttpResponseException"></exception>
        [HttpGet]
        [Route("classes")]
        public JToken GetClasses()
        {
            try
            {
                return _dndHandler.GetAllClasses();
            }
            catch (DndException e)
            {
                Console.WriteLine(e);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError,
                    e.Message + " If the problem persists, contact a server administrator"));
            }
        }

        /// <summary>
        ///     Get a boolean value indicating whether the class is a caster or not
        /// </summary>
        /// <param name="classType">A valid DND 5E class</param>
        /// <returns>true if the class is a caster, false otherwise</returns>
        /// <exception cref="HttpResponseException"></exception>
        [HttpGet]
        [Route("spellcaster/{classType}")]
        public bool GetSpellcaster(string classType)
        {
            try
            {
                return _dndHandler.IsCaster(classType);
            }
            catch (DndException e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest,
                    e.Message + " If the problem persists, contact a server administrator"));
            }
        }
    }
}