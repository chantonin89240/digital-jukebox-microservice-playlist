using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations;

public class SongConfiguration
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.HasKey(ps => new { ps.SongId });
    }
}
