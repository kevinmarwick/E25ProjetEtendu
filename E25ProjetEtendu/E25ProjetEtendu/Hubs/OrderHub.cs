using Microsoft.AspNetCore.SignalR;

namespace E25ProjetEtendu.Hubs
{
    public class OrderHub : Hub
    {
        // JoinGroup(userId) dans SignalR sert à regrouper les connexions SignalR d’un même utilisateur pour leur envoyer des messages ciblés.
        public async Task JoinGroup(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }

        public async Task LeaveGroup(string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }
    }
}
