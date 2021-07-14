using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlineAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();
        public DateTime Created { get; set; }
    }
}
