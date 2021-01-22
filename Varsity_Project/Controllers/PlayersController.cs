using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Varsity_Project.Models;
using System.Diagnostics;

namespace Varsity_Project.Controllers
{
    public class PlayersController : ApiController
    {
        //This variable is our database access point
        private VarsityDataContext db = new VarsityDataContext();

        //This code is mostly scaffolded from the base models and database context
        //New > WebAPIController with Entity Framework Read/Write Actions
        //Choose model "Player"
        //Choose context "Varsity Data Context"
        //Note: The base scaffolded code needs many improvements for a fully
        //functioning MVP.

        // GET: api/Players/GetPlayers
        // TODO: Searching Logic?
        public IEnumerable<PlayerDto> GetPlayers()
        {
            List<Player> Players = db.Players.ToList();
            List<PlayerDto> PlayerDtos = new List<PlayerDto>{ };

            //Here you can choose which information is exposed to the API
            foreach(var Player in Players)
            {
                PlayerDto NewPlayer = new PlayerDto {
                    PlayerID = Player.PlayerID,
                    PlayerBio = Player.PlayerBio,
                    PlayerName = Player.PlayerName
                };
                PlayerDtos.Add(NewPlayer);
            }

            return PlayerDtos;
        }

        // GET: api/Players/FindPlayer/5
        [ResponseType(typeof(PlayerDto))]
        [HttpGet]
        public IHttpActionResult FindPlayer(int id)
        {
            //Find the data
            Player Player = db.Players.Find(id);
            //if not found, return 404 status code.
            if (Player == null)
            {
                return NotFound();
            }

            //put into a 'friendly object format'
            PlayerDto PlayerDto = new PlayerDto
            {
                PlayerID = Player.PlayerID,
                PlayerBio = Player.PlayerBio,
                PlayerName = Player.PlayerName
            };

            
            //pass along data as 200 status code OK response
            return Ok(PlayerDto);
        }

        // POST: api/Players/UpdatePlayer/5
        // FORM DATA: Player JSON Object
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdatePlayer(int id, [FromBody]Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.PlayerID)
            {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Players/AddPlayer
        // FORM DATA: Player JSON Object
        [ResponseType(typeof(Player))]
        [HttpPost]
        public IHttpActionResult AddPlayer([FromBody]Player player)
        {
            //Will Validate according to data annotations specified on model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = player.PlayerID }, player);
        }

        // POST: api/Players/DeletePlayer/5
        [HttpPost]
        public IHttpActionResult DeletePlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(int id)
        {
            return db.Players.Count(e => e.PlayerID == id) > 0;
        }
    }
}