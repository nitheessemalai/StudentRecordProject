using Microsoft.EntityFrameworkCore;
using StudentLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLayer.RepositoryEF
{
    public class StudentRepositoryEF : IStudentRepositoryEF
    {

       
            private readonly EFContext _contxt;
            public StudentRepositoryEF(EFContext contxt)
            {
                _contxt = contxt;

            }
            public void Insert(StudentDetails stud)
            {
                try
                {
                    _contxt.Database.ExecuteSqlRaw($"exec studentsInsert '{stud.Name}','{stud.DOB}',{stud.Age},'{stud.Gender}',{stud.Mobile} ,'{stud.Email}','{stud.Subject}'");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            public void Update(int ID, StudentDetails stud)
            {
                try
                {
                    var result = _contxt.Database.ExecuteSqlRaw($" exec updatestudents set Name='{stud.Name}',DOB='{stud.DOB}',Age={stud.Age},Gender='{stud.Gender}',Mobile='{stud.Mobile}', Emailid='{stud.Email}',Subject='{stud.Subject}' where StudentID={ID} ");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            public void Delete(int studentID)
            {
                try
                {
                    _contxt.Database.ExecuteSqlRaw($"delete Student where StudentID={studentID}");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            public IEnumerable<StudentDetails> GetAllDetails()
            {
                try
                {
                    var result = _contxt.Student.FromSqlRaw("select * from Student").ToList();
                    return result;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            public StudentDetails GetbyID(int studentid)
            {
                try
                {
                    var result = _contxt.Student.FromSqlRaw<StudentDetails>($"select * from Student where StudentID={studentid}");
                    return result.ToList().FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }