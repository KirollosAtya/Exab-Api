using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.Application.Modules.Category.Query.GetById;
public  record GetCategoryByIdQuery(int Id) : IRequest<Exab.Test.Domain.Entities.Category?>;

