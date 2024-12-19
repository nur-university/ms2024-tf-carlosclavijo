using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracting.Domain.Abstractions;
using Contracting.Domain.Contracts;
using MediatR;

namespace Contracting.Application.Contracts.CompleteContract;

internal class CompleteContractHandler : IRequestHandler<CompleteContractCommand, bool>
{
    private readonly IContractRepository _contractRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CompleteContractHandler(IContractRepository contractRepository, IUnitOfWork unitOfWork)
    {
        _contractRepository = contractRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CompleteContractCommand request, CancellationToken cancellationToken)
    {
        var contract = await _contractRepository.GetByIdAsync(request.ContractId);

        if (contract == null)
        {
            throw new InvalidOperationException("Contract is not found");
        }
        contract.Complete();

        await _unitOfWork.CommitAsync(cancellationToken);

        return true;
    }
}
