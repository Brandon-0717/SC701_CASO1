(() => {
    const Citas = {
        tabla: null,

        init() {
            this.InicializarTabla();
           // Citas.RegistrarEventos();
        },
        RegistrarEventos() {


        },
        InicializarTabla() {
            this.tabla = $('#tablaCitas').DataTable({
                ajax: { url: '/Cita/ObtenerCitas', type: 'GET', dataSrc: 'data' },
                columns: [
                    { data: 'fechaCita', title: 'Fecha Cita', render: data => data ? new Date(data).toLocaleDateString('es-CR') : '' },
                    { data: 'nombreCliente', title: 'Cliente' },
                    { data: 'vehiculoId', title: 'Placa Vehiculo' },
                    { data: 'estado', title: 'Estado' },
                    { data: 'atenciones', title: 'Atenciones' },
                    
                    {
                        data: null, title: 'Acciones', orderable: false,
                        render: row => `
                            <button class="btn btn-sm btn-primary btn-edt" data-id="${row.citaId}" title="Editar">
                                <i class="bi bi-pencil-square"></i>
                            </button>
                            <button class="btn btn-sm btn-danger btn-del" data-id="${row.citaId}" title="Eliminar">
                                <i class="bi bi-trash3"></i>
                            </button>                       `
                    }
                ],
                responsive: true,
                processing: true,
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





    }
    $(document).ready(() => Citas.init());
})();