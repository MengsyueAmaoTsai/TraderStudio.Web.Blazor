using RichillCapital.Infrastructure.Resources.Contracts.SignalSources;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Infrastructure.Resources;

public interface IResourceService
{
    Task<Result<IEnumerable<SignalSourceResponse>>> ListSignalSourcesAsync();
}
