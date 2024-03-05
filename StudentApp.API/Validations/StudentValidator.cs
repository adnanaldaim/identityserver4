using FluentValidation;
using StudentApp.Object.Constants;
using StudentApp.Object.DTOs.Student;

namespace StudentApp.API.Validations
{
    public class StudentValidator
    {
        public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
        {
            public CreateStudentDtoValidator()
            {
                RuleFor(x => x.RollNumber).NotNull().NotEmpty().WithMessage(ValidationMessage.ROLLNUM_REQUIRED);
                RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(ValidationMessage.NAME_REQUIRED);
                RuleFor(x => x.DateOfBirth).NotNull().NotEmpty().WithMessage(ValidationMessage.DATEOFBIRTH_REQUIRED);
                RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage(ValidationMessage.EMAIL_REQUIRED);
                RuleFor(x => x.Phone).NotNull().NotEmpty().WithMessage(ValidationMessage.PHONE_REQUIRED);
            }
        }
        public class EditStudentDtoValidator : AbstractValidator<EditStudentDto>
        {
            public EditStudentDtoValidator()
            {
                RuleFor(x => x.RollNumber).NotNull().NotEmpty().WithMessage(ValidationMessage.ROLLNUM_REQUIRED);
                RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(ValidationMessage.NAME_REQUIRED);
                RuleFor(x => x.DateOfBirth).NotNull().NotEmpty().WithMessage(ValidationMessage.DATEOFBIRTH_REQUIRED);
                RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage(ValidationMessage.EMAIL_REQUIRED);
                RuleFor(x => x.Phone).NotNull().NotEmpty().WithMessage(ValidationMessage.PHONE_REQUIRED);
            }
        }
    }
}
