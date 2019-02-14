using System;
namespace TCP_Chat.Models
{
    public class Entity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

    }
}