using System.Collections.Generic;
using System.Threading.Tasks;
using Dalel.Repository;
using Models.HomeService;
public class ServiceProviderProposalService 
{
    private readonly ServiceProviderPropsalRepository _repository;

    public ServiceProviderProposalService(ServiceProviderPropsalRepository repository)
    {
        _repository = repository;
    }

    public async Task<IQueryable<ServiceProviderPropsal>> GetProposalsByRequestAsync(int requestId)
    {
        return (IQueryable<ServiceProviderPropsal>)await _repository.GetProposalsByRequestAsync(requestId);
    }

    public async Task<IQueryable<ServiceProviderPropsal>> GetProposalsByProviderAsync(string providerId)
    {
        return (IQueryable<ServiceProviderPropsal>)await _repository.GetProposalsByProviderAsync(providerId);
    }

    public IQueryable<ServiceProviderPropsal> GetProposals(int pageSize, int pageNumber)
    {
        return (IQueryable<ServiceProviderPropsal>)_repository.Get(null, pageSize, pageNumber).ToList();
    }

    public ServiceProviderPropsal GetProposalById(int id)
    {
        return _repository.GetList(p => p.Id == id).FirstOrDefault();
    }

    public async Task<ServiceProviderPropsal> GetProposalWithDetailsAsync(int id)
    {
        return await _repository.GetProposalWithDetailsAsync(id);
    }

    public async Task<bool> HasProviderProposedAsync(int requestId, string providerId)
    {
        return await _repository.HasProviderProposedAsync(requestId, providerId);
    }

    public ServiceProviderPropsal CreateProposal(ServiceProviderPropsal proposal)
    {
        _repository.Add(proposal);
        return proposal;
    }

    public async Task AcceptProposalAsync(int id)
    {
        await _repository.AcceptProposalAsync(id);
    }

    public async Task RejectProposalAsync(int id)
    {
        await _repository.RejectProposalAsync(id);
    }

    public void UpdateProposal(ServiceProviderPropsal proposal)
    {
        _repository.Update(proposal);
    }

    public void DeleteProposal(int id)
    {
        var proposal = GetProposalById(id);
        if (proposal != null)
        {
            _repository.Delete(proposal);
        }
    }
}