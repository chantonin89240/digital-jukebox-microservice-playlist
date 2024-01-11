using Application.Commands.AddPlaylist;
using Application.Commands.AddSong;
using Application.Queries.GetPlaylist;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/playlists")]
public class PlaylistController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlaylistController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("bar/{barId}/playlist/{playlistId}")]
    public async Task<IActionResult> GetPaylistById(int barId, int playlistId)
    {
        GetPlaylistDto getPlaylistDto = new GetPlaylistDto() { PlaylistId = playlistId, BarId = barId };
        var query = new GetPlaylistQuery(getPlaylistDto);
        var result = await _mediator.Send(query);

        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddPlaylist([FromBody] AddPlaylistCommand command)
    {
        int retour = await _mediator.Send(command);
        return Ok("Playlist " + retour + " add successfully");
    }

    [HttpPost("song")]
    public async Task<IActionResult> AddSongInPlaylist([FromBody] AddSongCommand command)
    {
        int retour = await _mediator.Send(command);
        return Ok("Song " + retour + " add successfully");
    }
}
