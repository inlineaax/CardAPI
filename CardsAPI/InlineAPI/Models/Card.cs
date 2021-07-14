using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InlineAPI.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Number { get; set; }

        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User user { get; set; }
        public DateTime Created { get; set; }

        public void GenerateCard()
        {
            Random random = new Random();
            for (int i = 1; i <= 4; i++) {
                this.Number += random.Next(1000, 10000).ToString();           
            }
            this.Created = DateTime.Now;
        }
       
    }
}
