using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Contracts;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class QueuesController : ControllerBase
{
    private readonly ILogger<QueuesController> _logger;
    private readonly IQueuesRepository _queuesRepository;

    public QueuesController(ILogger<QueuesController> logger, IQueuesRepository queuesRepository)
    {
        _logger = logger;
        _queuesRepository = queuesRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<QueuesModel>> Get()
    {
        var queues = await _queuesRepository.GetQueuesAsync();
        return queues.Select(s => (QueuesModel)s).ToList();
    }
}
