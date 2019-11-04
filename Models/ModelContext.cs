using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ASP.NETWebAPI.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public List<Dictionary<String, String>> getPureData(String filePath) {
            try {
                using (StreamReader r = new StreamReader(filePath)) {
                    String json = r.ReadToEnd();
                    List<Dictionary<String, String>> items = JsonConvert.DeserializeObject<List<Dictionary<String, String>>>(json);
                    return items;
                }
            } catch (Exception exp) {
                Console.WriteLine(exp.Message);
                return new List<Dictionary<String, String>>();
            }
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            String basePath = System.AppContext.BaseDirectory;

            List<String> filePaths = new List<String>();
            filePaths.Add("\\data\\category.json");
            filePaths.Add("\\data\\customer.json");
            filePaths.Add("\\data\\employee.json");
            filePaths.Add("\\data\\order.json");
            filePaths.Add("\\data\\orderdetail.json");
            filePaths.Add("\\data\\product.json");
            filePaths.Add("\\data\\shipper.json");
            filePaths.Add("\\data\\supplier.json");

            filePaths.ForEach(filePath => {
                String fileAbsPath = basePath + filePath;
                List<Dictionary<String, String>> Data = getPureData(fileAbsPath);
                switch (filePath) {
                    case "\\data\\category.json":
                        Category[] inputCategories = new Category[Data.Count];
                        for(int i = 0; i < Data.Count; i++) {
                            String id = "";
                            String name = "";
                            String description = "";
                            Data[i].TryGetValue("ID", out id);
                            Data[i].TryGetValue("Name", out name);
                            Data[i].TryGetValue("Description", out description);
                            inputCategories[i] = new Category{
                                ID = Convert.ToInt64(id),
                                Name = name,
                                Description = description
                            };
                        }
                        modelBuilder.Entity<Category>().HasData(inputCategories);
                        break;
                    case "\\data\\customer.json":
                        Customer[] inputCustomers = new Customer[Data.Count];
                        for(int i = 0; i < Data.Count; i++) {
                            String id = "";
                            String name = "";
                            String contactName = "";
                            String address = "";
                            String city = "";
                            String postalCode = "";
                            String country = "";
                            Data[i].TryGetValue("ID", out id);
                            Data[i].TryGetValue("Name", out name);
                            Data[i].TryGetValue("ContactName", out contactName);
                            Data[i].TryGetValue("Address", out address);
                            Data[i].TryGetValue("City", out city);
                            Data[i].TryGetValue("PostalCode", out postalCode);
                            Data[i].TryGetValue("Country", out country);
                            inputCustomers[i] = new Customer{
                                ID = Convert.ToInt64(id),
                                Name = name,
                                ContactName = contactName,
                                Address = address,
                                City = city,
                                PostalCode = postalCode,
                                Country = country
                            };
                        }
                        modelBuilder.Entity<Customer>().HasData(inputCustomers);
                        break;
                    case "\\data\\employee.json":
                        Employee[] inputEmployees = new Employee[Data.Count];
                        for(int i = 0; i < Data.Count; i++) {
                            String id = "";
                            String lastName = "";
                            String firstName = "";
                            String birthDate = "";
                            String photo = "";
                            String notes = "";
                            Data[i].TryGetValue("ID", out id);
                            Data[i].TryGetValue("LastName", out lastName);
                            Data[i].TryGetValue("FirstName", out firstName);
                            Data[i].TryGetValue("BirthDate", out birthDate);
                            Data[i].TryGetValue("Photo", out photo);
                            Data[i].TryGetValue("Notes", out notes);
                            inputEmployees[i] = new Employee{
                                ID = Convert.ToInt64(id),
                                LastName = lastName,
                                FirstName = firstName,
                                BirthDate = DateTime.ParseExact(birthDate,"yyyy-MM-dd",null),
                                Photo = photo,
                                Notes = notes
                            };
                        }
                        modelBuilder.Entity<Employee>().HasData(inputEmployees);
                        break;
                    case "\\data\\order.json":
                        Order[] inputOrders = new Order[Data.Count];
                        for(int i = 0; i < Data.Count; i++) {
                            String id = "";
                            String customerID = "";
                            String employeeID = "";
                            String date = "";
                            String shipperID = "";
                            Data[i].TryGetValue("ID", out id);
                            Data[i].TryGetValue("CustomerID", out customerID);
                            Data[i].TryGetValue("EmployeeID", out employeeID);
                            Data[i].TryGetValue("Date", out date);
                            Data[i].TryGetValue("ShipperID", out shipperID);
                            inputOrders[i] = new Order{
                                ID = Convert.ToInt64(id),
                                CustomerID = Convert.ToInt64(customerID),
                                EmployeeID = Convert.ToInt64(employeeID),
                                Date = DateTime.ParseExact(date,"yyyy-MM-dd",null),
                                ShipperID = Convert.ToInt64(shipperID)
                            };
                        }
                        modelBuilder.Entity<Order>().HasData(inputOrders);
                        break;
                    case "\\data\\orderdetail.json":
                        OrderDetail[] inputOrderDetails = new OrderDetail[Data.Count];
                        for(int i = 0; i < Data.Count; i++) {
                            String id = "";
                            String orderID = "";
                            String productID = "";
                            String quantity = "";
                            Data[i].TryGetValue("ID", out id);
                            Data[i].TryGetValue("OrderID", out orderID);
                            Data[i].TryGetValue("ProductID", out productID);
                            Data[i].TryGetValue("Quantity", out quantity);
                            inputOrderDetails[i] = new OrderDetail{
                                ID = Convert.ToInt64(id),
                                OrderID = Convert.ToInt64(orderID),
                                ProductID = Convert.ToInt64(productID),
                                Quantity = Convert.ToInt64(quantity)
                            };
                        }
                        modelBuilder.Entity<OrderDetail>().HasData(inputOrderDetails);
                        break;
                    case "\\data\\product.json":
                        Product[] inputProducts = new Product[Data.Count];
                        for(int i = 0; i < Data.Count; i++) {
                            String id = "";
                            String name = "";
                            String supplierID = "";
                            String categoryID = "";
                            String unit = "";
                            String price = "";
                            Data[i].TryGetValue("ID", out id);
                            Data[i].TryGetValue("Name", out name);
                            Data[i].TryGetValue("SupplierID", out supplierID);
                            Data[i].TryGetValue("CategoryID", out categoryID);
                            Data[i].TryGetValue("Unit", out unit);
                            Data[i].TryGetValue("Price", out price);
                            inputProducts[i] = new Product{
                                ID = Convert.ToInt64(id),
                                Name = name,
                                SupplierID = Convert.ToInt64(supplierID),
                                CategoryID =  Convert.ToInt64(categoryID),
                                Unit = unit,
                                Price = Convert.ToDouble(price)
                            };
                        }
                        modelBuilder.Entity<Product>().HasData(inputProducts);
                        break;
                    case "\\data\\shipper.json":
                        Shipper[] inputShippers = new Shipper[Data.Count];
                        for(int i = 0; i < Data.Count; i++) {
                            String id = "";
                            String name = "";
                            String phone = "";
                            Data[i].TryGetValue("ID", out id);
                            Data[i].TryGetValue("Name", out name);
                            Data[i].TryGetValue("Phone", out phone);
                            inputShippers[i] = new Shipper{
                                ID = Convert.ToInt64(id),
                                Name = name,
                                Phone = phone
                            };
                        }
                        modelBuilder.Entity<Shipper>().HasData(inputShippers);
                        break;
                    case "\\data\\supplier.json":
                        Supplier[] inputSuppliers = new Supplier[Data.Count];
                        for(int i = 0; i < Data.Count; i++) {
                            String id = "";
                            String name = "";
                            String contactName = "";
                            String address = "";
                            String city = "";
                            String postalCode = "";
                            String country = "";
                            String phone = "";
                            Data[i].TryGetValue("ID", out id);
                            Data[i].TryGetValue("Name", out name);
                            Data[i].TryGetValue("ContactName", out contactName);
                            Data[i].TryGetValue("Address", out address);
                            Data[i].TryGetValue("City", out city);
                            Data[i].TryGetValue("PostalCode", out postalCode);
                            Data[i].TryGetValue("Country", out country);
                            Data[i].TryGetValue("Phone", out phone);
                            inputSuppliers[i] = new Supplier{
                                ID = Convert.ToInt64(id),
                                Name = name,
                                ContactName = contactName,
                                Address = address,
                                City = city,
                                PostalCode = postalCode,
                                Country = country,
                                Phone = phone
                            };
                        }
                        modelBuilder.Entity<Supplier>().HasData(inputSuppliers);
                        break;
                    default:
                        break;
                }
            });
            
            /* modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    AuthorId = 1,
                    FirstName = "William",
                    LastName = "Shakespeare"
                }
            ); */
        }
    }
}