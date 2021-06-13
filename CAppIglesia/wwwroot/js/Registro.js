var dataTable;

$(document).ready(function () {
    cargarDataTable();
});


function cargarDataTable() {

    dataTable = $("#tbltablaR").DataTable({
        "ajax": {
            "url": "/Registros/GetAll",
            "type": "GET",
            "datatype": "json",
        },
        dom: 'Bfrtip',
        buttons: [
            'excel', 'pdf', 'print'
        ],

        "columns": [
            { "data": "primerNombre", "width": "10%" },
            { "data": "primerApellido", "width": "10%" },
            { "data": "concepto", "width": "10%" },
            { "data": "cantidad", "width": "10%" },
            { "data": "fechaDePago", "width": "20%" },

            {
                "data": "ofrendaID",
                "render": function (data) {
                    return `<div class="text-center"> 
                             <a href='/Registros/Editar/${data}' class='btn btn-success text-white' style='Cursor:pointer; width:100px;'>
                             <i class="fas fa-edit"></i> Editar
                             </a>
                        
                             &nbsp;
                             <a onclick=Delete("/Registros/Eliminar/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                             <i class='fas fa-trash-alt'></i> Borrar
                            </a>
                     
                         `;
                }, "width": "30%"

            }
        ],
       
        language:
        {
            "processing": "Procesando...",
            "lengthMenu": "Mostrar _MENU_ registros",
            "zeroRecords": "No se encontraron resultados",
            "emptyTable": "Ningún dato disponible en esta tabla",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "search": "Buscar:",
            "infoThousands": ",",
            "loadingRecords": "Cargando...",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}



function Delete(url) {
    swal({
        title: "Esta Seguro De Borrar",
        text: "Este Contenido no se puede recuperar",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, Borrar",
        closeOnconfirm: true
    },
        function () {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();

                    }
                    else {
                        toastr.error(data.message)

                    }
                }

            });
        });

}
