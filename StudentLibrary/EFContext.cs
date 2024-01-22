using EFDataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;

namespace StudentLibrary
{
    public class EFContext: DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        public DbSet<StudentDetails> Student { get; set; }
    }
}
