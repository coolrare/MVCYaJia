namespace MVCYaJia.Models
{
    using InputValidations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
    
    public partial class ProductMetaData
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "必填欄位: {0}")]
        [DisplayName("商品名稱")]
        [ValidateTaiwanSID(ErrorMessage = "身分證字號格式錯誤")]
        public string ProductName { get; set; }
        [Required]
        [DisplayName("商品價格")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public Nullable<decimal> Price { get; set; }
        [Required]
        [DisplayName("是否上架")]
        public Nullable<bool> Active { get; set; }
        [Required]
        [DisplayName("庫存量")]
        public Nullable<decimal> Stock { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
