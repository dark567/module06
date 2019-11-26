using ModuleBL;
using ModuleBL.Models;
using ModulePL.PostModels;
using ModulePL.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ModulePL
{
    public class StudentsController
    {
        public StudentViewModel GetById(int id)
        {
            var service = new StudentService();

            var student = service.GetById(id);

            return new StudentViewModel
            {
                Age = student.Age.GetValueOrDefault(),
                FullName = $"{student.FirstName} {student.LastName}",
                Payments = student.Payments.Select(payment => new PaymentViewModel
                {
                    Date = payment.Date,
                    Value = payment.Value
                })
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        public void Create(StudentPl student)
        {
            var studentModel = new StudentModel()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Payments = student.Payments.Select(p => new PaymentModel
                {
                    Date = p.Date,
                    Value = p.Value
                })
            };
            var service = new StudentService();
            service.CreateStudent(studentModel);

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public List<StudentViewModel> StudentWhoPayLess(int sum)
        {
            var result = new List<StudentViewModel>();
            var service = new StudentService();
            var studentsBl = service.GetWhoMinPay(sum);

            foreach (var studentBl in studentsBl)
            {
                result.Add(
                    new StudentViewModel
                    {
                        Age = studentBl.Age.GetValueOrDefault(),
                        FullName = $"{studentBl.FirstName} {studentBl.LastName}",
                        Payments = studentBl.Payments.Select(payment => new PaymentViewModel
                        {
                            Date = payment.Date,
                            Value = payment.Value
                        })
                    });
            }
            return result;
        }


    }
}
