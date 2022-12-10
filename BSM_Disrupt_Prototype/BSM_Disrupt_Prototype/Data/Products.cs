using System.ComponentModel.DataAnnotations;
namespace BSM_Disrupt_Prototype.Data
{
	public class Products
	{
        [Key]
        public int ID { get; set; }
        [StringLength(10)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageData { get; set; }
        public string SerialNumber { get; set; }
        public bool Active { get; set; }
    }
}

