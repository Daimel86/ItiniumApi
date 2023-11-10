using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Contracts;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientsController : ControllerBase
{
    private readonly ILogger<ClientsController> _logger;
    private readonly IClientsRepository _clientsRepository;

    public ClientsController(ILogger<ClientsController> logger, IClientsRepository clientsRepository)
    {
        _logger = logger;
        _clientsRepository = clientsRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClientModelPost client)
    {
        try
        {
            var response = await _clientsRepository.Add(client);
            return Ok((ClientModelGet)response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
