using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class AddressRequest
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Street { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string State { get; set; }

        [Required]
        public required string ZipCode { get; set; }
    }
}