using System;
using System.Data.SqlClient;

class Program
{
    public static void Main(string[] args)
    {
        // SqlConnectionStringBuilder se connection string banata hai,
        // jisme server name, database name aur authentication ki details hoti hain.
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "ZAHID-GUL\\SQLEXPRESS"; // SQL Server ka naam ya instance
        builder.InitialCatalog = "SQLConnectivity";   // Database ka naam
        builder.IntegratedSecurity = true;            // Windows Authentication use kar raha hai

        // SqlConnection object banata hai jo SQL Server se connect karega
        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
            try
            {
                connection.Open();  // Connection open karta hai database ke saath

                // SELECT query chalakar Employees table ke tamam records read kar raha hai
                string sqlSelect = "SELECT * FROM Employees";
                using (SqlCommand command = new SqlCommand(sqlSelect, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) // Har record ke liye loop
                        {
                            // Console par Id, Name, Job print karta hai
                            Console.WriteLine($"{reader["Id"]}, {reader["Name"]}, {reader["Job"]}");
                        }
                    }
                }

                // INSERT query chalakar Employees table mein ek naya record add karta hai
                string SqlInsert = "INSERT INTO Employees (Name, Job) VALUES ('John Doe', 'Software Engineer')";
                using (SqlCommand command = new SqlCommand(SqlInsert, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery(); // ExecuteNonQuery: insert/update/delete ke liye
                    Console.WriteLine($"{rowsAffected} row(s) inserted.");  // Kitni rows insert hui wo batata hai
                }

                // UPDATE query se John Doe ke Job ko update kar raha hai
                string sqlUpdate = "UPDATE Employees SET Job = 'Senior Software Engineer' WHERE Name = 'John Doe'";
                using (SqlCommand command = new SqlCommand(sqlUpdate, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) updated.");
                }

                // DELETE query se John Doe ka record delete kar raha hai
                string sqlDelete = "DELETE FROM Employees WHERE Name = 'John Doe'";
                using (SqlCommand command = new SqlCommand(sqlDelete, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) deleted.");
                }

                // Phir se SELECT query chalakar Employees ke records dikhata hai
                string sqlSelectAfter = "SELECT * FROM Employees";
                using (SqlCommand command = new SqlCommand(sqlSelectAfter, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Id"]}, {reader["Name"]}, {reader["Job"]}");
                        }
                    }
                }

                // COUNT aggregate function se total employees ki count nikalta hai
                string sqlSelectCount = "SELECT COUNT(*) FROM Employees";
                using (SqlCommand command = new SqlCommand(sqlSelectCount, connection))
                {
                    int count = (int)command.ExecuteScalar(); // ExecuteScalar: single value return karta hai
                    Console.WriteLine($"Total number of employees: {count}");
                }

                // MAX aggregate function se maximum salary nikalta hai
                string sqlSelectMax = "SELECT MAX(Salary) FROM Employees";
                using (SqlCommand command = new SqlCommand(sqlSelectMax, connection))
                {
                    decimal maxSalary = (decimal)command.ExecuteScalar();
                    Console.WriteLine($"Maximum salary: {maxSalary}");
                }

                // MIN aggregate function se minimum salary nikalta hai
                string sqlSelectMin = "SELECT MIN(Salary) FROM Employees";
                using (SqlCommand command = new SqlCommand(sqlSelectMin, connection))
                {
                    decimal minSalary = (decimal)command.ExecuteScalar();
                    Console.WriteLine($"Minimum salary: {minSalary}");
                }

                // AVG aggregate function se average salary nikalta hai
                string sqlSelectAvg = "SELECT AVG(Salary) FROM Employees";
                using (SqlCommand command = new SqlCommand(sqlSelectAvg, connection))
                {
                    decimal avgSalary = (decimal)command.ExecuteScalar();
                    Console.WriteLine($"Average salary: {avgSalary}");
                }

                // SUM aggregate function se total salary ka sum nikalta hai
                string sqlSelectSum = "SELECT SUM(Salary) FROM Employees";
                using (SqlCommand command = new SqlCommand(sqlSelectSum, connection))
                {
                    decimal totalSalary = (decimal)command.ExecuteScalar();
                    Console.WriteLine($"Total salary: {totalSalary}");
                }

                // GROUP BY se job ke mutabiq employees ki count nikalta hai
                string sqlSelectGroupBy = "SELECT Job, COUNT(*) FROM Employees GROUP BY Job";
                using (SqlCommand command = new SqlCommand(sqlSelectGroupBy, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Har job title aur us job ke employees ki count print karta hai
                            Console.WriteLine($"{reader["Job"]}, {reader[1]}");
                        }
                    }
                }

                // JOIN query se Employees aur Departments table ko join karta hai, taake department name bhi mile
                string sqlSelectJoin = "SELECT e.Name, d.DepartmentName FROM Employees e JOIN Departments d ON e.DepartmentId = d.Id";
                using (SqlCommand command = new SqlCommand(sqlSelectJoin, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Employee ka naam aur uska department name print karta hai
                            Console.WriteLine($"{reader["Name"]}, {reader["DepartmentName"]}");
                        }
                    }
                }

                // Transaction ka example: ek transaction mein insert kar raha hai
                string sqlSelectTransaction = "BEGIN TRANSACTION; INSERT INTO Employees (Name, Job) VALUES ('Jane Doe', 'Project Manager'); COMMIT;";
                using (SqlCommand command = new SqlCommand(sqlSelectTransaction, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) inserted in transaction.");
                }

                Console.WriteLine("Connection successful!");
            }
            catch (SqlException ex)
            {
                // Agar koi SQL error aaye to woh catch block mein aayega
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Chahe error aaye ya na aaye, connection ko close karna zaroori hai
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }
    }
}
/*
 
                Summary aur Kyu?
        SqlConnectionStringBuilder se connection string dynamic aur safe banti hai.

        Open() se connection start hoti hai database ke saath.

        SELECT queries se data retrieve karte hain aur display karte hain.

        INSERT, UPDATE, DELETE queries se data modify karte hain.

        ExecuteNonQuery() un queries ke liye jo data modify karti hain, aur affected rows return karti hain.

        ExecuteScalar() queries mein jab sirf ek single value chahiye, jaise count, max, min, avg, sum.

        Transactions se multiple operations ek atomic unit mein karte hain (all succeed or fail).

        Exception handling SQL errors ko catch karne ke liye zaroori hai.

        Connection ko close karna resource leak se bachata hai.

 */