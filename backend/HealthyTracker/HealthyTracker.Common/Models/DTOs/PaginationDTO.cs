namespace HealthyTracker.Common.Models.DTOs;

public class PaginationDTO
{
    public int Page { get; set; }
    public int PageSize { get; set; } = 5;
}