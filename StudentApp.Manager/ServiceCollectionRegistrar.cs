using CourseApp.Manager.Course;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentApp.Data;
using StudentApp.Manager.Exam;
using StudentApp.Manager.Repo;
using StudentApp.Manager.Student;
using System.Reflection;

namespace StudentApp.Manager
{
    public static class ServiceCollectionRegistrar
    {
        public static void ConfigAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        public static void ConfigDbContext(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
        public static void ConfigService(this IServiceCollection services)
        {
            services.AddTransient<IStudentManager, StudentManager>();
            services.AddTransient<ICourseManager, CourseManager>();
            services.AddTransient<IExamManager, ExamManager>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}
