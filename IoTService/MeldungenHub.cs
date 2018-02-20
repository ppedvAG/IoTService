using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace IoTService
{
    public class MeldungenHub : Hub
    {
        public static void AddMeldung(string meldung)
        {
            var ef = new MeldungsModel();
            var newMeldung = new ServiceMeldungen() { Meldung = meldung ,Datum=DateTime.Now};
            ef.ServiceMeldungen.Add(newMeldung);
            ef.SaveChanges();

            var ctx = GlobalHost.ConnectionManager.GetHubContext<MeldungenHub>();
       
            ctx.Clients.All.RefreshUI(newMeldung);
        }
    }
}