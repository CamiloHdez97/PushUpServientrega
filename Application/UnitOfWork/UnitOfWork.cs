using Aplicacion.Repository;
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private IRol _rols;
    private IUser _users;
    private ICiudad _ciudades;
    private IDireccion _direcciones;
    private IEnvio _envios;
    private IEstado _estados;
    private IFactura _facturas;
    private IPais _paises;
    private IPaquete _paquetes;
    private IPersona _personas;
    private IPersonaContacto _personaContactos;
    private IPostal _postales;
    private IPrefijoVia _prefijoVias;
    private IRegion _regiones;
    private ITipoDocumento _tipoDocumentos;
    private ITipoPaquete _tipoPaquetes;
    private ITipoVia _tipoVias;
    private IUbicacion _ubicaciones;
    

    
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }

    public IUser Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }


   public IRol Rols
    {
        get
        {
            _rols ??= new RolRepository(_context);
            return _rols;
        }
    }

    public ICiudad Ciudades
    {
        get
        {
            _ciudades ??= new CiudadRepository(_context);
            return _ciudades;
        }
    }
    
    public IDireccion Direcciones
    {
        get
        {
            _direcciones ??= new DireccionRepository(_context);
            return _direcciones;
        }
    }

    public IEnvio Envios
    {
        get
        {
            _envios ??= new EnvioRepository(_context);
            return _envios;
        }
    }

    public IEstado Estados
    {
        get
        {
            _estados ??= new EstadoRepository(_context);
            return _estados;
        }
    }

    public IFactura Facturas
    {
        get
        {
            _facturas ??= new FacturaRepository(_context);
            return _facturas;
        }
    }

    public IPais Paises
    {
        get
        {
            _paises ??= new PaisRepository(_context);
            return _paises;
        }
    }

    public IPaquete Paquetes
    {
        get
        {
            _paquetes ??= new PaqueteRepository(_context);
            return _paquetes;
        }
    }

    public IPersona Personas
    {
        get
        {
            _personas ??= new PersonaRepository(_context);
            return _personas;
        }
    }

    public IPersonaContacto PersonaContactos
    {
        get
        {
            _personaContactos ??= new PersonaContactoRepository(_context);
            return _personaContactos;
        }
    }

    public IPostal Postales
    {
        get
        {
            _postales ??= new PostalRepository(_context);
            return _postales;
        }
    }

    public IPrefijoVia PrefijoVias
    {
        get
        {
            _prefijoVias ??= new PrefijoViaRepository(_context);
            return _prefijoVias;
        }
    }

    public IRegion Regiones
    {
        get
        {
            _regiones ??= new RegionRepository(_context);
            return _regiones;
        }
    }

    public ITipoDocumento TipoDocumentos
    {
        get
        {
            _tipoDocumentos ??= new TipoDocumentoRepository(_context);
            return _tipoDocumentos;
        }
    }

    public ITipoPaquete TipoPaquetes
    {
        get
        {
            _tipoPaquetes ??= new TipoPaqueteRepository(_context);
            return _tipoPaquetes;
        }
    }

    public ITipoVia TipoVias
    {
        get
        {
            _tipoVias ??= new TipoViaRepository(_context);
            return _tipoVias;
        }
    }

    public IUbicacion Ubicaciones
    {
        get
        {
            _ubicaciones ??= new UbicacionRepository(_context);
            return _ubicaciones;
        }
    }
                                    
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}