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


    public class DelelContextFactory : IDesignTimeDbContextFactory<DelelContext>
    {
        public DelelContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DelelContext>();
            optionsBuilder.UseSqlServer("workstation id=DalelDB.mssql.somee.com;packet size=4096;user id=mahmoud_ms20_SQLLogin_3;pwd=bd6swv2t81;data source=DalelDB.mssql.somee.com;persist security info=False;initial catalog=DalelDB;TrustServerCertificate=True",
                b => b.MigrationsAssembly(typeof(DelelContext).Assembly.FullName));

//            return new DelelContext(optionsBuilder.Options);
//        }

//    }
//}

