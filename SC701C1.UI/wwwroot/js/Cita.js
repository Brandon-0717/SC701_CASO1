(() => {
    const Citas = {
        tabla: null,

        init() {
            this.InicializarTabla();
            this.RegistrarEventos();
        },
        RegistrarEventos() {
            $('#tablaCitas').on('click', '.btn-del', function () {
                const citaId = $(this).data('id');
                Citas.EliminarCita(citaId);
            });

            $('#modalCrearCita').on('show.bs.modal', function () {
                Citas.LlenarSelectClientes();
            });

            $('#modalCrearCita').on('hide.bs.modal', function () {
                const form = $('#formCrearCita');
                form[0].reset();
                form.validate().resetForm();
                form.find('.is-invalid').removeClass('is-invalid');
                form.find('.is-valid').removeClass('is-valid');
                $('#selectVehiculo').empty().prop("disabled", true);
                $('#selectVehiculo').append('<option value="">Seleccione Vehiculo...</option>');
            });

            $('#formCrearCita').on('submit', function (e) {
                e.preventDefault();
                Citas.CrearCita();
            });

            $('#selectCliente').on('change', function () {

                const clienteId = $(this).val();
                const selectVehiculo = $('#selectVehiculo');

                Citas.LlenarSelectVehiculosDelCliente(clienteId);
            });

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
        //---------------------
        CrearCita() {
            const form = $('#formCrearCita');
            if (!form.valid()) return;

            $.ajax({
                url: '/Cita/CrearCita',
                type: 'POST',
                data: form.serialize(),
                success: function (response) {
                    if (!response.esError) {
                        $('#modalCrearCita').modal('hide');
                        Citas.tabla.ajax.reload();
                        form[0].reset();

                        Swal.fire({
                            title: "Cita agendada!",
                            text: response.mensaje,
                            icon: "success",
                            showConfirmButton: false,
                            timer: 1500
                        })
                    } else {
                        $('#modalCrearCita').modal('hide');
                        Swal.fire({
                            title: "Ha ocurrido un error",
                            text: response.mensaje,
                            icon: "error",
                            showConfirmButton: true,
                            confirmButtonText: "Aceptar"
                        });
                    }
                }
            });
        },
        //---------------------
        EliminarCita(citaId) {
            Swal.fire({
                title: "Estas seguro de eliminar esta cita?",
                icon: "warning",
                showCancelButton: true,
                cancelButtonText: "Cancelar",
                confirmButtonText: "Si, eliminar",
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        url: '/Cita/EliminarCita',
                        type: 'DELETE',
                        data: { citaId: citaId },
                        success: function (response) {
                            if (!response.esError) {
                               Swal.fire({
                                    title: "Elemento eliminado!",
                                    text: response.mensaje,
                                    icon: "success",
                                    showConfirmButton: false,
                                    timer: 1500
                                });
                                Citas.tabla.ajax.reload();

                            } else {
                                Swal.fire({
                                    title: "Ha ocurrido un error",
                                    text: response.mensaje,
                                    icon: "error"
                                });
                                Citas.tabla.ajax.reload();
                            }
                        }
                    });
                }
            });

        },
        //---------------------
        LlenarSelectClientes() {
            $.get('/Cliente/ObtenerClientes', function (response) {
                const select = $('#selectCliente');
                select.empty();
                select.append('<option value="">Seleccione Cliente...</option>');

                if (!response.esError) {
                    response.data.forEach(cliente => {
                        let nombreCompleto = cliente.nombre;
                        if (cliente.primerApellido || cliente.segundoApellido) {
                            nombreCompleto += ` ${cliente.primerApellido} ${cliente.segundoApellido}`;
                        }
                        select.append(`<option value="${cliente.identificacion}">${nombreCompleto}</option>`);
                    });

                    // ✅ Activar Select2 después de llenar el select
                    select.select2({
                        placeholder: "Seleccione cliente...",
                        width: '100%',
                        allowClear: true,
                        dropdownParent: $('#modalCrearCita') // 👈 Esto es clave
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
        //---------------------
        LlenarSelectVehiculosDelCliente(clienteId) {
            $.get('/Vehiculo/ObtenerVehiculosPorCliente', { identificacion: clienteId }, function (response) {
                const select = $('#selectVehiculo');
                select.empty();

                if (!response.esError) {
                    response.data.forEach(vehiculo => {
                        let DatosVehiculo = `Placa: ${vehiculo.placa} - Vehiculo: ${vehiculo.marca} ${vehiculo.modelo}`;
                        select.append(`<option value="${vehiculo.placa}">${DatosVehiculo}</option>`);
                    });   
                }
                $('#selectVehiculo').prop("disabled", false);
            });
        },
    }
    $(document).ready(() => Citas.init());
})();