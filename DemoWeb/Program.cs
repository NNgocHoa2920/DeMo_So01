using DemoWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); //tạo ra ứng dụng web

// Add services to the container.
builder.Services.AddDbContext<CategoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews(); // add service
//khi add service thì add dưới var builder và trê var app

var app = builder.Build(); // chạy web lên

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // cấu hình điều hướng https
app.UseStaticFiles(); // sử dụng tài nguyên tĩnh

app.UseRouting(); // cấu hình định tuyến cho mô hfnh mvc

app.UseAuthorization();//cơ chế chưng thực trong quyền

//caasu hình cách thức truy cập
// https:localhosst1234/ controlerName/ actioneName/{id}
//https.../ sanpham/ deteal/{1}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
