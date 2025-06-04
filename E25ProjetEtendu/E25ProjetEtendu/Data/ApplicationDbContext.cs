using E25ProjetEtendu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using E25ProjetEtendu.Enums;

namespace E25ProjetEtendu.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Produit> produits { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<StockReservation> StockReservations { get; set; }
        public DbSet<Category> Categories { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Category Seed Data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Aliment" },
                new Category { CategoryId = 2, Name = "Breuvage" },
                new Category { CategoryId = 3, Name = "Hygiène" },
                new Category { CategoryId = 4, Name = "Matériel scolaire" }
            );

            #endregion

            #region Admin User Seed Data

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "admin-role-id", Name = "Admin", NormalizedName = "ADMIN" }
            );

            var hasher = new PasswordHasher<ApplicationUser>();
            var adminPassword = hasher.HashPassword(null, "Qwerty123!!");

            modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = "21111111-1111-1111-1111-111111111111",
                UserName = "edouardlivraisonsante@gmail.com",
                FirstName = "Admin",
                LastName = "Admin",
                NormalizedUserName = "EDOUARDLIVRAISONSANTE@GMAIL.COM",
                Email = "edouardlivraisonsante@gmail.com",
                NormalizedEmail = "EDOUARDLIVRAISONSANTE@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = adminPassword,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "5149465399"
            }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = "21111111-1111-1111-1111-111111111111", RoleId = "admin-role-id" }
            );
            #endregion

            #region Delivery Station User Seed Data

            modelBuilder.Entity<IdentityRole>().HasData(
           new IdentityRole { Id = "deliverystation-role-id", Name = "DeliveryStation", NormalizedName = "DELIVERYSTATION" }
           );
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "42222222-2222-2222-2222-222222222222",
                    UserName = "postelivraisonedouard@gmail.com",
                    FirstName = "Poste",
                    LastName = "Livreur",
                    NormalizedUserName = "POSTELIVRAISONEDOUARD@GMAIL.COM",
                    Email = "postelivraisonedouard@gmail.com",
                    NormalizedEmail = "POSTELIVRAISONEDOUARD@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Qwerty123!!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "5149465399"

                }
            ); modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "42222222-2222-2222-2222-222222222222",
                    RoleId = "deliverystation-role-id"
                }
            );


            #endregion

            #region Standard Users Seed Data

            // Ajout du rôle "User"
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "user-role-id", Name = "User", NormalizedName = "USER" }
            );

            var userPassword = hasher.HashPassword(null, "Qwerty123!!"); // mot de passe pour la démo

            // Ajout d’un utilisateur standard
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "32222222-2222-2222-2222-222222222222",
                    UserName = "jeanbeliveau011@gmail.com",
                    FirstName = "Jean",
                    LastName = "Beliveau",
                    NormalizedUserName = "JEANBELIVEAU011@GMAIL.COM",
                    Email = "jeanbeliveau011@gmail.com",
                    NormalizedEmail = "JEANBELIVEAU011@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = userPassword,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "5149465399"
                },
                new ApplicationUser
                {
                    Id = "54444444-4444-4444-4444-444444444444",
                    UserName = "maximee011@gmail.com",
                    FirstName = "Maxime",
                    LastName = "Ninep",
                    NormalizedUserName = "MAXIMEE011@GMAIL.COM",
                    Email = "maximee011@gmail.com",
                    NormalizedEmail = "MAXIMEE011@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = userPassword,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "5149465399"
                },
                new ApplicationUser
                {
                    Id = "65555555-5555-5555-5555-555555555555",
                    UserName = "nicolasquebec420@gmail.com",
                    FirstName = "Nicolas",
                    LastName = "Quebec",
                    NormalizedUserName = "NICOLASQUEBEC420@GMAIL.COM",
                    Email = "nicolasquebec420@gmail.com",
                    NormalizedEmail = "NICOLASQUEBEC420@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = userPassword,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "5149465399"
                }
            );

            // Associer le rôle "User"
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "32222222-2222-2222-2222-222222222222", RoleId = "user-role-id" },
                new IdentityUserRole<string> { UserId = "43333333-3333-3333-3333-333333333333", RoleId = "user-role-id" },
                new IdentityUserRole<string> { UserId = "54444444-4444-4444-4444-444444444444", RoleId = "user-role-id" },
                new IdentityUserRole<string> { UserId = "65555555-5555-5555-5555-555555555555", RoleId = "user-role-id" }
            );

            #endregion

            #region Deliverer Role + User Seed Data
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "deliverer-role-id", Name = "Deliverer", NormalizedName = "DELIVERER" }
            );

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "43333333-3333-3333-3333-333333333333",
                    UserName = "jacobby911@gmail.com",
                    FirstName = "Jacob",
                    LastName = "Lelivreux",
                    NormalizedUserName = "JACOBBY911@GMAIL.COM",
                    Email = "jacobby911@gmail.com",
                    NormalizedEmail = "JACOBBY911@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = userPassword,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "5149465399"
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "43333333-3333-3333-3333-333333333333", // Jacob
                    RoleId = "deliverer-role-id"
                }
            );
            #endregion

            #region Products Seed Data
            modelBuilder.Entity<Produit>().HasData(
     new Produit { ProduitId = 1, SKU = "100001", Nom = "Red Bull", InventoryQuantity = 120, Prix = 3, Image = "redbull.png", EstActif = true, Note = 4, ValeurNutritive = "Calories: 110, Sucres: 27g, Caféine: 80mg, Glucides: 28g, Protéines: 1g", CategoryId = 2 },
     new Produit { ProduitId = 2, SKU = "100002", Nom = "Pogo", InventoryQuantity = 200, Prix = 2, Image = "pogo.jpg", EstActif = true, Note = 3, ValeurNutritive = "Calories: 190, Lipides: 9g, Glucides: 20g, Protéines: 6g, Sodium: 500mg", CategoryId = 1 },
     new Produit { ProduitId = 3, SKU = "100003", Nom = "Bouteille d'eau", InventoryQuantity = 300, Prix = 1, Image = "eau.jpg", EstActif = true, Note = 5, ValeurNutritive = "Calories: 0, Lipides: 0g, Sucres: 0g, Sodium: 0mg", CategoryId = 2 },
     new Produit { ProduitId = 4, SKU = "100004", Nom = "Chips Lay’s", InventoryQuantity = 100, Prix = 2, Image = "chips.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 160, Lipides: 10g, Glucides: 15g, Sucres: 1g, Sodium: 170mg", CategoryId = 1 },
     new Produit { ProduitId = 5, SKU = "100005", Nom = "Nutella", InventoryQuantity = 80, Prix = 5, Image = "nutella.jpg", EstActif = true, Note = 5, ValeurNutritive = "Calories: 200, Lipides: 11g, Glucides: 22g, Sucres: 21g, Protéines: 2g", CategoryId = 1 },
     new Produit { ProduitId = 6, SKU = "100006", Nom = "Yogourt Activia", InventoryQuantity = 150, Prix = 3, Image = "activia.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 100, Lipides: 2g, Glucides: 15g, Sucres: 12g, Protéines: 5g", CategoryId = 1 },
     new Produit { ProduitId = 7, SKU = "100007", Nom = "Pizza congelée", InventoryQuantity = 60, Prix = 6, Image = "pizza.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 350, Lipides: 15g, Glucides: 40g, Sucres: 5g, Protéines: 12g", CategoryId = 1 },
     new Produit { ProduitId = 8, SKU = "100008", Nom = "Barre de granola", InventoryQuantity = 180, Prix = 2, Image = "granola.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 190, Lipides: 7g, Glucides: 29g, Sucres: 11g, Protéines: 4g", CategoryId = 1 },
     new Produit { ProduitId = 9, SKU = "100009", Nom = "Coca-Cola", InventoryQuantity = 220, Prix = 2, Image = "coca.jpg", EstActif = true, Note = 3, ValeurNutritive = "Calories: 140, Sucres: 39g, Glucides: 39g, Sodium: 45mg", CategoryId = 2 },
     new Produit { ProduitId = 10, SKU = "100010", Nom = "Sandwich jambon-fromage", InventoryQuantity = 75, Prix = 4, Image = "sandwich.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 320, Lipides: 12g, Glucides: 30g, Protéines: 18g, Sodium: 780mg", CategoryId = 1 },
     new Produit { ProduitId = 11, SKU = "100011", Nom = "Café Starbucks", InventoryQuantity = 90, Prix = 4, Image = "starbucks.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 150, Sucres: 20g, Caféine: 95mg", CategoryId = 2 },
     new Produit { ProduitId = 12, SKU = "100012", Nom = "Déodorant Axe", InventoryQuantity = 50, Prix = 6, Image = "axe.jpg", EstActif = true, Note = 5, ValeurNutritive = "Sans calories", CategoryId = 3 },
     new Produit { ProduitId = 13, SKU = "100013", Nom = "Shampooing Head & Shoulders", InventoryQuantity = 60, Prix = 7, Image = "headshoulders.jpg", EstActif = true, Note = 4, ValeurNutritive = "Sans calories", CategoryId = 3 },
     new Produit { ProduitId = 14, SKU = "100014", Nom = "Crème glacée Ben & Jerry's", InventoryQuantity = 40, Prix = 8, Image = "benjerry.jpg", EstActif = true, Note = 5, ValeurNutritive = "Calories: 270, Lipides: 14g, Sucres: 26g", CategoryId = 1 },
     new Produit { ProduitId = 15, SKU = "100015", Nom = "Pain tranché", InventoryQuantity = 120, Prix = 3, Image = "pain.jpg", EstActif = true, Note = 3, ValeurNutritive = "Calories: 80, Glucides: 15g, Protéines: 3g", CategoryId = 1 },
     new Produit { ProduitId = 16, SKU = "100016", Nom = "Fromage cheddar", InventoryQuantity = 100, Prix = 5, Image = "cheddar.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 110, Lipides: 9g, Protéines: 7g", CategoryId = 1 },
     new Produit { ProduitId = 17, SKU = "100017", Nom = "Yaourt grec", InventoryQuantity = 130, Prix = 4, Image = "yaourt.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 120, Protéines: 10g, Sucres: 8g", CategoryId = 1 },
     new Produit { ProduitId = 18, SKU = "100018", Nom = "Crackers Ritz", InventoryQuantity = 80, Prix = 3, Image = "ritz.jpg", EstActif = true, Note = 3, ValeurNutritive = "Calories: 160, Lipides: 8g, Glucides: 20g", CategoryId = 1 },
     new Produit { ProduitId = 19, SKU = "100019", Nom = "Soupe Campbell", InventoryQuantity = 70, Prix = 2, Image = "soupe.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 90, Sodium: 480mg", CategoryId = 1 },
     new Produit { ProduitId = 20, SKU = "100020", Nom = "Jus d'orange Tropicana", InventoryQuantity = 150, Prix = 3, Image = "tropicana.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 110, Sucres: 23g", CategoryId = 2 },
     new Produit { ProduitId = 21, SKU = "100021", Nom = "Brosse à dents Colgate", InventoryQuantity = 200, Prix = 2, Image = "colgate.jpg", EstActif = true, Note = 4, ValeurNutritive = "Sans calories", CategoryId = 3 },
     new Produit { ProduitId = 22, SKU = "100022", Nom = "Dentifrice Sensodyne", InventoryQuantity = 150, Prix = 5, Image = "sensodyne.jpg", EstActif = true, Note = 5, ValeurNutritive = "Sans calories", CategoryId = 3 },
     new Produit { ProduitId = 23, SKU = "100023", Nom = "Savon Dove", InventoryQuantity = 180, Prix = 2, Image = "dove.jpg", EstActif = true, Note = 4, ValeurNutritive = "Sans calories", CategoryId = 3 },
     new Produit { ProduitId = 24, SKU = "100024", Nom = "Boisson Gatorade", InventoryQuantity = 110, Prix = 3, Image = "gatorade.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 80, Sucres: 21g", CategoryId = 2 },
     new Produit { ProduitId = 25, SKU = "100025", Nom = "Chocolat Kinder", InventoryQuantity = 100, Prix = 2, Image = "kinder.jpg", EstActif = true, Note = 5, ValeurNutritive = "Calories: 120, Sucres: 12g", CategoryId = 1 },
     new Produit { ProduitId = 26, SKU = "100026", Nom = "Céréales Cheerios", InventoryQuantity = 90, Prix = 4, Image = "cheerios.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 110, Glucides: 20g, Protéines: 3g", CategoryId = 1 },
     new Produit { ProduitId = 27, SKU = "100027", Nom = "Biscuit Oreo", InventoryQuantity = 130, Prix = 3, Image = "oreo.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 160, Sucres: 14g", CategoryId = 1 },
     new Produit { ProduitId = 28, SKU = "100028", Nom = "Beurre d'arachide", InventoryQuantity = 70, Prix = 5, Image = "beurre.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 190, Lipides: 16g, Protéines: 7g", CategoryId = 1 },
     new Produit { ProduitId = 29, SKU = "100029", Nom = "Eau gazeuse Perrier", InventoryQuantity = 200, Prix = 2, Image = "perrier.jpg", EstActif = true, Note = 4, ValeurNutritive = "Calories: 0", CategoryId = 2 },
     new Produit { ProduitId = 30, SKU = "100030", Nom = "Muffin aux bleuets", InventoryQuantity = 60, Prix = 3, Image = "muffin.jpg", EstActif = true, Note = 5, ValeurNutritive = "Calories: 380, Lipides: 16g, Sucres: 28g", CategoryId = 1 },
     new Produit { ProduitId = 31, SKU = "100031", Nom = "BandAid", InventoryQuantity = 0, Prix = 3, Image = "Aid.jpg", EstActif = true, Note = 5, ValeurNutritive = "Calories: 0", CategoryId = 3 }
 );

            #endregion

            #region Sample Orders Seed Data

            // Delivered Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 2001, BuyerId = "32222222-2222-2222-2222-222222222222", DelivererId = "43333333-3333-3333-3333-333333333333", OrderDate = new DateTime(2024, 5, 1), TotalPrice = 6.00m, Location = "D-0001", Status = OrderStatus.Delivered },
                new Order { OrderId = 2002, BuyerId = "32222222-2222-2222-2222-222222222222", DelivererId = "43333333-3333-3333-3333-333333333333", OrderDate = new DateTime(2024, 5, 2), TotalPrice = 4.00m, Location = "D-0002", Status = OrderStatus.Delivered },

                new Order { OrderId = 2003, BuyerId = "54444444-4444-4444-4444-444444444444", DelivererId = "43333333-3333-3333-3333-333333333333", OrderDate = new DateTime(2024, 5, 3), TotalPrice = 5.00m, Location = "D-0003", Status = OrderStatus.Delivered },
                new Order { OrderId = 2004, BuyerId = "54444444-4444-4444-4444-444444444444", DelivererId = "43333333-3333-3333-3333-333333333333", OrderDate = new DateTime(2024, 5, 4), TotalPrice = 2.00m, Location = "D-0004", Status = OrderStatus.Delivered },

                new Order { OrderId = 2005, BuyerId = "65555555-5555-5555-5555-555555555555", DelivererId = "43333333-3333-3333-3333-333333333333", OrderDate = new DateTime(2024, 5, 5), TotalPrice = 2.00m, Location = "D-0005", Status = OrderStatus.Delivered },
                new Order { OrderId = 2006, BuyerId = "65555555-5555-5555-5555-555555555555", DelivererId = "43333333-3333-3333-3333-333333333333", OrderDate = new DateTime(2024, 5, 6), TotalPrice = 3.00m, Location = "D-0006", Status = OrderStatus.Delivered }
            );

            // Pending Orders (no DelivererId, Status = Pending)
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 2007, BuyerId = "32222222-2222-2222-2222-222222222222", DelivererId = null, OrderDate = new DateTime(2024, 5, 7), TotalPrice = 3.00m, Location = "D-0007", Status = OrderStatus.Pending },
                new Order { OrderId = 2008, BuyerId = "54444444-4444-4444-4444-444444444444", DelivererId = null, OrderDate = new DateTime(2024, 5, 8), TotalPrice = 4.00m, Location = "D-0008", Status = OrderStatus.Pending },
                new Order { OrderId = 2009, BuyerId = "65555555-5555-5555-5555-555555555555", DelivererId = null, OrderDate = new DateTime(2024, 5, 9), TotalPrice = 2.00m, Location = "D-0009", Status = OrderStatus.Pending }
            );

            // Order Items
            modelBuilder.Entity<OrderItem>().HasData(
                // Delivered
                new OrderItem { OrderItemId = 1, OrderId = 2001, ProductId = 1, Quantity = 2, UnitPrice = 3.00m },
                new OrderItem { OrderItemId = 2, OrderId = 2002, ProductId = 2, Quantity = 2, UnitPrice = 2.00m },
                new OrderItem { OrderItemId = 3, OrderId = 2003, ProductId = 5, Quantity = 1, UnitPrice = 5.00m },
                new OrderItem { OrderItemId = 4, OrderId = 2004, ProductId = 8, Quantity = 1, UnitPrice = 2.00m },
                new OrderItem { OrderItemId = 5, OrderId = 2005, ProductId = 9, Quantity = 1, UnitPrice = 2.00m },
                new OrderItem { OrderItemId = 6, OrderId = 2006, ProductId = 6, Quantity = 1, UnitPrice = 3.00m },

                // Pending
                new OrderItem { OrderItemId = 7, OrderId = 2007, ProductId = 9, Quantity = 1, UnitPrice = 3.00m },
                new OrderItem { OrderItemId = 8, OrderId = 2008, ProductId = 5, Quantity = 1, UnitPrice = 4.00m },
                new OrderItem { OrderItemId = 9, OrderId = 2009, ProductId = 2, Quantity = 1, UnitPrice = 2.00m }
            );

            #endregion

            #region EF Relations Fluent API

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Buyer)
                .WithMany(u => u.BoughtOrders)
                .HasForeignKey(o => o.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Deliverer)
                .WithMany(u => u.DeliveredOrders)
                .HasForeignKey(o => o.DelivererId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region DB Indexes

            modelBuilder.Entity<StockReservation>()
                .HasIndex(r => r.ProductId);

            modelBuilder.Entity<StockReservation>()
                .HasIndex(r => r.ReservedAt);

            #endregion

            #region Mass Seed Data

            //add 30 different users, named Client + i

            var extraUsers = new List<ApplicationUser>();
            var extraUserRoles = new List<IdentityUserRole<string>>();

            for (int i = 1; i <= 30; i++)
            {
                var id = $"80000000-0000-0000-0000-{i.ToString("D12")}";
                var email = $"client{i}@test.com";

                extraUsers.Add(new ApplicationUser
                {
                    Id = id,
                    UserName = email,
                    FirstName = $"Client{i}",
                    LastName = $"Testeur",
                    NormalizedUserName = email.ToUpper(),
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = userPassword,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "5149465399"
                });

                extraUserRoles.Add(new IdentityUserRole<string>
                {
                    UserId = id,
                    RoleId = "user-role-id"
                });
            }

            modelBuilder.Entity<ApplicationUser>().HasData(extraUsers);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(extraUserRoles);

            var orders = new List<Order>();
            var orderItems = new List<OrderItem>();
            var rand = new Random();
            int orderId = 3001;
            int itemId = 1001;

            // add 15 pending orders
            
            for (int i = 1; i <= 15; i++)
            {
                var userId = $"80000000-0000-0000-0000-{i.ToString("D12")}";
                var currentOrderId = orderId;

                orders.Add(new Order
                {
                    OrderId = currentOrderId,
                    BuyerId = userId,
                    DelivererId = null,
                    OrderDate = DateTime.Now.AddMinutes(-i * 10),
                    Status = OrderStatus.Pending,
                    TotalPrice = 0, // On calcule à partir des items
                    Location = $"D-{currentOrderId}"
                });

                decimal total = 0;

                var usedProductIds = new HashSet<int>();
                while (usedProductIds.Count < 5)
                {
                    int productId = rand.Next(1, 32); // [1, 31]
                    if (usedProductIds.Contains(productId)) continue;

                    usedProductIds.Add(productId);
                    var unitPrice = rand.Next(1, 9); // simulate unit prices between 1$ and 8$
                    var quantity = rand.Next(1, 4); // simulate quantity between 1 and 3

                    total += unitPrice * quantity;

                    orderItems.Add(new OrderItem
                    {
                        OrderItemId = itemId++,
                        OrderId = currentOrderId,
                        ProductId = productId,
                        Quantity = quantity,
                        UnitPrice = unitPrice
                    });
                }

                orders.Last().TotalPrice = total;

                orderId++;
            }


            // add 50 delivered orders
            for (int i = 0; i < 50; i++)
            {
                var userIndex = (i % 30) + 1;
                var userId = $"80000000-0000-0000-0000-{userIndex.ToString("D12")}";

                orders.Add(new Order
                {
                    OrderId = orderId,
                    BuyerId = userId,
                    DelivererId = "43333333-3333-3333-3333-333333333333",
                    OrderDate = DateTime.Now.AddDays(-i - 10),
                    Status = OrderStatus.Delivered,
                    TotalPrice = 5,
                    Location = $"C-{orderId}"
                });

                orderItems.Add(new OrderItem
                {
                    OrderItemId = itemId++,
                    OrderId = orderId,
                    ProductId = 2,
                    Quantity = 1,
                    UnitPrice = 5
                });

                orderId++;
            }

            // Add 20 canceled orders
            for (int i = 0; i < 20; i++)
            {
                var userIndex = (i % 30) + 1;
                var userId = $"80000000-0000-0000-0000-{userIndex.ToString("D12")}";

                orders.Add(new Order
                {
                    OrderId = orderId,
                    BuyerId = userId,
                    DelivererId = "43333333-3333-3333-3333-333333333333",
                    OrderDate = DateTime.Now.AddDays(-i - 100),
                    Status = OrderStatus.Cancelled,
                    TotalPrice = 2,
                    Location = $"X-{orderId}",
                    CancellationActor = CancellationActor.DeliveryStation,
                    CancellationDate = DateTime.Now.AddDays(-i - 99),
                    CancellingUserId = "42222222-2222-2222-2222-222222222222" // Delivery station
                });

                orderItems.Add(new OrderItem
                {
                    OrderItemId = itemId++,
                    OrderId = orderId,
                    ProductId = 3,
                    Quantity = 1,
                    UnitPrice = 2
                });

                orderId++;
            }

            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<OrderItem>().HasData(orderItems);

            #endregion
        }
    }
}
