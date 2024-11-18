using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TinyTotsWebApp.Models;
namespace TinyTotsWebApp
{
    public partial class RegisterChild : System.Web.UI.Page
    {
        protected void Page_Load(object sender,  EventArgs e)
        {
            if (!IsPostBack) {
                lblCurrentTime.Text = "Hello friends! The time now is " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            using(var db = new TinyTotsDbContext())
            {
                var registration = new TinyTots
                {
                    FirstName = txtFirstName.Text,
                    SecondName = txtSecondName.Text,
                    Race = ddlRace.SelectedValue,
                    Gender = rblGender.SelectedValue,
                    FoodAllergies = string.Join(",", cblAllergies.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Text))
                    

                };

                db.TinyTotsTable.Add(registration);
                db.SaveChanges();
            }
        }

        protected void cblAllergies_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isNoneChecked = cblAllergies.Items.FindByValue("None").Selected;

            foreach (ListItem item in cblAllergies.Items)
            {
                if (item.Value != "None")
                {
                    item.Enabled = !isNoneChecked;
                }

                if (isNoneChecked && item.Value != "None")
                {
                    item.Selected = false;
                }

            }
               
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = string.Empty;
            txtSecondName.Text = string.Empty;

            ddlRace.SelectedIndex = 0;

            rblGender.ClearSelection();

            foreach (ListItem item in cblAllergies.Items)
            {
                item.Selected = false;
            }

        }


    }
}