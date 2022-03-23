using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DataBaseDemo1
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(@"Server=DESKTOP-LO30BL0\SQLEXPRESS;Database=Praticaldb;Integrated Security=True");
        }

        public void Cleardata()
        {
            textid.Clear();
            textName.Clear();
            textDesignation.Clear();
            textsalary.Clear();

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into Employee values(@Id,@Name,@Designation,@Salary)";
                cmd = new SqlCommand(qry, con);
                con.Open();
                cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(textid.Text));
                cmd.Parameters.AddWithValue("@Name", textName.Text);
                cmd.Parameters.AddWithValue("@Designation", textDesignation.Text);
                cmd.Parameters.AddWithValue("@Salary", Convert.ToDouble(textsalary.Text));
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Sucessfully saved the record");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "Select * from Employee Where ID=@id";
                cmd = new SqlCommand(qry, con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textid.Text));
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        textName.Text = dr["Name"].ToString();
                        textDesignation.Text = dr["Designation"].ToString();
                        textsalary.Text = dr["salary"].ToString();

                    }
                }

                else
                {
                    MessageBox.Show("record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "update  Employee set values Name=@name,Designation=@designation,Salary=@Salary where ID=@id";
                cmd = new SqlCommand(qry, con);
                con.Open();
                cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(textid.Text));
                cmd.Parameters.AddWithValue("@Name", textName.Text);
                cmd.Parameters.AddWithValue("@Designation", textDesignation.Text);
                cmd.Parameters.AddWithValue("@Salary", Convert.ToDouble(textsalary.Text));
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Sucessfully saved the record");
                    Cleardata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try {
                string qry = "Delete from Employee where ID=@id";
                cmd = new SqlCommand(qry, con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textid.Text));
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Sucessfully Delete the record");
                    Cleardata();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try {
                String qry = "Select MAX(Id) from Employee";
                cmd = new SqlCommand(qry, con);
                con.Open();
                object obj = cmd.ExecuteScalar();
                if (obj == DBNull.Value)
                {
                    textid.Text = "101";

                }
                else
                {
                    int id = Convert.ToInt32(obj);
                    id++;
                    textid.Text = id.ToString();
                }
                textid.Enabled = false;
                Cleardata();
            }
    
         catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }


        }
    }
}

    //    private void btnUpdate_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            string qry = "update  Employee set values Name=@name,Designation=@designation,Salary=@Salary where ID=@id";
    //            cmd = new SqlCommand(qry, con);
    //            con.Open();
    //            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(textid.Text));
    //            cmd.Parameters.AddWithValue("@Name", textName.Text);
    //            cmd.Parameters.AddWithValue("@Designation", textDesignation.Text);
    //            cmd.Parameters.AddWithValue("@Salary", Convert.ToDouble(textsalary.Text));
    //            int result = cmd.ExecuteNonQuery();
    //            if (result == 1)
    //            {
    //                MessageBox.Show("Sucessfully updated the record");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.Message);
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }
    //    }
    //}
    //}

