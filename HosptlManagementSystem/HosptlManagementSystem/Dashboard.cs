﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace HosptlManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            labellndecator1.ForeColor = System.Drawing.Color.Red;
            labellndecator2.ForeColor = System.Drawing.Color.Black;
            labellndecator3.ForeColor = System.Drawing.Color.Black;
            labellndecator4.ForeColor = System.Drawing.Color.Black;


            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
           
        }

        private void btnAddDiagnosis_Click(object sender, EventArgs e)
        {
            labellndecator2.ForeColor = System.Drawing.Color.Red;
            labellndecator1.ForeColor = System.Drawing.Color.Black;
            labellndecator3.ForeColor = System.Drawing.Color.Black;
            labellndecator4.ForeColor = System.Drawing.Color.Black;

            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void btnFullHistory_Click(object sender, EventArgs e)
        {
            labellndecator3.ForeColor = System.Drawing.Color.Red;
            labellndecator1.ForeColor = System.Drawing.Color.Black;
            labellndecator2.ForeColor = System.Drawing.Color.Black;
            labellndecator4.ForeColor = System.Drawing.Color.Black;

            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-5TLLTDN\\SQLEXPRESS; database= hospital; integrated security = True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from AddPatient inner join PatientMore on AddPatient.pid = PatientMore.pid";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView2.DataSource = DS.Tables[0];

        }

        private void btnHospital_Click(object sender, EventArgs e)
        {
            labellndecator4.ForeColor = System.Drawing.Color.Red;
            labellndecator1.ForeColor = System.Drawing.Color.Black;
            labellndecator2.ForeColor = System.Drawing.Color.Black;
            labellndecator3.ForeColor = System.Drawing.Color.Black;

            panel4.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                String name = txtName.Text;
                String address = txtAddress.Text;
                Int64 contact = Convert.ToInt64(txtContact.Text);
                int age = Convert.ToInt32(txtAge.Text);
                String gender = comboGender.Text;
                String blood = txtBlood.Text;
                String any = txtAny.Text;
                int pid = Convert.ToInt32(txtPid.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5TLLTDN\\SQLEXPRESS; database = hospital; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "INSERT INTO AddPatient VALUES ('" + name + "', '" + address + "', " + contact + ", " + age + ", '" + gender + "', '" + blood + "', '" + any + "', '" + pid + "')";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
            }
            catch(Exception)
            {
                MessageBox.Show("Invalied Data Format! ");
            }

                MessageBox.Show("Data Saved");

            txtName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtAge.Clear();
            txtBlood.Clear();
            txtAny.Clear();
            txtPid.Clear();
            comboGender.ResetText();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") ;

            int pid = Convert.ToInt32 (textBox1.Text);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-5TLLTDN\\SQLEXPRESS; database= hospital; integrated security = True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from AddPatient where pid = " + pid + "";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(textBox1.Text);
                String sympt = txtBxSymptoms.Text;
                String diag = txtBxDiagnosis.Text;
                String medicine = txtBxMedicines.Text;
                String ward = comboBxWard.Text;
                String wardType = comboBXWardType.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5TLLTDN\\SQLEXPRESS; database= hospital; integrated security = True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into PatientMore values ("+pid+", '"+sympt+"', '"+diag+"', '"+medicine+"','"+ward+"','"+wardType+"')";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

            }
            catch(Exception)
            {
                MessageBox.Show("Any field is emprt OR data is in WRONG format");
            }
            MessageBox.Show("Data saved");

            textBox1.Clear();
            txtBxDiagnosis.Clear();
            txtBxMedicines.Clear();
            txtBxSymptoms.Clear();
            comboBxWard.ResetText();
            comboBXWardType.ResetText();
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
