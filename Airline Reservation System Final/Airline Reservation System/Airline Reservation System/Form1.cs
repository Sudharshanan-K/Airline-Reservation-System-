using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.OleDb;
using System.Data.SqlClient;
//using System.Data.SqlClient;

namespace Airline_Reservation_System
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        public Form1()
        {
            InitializeComponent();
            DisplayData();
            
        }

        private void btnadd_Click(object sender, EventArgs e)
        {

           
            if(tb1.Text=="" && tb2.Text == "" && tb3.Text == "" && tb4.Text == "" && tb5.Text == "" && tb6.Text == "" && cb3.Text == "" && cb4.Text == "" && cb7.Text == "")
            {
                MessageBox.Show("Please Fill all the Details :(","Warning");
            }
            if (tb1.Text == "" && tb2.Text == "" && tb3.Text == "" && tb4.Text == "" && tb5.Text == "" && tb6.Text == "" && cb3.Text == "" && cb4.Text == "" && cb7.Text == "")
            {
                cmd = new SqlCommand("insert into Table(Name,Age,Gender,Nationality,Depart from,Destination,Class) values(@name,@age,@gender,@nationality,@depart from,@destination,@class)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Name", tb1.Text);
                cmd.Parameters.AddWithValue("@Age", tb2.Text);
                cmd.Parameters.AddWithValue("@Gender", cb1.Text);
                cmd.Parameters.AddWithValue("@Nationality", tb3.Text);
                cmd.Parameters.AddWithValue("@Depart from", cb3.Text);
                cmd.Parameters.AddWithValue("@Destination", cb4.Text);
                cmd.Parameters.AddWithValue("@Class", cb7.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Table", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Clear Data  
       

        private void btnclear_Click(object sender, EventArgs e)
        {
            /*tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            cb6.Text = "";
            cb7.Text = "";
            cb1.Text = "";
            cb2.Text = "";
            cb3.Text = "";
            cb4.Text = "";
            cb5.Text = "";*/
            
        }
        private void ClearData()
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            cb6.Text = "";
            cb7.Text = "";
            cb1.Text = "";
            cb2.Text = "";
            cb3.Text = "";
            cb4.Text = "";
            cb5.Text = ""; 
             ID = 0;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = tb1.Text;
            dataGridView1.Rows[n].Cells[1].Value = tb2.Text;
            dataGridView1.Rows[n].Cells[2].Value = cb1.Text;
            dataGridView1.Rows[n].Cells[3].Value = tb3.Text;
            dataGridView1.Rows[n].Cells[4].Value = cb6.Text;
            dataGridView1.Rows[n].Cells[5].Value = cb7.Text;
            dataGridView1.Rows[n].Cells[6].Value = cb5.Text;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "" && tb2.Text == "" && tb3.Text == "" && tb4.Text == "" && tb5.Text == "" && tb6.Text == "" && cb3.Text == "" && cb4.Text == "" && cb7.Text == "")
            {
                
                cmd = new SqlCommand("update Table set Name=@name,Age=@age,Gender=@gender,Nationality=@nationality,Depart from=@depart from,Destination=@destination,Class=@class where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", tb1.Text);
                cmd.Parameters.AddWithValue("@gender", cb1.Text);
                cmd.Parameters.AddWithValue("@nationality", tb3.Text);
                cmd.Parameters.AddWithValue("@depart from", cb3.Text);
                cmd.Parameters.AddWithValue("@destination", cb4.Text);
                cmd.Parameters.AddWithValue("@class", cb7.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                DisplayData();
                ClearData();

            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("Table where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
    }
}
