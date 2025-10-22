
namespace SC701C1.Abstracciones.LogicaDeNegocio
{
    public class CustomResponse<T>
    {
        public string Mensaje { get; set; }

        public bool EsError { get; set; }

        public T Data { get; set; }

        public CustomResponse()
        {
            EsError = false;
            Mensaje = string.Empty;
        }
    }
}
