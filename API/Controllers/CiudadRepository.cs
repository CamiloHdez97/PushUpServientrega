using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class CiudadController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CiudadDto>>> Get()
    {
        var Con = await  _unitofwork.Ciudades.GetAllAsync();
        return _mapper.Map<List<CiudadDto>>(Con);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CiudadDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Ciudades.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<CiudadDto>>(pag.registros);
        return new Pager<CiudadDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Ciudades.GetByIdAsync(id);
        return Ok(byidC);
    }

     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Ciudad>> Post(CiudadDto CiudadDto){
        var ciudad = _mapper.Map<Ciudad>(CiudadDto);
        this._unitofwork.Ciudades.Add(ciudad);
        await _unitofwork.SaveAsync();
        if(ciudad == null)
        {
            return BadRequest();
        }
        CiudadDto.Id = ciudad.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= CiudadDto.Id}, CiudadDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Ciudad>> Put(int id, [FromBody]Ciudad ciudad){
        if(ciudad == null)
            return NotFound();
        _unitofwork.Ciudades.Update(ciudad);
        await _unitofwork.SaveAsync();
        return ciudad;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Ciudades.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Ciudades.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}