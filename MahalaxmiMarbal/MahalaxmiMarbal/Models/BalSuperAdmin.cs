using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MahalaxmiMarbal.Models
{
    public class BalSuperAdmin
    {
        static string constring = ConfigurationManager.ConnectionStrings["MMG"].ConnectionString;
        public SqlConnection con = new SqlConnection(constring);

        //Get All Customer Deatils
        public DataSet Course()
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Customer_Deatils", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetAllCustomerDeatils");
            DataSet ds = new DataSet();
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            adpt.Fill(ds);
            con.Close();
            return ds;
        }


        public SqlDataReader GetlatestCustId(string count)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Customer_Deatils", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "getlatestcustid");
            SqlDataReader dr = cmd.ExecuteReader();
            // con.Close();
            return dr;
        }

    }


}