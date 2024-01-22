using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLayer.RepositoryEF
{
    public  interface IStudentRepositoryEF
    {
        public IEnumerable<StudentDetails> GetAll();
        public StudentDetails GetById(long Id);
        public void Create(StudentDetails data);
        public void Update(StudentDetails value);
        public void Delete(long Id);
    }
}
