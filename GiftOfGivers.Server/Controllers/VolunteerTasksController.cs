using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftOfGivers.Server.Data;
using GiftOfGivers.Server.Models;
using GiftOfGivers.Shared.DTOs;

namespace GiftOfGivers.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VolunteerTasksController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VolunteerTasksController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VolunteerTaskDto>>> GetTasks()
    {
        return await _context.VolunteerTasks
            .Select(t => new VolunteerTaskDto
            {
                Id = t.Id,
                Name = t.Name,
                Category = t.Category,
                Status = t.Status,
                Urgency = t.Urgency,
                Volunteers = t.Volunteers,
                MaxVolunteers = t.MaxVolunteers,
                Description = t.Description
            })
            .ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] VolunteerTaskDto dto)
    {
        var task = new VolunteerTask
        {
            Name = dto.Name,
            Category = dto.Category,
            Status = dto.Status,
            Urgency = dto.Urgency,
            Volunteers = dto.Volunteers,
            MaxVolunteers = dto.MaxVolunteers,
            Description = dto.Description
        };

        _context.VolunteerTasks.Add(task);
        await _context.SaveChangesAsync();
        return Ok(task);
    }
}
