using System;

namespace PlatformService.Dtos
{
    public class PlatformReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Cost { get; set; }
    }
}