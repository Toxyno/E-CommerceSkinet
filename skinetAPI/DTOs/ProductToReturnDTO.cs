namespace skinetAPI.DTOs
{
    public class ProductToReturnDTO
    {
        public int Id {get;set;}
        public string Description { get; set; }
        public string  Name { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }  
        public string ProductType { get; set; }   //Related Entity 
        public string ProductBrand { get; set; }  
        
    }
}