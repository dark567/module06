using ModuleBL.Models;
using ModuleDal;
using ModuleDal.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ModuleBL
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentModel GetById(int id)
        {
            var studentEntity = _studentRepository.GetById(id);

            if (studentEntity == null)
                throw new ArgumentException("Student not found");

            var resultStudent = new StudentModel
            {
                FirstName = studentEntity.FirstName,
                LastName = studentEntity.LastName,
            };

            resultStudent.Payments = studentEntity.Payments.Select(payment => new PaymentModel
            {
                Student = resultStudent,
                Value = payment.Value,
                Date = payment.Date
            });

            return resultStudent;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StudentModel> GetWhoMinPay(int sum)
        {
            var studentsEntity = _studentRepository.GetAll();

            if (studentsEntity == null)
                throw new ArgumentException("studentsEntity null");

            var resultStudent = new List<StudentModel>();

            studentsEntity = studentsEntity.Where(x => x.Payments.Select(pay => pay.Value).Sum() < sum).ToList(); 



            foreach (var studEntity in studentsEntity)
            {
                resultStudent.Add(new StudentModel
                {
                    FirstName = studEntity.FirstName,
                    LastName = studEntity.LastName,
                    Age = studEntity.Age,
                    Payments = studEntity.Payments.Select(pay => new PaymentModel
                    {
                        Value = pay.Value,
                        Date = pay.Date
                    })
                });
            }

            return resultStudent;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        public void CreateStudent(StudentModel student)
        {
            if (!student.Payments.Any())
                throw new ArgumentException("No Payments");

            Student studentDAL = new Student() { Payments = new List<Payment>() };
            studentDAL.FirstName = student.FirstName;
            studentDAL.LastName = student.LastName;
            studentDAL.Age = student.Age;
            var payments = student.Payments;

            foreach (var payment in payments)
            {
                studentDAL.Payments.Add(new Payment { Date = payment.Date, Value = payment.Value });
            }

            _studentRepository.AddStudents(studentDAL);
        }
    }
}
