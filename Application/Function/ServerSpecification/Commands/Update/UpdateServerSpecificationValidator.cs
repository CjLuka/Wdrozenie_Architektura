using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Function.ServerSpecification.Commands.Update
{
    public class UpdateServerSpecificationValidator : AbstractValidator<UpdateServerSpecificationCommand>
    {
        public UpdateServerSpecificationValidator()
        {
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
                .WithMessage("Pole nie może być puste");
                //.Must(x => x.Contains("."));
        }
    }
}
