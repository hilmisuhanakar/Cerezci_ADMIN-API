
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string ProductPlace { get; set; }
        public int ProductPrice { get; set; }
        public int ProductPiece { get; set; }
        public string ProductImage { get; set; }
    }
}
