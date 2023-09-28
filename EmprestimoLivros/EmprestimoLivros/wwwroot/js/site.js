$(document).ready(function () {
    $('#Emprestimos').DataTable({
        language: 
        {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "Mostrando _START_ registro de _END_ em um total de _TOTAL_ entradas",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "(filtrado de _MAX_ entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ entradas",
            "loadingRecords": "Loading...",
            "processing": "",
            "search": "Procurar:",
            "zeroRecords": "No matching records found",
            "paginate":
            {
               "first": "Primeiro",
               "last": "Último",
               "next": "Próximo",
               "previous": "Anterior"
                },
            "aria":
            {
               "sortAscending": ": activate to sort column ascending",
               "sortDescending": ": activate to sort column descending"
            }
        }
        
    });

    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        })
    },3000)
})