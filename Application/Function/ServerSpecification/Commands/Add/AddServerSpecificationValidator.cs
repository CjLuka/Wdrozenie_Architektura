using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Function.ServerSpecification.Commands.Add
{
    public class AddServerSpecificationValidator : AbstractValidator<AddServerSpecificationCommand>
    {
        public AddServerSpecificationValidator()
        {
            RuleFor(x => x.CreateDate)
                .NotEmpty().WithMessage("Pole nie może być puste");

            RuleFor(x => x.IpAddress) 
                .NotEmpty().WithMessage("Pole nie może być puste");

            RuleFor(x => x.DiskSizeInGB)
                .NotEmpty().WithMessage("Pole nie może być puste");

            RuleFor(x => x.NumberOfCores)
                .NotEmpty().WithMessage("Pole nie może być puste");
                //.Must(ip => System.Net.IPAddress.TryParse(ip, out _)).WithMessage("Nieprawidłowy format adresu IP");

            RuleFor(x => x.NumberOfRam)
                .NotEmpty().WithMessage("Pole nie może być puste");

            RuleFor(x => x.DomainName)
                .NotEmpty()
                .WithMessage("Pole nie może być puste")
                .Must(x => x.Contains("."));

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Pole nie może być puste");
        }
    }
}
