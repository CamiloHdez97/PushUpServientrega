using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class PrefijoViaController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public PrefijoViaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PrefijoViaDto>>> Get()
    {
        var Con = await  _unitofwork.PrefijoVias.GetAllAsync();
        return _mapper.Map<List<PrefijoViaDto>>(Con);
    }


    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PrefijoViaDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.PrefijoVias.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<PrefijoViaDto>>(pag.registros);
        return new Pager<PrefijoViaDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.PrefijoVias.GetByIdAsync(id);
        return Ok(byidC);
    }

     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PrefijoVia>> Post(PrefijoViaDto prefijoViaDto){
        var prefijoVia = _mapper.Map<PrefijoVia>(prefijoViaDto);
        this._unitofwork.PrefijoVias.Add(prefijoVia);
        await _unitofwork.SaveAsync();
        if(prefijoVia == null)
        {
            return BadRequest();
        }
        prefijoViaDto.Id = prefijoVia.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= prefijoViaDto.Id}, prefijoViaDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PrefijoVia>> Put(int id, [FromBody]PrefijoVia prefijoVia){
        if(prefijoVia == null)
            return NotFound();
        _unitofwork.PrefijoVias.Update(prefijoVia);
        await _unitofwork.SaveAsync();
        return prefijoVia;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.PrefijoVias.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.PrefijoVias.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }

}