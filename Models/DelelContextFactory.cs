//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Options;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Models
//{


//    public class DelelContextFactory : IDesignTimeDbContextFactory<DelelContext>
//    {
//        public DelelContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<DelelContext>();
//            optionsBuilder.UseSqlServer("Data source = REEM-ASHRAF; Initial catalog = DaleLDB; Integrated security= true; trustservercertificate = true;MultipleActiveResultSets=True",
//                b => b.MigrationsAssembly(typeof(DelelContext).Assembly.FullName));

//            return new DelelContext(optionsBuilder.Options);
//        }

//    }
//}

