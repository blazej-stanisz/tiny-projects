using System.Collections.Generic;

namespace EFCFTest.Model
{
    public class Standard
    {
        public Standard()
        {
        }

        public int Id { get; set; }
        public string StandardName { get; set; }

        public IList<Student> Students { get; set; }
    }
}
