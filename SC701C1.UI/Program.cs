using SC701C1.Abstracciones.AccesoDatos.Citas;
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.LogicaDeNegocio.Citas;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos;
using SC701C1.AccesoDatos.Citas;
using SC701C1.AccesoDatos.Clientes;
using SC701C1.AccesoDatos.Vehiculos;
using SC701C1.LogicaDeNegocio.Citas;
using SC701C1.LogicaDeNegocio.Clientes;
using SC701C1.LogicaDeNegocio.Mapper;
using SC701C1.LogicaDeNegocio.Vehiculos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(cfg => { }, typeof(MapeoClases));

//INYECCIONES DE DEPENDENCIAS
//----------Clientes
builder.Services.AddScoped<IListarClienteAD, ListarClienteAD>();
builder.Services.AddScoped<IListarClienteLN, ListarClienteLN>();
builder.Services.AddScoped<IObtenerClientePorIdentificacionAD, ObtenerClientePorIdentificacionAD>();    
builder.Services.AddScoped<IObtenerClientePorIdentificacionLN, ObtenerClientePorIdentificacionLN>();
builder.Services.AddScoped<IEliminarClienteAD, EliminarClienteAD>();
builder.Services.AddScoped<IEliminarClienteLN, EliminarClienteLN>();
builder.Services.AddScoped<IModificarClienteAD, ModificarClienteAD>();
builder.Services.AddScoped<IModificarClienteLN, ModificarClienteLN>();
builder.Services.AddScoped<IRegistrarClienteAD, RegistrarClienteAD>();
builder.Services.AddScoped<IRegistrarClienteLN, RegistrarClienteLN>();
builder.Services.AddScoped<IValidarExistenciaAD, ValidarExistenciaAD>();
//----------Vehiculos
builder.Services.AddScoped<IObtenerVehiculosAD, ObtenerVehiculosAD>();
builder.Services.AddScoped<IObtenerVehiculosLN, ObtenerVehiculosLN>();
builder.Services.AddScoped<ICrearVehiculoAD, CrearVehiculoAD>();
builder.Services.AddScoped<ICrearVehiculoLN, CrearVehiculoLN>();
builder.Services.AddScoped<IEliminarVehiculoAD, EliminarVehiculoAD>();
builder.Services.AddScoped<IEliminarVehiculoLN, EliminarVehiculoLN>();
builder.Services.AddScoped<IObtenerVehiculoPorPlacaAD, ObtenerVehiculoPorPlacaAD>();
builder.Services.AddScoped<IObtenerVehiculoPorPlacaLN, ObtenerVehiculoPorPlacaLN>();
builder.Services.AddScoped<IModificarVehiculoAD, ModificarVehiculoAD>();
builder.Services.AddScoped<IModificarVehiculoLN, ModificarVehiculoLN>();
builder.Services.AddScoped<IValidarExistenciaPlacaAD, ValidarExistenciaPlacaAD>();
builder.Services.AddScoped<IValidarExistenciaPlacaLN, ValidarExistenciaPlacaLN>();
builder.Services.AddScoped<IObtenerVehiculosPorClienteAD, ObtenerVehiculosPorClienteAD>();
builder.Services.AddScoped<IObtenerVehiculosPorClienteLN, ObtenerVehiculosPorClienteLN>();
//----------Citas
builder.Services.AddScoped<IListarCitaAD, ListarCitaAD>();
builder.Services.AddScoped<IListarCitaLN, ListarCitaLN>();
builder.Services.AddScoped<ICrearCitaAD, CrearCitaAD>();
builder.Services.AddScoped<ICrearCitaLN, CrearCitaLN>();
builder.Services.AddScoped<IEliminarCitaAD, EliminarCitaAD>();
builder.Services.AddScoped<IEliminarCitaLN, EliminarCitaLN>();
builder.Services.AddScoped<IObtenerCitaPorIdAD, ObtenerCitaPorIdAD>();
builder.Services.AddScoped<IObtenerCitaPorIdLN, ObtenerCitaPorIdLN>();
builder.Services.AddScoped<IModificarCitaAD, ModificarCitaAD>();
builder.Services.AddScoped<IModificarCitaLN, ModificarCitaLN>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
