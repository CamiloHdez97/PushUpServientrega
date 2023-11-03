using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class TipoPaqueteController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public TipoPaqueteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoPaqueteDto>>> Get()
    {
        var Con = await  _unitofwork.TipoPaquetes.GetAllAsync();
        return _mapper.Map<List<TipoPaqueteDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoPaqueteDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.TipoPaquetes.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<TipoPaqueteDto>>(pag.registros);
        return new Pager<TipoPaqueteDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.TipoPaquetes.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoPaquete>> Post(TipoPaqueteDto tipoPaqueteDto){
        var tipoPaquete = _mapper.Map<TipoPaquete>(tipoPaqueteDto);
        this._unitofwork.TipoPaquetes.Add(tipoPaquete);
        await _unitofwork.SaveAsync();
        if(tipoPaquete == null)
        {
            return BadRequest();
        }
        tipoPaqueteDto.Id = tipoPaquete.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= tipoPaqueteDto.Id}, tipoPaqueteDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoPaquete>> Put(int id, [FromBody]TipoPaquete tipoPaquete){
        if(tipoPaquete == null)
            return NotFound();
        _unitofwork.TipoPaquetes.Update(tipoPaquete);
        await _unitofwork.SaveAsync();
        return tipoPaquete;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.TipoPaquetes.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.TipoPaquetes.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}