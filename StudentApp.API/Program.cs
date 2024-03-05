using FluentValidation;
using FluentValidation.AspNetCore;
using StudentApp.API.Identity;
using StudentApp.API.Validations;
using StudentApp.Manager;
using StudentApp.Object.DTOs.Course;
using StudentApp.Object.DTOs.Exam;
using StudentApp.Object.DTOs.Student;
using static StudentApp.API.Validations.CourseValidator;
using static StudentApp.API.Validations.ExamValidator;
using static StudentApp.API.Validations.StudentValidator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

ConfigFluentValidation(builder);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddJsonConsole();
});

#region Service Registrar

builder.Services.ConfigDbContext(builder.Configuration);
builder.Services.ConfigAutoMapper();
builder.Services.ConfigService();

#endregion

#region OpenId Client Config

builder.Services.Configure<IdentityServerSettings>(builder.Configuration.GetSection("IdentityServerSettings"));

builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.Authority = "https://localhost:7055";
        options.ApiName = "StudentApp.API";
    });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigFluentValidation(WebApplicationBuilder builder)
{
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddScoped<IValidator<CreateStudentDto>, CreateStudentDtoValidator>();
    builder.Services.AddScoped<IValidator<EditStudentDto>, EditStudentDtoValidator>();

    builder.Services.AddScoped<IValidator<CreateCourseDto>, CreateCourseDtoValidator>();
    builder.Services.AddScoped<IValidator<EditCourseDto>, EditCourseDtoValidator>();


    builder.Services.AddScoped<IValidator<CreateExamDto>, CreateExamDtoValidator>();
    builder.Services.AddScoped<IValidator<EditExamDto>, EditExamDtoValidator>();
}