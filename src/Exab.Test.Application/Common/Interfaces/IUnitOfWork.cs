using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.Application.Common.Interfaces;
public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Categories { get; }
    IProductRepository Product { get; }
    IUserRepository User { get; }
    Task CommitAsync(CancellationToken cancellationToken);
}
