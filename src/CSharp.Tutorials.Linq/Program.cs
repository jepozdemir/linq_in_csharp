class Program
{
	static void Main(string[] args)
	{
		var products = new List<Product>
		{
			new Product { Name = "Laptop", Price = 1200 },
			new Product { Name = "Phone", Price = 800 },
			new Product { Name = "Tablet", Price = 500 },
			new Product { Name = "Headphones", Price = 150 },
			new Product { Name = "Mouse", Price = 50 }
		};
		FilterProducts(products);
		PrintProducts(products);
		SortProducts(products);
		GetTotalPrice(products);
		GroupProducts(products);
	}

	static void FilterProducts(List<Product> products)
	{
		Console.WriteLine("\r\nFiltered Products:\r\n");
		var filteredProducts = products.Where(p => p.Price > 200);

		foreach (var product in filteredProducts)
		{
			Console.WriteLine(product.Name);
		}
	}

	static void PrintProducts(List<Product> products)
	{
		Console.WriteLine("\r\nUppercase Products:\r\n");
		var upperCaseNames = products.Select(p => p.Name.ToUpper());

		foreach (var name in upperCaseNames)
		{
			Console.WriteLine(name);
		}
	}

	static void SortProducts(List<Product> products)
	{
		Console.WriteLine("\r\nSorted Products:\r\n");
		var orderedProducts = products.OrderBy(p => p.Name);

		foreach (var product in orderedProducts)
		{
			Console.WriteLine(product.Name);
		}
	}

	static void GetTotalPrice(List<Product> products)
	{
		Console.WriteLine("\r\nCalculating Total Price..\r\n");
		var total = products.Sum(p => p.Price);

		Console.WriteLine("Total= " + total); // Output: Total= 2700
	}

	static void GroupProducts(List<Product> products)
	{
		Console.WriteLine("\r\nGrouped Products:\r\n");
		var groupedProducts = products.GroupBy(p => GetPriceRange(p.Price));

		foreach (var group in groupedProducts)
		{
			Console.WriteLine($"Price Range: {group.Key}");
			foreach (var product in group)
			{
				Console.WriteLine($"- {product.Name}: ${product.Price}");
			}
			Console.WriteLine();
		}
	}

	static string GetPriceRange(decimal price)
	{
		if (price <= 100)
			return "Cheap";
		else if (price <= 500)
			return "Moderate";
		else
			return "Expensive";
	}
}