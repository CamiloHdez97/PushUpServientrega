using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class PersonaController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
    {
        var Con = await  _unitofwork.Personas.GetAllAsync();
        return _mapper.Map<List<PersonaDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PersonaDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Personas.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<PersonaDto>>(pag.registros);
        return new Pager<PersonaDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }


     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Personas.GetByIdAsync(id);
        return Ok(byidC);
    }


     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persona>> Post(PersonaDto personaDto){
        var persona = _mapper.Map<Persona>(personaDto);
        this._unitofwork.Personas.Add(persona);
        await _unitofwork.SaveAsync();
        if(persona == null)
        {
            return BadRequest();
        }
        personaDto.Id = persona.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= personaDto.Id}, personaDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persona>> Put(int id, [FromBody]Persona persona){
        if(persona == null)
            return NotFound();
        _unitofwork.Personas.Update(persona);
        await _unitofwork.SaveAsync();
        return persona;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Personas.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Personas.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}