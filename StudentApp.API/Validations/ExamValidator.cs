using FluentValidation;
using StudentApp.Object.DTOs.Exam;

namespace StudentApp.API.Validations
{
    public class ExamValidator
    {
        public class CreateExamDtoValidator : AbstractValidator<CreateExamDto>
        {
            public CreateExamDtoValidator()
            {
                RuleFor(x => x.ExamDate).NotEmpty().NotNull();
                RuleFor(x => x.CourseId).NotEmpty().NotNull().NotEqual(0);
            }
        }
        public class EditExamDtoValidator : AbstractValidator<EditExamDto>
        {
            public EditExamDtoValidator()
            {
                RuleFor(x => x.ExamDate).NotEmpty().NotNull();
                RuleFor(x => x.CourseId).NotEmpty().NotNull().NotEqual(0);
            }
        }
    }
}
