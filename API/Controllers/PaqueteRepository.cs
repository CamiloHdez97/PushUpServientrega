using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class PaqueteController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public PaqueteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PaqueteDto>>> Get()
    {
        var Con = await  _unitofwork.Paquetes.GetAllAsync();
        return _mapper.Map<List<PaqueteDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PaqueteDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Paquetes.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<PaqueteDto>>(pag.registros);
        return new Pager<PaqueteDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }



     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Paquetes.GetByIdAsync(id);
        return Ok(byidC);
    }



     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Paquete>> Post(PaqueteDto paqueteDto){
        var paquete = _mapper.Map<Paquete>(paqueteDto);
        this._unitofwork.Paquetes.Add(paquete);
        await _unitofwork.SaveAsync();
        if(paquete == null)
        {
            return BadRequest();
        }
        paqueteDto.Id = paquete.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= paqueteDto.Id}, paqueteDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Paquete>> Put(int id, [FromBody]Paquete paquete){
        if(paquete == null)
            return NotFound();
        _unitofwork.Paquetes.Update(paquete);
        await _unitofwork.SaveAsync();
        return paquete;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Paquetes.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Paquetes.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}