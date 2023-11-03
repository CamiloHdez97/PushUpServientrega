using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class FacturaController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public FacturaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<FacturaDto>>> Get()
    {
        var Con = await  _unitofwork.Facturas.GetAllAsync();
        return _mapper.Map<List<FacturaDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<FacturaDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Facturas.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<FacturaDto>>(pag.registros);
        return new Pager<FacturaDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Facturas.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Factura>> Post(FacturaDto facturaDto){
        var factura = _mapper.Map<Factura>(facturaDto);
        this._unitofwork.Facturas.Add(factura);
        await _unitofwork.SaveAsync();
        if(factura == null)
        {
            return BadRequest();
        }
        facturaDto.Id = factura.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= facturaDto.Id}, facturaDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Factura>> Put(int id, [FromBody]Factura factura){
        if(factura == null)
            return NotFound();
        _unitofwork.Facturas.Update(factura);
        await _unitofwork.SaveAsync();
        return factura;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Facturas.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Facturas.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}