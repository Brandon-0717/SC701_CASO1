(() => {
    const Clientes = {
        tabla: null,

        init() {
            this.inicializarTabla();
            //this.registrarEventos();
        },
        inicializarTabla() {
            this.tabla = $('#tablaClientes').DataTable({
                ajax: { url: '/Cliente/ObtenerClientes', type: 'GET', dataSrc: 'data' },
                columns: [
                    { data: 'identificacion', title: 'Identificacion' },
                    { data: 'nombre', title: 'Nombre' },
                    { data: 'primerApellido', title: 'Apellido 1' },
                    { data: 'segundoApellido', title: 'Apellido 2' },
                    { data: 'edad', title: 'Edad' },
                    { data: 'sexo', title: 'Sexo',
                        render: data => data ? 'Masculino' : 'Femenino' 
                    },
                    { data: 'telefono', title: 'Telefono' },
                    {
                        data: null, title: 'Acciones', orderable: false,
                        render: row => `
                            <button class="btn btn-sm btn-secondary  btn-con" data-id="${row.identificacion}" title="Editar">
                                <i class="bi bi-search"></i>
                            </button>
                            <button class="btn btn-sm btn-primary btn-edt" data-id="${row.Identificacion}">Editar</button>
                            <button class="btn btn-sm btn-danger btn-del" data-id="${row.Identificacion}">Eliminar</button>                       `
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
                }
            });
        },

        registrarEventos() {

        }

    }
    $(document).ready(() => Clientes.init());
})();

