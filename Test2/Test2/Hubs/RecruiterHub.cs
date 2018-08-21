using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Test2.Hubs
{
    /// <summary>
    /// Used for providing realtime updates for the ValuesController.
    /// </summary>
    public class RecruiterHub : Hub
    {
       
        public async Task Add(string value) => await Clients.All.SendAsync(value);

    }
}
