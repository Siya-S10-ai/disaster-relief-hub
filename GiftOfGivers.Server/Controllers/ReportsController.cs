using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftOfGivers.Server.Data;
using GiftOfGivers.Server.Models;
using GiftOfGivers.Shared.DTOs;

namespace GiftOfGivers.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReportsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitReport([FromBody] ReportDto dto)
    {
        var report = new Report
        {
            ReporterName = dto.ReporterName,
            ReporterEmail = dto.ReporterEmail,
            ReporterPhone = dto.ReporterPhone,
            ReportType = dto.ReportType,
            Location = dto.Location,
            Description = dto.Description,
            Urgency = dto.Urgency,
            ImageUrl = dto.ImageUrl
        };

        _context.Reports.Add(report);
        await _context.SaveChangesAsync();
        return Ok(report);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReportDto>>> GetReports()
    {
        return await _context.Reports
            .Select(r => new ReportDto
            {
                Id = r.Id,
                ReporterName = r.ReporterName,
                ReporterEmail = r.ReporterEmail,
                ReporterPhone = r.ReporterPhone,
                ReportType = r.ReportType,
                Location = r.Location,
                Description = r.Description,
                Urgency = r.Urgency,
                Status = r.Status,
                CreatedAt = r.CreatedAt,
                ImageUrl = r.ImageUrl
            })
            .ToListAsync();
    }
}
