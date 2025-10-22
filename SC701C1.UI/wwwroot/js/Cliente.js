(() => {
    const Clientes = {
        tabla: null,

        init() {
            this.inicializarTabla();
            this.registrarEventos();
        },
        registrarEventos() {
            $('#tablaClientes tbody').on('click', '.btn-con', function () {
                const id = $(this).data("id");
                Clientes.MostrarDetallesCliente(id);
            });
            //--------------------
            $('#tablaClientes tbody').on('click', '.btn-edt', function () {
                const id = $(this).data("id");
                Clientes.MostrarDetallesCliente(id);
            });
            //--------------------
            $('#tablaClientes tbody').on('click', '.btn-del', function () {
                const id = $(this).data("id");
                Clientes.EliminarCliente(id);
            });
            
        },
        //---------------------
        inicializarTabla() {
            this.tabla = $('#tablaClientes').DataTable({
                ajax: { url: '/Cliente/ObtenerClientes', type: 'GET', dataSrc: 'data' },
                columns: [
                    { data: 'identificacion', title: 'Identificacion' },
                    { data: 'tipoIdentificacion', title: 'Tipo Identificacion' },
                    { data: null, title: 'Nombre',
                        render: (data, type, row) => `${row.nombre} ${row.primerApellido} ${row.segundoApellido}`
                    },
                    { data: 'edad', title: 'Edad' },
                    { data: 'sexo', title: 'Sexo', render: data => data ? 'Masculino' : 'Femenino' },
                    { data: 'telefono', title: 'Telefono' },
                    { data: 'correoElectronico', title: 'Correo Electronico' },
                    { data: 'fechaRegistro', title: 'Fecha Registro', render: data => data ? new Date(data).toLocaleDateString('es-CR') : '' },
                    {
                        data: null, title: 'Acciones', orderable: false,
                        render: row => `
                            <button class="btn btn-sm btn-primary btn-edt" data-id="${row.identificacion}" title="Editar">
                                <i class="bi bi-pencil-square"></i>
                            </button>
                            <button class="btn btn-sm btn-danger btn-del" data-id="${row.identificacion}" title="Eliminar">
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
        //---------------------
        MostrarDetallesCliente: function (id) {
            $.get('Cliente/ObtenerClientePorIdentificacion', { identificacion: id }, function (response) {
                if (!response.EsError) {
                    $('#edt-cl-identificacion').val(response.data.identificacion);
                    $('#edt-cl-tipoIdentificacion').val(response.data.tipoIdentificacion);
                    $('#edt-cl-nombre').val(response.data.nombre);
                    $('#edt-cl-apellido1').val(response.data.primerApellido);
                    $('#edt-cl-apellido2').val(response.data.segundoApellido);
                    $('#edt-cl-sexo').val(response.data.sexo ? 'Masculino' : 'Femenino');
                    $('#edt-cl-edad').val(response.data.edad);
                    $('#edt-cl-telefono').val(response.data.telefono);
                    $('#edt-cl-email').val(response.data.correoElectronico);
                    $('#edt-cl-fechaRegistro').val(response.data.fechaRegistro);

                    $('#clienteEditarModal').modal('show');
                } else {
                    Swal.fire({
                        title: 'Ha ocurrido un error',
                        text: response.Mensaje,
                        icon: 'error'
                    });
                }
            });
        },
        //---------------------
        EliminarCliente: function (id) {
            Swal.fire({
                title: "Estas seguro de eliminar este cliente?",
                icon: "warning",
                showCancelButton: true,
                cancelButtonText: "Cancelar",
                confirmButtonText: "Si, eliminar",
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        url: '/Cliente/EliminarCliente',
                        type: 'DELETE',
                        data: { identificacion: id },
                        success: function (response) {
                            if (!response.EsError) {
                                Swal.fire({
                                    title: "Elemento eliminado!",
                                    text: response.Mensaje,
                                    icon: "success"
                                });
                                Clientes.tabla.ajax.reload();
                            } else {
                                Swal.fire({
                                    title: "Ha ocurrido un error",
                                    text: response.Mensaje,
                                    icon: "error"
                                });
                                Clientes.tabla.ajax.reload();
                            }
                        }
                    });
                }
            });
        },
        //---------------------

    }
    $(document).ready(() => Clientes.init());
})();

