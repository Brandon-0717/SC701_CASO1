(() => {
    const Vehiculo = {
        tabla: null,

        init() {
            this.InicializarTabla();
            this.RegistrarEventos();
        },
        RegistrarEventos() {
            ;
            $('#modalCrearVehiculo').on('shown.bs.modal', function () {
                Vehiculo.LlenarSelectPropietarios();
            });

            $('#modalCrearVehiculo').on('hidden.bs.modal', function () {
                $('#formCrearVehiculo')[0].reset();
            });

            $('#formCrearVehiculo').on('submit', function (e) {
                e.preventDefault();
                Vehiculo.CrearVehiculo();
            });

            $('#tablaVehiculos').on('click', '.btn-edt', function () {
                const placa = $(this).data('id');
                Vehiculo.MostrarModalEditarVehiculo(placa);
            });
            //---------------------
            let checkVehiculoElectrico = document.getElementById('checkVehiculoElectrico');
            let checkTransmisionManual = document.getElementById('checkTransmisionManual');

            checkVehiculoElectrico.addEventListener("change", () => {
                checkTransmisionManual.disabled = checkVehiculoElectrico.checked;
            });

            checkTransmisionManual.addEventListener("change", () => {
                checkVehiculoElectrico.disabled = checkTransmisionManual.checked;
            });

            let edtCheckVehiculoElectrico = document.getElementById('edt-vh-electrico');
            let edtCheckTransmisionManual = document.getElementById('edt-vh-transmision');

            let isLoadingData = false;//Bandera para evitar disparar eventos durante la carga de datos

            edtCheckVehiculoElectrico.addEventListener("change", () => {
                if (isLoadingData) return;
                edtCheckTransmisionManual.disabled = edtCheckVehiculoElectrico.checked;
            });

            edtCheckTransmisionManual.addEventListener("change", () => {
                if (isLoadingData) return;
                edtCheckVehiculoElectrico.disabled = edtCheckTransmisionManual.checked;
            });
            //---------------------
            $('#tablaVehiculos').on('click', '.btn-del', function () {
                const placa = $(this).data('id');
                Vehiculo.EliminarVehiculo(placa);
            });

            $('#formEditarVehiculo').on('submit', function (e) {
                e.preventDefault();
                Vehiculo.ModificarVehiculo();
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
        //---------------------
        LlenarSelectPropietarios() {
            $.get('/Cliente/ObtenerClientes', function (response) {
                const select = $('#selectPropietario');
                select.empty();
                select.append('<option value="">Seleccione propietario...</option>');

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
                        placeholder: "Seleccione propietario...",
                        width: '100%',
                        allowClear: true,
                        dropdownParent: $('#modalCrearVehiculo') // 👈 Esto es clave
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
        MostrarModalEditarVehiculo(placa) {
            $.get('/Vehiculo/ObtenerVehiculoPorPlaca', { placa: placa }, function (response) {
                if (!response.esError) {
                    isLoadingData = true;

                    $('#edt-vh-placa').val(response.data.placa);
                    $('#edt-vh-marca').val(response.data.marca);
                    $('#edt-vh-anio').val(response.data.anio);
                    $('#edt-vh-modelo').val(response.data.modelo);
                    $('#edt-vh-kilometraje').val(response.data.kilometraje);
                    $('#edt-vh-peso').val(response.data.peso);
                    $('#edt-vh-combustible').val(response.data.capacidadCombustible);
                    $('#edt-vh-color').val(response.data.color);
                    $('#edt-vh-electrico').prop('checked', response.data.vehiculoElectrico);
                    $('#edt-vh-transmision').prop('checked', response.data.transmisionManual);
                    $('#edt-vh-transmision').prop('disabled', response.data.vehiculoElectrico);
                    $('#edt-vh-electrico').prop('disabled', response.data.transmisionManual);
                    $('#edt-vh-fechaRegistro').val(response.data.fechaRegistro);


                    // 🔹 Llenar el select de propietarios con el actual seleccionado
                    Vehiculo.LlenarSelectPropietariosEditar(response.data.propietarioId);

                    $('#edt-vh-fechaRegistro').val(response.data.fechaRegistro);
                    isLoadingData = false;

                    $('#modalEditarVehiculo').modal('show');
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
        LlenarSelectPropietariosEditar(propietarioSeleccionadoId = null) {
            $.get('/Cliente/ObtenerClientes', function (response) {
                const select = $('#edt-vh-propietarioId');
                select.empty();
                select.append('<option value="">Seleccione propietario...</option>');

                if (!response.esError) {
                    response.data.forEach(cliente => {
                        let nombreCompleto = cliente.nombre;
                        if (cliente.primerApellido || cliente.segundoApellido) {
                            nombreCompleto += ` ${cliente.primerApellido} ${cliente.segundoApellido}`;
                        }
                        select.append(`<option value="${cliente.identificacion}">${nombreCompleto}</option>`);
                    });

                    // Inicializa Select2
                    select.select2({
                        placeholder: "Seleccione propietario...",
                        width: '100%',
                        allowClear: true,
                        dropdownParent: $('#modalEditarVehiculo')
                    });

                    // Si hay un propietario ya asignado, se selecciona automáticamente
                    if (propietarioSeleccionadoId) {
                        select.val(propietarioSeleccionadoId).trigger('change');
                    }

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
        CrearVehiculo() {
            let form = $('#formCrearVehiculo');
            if (!form.valid()) return;

            $.ajax({
                url: '/Vehiculo/CrearVehiculo',
                type: 'POST',
                data: form.serialize(),
                success: function (response) {
                    if (!response.esError) {
                        $('#modalCrearVehiculo').modal('hide');
                        Vehiculo.tabla.ajax.reload();
                        form[0].reset();

                        Swal.fire({
                            icon: 'success',
                            title: 'Vehiculo Creado',
                            text: response.mensaje,
                            showConfirmButton: false,
                            timer: 1490
                        });
                    } else {
                        Swal.fire({
                            title: 'Ha ocurrido un error',
                            text: response.mensaje,
                            icon: 'error',
                            showConfirmButton: false,
                            timer: 1490
                        })
                    }
                }
            })
        },
        //---------------------
        EliminarVehiculo(placa) {
            Swal.fire({
                title: "Estas seguro de eliminar este vehiculo?",
                icon: "warning",
                showCancelButton: true,
                cancelButtonText: "Cancelar",
                confirmButtonText: "Si, eliminar",
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        url: '/Vehiculo/EliminarVehiculo',
                        type: 'DELETE',
                        data: { placa: placa },
                        success: function (response) {
                            if (!response.esError) {
                                Swal.fire({
                                    title: "Vehiculo eliminado",
                                    text: response.mensaje,
                                    icon: "success",
                                    showConfirmButton: false,
                                    timer: 1500
                                });
                                Vehiculo.tabla.ajax.reload();
                            } else {
                                Swal.fire({
                                    title: "Ha ocurrido un error",
                                    text: response.mensaje,
                                    icon: "error"
                                });
                                Vehiculo.tabla.ajax.reload();
                            }
                        }
                    });
                }
            });
        },
        //---------------------
        ModificarVehiculo() {
            let form = $('#formEditarVehiculo');
            if (!form.valid()) return;

            $.ajax({
                url: '/Vehiculo/ModificarVehiculo',
                type: 'PUT',
                data: form.serialize(),
                success: function (response) {
                    if (!response.EsError) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Vehiculo modificado',
                            text: response.Mensaje,
                            showConfirmButton: false,
                            timer: 1490
                        });
                        $('#modalEditarVehiculo').modal('hide');
                        Vehiculo.tabla.ajax.reload();
                        form[0].reset();
                    } else {
                        Swal.fire({
                            title: 'Ha ocurrido un error',
                            text: response.Mensaje,
                            icon: 'error',

                        });
                    }
                }
            });
        }
    }
    $(document).ready(() => Vehiculo.init());
})();

