$.extend($.fn.dataTable.defaults, {
    language: {
        search: 'Buscar:',
        lengthMenu: 'Exibir _MENU_ Registros por página',
        info: 'Exibindo _START_ a _END_ de _TOTAL_ registros',
        infoEmpty: 'Nenhum registro encontrado',
        infoFiltered: '(filtrado de um total de _MAX_ registros)',
        emptyTable: 'Nenhum dado disponível na tabela',
    }
});

// Para esta tabela específica, vamos habilitar a ordenação e ocultar a coluna Sigla
$(document).ready(function() {
    $('#example').DataTable({
        ordering: true,
        columnDefs: [
            {
                targets: [4],  // Índice da coluna que você deseja ocultar (começa do zero)
                visible: false
            }
        ]
    });
});
