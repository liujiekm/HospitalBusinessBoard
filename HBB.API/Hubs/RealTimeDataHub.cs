using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace HBB.API.Hubs
{

    [HubName("realTimeDataHub")]

    public class RealTimeDataHub : Hub
    {
        
    }
}