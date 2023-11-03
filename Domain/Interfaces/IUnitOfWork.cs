
namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IRol Rols {get;} 
    IUser Users {get;}
    ICiudad Ciudades {get;}
    IDireccion Direcciones {get;}
    IEnvio Envios {get;}
    IEstado Estados {get;}
    IFactura Facturas {get;}
    IPais Paises {get;}
    IPaquete Paquetes {get;}
    IPersona Personas {get;}
    IPersonaContacto PersonaContactos {get;}
    IPostal Postales {get;}
    IPrefijoVia PrefijoVias {get;}
    IRegion Regiones {get;}
    ITipoDocumento TipoDocumentos {get;}
    ITipoPaquete TipoPaquetes {get;}
    ITipoVia TipoVias {get;}
    IUbicacion Ubicaciones {get;}
      
    Task<int> SaveAsync();
}