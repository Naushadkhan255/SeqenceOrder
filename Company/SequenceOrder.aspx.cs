﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Company
{
    public partial class SequenceOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

        }

        
            protected void CompanyDDL_SelectedIndexChanged(object sender, EventArgs e)
            {
                string selectedCompanyID = CompanyDDL.SelectedValue;
                int number = GetNextNumber(selectedCompanyID);
                NumberTxt.Text = number.ToString();
            }

            private int GetNextNumber(string CompanyId)
            {
                string cs = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
                //SqlConnection con = new SqlConnection(cs);
                string query = "SELECT max(Number) FROM CompanyData WHERE CompanyId = @CompanyId";

                using (SqlConnection Con = new SqlConnection(cs))
                {
                    SqlCommand command = new SqlCommand(query, Con);
                    command.Parameters.AddWithValue("@CompanyId", CompanyId);
                    Con.Open();

                    int maxNumber = (int)command.ExecuteScalar();
                    return maxNumber + 1;
                }
            }

            protected void Button1_Click(object sender, EventArgs e)
            {
                string selectedCompanyID = CompanyDDL.SelectedValue;
                int number = int.Parse(NumberTxt.Text);

                string cs = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString; 
                string query = "INSERT INTO CompanyData (CompanyId, Number) VALUES (@CompanyId, @Number)";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@CompanyId", selectedCompanyID);
                    command.Parameters.AddWithValue("@Number", number);
                    con.Open();
                    command.ExecuteNonQuery();
                              
                }
                    this.lebMassage.Text = "Data inserted successfully!";
                    this.lebMassage.Visible = true;
                    this.lebMassage.ForeColor = Color.Green;
            }
    }
}
