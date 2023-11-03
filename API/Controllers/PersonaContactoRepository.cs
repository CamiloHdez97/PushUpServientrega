using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class PersonaContactoController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public PersonaContactoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaContactoDto>>> Get()
    {
        var Con = await  _unitofwork.PersonaContactos.GetAllAsync();
        return _mapper.Map<List<PersonaContactoDto>>(Con);
    }


    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PersonaContactoDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.PersonaContactos.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<PersonaContactoDto>>(pag.registros);
        return new Pager<PersonaContactoDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.PersonaContactos.GetByIdAsync(id);
        return Ok(byidC);
    }


     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaContacto>> Post(PersonaContactoDto personContactoDto){
        var personContacto = _mapper.Map<PersonaContacto>(personContactoDto);
        this._unitofwork.PersonaContactos.Add(personContacto);
        await _unitofwork.SaveAsync();
        if(personContacto == null)
        {
            return BadRequest();
        }
        personContactoDto.Id = personContacto.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= personContactoDto.Id}, personContactoDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaContacto>> Put(int id, [FromBody]PersonaContacto personContacto){
        if(personContacto == null)
            return NotFound();
        _unitofwork.PersonaContactos.Update(personContacto);
        await _unitofwork.SaveAsync();
        return personContacto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.PersonaContactos.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.PersonaContactos.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}