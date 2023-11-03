using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class TipoDocumentoController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public TipoDocumentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoDocumentoDto>>> Get()
    {
        var Con = await  _unitofwork.TipoDocumentos.GetAllAsync();
        return _mapper.Map<List<TipoDocumentoDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoDocumentoDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.TipoDocumentos.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<TipoDocumentoDto>>(pag.registros);
        return new Pager<TipoDocumentoDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.TipoDocumentos.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumento>> Post(TipoDocumentoDto tipoDocumentoDto){
        var tipoDocumento = _mapper.Map<TipoDocumento>(tipoDocumentoDto);
        this._unitofwork.TipoDocumentos.Add(tipoDocumento);
        await _unitofwork.SaveAsync();
        if(tipoDocumento == null)
        {
            return BadRequest();
        }
        tipoDocumentoDto.Id = tipoDocumento.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= tipoDocumentoDto.Id}, tipoDocumentoDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumento>> Put(int id, [FromBody]TipoDocumento tipoDocumento){
        if(tipoDocumento == null)
            return NotFound();
        _unitofwork.TipoDocumentos.Update(tipoDocumento);
        await _unitofwork.SaveAsync();
        return tipoDocumento;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.TipoDocumentos.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.TipoDocumentos.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}