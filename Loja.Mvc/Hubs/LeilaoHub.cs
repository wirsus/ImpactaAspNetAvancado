﻿using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace Loja.Mvc.Hubs
{
    public class LeilaoHub : Hub
    {
        public async Task Participar(string nomeParticipante, string produtoId)
        {
            await Groups.Add(Context.ConnectionId, produtoId);
            Clients.Group(produtoId).adicionarMensagem(nomeParticipante, Context.ConnectionId, "Have a nice day!");
            
        }

        public void RealizarLance(string nomeParticipante, string connectionId, string valor, string produtoId)
        {
            Clients.Group(produtoId).adicionarMensagem(nomeParticipante, connectionId, valor);
        }

        public void EnviarLike(string nomeRemetente, string connectionIdDestinatario )
        {
            Clients.Client(connectionIdDestinatario).receberLike(nomeRemetente);
        }
    }
}