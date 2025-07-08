﻿namespace Exab.Test.Application.Modules;
public  class PaginatedRequest
{
    public string? Search { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; }    
    public bool IsDescending { get; set; } = false;
}
