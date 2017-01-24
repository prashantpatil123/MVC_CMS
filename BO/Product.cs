using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public class Design
    {
        public int DesignId { get; set; }

        [Display(Name = "Product Code")]
        [Required(ErrorMessage = "Product Code Required")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Product Title Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Product Description Required")]

        public string Description { get; set; }
        [Required(ErrorMessage = "Image Url Required")]
        [DataType(DataType.ImageUrl)]

        public string ImageUrl { get; set; }

        public Varient varient { get; set; }
    }

    public class Varient
    {

        [Required(ErrorMessage = "*")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "*")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "*")]
        public int Color { get; set; }

        [Required(ErrorMessage = "*")]
        public int Size { get; set; }

        public string ColorName { get; set; }

        public string SizeName { get; set; }

        public int ItemId { get; set; }
    }   
}
