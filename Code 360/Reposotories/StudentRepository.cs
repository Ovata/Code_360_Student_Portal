﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models
{
    public class StudentRepository : IStudentRepository
    {
        private StudentDbContext studentDbContext;

        public StudentRepository(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        public Student AddStudent(Student _student)
        {
            studentDbContext.Students.Add(_student);
            studentDbContext.SaveChanges();
            return _student;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return studentDbContext.Students;
        }

        public Student GetStudent(Guid Id)
        {
            return studentDbContext.Students.Find(Id);
        }

        public Student RemoveStudent(Guid Id)
        {
            Student student = studentDbContext.Students.Find(Id);
            if (student != null)
            {
                studentDbContext.Students.Remove(student);
                studentDbContext.SaveChanges();
            }
            return student;
        }

        public IEnumerable<StudentGuarantor> StudentGuarantors(Guid Id)
        {
            return studentDbContext.StudentGuarantors.Where(sg => sg.StudentId == Id).ToList();
        }

        public Student UpdateStudent(Student studentUpdate)
        {
            var student = studentDbContext.Students.Attach(studentUpdate);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            studentDbContext.SaveChanges();
            return studentUpdate;
        }
    }
}