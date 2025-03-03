using Microsoft.AspNetCore.SignalR;

namespace labo.signalr.api.Hubs
{
    public class TaskHub : Hub
    {
        public async Task AddTask(string name, string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("TaskList");
            //est-ce que tu envoies le tasklist au client avec un certain connectionid
            //( await Clients.Client(connectionId).SendAsync("TaskList"); )
            
            //ou est-ce que tu envoies le tasklist au user avec un certain userid
            //( await Clients.User(userId).SendAsync("TaskList"); )
        }
    }
}
