using Exab.Test.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.Application.Interface;
public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Categories { get; }
    IProductRepository Product { get; }
    Task CommitAsync(CancellationToken cancellationToken);
}
