using Microsoft.Extensions.Logging;
using ProductPromotion.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace ProductPromotion.Data
{
    public class SeedContext
    {
        public static async Task SeedAsync(Context aspnetrunContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // TODO: Only run this if using a real database
                // aspnetrunContext.Database.Migrate();
                // aspnetrunContext.Database.EnsureCreated();

                if (!aspnetrunContext.Categories.Any())
                {
                    aspnetrunContext.Categories.AddRange(GetPreconfiguredCategories());
                    await aspnetrunContext.SaveChangesAsync();
                }

                if (!aspnetrunContext.Products.Any())
                {
                    aspnetrunContext.Products.AddRange(GetPreconfiguredProducts());
                    await aspnetrunContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<SeedContext>();
                    log.LogError(exception.Message);
                    await SeedAsync(aspnetrunContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Name = "Kulaklık",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    ImageName = "one"
                },
                new Category()
                {
                    Name = "Akıllı Telefon",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    ImageName = "two"
                },
                new Category()
                {
                    Name = "Bilgisayar",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    ImageName = "tree"
                }
            };
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "IPhone 14",
                    Summary = "IPhone 14 en yeni telefonu ile sizlerle. 128 GB versiyon ile hemen alın",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 30999.00M,
                    CategoryId = 2
                },
                new Product()
                {
                    Name = "IPhone 11",
                    Summary = "IPhone 11 büyük indirim ile sizlerle. 128 GB versiyon ile hemen alın",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-2.png",
                    Price = 12000.00M,
                    CategoryId = 2
                },
                new Product()
                {
                    Name = "Samsung Galaxy S20",
                    Summary = "Samsung Galaxy S20 FE 256 GB Snapdragon (Samsung Türkiye Garantili)",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-3.png",
                    Price = 11789.00M,
                    CategoryId = 2
                },
                new Product()
                {
                    Name = "Samsung Galaxy A33",
                    Summary = "Samsung Galaxy A33 5G 128 GB (Samsung Türkiye Garantili)",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-4.png",
                    Price = 8938.00M,
                    CategoryId = 2
                },
                new Product()
                {
                    Name = "Xiaomi Redmi Note 11 Pro",
                    Summary = "Xiaomi Redmi Note 11 Pro 128 GB 8 GB Ram (Xiaomi Türkiye Garantili)",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-5.png",
                    Price = 8699.00M,
                    CategoryId = 2
                },
                new Product()
                {
                    Name = "Xiaomi Redmi 9c",
                    Summary = "Xiaomi Redmi 9c 32 GB (Xiaomi Türkiye Garantili)",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-6.png",
                    Price = 3299.00M,
                    CategoryId = 2
                },
                new Product()
                {
                    Name = "Huawei Matebook D15",
                    Summary = "Huawei Matebook D15 AMD Ryzen 5 5500U 8GB 512GB SSD Windows 11 Home 15.6\" FHD Taşınabilir Bilgisayar",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-7.png",
                    Price = 14200.00M,
                    CategoryId = 3
                },
                new Product()
                {
                    Name = "Apple MacBook Air M1",
                    Summary = "Apple MacBook Air M1 Çip 8GB 256GB SSD macOS 13\" QHD Taşınabilir Bilgisayar Altın MGND3TU/A",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-8.png",
                    Price = 20000.00M,
                    CategoryId = 3
                },
                new Product()
                {
                    Name = "JBL C100SIUBLK",
                    Summary = "JBL C100SIUBLK Mikrofonlu Kulakiçi Kulaklık CT IE Siyah",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-9.png",
                    Price = 199.00M,
                    CategoryId = 1
                },
                new Product()
                {
                    Name = "Anker Soundcore Life Q30 Bluetooth Kablosuz Kulaklık",
                    Summary = "Anker Soundcore Life Q30 Bluetooth Kablosuz Kulaklık - Hibrit Aktif Gürültü Önleyici ANC - Siyah - A3028 (Anker Türkiye Garantili)",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-10.png",
                    Price = 2000.00M,
                    CategoryId = 1
                }
            };
        }
    }
}
