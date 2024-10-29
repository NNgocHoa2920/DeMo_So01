
using Microsoft.EntityFrameworkCore;

namespace DemoWeb.Models
{
    //class này là class đại diện cho sql server
    //vây nên ki dùng đên db ví dụ thêm sửa sửa xóa làm ơn lôi cổ nó ra
    public class CategoryDbContext : DbContext
    {
        //tạo các contructor
        //k tham số: ctor + tab
        public CategoryDbContext()
        {
            
        }
        //có tham số: ctr+. => option
        public CategoryDbContext(DbContextOptions options) : base(options)
        {
        }


        //cách 1: dán chuỗi kết nối vào đây

        //ctr + . => generate override => Onconfig(dbcontext)

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=NGUYEN_NGOC_HOA\\HOANN; Database=DbDemo_01;Trusted_Connection= True;" +
        //        "TrustServerCertificate=True");
        //}

        //Tạo luôn dữ liệu vào db nếu muốn
        //nếu  muốn thì thôi vẫn chạy đc
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Ma = 1, Name="Khoai", Description=" Tím"},
               new Category { Ma = 2, Name="Sắn", Description=" Tím"},
               new Category { Ma = 3, Name="Ngô", Description=" Tím"},
               new Category { Ma = 4, Name="Bắp", Description=" Tím"},
               new Category { Ma = 5, Name="Dưa hấu", Description=" Tím"}

            );
        }

        //cách 2: gắn chuỗi kết nối ở appseting
        
          

      



    }
}
