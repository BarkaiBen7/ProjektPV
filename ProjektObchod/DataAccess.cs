using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;

namespace ProjektObchod
{
    internal class DataAccess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void InsertCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (Name, Email, RegistrationDate) VALUES (@Name, @Email, @RegistrationDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@RegistrationDate", customer.RegistrationDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "SELECT * FROM Customers WHERE ID = @Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                Customer customer = null;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customer = new Customer
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            RegistrationDate = (DateTime)reader["RegistrationDate"]
                        };
                    }
                }
                return customer;
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Customers SET Name = @Name, Email = @Email, RegistrationDate = @RegistrationDate WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", customer.ID);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@RegistrationDate", customer.RegistrationDate);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "DELETE FROM Customers WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Products (Name, Price, InStock) VALUES (@Name, @Price, @InStock)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@InStock", product.InStock);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public Product GetProductById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "SELECT * FROM Products WHERE ID = @Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                Product product = null;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Price = (float)(double)reader["Price"],
                            InStock = (bool)reader["InStock"]
                        };
                    }
                }
                return product;
            }
        }

        public void UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Products SET Name = @Name, Price = @Price, InStock = @InStock WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", product.ID);
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@InStock", product.InStock);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "DELETE FROM Products WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Orders (CustomerID, OrderDate, Status) VALUES (@CustomerID, @OrderDate, @Status)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@Status", order.Status);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Order GetOrderById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "SELECT * FROM Orders WHERE ID = @Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                Order order = null;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order = new Order
                        {
                            ID = (int)reader["ID"],
                            CustomerID = (int)reader["CustomerID"],
                            OrderDate = (DateTime)reader["OrderDate"],
                            Status = reader["Status"].ToString()
                        };
                    }
                }
                return order;
            }
        }

        public void UpdateOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Orders SET CustomerID = @CustomerID, OrderDate = @OrderDate, Status = @Status WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", order.ID);
                    cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@Status", order.Status);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "DELETE FROM Orders WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertOrderItem(OrderItem orderItem)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO OrderItems (OrderID, ProductID, Quantity) VALUES (@OrderID, @ProductID, @Quantity)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderItem.OrderID);
                    cmd.Parameters.AddWithValue("@ProductID", orderItem.ProductID);
                    cmd.Parameters.AddWithValue("@Quantity", orderItem.Quantity);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public OrderItem GetOrderItemById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "SELECT * FROM OrderItems WHERE ID = @Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                OrderItem orderItem = null;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        orderItem = new OrderItem
                        {
                            ID = (int)reader["ID"],
                            OrderID = (int)reader["OrderID"],
                            ProductID = (int)reader["ProductID"],
                            Quantity = (int)reader["Quantity"]
                        };
                    }
                }
                return orderItem;
            }
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE OrderItems SET OrderID = @OrderID, ProductID = @ProductID, Quantity = @Quantity WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", orderItem.ID);
                    cmd.Parameters.AddWithValue("@OrderID", orderItem.OrderID);
                    cmd.Parameters.AddWithValue("@ProductID", orderItem.ProductID);
                    cmd.Parameters.AddWithValue("@Quantity", orderItem.Quantity);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrderItem(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "DELETE FROM OrderItems WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertSupplier(Supplier supplier)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Suppliers (Name, Phone) VALUES (@Name, @Phone)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", supplier.Name);
                    cmd.Parameters.AddWithValue("@Phone", supplier.Phone);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public Supplier GetSupplierById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "SELECT * FROM Suppliers WHERE ID = @Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                Supplier supplier = null;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        supplier = new Supplier
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Phone = reader["Phone"].ToString()
                        };
                    }
                }
                return supplier;
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Suppliers SET Name = @Name, Phone = @Phone WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", supplier.ID);
                    cmd.Parameters.AddWithValue("@Name", supplier.Name);
                    cmd.Parameters.AddWithValue("@Phone", supplier.Phone);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSupplier(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "DELETE FROM Suppliers WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ImportCustomersFromCsv(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var customers = csv.GetRecords<Customer>();
                foreach (var customer in customers)
                {
                    InsertCustomer(customer);
                }
            }
        }

        public void ImportProductsFromCsv(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var products = csv.GetRecords<Product>();
                foreach (var product in products)
                {
                    InsertProduct(product);
                }
            }
        }
        public void ImportOrdersFromCsv(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var orders = csv.GetRecords<Order>();
                foreach (var order in orders)
                {
                    InsertOrder(order);
                }
            }
        }

        public void ImportOrderItemsFromCsv(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var orderItems = csv.GetRecords<OrderItem>();
                foreach (var item in orderItems)
                {
                    InsertOrderItem(item);
                }
            }
        }

        public void ImportSuppliersFromCsv(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var suppliers = csv.GetRecords<Supplier>();
                foreach (var supplier in suppliers)
                {
                    InsertSupplier(supplier);
                }
            }
        }
    }
}