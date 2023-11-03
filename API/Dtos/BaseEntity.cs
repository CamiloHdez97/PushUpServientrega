using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

    public class BaseEntity
    {
        [Key]
        public string Id {get; set;}
    }