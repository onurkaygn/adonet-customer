﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adonetCustomerProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=ONURALPKAYGIN; initial catalog=DbCustomer; integrated security=true");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM TblCity", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO TblCity (CityName, CityCountry) VALUES (@cityName, @cityCountry)", sqlConnection);
            command.Parameters.AddWithValue("@cityName", txtCityName.Text);
            command.Parameters.AddWithValue("@cityCountry", txtCityCountry.Text);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("City Added Successfully");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM TblCity WHERE CityId=@cityId", sqlConnection);
            command.Parameters.AddWithValue("@cityId", txtCityId.Text);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("City Deleted Successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE TblCity SET CityName=@cityName, CityCountry=@cityCountry WHERE CityId=@cityId", sqlConnection);
            command.Parameters.AddWithValue("@cityId", txtCityId.Text);
            command.Parameters.AddWithValue("@cityName", txtCityName.Text);
            command.Parameters.AddWithValue("@cityCountry", txtCityCountry.Text);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("City Updated Successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
