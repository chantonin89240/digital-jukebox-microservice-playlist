using Application.Commands.AddPlaylist;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddSong;

public class AddSongCommandValidator : AbstractValidator<AddSongCommand>
{
    public AddSongCommandValidator()
    {
        RuleFor(b => b.IdPlaylist).NotEmpty();
        RuleFor(b => b.Title).NotEmpty();
    }
}
