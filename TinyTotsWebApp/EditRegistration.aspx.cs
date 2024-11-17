using System;
using System.Linq;
using System.Web.UI.WebControls;
using TinyTotsWebApp.Models;

namespace TinyTotsWebApp
{
    public partial class EditRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the RegistrationId from the query string 
                int registrationId = Convert.ToInt32(Request.QueryString["RegistrationId"]);

                // Load the data for the specific registration 
                LoadRegistration(registrationId);
            }
        }

        // Method to load the registration data 
        private void LoadRegistration(int registrationId)
        {
            using (var db = new TinyTotsDbContext())
            {
                // Find the record in the database 
                var registration = db.TinyTotsTable.SingleOrDefault(c => c.RegistrationId == registrationId);

                if (registration != null)
                {
                    // Populate form fields with the existing data 
                    hfRegistrationId.Value = registration.RegistrationId.ToString();
                    txtFirstName.Text = registration.FirstName;
                    txtSecondName.Text = registration.SecondName;
                    ddlRace.SelectedValue = registration.Race;
                    rblGender.SelectedValue = registration.Gender;

                    // Populate the allergies CheckBoxList 
                    string[] allergies = registration.FoodAllergies.Split(new[] { ", " }, StringSplitOptions.None);
                    foreach (ListItem item in cblAllergies.Items)
                    {
                        if (allergies.Contains(item.Value))
                        {
                            item.Selected = true;
                        }
                    }

                }
            }
        }

        // Method to handle the Save button click event 
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int registrationId = Convert.ToInt32(hfRegistrationId.Value);

            using (var db = new TinyTotsDbContext())
            {
                // Find the existing registration record 
                var registrationToUpdate = db.TinyTotsTable.SingleOrDefault(c => c.RegistrationId ==
registrationId);

                if (registrationToUpdate != null)
                {
                    // Update the properties with the values from the form fields 
                    registrationToUpdate.FirstName = txtFirstName.Text;
                    registrationToUpdate.SecondName = txtSecondName.Text;
                    registrationToUpdate.Race = ddlRace.SelectedValue;
                    registrationToUpdate.Gender = rblGender.SelectedValue;

                    // Update the Food Allergies 
                    registrationToUpdate.FoodAllergies = string.Join(", ",
cblAllergies.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value));

                    // Save changes to the database 
                    db.SaveChanges();

                    // Show success message (you can replace this with any message control on your form if needed) 
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Update successful!');", true);

                    // Redirect to RegistrationList.aspx after update 
                    Response.Redirect("RegistrationList.aspx");
                }
            }
        }
    }
}