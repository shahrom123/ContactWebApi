
var productService = new ProductService();
var AllProduct = productService.GetProducts();



Show();

Console.WriteLine();
Add();
Update();
Show();
void Add()
{
    var ad = new Product()
    {
        ProductName = "Category",
        Company = "Category",
        ProductCount = 11,
        Price = 5,
    };
    productService.AddProduct(ad);
}
void Update()
{
    var up = new Product()
    { 
        Id = 5 ,
        ProductName = " Sharipov",
        Company = " Shahrom ",
        ProductCount = 22454,
        Price = 145451,
    };
    productService.UpdateProduct(up);
}
void Delete(int id)
{
    productService.DeleteProduct(id);

}
void Show()
{
    Console.WriteLine(" Id    ProductName    Company    ProductCount   Price ");
    foreach (var product in AllProduct)
    {
        Console.WriteLine($" {product.Id}     {product.ProductName}    " +
            $" {product.Company}       {product.ProductCount}      {product.Price}");
    }
}



