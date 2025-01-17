﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data;

public static class InitialiserExtensions
{
    
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<PlaylistDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }

}

public class PlaylistDbContextInitialiser
{
    //private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly PlaylistDbContext _context;
    //private readonly UserManager<ApplicationUser> _userManager;
    //private readonly RoleManager<IdentityRole> _roleManager;

    public PlaylistDbContextInitialiser(PlaylistDbContext context)
    {
        //_logger = logger;
        _context = context;
        //_userManager = userManager;
        //_roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
    public async Task TrySeedAsync()
    {
        //// Default roles
        //var administratorRole = new IdentityRole(Roles.Administrator);

        //if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        //{
        //    await _roleManager.CreateAsync(administratorRole);
        //}

        //// Default users
        //var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        //if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        //{
        //    await _userManager.CreateAsync(administrator, "Administrator1!");
        //    if (!string.IsNullOrWhiteSpace(administratorRole.Name))
        //    {
        //        await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        //    }
        //}

        // Default data
        // Seed, if necessary
        //if (!_context.Playlists.Any())
        //{
        //    _context.Songs.Add(new Song
        //    {
        //        Title = "test1"
        //    });
        //    _context.Songs.Add(new Song
        //    {
        //        Title = "test2"
        //    });
        //    _context.Songs.Add(new Song
        //    {
        //        Title = "test3"
        //    });

        //    _context.Playlists.Add(new Playlist
        //    {
        //        Name = "playlistExample",
        //        PlayedSongId = 1,
        //        PlaylistSongs = new List<SongPlaylist>()
        //        {
        //            new SongPlaylist { SongId = 1, PlaylistOrder = 1 },
        //            new SongPlaylist { SongId = 2, PlaylistOrder = 3 },
        //            new SongPlaylist { SongId = 3, PlaylistOrder = 2 },
        //        },
        //        TotalSong = 3
        //    });

        //    await _context.SaveChangesAsync();
        //}
    }
}
