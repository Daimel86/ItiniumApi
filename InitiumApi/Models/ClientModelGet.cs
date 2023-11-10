using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class ClientModelGet: ClientModelPost
{
    public int QueueId { get; set; }

    public static implicit operator ClientModelGet(ClientsEntity entity) =>
        new()
        {
            ClientName = entity.ClientName,
            Id = entity.Id,
            QueueId = entity.QueueId,
        };
}
