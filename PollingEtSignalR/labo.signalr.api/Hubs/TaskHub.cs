using labo.signalr.api.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace labo.signalr.api.Hubs
{
    public class TaskHub : Hub
    {
        ApplicationDbContext _context;

        public TaskHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public static class UserHandler
        {
            public static HashSet<string> ConnectedIds = new HashSet<string>();
        }

        public async Task Connection(string connectionId)
        {
            UserHandler.ConnectedIds.Add(connectionId);
            await Clients.Caller.SendAsync("TaskList", _context.UselessTasks.ToListAsync());
            //est-ce que tu envoies le tasklist au client avec un certain connectionid
            //( await Clients.Client(connectionId).SendAsync("TaskList"); )

            //ou est-ce que tu envoies le tasklist au user avec un certain userid
            //( await Clients.User(userId).SendAsync("TaskList"); )
        }
    }
}
