using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddPlaylist;

public class AddPlaylistCommandValidator : AbstractValidator<AddPlaylistCommand>
{
    public AddPlaylistCommandValidator()
    {
        RuleFor(b => b.Name).NotEmpty();
        RuleFor(b => b.BarId).NotEmpty();
    }
}
