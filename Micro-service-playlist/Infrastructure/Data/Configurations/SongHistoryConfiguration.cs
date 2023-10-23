﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations;

public class SongHistoryConfiguration : IEntityTypeConfiguration<SongHistory>
{
    public void Configure(EntityTypeBuilder<SongHistory> builder)
    {
        builder.HasKey(ps => new { ps.HistoryId });
    }
}
