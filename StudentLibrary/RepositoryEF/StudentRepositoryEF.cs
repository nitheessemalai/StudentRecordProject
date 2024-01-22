using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLayer.RepositoryEF
{
    public class StudentRepositoryEF : IStudentRepositoryEF
    {
       

         public IEnumerable<StudentDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public StudentDetails GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public void Create(StudentDetails data)
        {
            throw new NotImplementedException();
        }
        public void Update(StudentDetails value)
        {
            throw new NotImplementedException();
        }
        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
