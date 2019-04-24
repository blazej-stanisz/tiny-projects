using EFCFTest.DatabaseContext;
using EFCFTest.Model;
using System;
using System.Linq;

namespace EFCFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new TestContext())
            {
                //Student stud = new Student() { StudentName = "New Student",  };
                //ctx.Students.Add(stud);

                ctx.Students.Where(x => x.Id > 0);
                var a = 10;
                //ctx.SaveChanges();
            }
        }
    }
}
