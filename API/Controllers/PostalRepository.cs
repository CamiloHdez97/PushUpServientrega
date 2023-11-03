using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class PostalController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public PostalController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PostalDto>>> Get()
    {
        var Con = await  _unitofwork.Postales.GetAllAsync();
        return _mapper.Map<List<PostalDto>>(Con);
    }


    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PostalDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Postales.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<PostalDto>>(pag.registros);
        return new Pager<PostalDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }


     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Postales.GetByIdAsync(id);
        return Ok(byidC);
    }


     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Postal>> Post(PostalDto postalDto){
        var postal = _mapper.Map<Postal>(postalDto);
        this._unitofwork.Postales.Add(postal);
        await _unitofwork.SaveAsync();
        if(postal == null)
        {
            return BadRequest();
        }
        postalDto.Id = postal.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= postalDto.Id}, postalDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Postal>> Put(int id, [FromBody]Postal postal){
        if(postal == null)
            return NotFound();
        _unitofwork.Postales.Update(postal);
        await _unitofwork.SaveAsync();
        return postal;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Postales.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Postales.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}