using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDbApp
{
    class Student
    {
        static string? connectionString = "server=localhost;userid=root;password=naveen1*;database=studb";
        MySqlConnection connection=new MySqlConnection(connectionString);
        String? cmd;
        MySqlCommand? command;
        MySqlDataReader? reader;
        
        string? name;
        string? roll_no;
        int? age ;
        public void student_entry()
        {
            Console.WriteLine("---Student Profile---");
            Console.WriteLine("---Student Name---");
            name = Console.ReadLine();
            Console.WriteLine("---Student roll number---");
            roll_no = Console.ReadLine();
            Console.WriteLine("---Student Age---");
            age = Convert.ToInt32(Console.ReadLine());
            try
            {
                connection.Open();
                cmd = "insert into studentdetail(name,roll_no,age)values(@name,@roll_no,@age)";
                command = new MySqlCommand(cmd, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@roll_no", roll_no);
                command.Parameters.AddWithValue("@age", age);
                command.Prepare();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void student_info()
        {
            Console.WriteLine("---Student Profile---");
            try
            {
                connection.Open ();
                cmd = "select * from studentdetail";
                command = new MySqlCommand(cmd, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine(reader.GetName(0) + "\t" + reader.GetName(1) + "\t\t" + reader.GetName(2) + "\t" + reader.GetName(3));
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetInt32(0) + "\t" + reader.GetString(1) + "\t" + reader.GetString(2) + "\t" + reader.GetString(3));
                    }
                }
                connection.Close();
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void updateprofile()
        {
            Console.WriteLine("---Update Profile---");
            Console.WriteLine("Enter the id to update the record");
            int id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Upadte the roll_no of the student");
            roll_no=Console.ReadLine();
            Console.WriteLine("Update the age of the student");
            age = Convert.ToInt32(Console.ReadLine());
            try
            {
                connection.Open();
                cmd = "update studentdetail set roll_no='" + roll_no + "',age='" + age + "' where id='" + id + "'";
                command = new MySqlCommand(cmd, connection);
                command.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("updated Successfully");
                student_info();

            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void deleteprofile()
        {
            Console.WriteLine("Enter the id to be deleted");
            int id=Convert.ToInt32(Console.ReadLine());
            try
            {
                connection.Open();
                cmd = "delete from studentdetail where id='" + id + "'";
                command = new MySqlCommand(cmd, connection);
                command.ExecuteNonQuery();
                connection.Close();
                student_info();
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
