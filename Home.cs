using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDbApp
{
    internal class Home
    {
        Student student=new Student();
        int option;
        public void HomePage()
        {
            Console.WriteLine("Welcome to Student Management");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. View Profile");
            Console.WriteLine("3. Update Profile");
            Console.WriteLine("4. Delete Profile");
            Console.WriteLine("5. Exit");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter Your Option");
            option=Convert.ToInt32(Console.ReadLine()); 
            if(option<0 || option>6)
            {
                Console.WriteLine("---You Entered the Wrong option---");
                Console.WriteLine("Please Enter correct One For Ex: 1/2/3/4/5");
                option= Convert.ToInt32(Console.ReadLine());
            }
            if(option==1)
            {
                student.student_entry();
                Console.WriteLine("Successfully Registered");
                HomePage();
            }
            if (option==2)
            {
                student.student_info();
                HomePage();
            }
            if(option==3)
            {
                student.updateprofile();
               HomePage() ;
            }
            if (option == 4)
            {
                student.deleteprofile();
                HomePage();
            }
            if(option==5)
            {
                Environment.Exit(0);
            }
        }
    }
}
