﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return studentDbContext.Students.Include(s => s.StudentGuarantors).FirstOrDefault(s => s.Id == Id);
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

        public Student UpdateStudent(Student studentUpdate)
        {
            var student = studentDbContext.Students.Attach(studentUpdate);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            studentDbContext.SaveChanges();
            return studentUpdate;
        }

        public List<StudentGuarantor> GetSG(Guid id)
        {
            return studentDbContext.StudentGuarantors.Include(sg => sg.Guarantor).Where(sg => sg.GuarantorId == id).ToList();
        }
    }
}
