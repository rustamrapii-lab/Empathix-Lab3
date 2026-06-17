using Microsoft.AspNetCore.Mvc;
using EmpathixProject;

namespace ApiWrapper.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpathixController : ControllerBase
{
    
    [HttpGet("health")]
    public IActionResult Health() 
    {
        return Ok(new { status = "Healthy", time = DateTime.UtcNow });
    }

    
    [HttpPost("process")]
    public IActionResult Process([FromBody] ProcessRequest request)
    {
        try 
        {
            
            var session = new GenerationSession(request.Tone);
            
            var result = session.ProcessText(request.Text);
            
            return Ok(new { result = result });
        } 
        catch (Exception ex) 
        {
           
            return BadRequest(new { error = ex.Message });
        }
    }
}


public class ProcessRequest 
{
    public string? Tone { get; set; } 
    public string? Text { get; set; }
}