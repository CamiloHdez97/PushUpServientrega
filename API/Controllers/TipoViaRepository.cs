using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class TipoViaController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public TipoViaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoViaDto>>> Get()
    {
        var Con = await  _unitofwork.TipoVias.GetAllAsync();
        return _mapper.Map<List<TipoViaDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoViaDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.TipoVias.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<TipoViaDto>>(pag.registros);
        return new Pager<TipoViaDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.TipoVias.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoVia>> Post(TipoViaDto tipoViaDto){
        var tipoVia = _mapper.Map<TipoVia>(tipoViaDto);
        this._unitofwork.TipoVias.Add(tipoVia);
        await _unitofwork.SaveAsync();
        if(tipoVia == null)
        {
            return BadRequest();
        }
        tipoViaDto.Id = tipoVia.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= tipoViaDto.Id}, tipoViaDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoVia>> Put(int id, [FromBody]TipoVia tipoVia){
        if(tipoVia == null)
            return NotFound();
        _unitofwork.TipoVias.Update(tipoVia);
        await _unitofwork.SaveAsync();
        return tipoVia;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.TipoVias.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.TipoVias.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}