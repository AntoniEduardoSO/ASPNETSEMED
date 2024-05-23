console.log("oi");

$(document).ready(function() {
    $('#searchInput').on('keyup', function() {
        var value = $(this).val().toLowerCase();
        $('.card-item').filter(function() {
            $(this).toggle($(this).attr('data-escola').toLowerCase().indexOf(value) > -1);
        });
    });

    $('.form-control').on('input', function() {
        if ($(this).val() === "") {
            resetFilter();
        }
    });

    function resetFilter() {
        $('.card-item').show(); // Mostra todos os itens
    }

    $('#exampleModal').on('show.bs.modal', function(event) {
        console.log("PINGUEI!!!");
        var button = $(event.relatedTarget); // Botão que acionou o modal
        var ip = button.siblings('.text-center').text().split(': ')[1]; // Obtém o IP da escola

        // Define o texto do título do modal com o IP da escola
        var modal = $(this);
        modal.find('.modal-title').text('Ping no IP: ' + ip);

        // Define a ação a ser executada quando o botão "Save changes" do modal é clicado
        modal.find('.btn-primary').on('click', function() {
            console.log("PINGUEI!!!");
            // Aqui você pode realizar o ping no endereço IP e verificar se está tudo OK
            // Por exemplo, você pode usar fetch() para enviar uma solicitação ao servidor
            // e processar a resposta para determinar se o ping foi bem-sucedido ou não.
            console.log('Pinging IP:', ip);
            fetch('/ping', {
                method: 'POST',
                body: JSON.stringify({ ip: ip }),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => {
                if (response.ok) {
                    console.log('Ping successful');
                } else {
                    console.log('Ping failed');
                }
            })
            .catch(error => {
                console.error('Error pinging IP:', error);
            });

            // Fechar o modal após realizar o ping
            $('#exampleModal').modal('hide');
        });
    });
});
