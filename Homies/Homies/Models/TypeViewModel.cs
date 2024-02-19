using Homies.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class TypeViewModel
    {
        [Comment("Type identifier")]
        public int Id { get; set; }

        [Comment("Type name")]
        public string Name { get; set; } = string.Empty;

    }
}
