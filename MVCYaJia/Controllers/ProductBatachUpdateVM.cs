using System;

namespace MVCYaJia.Controllers
{
    public class ProductBatachUpdateVM
    {
        public int ProductId { get; set; }

        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
    }
}