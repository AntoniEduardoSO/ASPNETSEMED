$.extend( $.fn.dataTable.defaults, {
    // paging: false

    language: {
        search: 'Buscar:',
        lengthMenu: 'Exibir _MENU_ Registros por página',
        info: 'Exibindo _START_ a _END_ de _TOTAL_ registros',
        infoEmpty: 'Nenhum registro encontrado',
        infoFiltered: '(filtrado de um total de _MAX_ registros)',
        emptyTable: 'Nenhum dado disponível na tabela',
    }
} );
 
// For this specific table we are going to enable ordering
// (searching is still disabled)
$('#example').DataTable( {
    ordering: true
} );