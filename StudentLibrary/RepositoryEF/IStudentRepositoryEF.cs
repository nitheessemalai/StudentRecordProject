using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLayer.RepositoryEF
{
    public  interface IStudentRepositoryEF
    {
        public IEnumerable<StudentDetails> GetAllDetails();
        public StudentDetails GetbyID(long studentid);
        public void Insert(StudentDetails stud);
        public void Update(int id, StudentDetails stud);
        public void Delete(int studentId);
    }
}
