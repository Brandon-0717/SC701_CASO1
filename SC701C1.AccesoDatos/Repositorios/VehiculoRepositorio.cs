
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.AccesoDatos.Repositorios
{
    public class VehiculoRepositorio
    {
        List<VehiculoAD> vehiculos = new List<VehiculoAD>
        {
            new VehiculoAD
            {
                Placa = "ABC123",
                Marca = "Toyota",
                Anio = 2018,
                Modelo = "Corolla",
                Kilometraje = 4500,
                Peso = 1300,
                CapacidadCombustible = 50,
                Color = "Rojo",
                VehiculoElectrico = false,
                TransmisionManual = true,
                PropietarioId = 101230456,
                FechaRegistro = DateTime.Now.AddDays(-10)
            },
            new VehiculoAD
            {
                Placa = "XYZ789",
                Marca = "Tesla",
                Anio = 2022,
                Modelo = "Model 3",
                Kilometraje = 12000,
                Peso = 1600,
                CapacidadCombustible = 0,
                Color = "Negro",
                VehiculoElectrico = true,
                TransmisionManual = false,
                PropietarioId = 204567891,
                FechaRegistro = DateTime.Now.AddDays(-20)
            },
            new VehiculoAD
            {
                Placa = "LMN456",
                Marca = "Hyundai",
                Anio = 2020,
                Modelo = "Tucson",
                Kilometraje = 30000,
                Peso = 1500,
                CapacidadCombustible = 60,
                Color = "Gris",
                VehiculoElectrico = false,
                TransmisionManual = false,
                PropietarioId = 305678912,
                FechaRegistro = DateTime.Now.AddDays(-7)
            }
        };

    }
}
