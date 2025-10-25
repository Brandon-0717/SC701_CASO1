(() => {
    const Vehiculo = {
        tabla: null,

        init() {
            this.InicializarTabla();
            this.RegistrarEventos();
        },
        RegistrarEventos() {;
            $('#modalCrearVehiculo').on('shown.bs.modal', function () {
                Vehiculo.LlenarSelectPropietarios();
            });
        },
        //---------------------
        InicializarTabla() {
            this.tabla = $('#tablaVehiculos').DataTable({
                ajax: { url: '/Vehiculo/ObtenerVehiculos', type: 'GET', dataSrc: 'data' },
                columns: [
                    { data: 'placa', title: 'Placa' },
                    { data: 'nombrePropietario', title: 'Propietario' },
                    { data: 'marca', title: 'Marca' },
                    { data: 'modelo', title: 'Modelo' },
                    { data: 'anio', title: 'Año' },
                    { data: 'color', title: 'Color' },
                    { data: 'kilometraje', title: 'Kilometraje', render: data => `${data}Km` },
                    //{ data: 'peso', title: 'Peso' },
                    { data: 'capacidadCombustible', title: 'Cap Comb', render: data => `${data}L` },
                    { data: 'vehiculoElectrico', title: 'Vehiculo Electrico', render: data => data ? 'Si' : 'No' },
                    { data: 'transmisionManual', title: 'Transmision Manual', render: data => data ? 'Si' : 'No' },
                    { data: 'fechaRegistro', title: 'Fecha Registro', render: data => data ? new Date(data).toLocaleDateString('es-CR') : '' },
                    {
                        data: null, title: 'Acciones', orderable: false,
                        render: row => `
                            <div class="d-flex justify-content-center gap-2">
                                <button class="btn btn-sm btn-primary btn-edt" data-id="${row.placa}" title="Editar">
                                    <i class="bi bi-pencil-square"></i>
                                </button>
                                <button class="btn btn-sm btn-danger btn-del" data-id="${row.placa}" title="Eliminar">
                                    <i class="bi bi-trash3"></i>
                                </button>
                            </div>
                        `
                    }
                ],
                //responsive: true,
                processing: true,
                //scrollX: true,
                pageLength: 10,
                columnDefs: [
                    { targets: '_all', className: 'text-center' }
                ],
                language: {
                    search: "Búsqueda",
                    lengthMenu: "Mostrar _MENU_ registros por página",
                    info: "Mostrando _START_ a _END_ de _TOTAL_ registros",
                    paginate: {
                        first: "Primero",
                        last: "Último",
                        next: "Siguiente",
                        previous: "Anterior"
                    },
                    processing: "Procesando...",
                    zeroRecords: "No se encontraron registros coincidentes",
                    infoEmpty: "Mostrando 0 a 0 de 0 registros",
                    infoFiltered: "(filtrado de _MAX_ registros totales)",
                }
            });
        },

        LlenarSelectPropietarios() {
            $.get('/Cliente/ObtenerClientes', function (response) {
                const select = $('#selectPropietario');
                select.empty(); // Limpiar opciones previas
                select.append('<option value="">Seleccione propietario...</option>');

                if (!response.esError) {
                    response.data.forEach(cliente => {
                        // Crear un nombre completo o usar solo nombre si es persona jurídica
                        let nombreCompleto = cliente.nombre;
                        if (cliente.primerApellido || cliente.segundoApellido) {
                            nombreCompleto += ` ${cliente.primerApellido} ${cliente.segundoApellido}`;
                        }
                        select.append(`<option value="${cliente.identificacion}">${nombreCompleto}</option>`);
                    });
                } else {
                    Swal.fire({
                        title: 'Ha ocurrido un error',
                        text: response.mensaje,
                        icon: 'error'
                    });
                }
            });
        },
    }
    $(document).ready(() => Vehiculo.init());
})();

