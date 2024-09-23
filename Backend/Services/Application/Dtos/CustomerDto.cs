namespace Application.Dtos;
public record CustomerDto(int Id, string Name, string? Address, int City, string? Phone, string? Fax, int? Coworkers);
