var dataTable;

$(document).ready(function () {
    cargarDataTables();
});


function cargarDataTables(){

    dataTable = $('#tblslaider').DataTable({
        "ajax": {
            "url":"/Sliders/GetAll",
            "type": "GET",
            "datatype": "json",
        },

          "columns": [
            { "data": "nombre", "width": "15%" },

            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center"> 
                             <a href='/Sliders/Edit/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                             <i class="fas fa-edit"></i> Editar
                             </a>

                             &nbsp;
                             <a onclick=Delete("/Sliders/Eliminar/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                             <i class='fas fa-trash-alt'></i> Borrar
                            </a>

                         `;
                }, "width": "30%"
            }
        ],
        language:
           {
                "emptyTable": "No Hay Registro"
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