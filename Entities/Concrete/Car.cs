using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public uint Id { get; set; }
        public ushort BrandId { get; set; }
        public uint ColorId { get; set; }
        public ushort ModelYear { get; set; }
        public uint DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
