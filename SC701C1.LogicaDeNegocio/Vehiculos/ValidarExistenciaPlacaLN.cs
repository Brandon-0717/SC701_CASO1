
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos;

namespace SC701C1.LogicaDeNegocio.Vehiculos
{
    public class ValidarExistenciaPlacaLN : IValidarExistenciaPlacaLN
    {
        private readonly IValidarExistenciaPlacaAD _validarExistenciaPlacaAD;

        public ValidarExistenciaPlacaLN(IValidarExistenciaPlacaAD validarExistenciaPlacaAD)
        {
            _validarExistenciaPlacaAD = validarExistenciaPlacaAD;
        }
        public async Task<CustomResponse<bool>> Validar(string placa)
        {
            var customResponse = new CustomResponse<bool>();    

            bool existe = await _validarExistenciaPlacaAD.Validar(placa);

            if(existe)
            {
                customResponse.EsError = true;
                customResponse.Mensaje = "La placa ya existe en el sistema.";
                return customResponse;
            }
            else
            {
                customResponse.Mensaje = "La placa no existe en el sistema.";
                return customResponse;
            }
        }
    }
}
