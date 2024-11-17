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

        private void BindGrid(string searchTerm = null)
        {
            using (var db = new TinyTotsDbContext())
            {

                var query = db.TinyTotsTable.AsQueryable();

                // Apply search filter if search term is provided
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    searchTerm = searchTerm.ToLower(); // Case-insensitive search
                    query = query.Where(r => r.FirstName.ToLower().Contains(searchTerm) ||
                                              r.SecondName.ToLower().Contains(searchTerm));
                }
                // Just bind all the data in TinyTotsTable as all records are considered registered 
                gvRegistrations.DataSource = query.ToList();
                gvRegistrations.DataBind();
            }
        }

        // Handle Search button click
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the search term entered by the user
            string searchTerm = txtSearch.Text.Trim();
            BindGrid(searchTerm); // Pass the search term to filter the data
        }

        // Handle Delete operation (deleting record from the list and database) 
        protected void gvRegistrations_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int registrationId = Convert.ToInt32(gvRegistrations.DataKeys[e.RowIndex].Value); 
            int registrationId = (int)e.Keys["RegistrationId"]; // Assuming RegistrationId is an int 
            using (var db = new TinyTotsDbContext())
            {
                // Find and remove the record with the specified RegistrationId 
                var recordToDelete = db.TinyTotsTable.FirstOrDefault(r => r.RegistrationId == registrationId);
                if (recordToDelete != null)
                {
                    db.TinyTotsTable.Remove(recordToDelete);
                    db.SaveChanges();
                }
            }
            // Re-bind the GridView to reflect the changes 
            BindGrid();
        }
    }
}
