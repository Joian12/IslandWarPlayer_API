using IslandWarPlayer_API.DTO;
using IslandWarPlayer_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IslandWarPlayer_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerInfoController : Controller
    {
        private readonly DBContext _DBContext;

        public PlayerInfoController(DBContext DBContext)
        {
            this._DBContext = DBContext;
        }

        [HttpGet("GetPlayer")]
        public async Task<ActionResult<List<PlayerInfoDTO>>> Get()
        {
            var List = await _DBContext.playerInfos.Select(
                    s => new PlayerInfoDTO
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Username = s.Username,
                        Password = s.Password,

                    }
                ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpPost("SavePlayer")]
        public async Task<IActionResult> SavePlayer(PlayerInfoDTO player)
        {
            var newPlayer = new PlayerInfo() {
                FirstName = player.FirstName,
                LastName = player.LastName,
                Username = player.Username,
                Password = player.Password,
            };

            await _DBContext.playerInfos.AddAsync(newPlayer);
            await _DBContext.SaveChangesAsync();
            return Ok(newPlayer);
        }
    }
}
