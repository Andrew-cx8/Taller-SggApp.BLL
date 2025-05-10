# SggApp - Aplicación de Gestión de Gastos

## Descripción

SggApp es una aplicación diseñada para la gestión de gastos personales. Esta aplicación permite a los usuarios registrar, categorizar y gestionar sus gastos de manera eficiente. La arquitectura de la aplicación está basada en capas, lo que facilita el mantenimiento y la escalabilidad.

## Estructura del Proyecto

El proyecto está organizado en varias capas, cada una con su propia responsabilidad:
SggApp/
├── SggApp.BLL/                # Capa de Lógica de Negocio
│   ├── Interfaces/            # Interfaces de servicios
│   │   ├── IUsuarioService.cs
│   │   ├── IGastoService.cs
│   │   ├── ICategoriaService.cs
│   │   ├── IMonedaService.cs
│   │   └── IPresupuestoService.cs
│   ├── Servicios/             # Implementaciones de servicios
│   │   ├── UsuarioService.cs
│   │   ├── GastoService.cs
│   │   ├── CategoriaService.cs
│   │   ├── MonedaService.cs
│   │   └── PresupuestoService.cs
│   └── Models/                # Modelos opcionales
│       ├── UsuarioModel.cs
│       └── GastoModel.cs
├── SggApp.DAL/                # Capa de Acceso a Datos
├── SggApp.API/                # Capa de Presentación (API)
└── ...

## Funcionalidades

- **Registro de Gastos**: Permite a los usuarios agregar nuevos gastos.
- **Visualización de Gastos**: Los usuarios pueden ver todos sus gastos registrados.
- **Filtrado por Categoría**: Los gastos se pueden filtrar por categoría para una mejor organización.
- **Gestión de Presupuestos**: Los usuarios pueden establecer y gestionar presupuestos.

## Capa de Lógica de Negocio (BLL)

La capa de lógica de negocio (BLL) es responsable de implementar la lógica de negocio de la aplicación. Esta capa incluye:

- **Interfaces**: Definiciones de métodos que deben ser implementados por los servicios.
- **Servicios**: Clases que implementan la lógica de negocio y se comunican con los repositorios de datos.

### Ejemplo de Servicio

```csharp
public class GastoService : IGastoService {
    private readonly GastoRepository _gastoRepository;

    public GastoService(GastoRepository gastoRepository) {
        _gastoRepository = gastoRepository;
    }

    public async Task<IEnumerable<Gasto>> ObtenerTodosAsync() {
        return await _gastoRepository.GetAllAsync();
    }
}
```
## Inyección de Dependencias
La aplicación utiliza inyección de dependencias para gestionar la creación y el ciclo de vida de los servicios. En el archivo Program.cs, se registran los servicios y repositorios:

```csharp
builder.Services.AddScoped<GastoRepository>();
builder.Services.AddScoped<IGastoService, GastoService>();
```

##Integrantes
- Adolfo Chaverra
- Juan Jose Castro

