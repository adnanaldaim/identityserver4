using FluentValidation;
using StudentApp.Object.DTOs.Course;

namespace StudentApp.API.Validations
{
    public class CourseValidator
    {
        public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
        {
            public CreateCourseDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().NotNull();
            }
        }
        public class EditCourseDtoValidator : AbstractValidator<EditCourseDto>
        {
            public EditCourseDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().NotNull();
            }
        }
    }
}
