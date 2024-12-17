namespace SixShopOOP
{
    //Существует продавец, он имеет у себя список товаров,
    //и при нужде, может вам его показать, также продавец может продать вам товар.
    //После продажи товар переходит к вам, и вы можете также посмотреть свои вещи.
    //Возможные классы – игрок, продавец, товар.
    //Вы можете сделать так, как вы видите это.

    public class Product
    {
        private string _nameProduct;

        private int _settingsPrice;

        public Product(string _nameProduct, int _settingsPrice)
        {
            NameProduct = _nameProduct;
            SettingsPrice = _settingsPrice;
        }

        public int SettingsPrice { get { return _settingsPrice; } set { _settingsPrice = value; } }

        public string NameProduct { get { return _nameProduct; } set { _nameProduct = value; } }
    }

    public class Shop
    {
        private readonly Dictionary<int, Product> productList = new Dictionary<int, Product>()
        {
            {1, new Product("Молоко", 100)},
            {2, new Product("Мясо", 200)},
            {3, new Product("Шоколад", 300)},
            {4, new Product("Сыр", 400)},
            {5, new Product("Торт", 500)}
        };

        public void DisplayProducts()
        {
            foreach (KeyValuePair<int, Product> valuePairShop in productList)
            {
                Console.WriteLine($"Индекс: {valuePairShop.Key}.\n" +
                    $"Название продукта: {valuePairShop.Value.NameProduct}.\n" +
                    $"Цена продукта: {valuePairShop.Value.SettingsPrice}.\n");
                Console.WriteLine();
            }
        }

        public void DeleteProduct(int key)
        {
            productList.Remove(key);
        }

        public bool TryGetProduct(int key, out Product product)
        {
            product = null;

            if (productList.ContainsKey(key))
            {
                product = productList[key];
                return true;
            }
            return false;
        }
    }

    public class Buyer
    {
        public readonly List<Product> productList = new List<Product>();
        public void DisplayProduct()
        {
            foreach (Product valuePairShop in productList)
            {
                Console.WriteLine($"Название продукта: {valuePairShop.NameProduct}.\n" +
                    $"Цена продукта: {valuePairShop.SettingsPrice}.\n");
                Console.WriteLine();
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Buyer buyer = new Buyer();

            while (true)
            {
                Console.WriteLine("Выберите команду: \n1 - показать список товара. " +
                    "\n2 - Продать товар. \n3 - Корзина покупателя.");

                string inputCommandStr = Console.ReadLine();
                if (int.TryParse(inputCommandStr, out int inputCommand))
                {
                    switch (inputCommand)
                    {
                        case (int)ShopProduct.ShopProduct:

                            shop.DisplayProducts();

                            break;

                        case (int)ShopProduct.SellProduct:

                            shop.DisplayProducts();

                            Console.WriteLine("Выберите товар для покупки. Введите индекс.");
                            int productChoice = Convert.ToInt32(Console.ReadLine());

                            if (shop.TryGetProduct(productChoice, out Product product))
                            {
                                buyer.productList.Add(product);

                                shop.DeleteProduct(productChoice);
                            }
                            break;

                        case (int)ShopProduct.ShowBuyProduct:

                            buyer.DisplayProduct();

                            break;

                        default:
                            Console.WriteLine("Неизвестная команда.");
                            break;
                    }
                }
            }
        }
    }
}

public enum ShopProduct
{
    ShopProduct = 1,
    SellProduct,
    ShowBuyProduct
}
