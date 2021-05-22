namespace MicroMachines.Shopping.API.Dtos
{
    public record AddressDto
    {
        public string? FullName { get; init; }
        public string Email { get; init; }
        public string? Street { get; init; }
        public string? City { get; init; }
        public string? State { get; init; }
        public string? Country { get; init; }
        public string? ZipCode { get; init; }
    }
}