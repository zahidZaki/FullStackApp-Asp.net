using System; // .NET ka base namespace jo Console, String, etc. provide karta hai
using System.Data.SqlClient; // SQL Server ke objects (SqlConnection, SqlCommand etc.) ke liye zaroori namespace

class Program
{
    public static void Main(string[] args) // Entry point method, program yahin se start hota hai
    {
        // SQL Server ke connection string manually define ki gayi hai jisme server, database aur auth method diya gaya hai
        string connectionString = "Server=ZAHID-GUL\\SQLEXPRESS;Database=SQLConnectivity;Integrated Security=true";

        // SqlConnection object create kiya gaya hai, jo SQL Server se connection banayega
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // SQL connection open kiya ja raha hai, iske bina aage koi query nahi chal sakti
                connection.Open();
                Console.WriteLine("✅ Connection opened successfully.\n"); // Agar connection sahi se open ho jaye to message print kare

                // Existing employee records dikhane ke liye function call
                DisplayAllEmployees(connection);

                // Naya employee insert karne ke liye InsertQuery function call, dynamic name aur job ke sath
                InsertQuery(connection, "Ali Khan", "Software Engineer");

                // Insert kiye gaye employee ka job update karne ke liye function call
                UpdateEmployeeJob(connection, "Ali Khan", "Senior Developer");

                // ID = 1 wale employee ko delete karne ke liye function call
                DeleteEmployeeById(connection, 1);

                // Dubara se sabhi employees ko SELECT karne ke liye function call
                SelectQuery(connection);

                // Total employees ki count nikalne ke liye function call
                ShowEmployeeCount(connection);

                // Sabse zyada salary wale employee ki salary dikhane ke liye
                ShowMaxSalary(connection);

                // Sabse kam salary wale employee ki salary dikhane ke liye
                ShowMinSalary(connection);

                // Average salary nikalne ke liye
                ShowAvgSalary(connection);

                // Total salary ka sum nikalne ke liye
                ShowTotalSalary(connection);

                // Har job title ke hisaab se employees ki count dikhane ke liye
                ShowEmployeeCountByJob(connection);

                // Employees ko unke departments ke saath dikhane ke liye JOIN query ka function call
                ShowEmployeesWithDepartments(connection);

                // Transaction ke through safe insert karne ka function call
                InsertEmployeeWithTransaction(connection, "Sara Ahmed", "Project Manager");

                // Jab sab kuch successfully complete ho jaye to success message print kare
                Console.WriteLine("\n🎉 All operations completed successfully!");
            }
            catch (SqlException ex) // Agar koi SQL error aaye to is block mein catch hoga
            {
                Console.WriteLine("❌ SQL Error: " + ex.Message); // Error message print kare
            }
            finally
            {
                // Hamesha, chahe error aaye ya na aaye, SQL connection ko close karna chahiye
                connection.Close();
                Console.WriteLine("🔒 Connection closed."); // Connection band hone ka message
            }
        }




        // ✅ SELECT query: Tamam employee records fetch karta hai
        static void SelectQuery(SqlConnection connection)
        {
            try
            {
                // Query define karte hain
                string sqlSelect = "SELECT * FROM Employees";

                // SqlCommand banate hain query aur connection ke sath
                using (SqlCommand command = new SqlCommand(sqlSelect, connection))
                {
                    // Reader object banate hain jo records ko line by line read karega
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) // Jab tak records milte rahen, loop chalayen
                        {
                            // Console par Id, Name, Job display karte hain
                            Console.WriteLine($"{reader["Id"]}, {reader["Name"]}, {reader["Job"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in SelectQuery: " + ex.Message);
            }
        }

        // ✅ INSERT query: Naya employee record insert karta hai
        static void InsertQuery(SqlConnection connection, string name, string job)
        {
            try
            {
                string SqlInsert = "INSERT INTO Employees (Name, Job) VALUES (@Name, @Job)"; // Query define karte hain

                using (SqlCommand command = new SqlCommand(SqlInsert, connection)) // Command object banate hain
                {
                    command.Parameters.AddWithValue("@Name", name); // Name parameter assign karte hain
                    command.Parameters.AddWithValue("@Job", job);   // Job parameter assign karte hain

                    int rowsAffected = command.ExecuteNonQuery(); // Query execute karte hain aur rows count nikalte hain
                    Console.WriteLine($"{rowsAffected} row(s) inserted."); // Console par result show karte hain
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in InsertQuery: " + ex.Message);
            }
        }

        // ✅ UPDATE query: Employee ka job update karta hai name ke basis par
        static void UpdateEmployeeJob(SqlConnection connection, string name, string newJob)
        {
            try
            {
                string sqlUpdate = "UPDATE Employees SET Job = @Job WHERE Name = @Name"; // Query define karte hain

                using (SqlCommand command = new SqlCommand(sqlUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Job", newJob);   // Naya job assign karte hain
                    command.Parameters.AddWithValue("@Name", name);   // Name ke basis par record select hota hai

                    int rowsAffected = command.ExecuteNonQuery(); // Query execute karte hain
                    Console.WriteLine($"{rowsAffected} row(s) updated.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in UpdateEmployeeJob: " + ex.Message);
            }
        }

        // ✅ DELETE query: ID ke basis par employee delete karta hai
        static void DeleteEmployeeById(SqlConnection connection, int Id)
        {
            try
            {
                string sqlDelete = "DELETE FROM Employees WHERE Id = @Id"; // Query define

                using (SqlCommand command = new SqlCommand(sqlDelete, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id); // ID parameter assign karte hain
                    int rowsAffected = command.ExecuteNonQuery(); // Execute karte hain
                    Console.WriteLine($"{rowsAffected} row(s) deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in DeleteEmployeeById: " + ex.Message);
            }
        }

        // ✅ SELECT * for display: Tamam employee data dikhata hai
        static void DisplayAllEmployees(SqlConnection connection)
        {
            try
            {
                string sqlSelect = "SELECT * FROM Employees";

                using (SqlCommand command = new SqlCommand(sqlSelect, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("\n📋 Employee List:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]}, {reader["Name"]}, {reader["Job"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in DisplayAllEmployees: " + ex.Message);
            }
        }

        // ✅ COUNT aggregate function: Total employees count karta hai
        static void ShowEmployeeCount(SqlConnection connection)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM Employees";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int count = (int)command.ExecuteScalar(); // Single value return hoti hai
                    Console.WriteLine($"\n👥 Total number of employees: {count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in ShowEmployeeCount: " + ex.Message);
            }
        }

        // ✅ MAX aggregate: Sabse zyada salary show karta hai
        static void ShowMaxSalary(SqlConnection connection)
        {
            try
            {
                string sql = "SELECT MAX(Salary) FROM Employees";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    decimal maxSalary = (decimal)command.ExecuteScalar();
                    Console.WriteLine($"💰 Maximum salary: {maxSalary}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in ShowMaxSalary: " + ex.Message);
            }
        }

        // ✅ MIN aggregate: Sabse kam salary
        static void ShowMinSalary(SqlConnection connection)
        {
            try
            {
                string sql = "SELECT MIN(Salary) FROM Employees";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    decimal minSalary = (decimal)command.ExecuteScalar();
                    Console.WriteLine($"💸 Minimum salary: {minSalary}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in ShowMinSalary: " + ex.Message);
            }
        }

        // ✅ AVG salary: Average salary return karta hai
        static void ShowAvgSalary(SqlConnection connection)
        {
            try
            {
                string sql = "SELECT AVG(Salary) FROM Employees";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    decimal avgSalary = (decimal)command.ExecuteScalar();
                    Console.WriteLine($"📊 Average salary: {avgSalary}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in ShowAvgSalary: " + ex.Message);
            }
        }

        // ✅ SUM salary: Total salary ka sum karta hai
        static void ShowTotalSalary(SqlConnection connection)
        {
            try
            {
                string sql = "SELECT SUM(Salary) FROM Employees";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    decimal totalSalary = (decimal)command.ExecuteScalar();
                    Console.WriteLine($"🧾 Total salary: {totalSalary}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in ShowTotalSalary: " + ex.Message);
            }
        }

        // ✅ GROUP BY Job: Job ke mutabiq employee count karta hai
        static void ShowEmployeeCountByJob(SqlConnection connection)
        {
            try
            {
                string sql = "SELECT Job, COUNT(*) AS Count FROM Employees GROUP BY Job";
                using (SqlCommand command = new SqlCommand(sql, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("\n🧑‍💼 Employees by Job:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Job"]}: {reader["Count"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in ShowEmployeeCountByJob: " + ex.Message);
            }
        }

        // ✅ JOIN: Employees aur unke department names show karta hai
        static void ShowEmployeesWithDepartments(SqlConnection connection)
        {
            try
            {
                string sql = @"SELECT e.Name, d.DepartmentName FROM Employees e JOIN Departments d ON e.DepartmentId = d.Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("\n🏢 Employee with Department:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} — {reader["DepartmentName"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in ShowEmployeesWithDepartments: " + ex.Message);
            }
        }

        // ✅ Transaction: Secure insert karta hai jahan ya toh poora insert ho ya kuch bhi nahi ho
        static void InsertEmployeeWithTransaction(SqlConnection connection, string name, string job)
        {
            SqlTransaction transaction = connection.BeginTransaction(); // Transaction start karte hain

            try
            {
                string sql = "INSERT INTO Employees (Name, Job) VALUES (@Name, @Job)";
                using (SqlCommand command = new SqlCommand(sql, connection, transaction))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Job", job);

                    int rowsAffected = command.ExecuteNonQuery(); // Insert hota hai
                    transaction.Commit(); // Agar successful ho toh commit karte hain

                    Console.WriteLine($"✅ {rowsAffected} row(s) inserted in transaction.");
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Agar koi error aaye toh transaction rollback hoti hai
                Console.WriteLine("❌ Transaction failed: " + ex.Message);
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