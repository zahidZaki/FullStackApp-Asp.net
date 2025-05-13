using FullStackApp.Api.Hubs;
using FullStackApp.BLL.Interface;
using FullStackApp.BLL.Service;
using FullStackApp.Utils.MappingProfiles;
using Microsoft.EntityFrameworkCore;
using ProjectForLearing.DLL.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddAutoMapper(typeof(StudentProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// 👇 Add SignalR endpoint
//app.MapHub<SchoolHub>("/schoolhub");
app.UseHttpsRedirection();
builder.Services.AddSignalR();
app.UseAuthorization();

app.MapControllers();
app.MapHub<SchoolHub>("/schoolHub");
app.Run();
