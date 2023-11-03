using AutoMapper;
using Domain.Entities;
using API.Dtos;

namespace ApiJwt.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
     { 
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<Ciudad, CiudadDto>().ReverseMap();
            CreateMap<Direccion, DireccionDto>().ReverseMap();
            CreateMap<Envio, EnvioDto>().ReverseMap();
            CreateMap<Estado, EstadoDto>().ReverseMap();
            CreateMap<Factura, FacturaDto>().ReverseMap();
            CreateMap<Pais, PaisDto>().ReverseMap();
            CreateMap<Paquete, PaqueteDto>().ReverseMap();
            CreateMap<Persona, PersonaDto>().ReverseMap();
            CreateMap<PersonaContacto, PersonaContactoDto>().ReverseMap();
            CreateMap<Postal, PostalDto>().ReverseMap();
            CreateMap<PrefijoVia, PrefijoViaDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<TipoDocumento, TipoDocumentoDto>().ReverseMap();
            CreateMap<TipoPaquete, TipoPaqueteDto>().ReverseMap();
            CreateMap<TipoVia, TipoViaDto>().ReverseMap();
            CreateMap<Ubicacion, UbicacionDto>().ReverseMap();

           

    }
}