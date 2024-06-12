$(document).ready(function() {
    // Função para atualizar a tabela de aloos
    function atualizarTabelaAloos() {
        $.get('@Url.Action("AtualizarTabelaAloos", "Aloo")', function(data) {
            $('#aloosTable').html(data);
        });
    }

    // Atualizar a tabela a cada 5 segundos (5000 milissegundos)
    setInterval(atualizarTabelaAloos, 60000);
});


$.extend( $.fn.dataTable.defaults, {

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


