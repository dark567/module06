using ModulePL;
using ModulePL.PostModels;
using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ctrl = new StudentsController();

            var student = ctrl.GetById(1);

            //Console.WriteLine(student.FullName);


            var payments = new List<PaymentPl>();

            payments.Add(new PaymentPl { Date = DateTime.Now, Value = 15500 });
            payments.Add(new PaymentPl { Date = DateTime.Now, Value = 2000 });
            payments.Add(new PaymentPl { Date = DateTime.Now, Value = 2200 });
          

            var addFirstStudent = new StudentPl()
            {
                FirstName = "Ivan",
                LastName = "Shmig",
                Age = 36,
                Payments = payments
            };

            ctrl.Create(addFirstStudent);


            var test = ctrl.StudentWhoPayLess(100000);


            Console.WriteLine(test);

            Console.ReadLine();
        }
    }
}
