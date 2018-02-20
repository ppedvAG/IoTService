using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IoTService
{
    public partial class MeldungsListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Der Rückgabetyp kann in 'IEnumerable' geändert werden. Damit Paginierung und Sortierung
        // unterstützt werden, müssen jedoch die folgenden Parameter hinzugefügt werden:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<ServiceMeldungen> GridView1_GetData()
        {

            var ef = new MeldungsModel();
               return ef.ServiceMeldungen.AsQueryable<ServiceMeldungen>();
        }
    }
}