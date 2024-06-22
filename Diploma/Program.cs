using Diploma.BLL;
using Diploma.DAL;
using Diploma.DAL.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ISettingDAL, SettingDAL>();
builder.Services.AddSingleton<IStudentDAL, StudentDAL>();
builder.Services.AddSingleton<ITeacherDAL, TeacherDAL>();
builder.Services.AddScoped<IDiplomaBLL, DiplomaBLL>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
/*using (var connection = new DBHelper())
{
    //Student student = new Student{Name = "Илья", Nomination = "1 место", Organisation = "дет сад", Place = "Уфа"};
    TextSettings setting1 = new TextSettings{fontSize = 64, x = 750, y = 600};
    TextSettings setting2 = new TextSettings{fontSize = 64, x = 750, y = 700};
    TextSettings setting3 = new TextSettings{fontSize = 64, x = 750, y = 800};
    TextSettings setting4 = new TextSettings{fontSize = 64, x = 750, y = 900};
    TextSettings setting5 = new TextSettings{fontSize = 64, x = 750, y = 900};
    //connection.Students.Add(student);
    connection.TextSettings.AddRange(setting1, setting2, setting3, setting4, setting5);
    connection.SaveChanges();
}*/
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();