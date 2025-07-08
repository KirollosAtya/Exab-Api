using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.Application.Wrappers;
public  class PaginatedRequest
{
    public string? Search { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; }    
    public bool IsDescending { get; set; } = false;
}
