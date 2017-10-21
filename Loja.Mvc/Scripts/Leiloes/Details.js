// Kyle Simpson - object literal
var Details = {
    produtoId: 0,
    nomeParticipante: "",
    preco: 0,
    estoque: 0,
    categoriaId: 0,
    ativo: 0,
    emLeilao: 0,

    inicializar: function (produtoId) {
        this.produtoId = produtoId;
        this.conectarLeilaoHub();
        this.vincularEventos();
    },

    conectarLeilaoHub: function () {
        var connection = $.hubConnection();
        var hub = connection.createHubProxy("LeilaoHub");

        //hub.on("atualizarOfertas", function () { document.location.reload(); });
        connection.start();
    },

    vincularEventos: function () {
        $("#entrarButton").on("click", function () { this.entrarLeilao(); });
    },

    entrarLeilao: function () {
        this.nomeParticipante = $("#nomeParticipante").val();

        //this.leilaoHub.invoke("Participar", this.nomeParticipante, this.produtoId);

        $("#participanteDiv").hide();
        $("#lanceDiv").show();
        $("#valorLance").focus();
    }
};