using Application.Commands.AddTrack;
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

    //[HttpPost]
    //public async Task<IActionResult> AddTrack(Playlist playlist, Song song, [FromBody] AddTrackCommand command)
    //{
    //    var result = await _mediator.Send(command);
    //    return Ok(result);
    //}
}
