using System;
using System.Linq;
using System.Web.UI.WebControls;
using TinyTotsWebApp.Models;

namespace TinyTotsWebApp
{
    public partial class RegistrationList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            using (var db = new TinyTotsDbContext())
            {
                // Just bind all the data in TinyTotsTable as all records are considered registered 
                gvRegistrations.DataSource = db.TinyTotsTable.ToList();
                gvRegistrations.DataBind();
            }
        }
    }
}
