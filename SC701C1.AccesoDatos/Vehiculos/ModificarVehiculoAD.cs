
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Vehiculos
{
    public class ModificarVehiculoAD : IModificarVehiculoAD
    {
        public Task<bool> Modificar(VehiculoAD vehiculo)
        {
            var vehiculoActual = VehiculoRepositorio.vehiculos.FirstOrDefault(v => v.Placa == vehiculo.Placa);
            vehiculoActual.Marca = vehiculo.Marca;
            vehiculoActual.Anio = vehiculo.Anio;
            vehiculoActual.Modelo = vehiculo.Modelo;
            vehiculoActual.Kilometraje = vehiculo.Kilometraje;
            vehiculoActual.Peso = vehiculo.Peso;
            vehiculoActual.CapacidadCombustible = vehiculo.CapacidadCombustible;
            vehiculoActual.Color = vehiculo.Color;
            vehiculoActual.VehiculoElectrico = vehiculo.VehiculoElectrico;
            vehiculoActual.TransmisionManual = vehiculo.TransmisionManual;
            vehiculoActual.PropietarioId = vehiculo.PropietarioId;
            return Task.FromResult(true);
        }
    }
}
