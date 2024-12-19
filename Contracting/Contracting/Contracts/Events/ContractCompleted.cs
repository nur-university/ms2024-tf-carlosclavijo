using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracting.Domain.Abstractions;
using Contracting.Domain.Shared;

namespace Contracting.Domain.Contracts.Events;

public record ContractCompleted : DomainEvent
{
    public Guid ContractId { get; init; }
    public ContractType ContractType { get; init; }
    public CostValue Cost { get; init; }

    public ContractCompleted(Guid contractId, ContractType type, CostValue cost)
    {
        ContractId = contractId;
        ContractType = type;
        Cost = cost;
    }
}
