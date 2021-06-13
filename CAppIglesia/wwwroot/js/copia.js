var dataTable;

$(document).ready(function () {
    cargarDataTables();
});


function cargarDataTables(){

    dataTable = $('#tbltablaR').DataTable({
        "ajax": {
            "url":"/Registros/GetAll",
            "type": "GET",
            "datatype": "json",
        },

          "columns": [
              { "data": "primerNombre", "width": "10%" },
              { "data": "primerApellido", "width": "10%" },
              { "data": "concepto", "width": "10%" },
              { "data": "cantidad", "width": "10%" },
              { "data": "fechaDePago", "width": "20%" },

         
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
       
   
    })
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