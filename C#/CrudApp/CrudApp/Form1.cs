using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CrudApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=laptop-2a4lsaor\sqlexpress;Initial Catalog=School;Integrated Security=True");
        public int StudentId;

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();

        }

        private void GetStudentsRecord()
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentDetails", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);

            con.Close();

            StudentRecorddataGridView.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentDetails VALUES (@StudentName,@StudentFatherName,@StudentRollNumber,@StudentAddress,@StudentContact)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@StudentName", txtName.Text);
                cmd.Parameters.AddWithValue("@StudentFatherName", txtFatherName.Text);
                cmd.Parameters.AddWithValue("@StudentRollNumber", txtRollNumber.Text);
                cmd.Parameters.AddWithValue("@StudentAddress", txtAddress.Text);
                cmd.Parameters.AddWithValue("@StudentContact", txtMobileNumber.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New Student Inserted Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentsRecord();
                ResetFormControls();
            }
        }
        private bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Student Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!IsAlpha(txtName.Text))
            {
                MessageBox.Show("Student Name should only contain alphabetic characters", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFatherName.Text))
            {
                MessageBox.Show("Father's Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!IsAlpha(txtFatherName.Text))
            {
                MessageBox.Show("Father's Name should only contain alphabetic characters", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtRollNumber.Text))
            {
                MessageBox.Show("Roll Number is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!IsNumeric(txtRollNumber.Text))
            {
                MessageBox.Show("Roll Number should be a numeric value", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMobileNumber.Text))
            {
                MessageBox.Show("Mobile Number is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!IsNumeric(txtMobileNumber.Text))
            {
                MessageBox.Show("Mobile Number should be a numeric value", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobileNumber.Text.Length != 10)
            {
                MessageBox.Show("Mobile Number should be 10 digits long", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool IsAlpha(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StudentId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE StudentDetails SET StudentName=@StudentName,StudentFatherName=@StudentFatherName,StudentRollNumber=@StudentRollNumber,StudentAddress=@StudentAddress,StudentContact=@StudentContact WHERE StudentId = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@StudentName", txtName.Text);
                cmd.Parameters.AddWithValue("@StudentFatherName", txtFatherName.Text);
                cmd.Parameters.AddWithValue("@StudentRollNumber", txtRollNumber.Text);
                cmd.Parameters.AddWithValue("@StudentAddress", txtAddress.Text);
                cmd.Parameters.AddWithValue("@StudentContact", txtMobileNumber.Text);
                cmd.Parameters.AddWithValue("@ID", this.StudentId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Student details Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudentsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show(" Select a student to update", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (StudentId > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM StudentDetails WHERE StudentId = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.StudentId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Student entry deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudentsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show(" Select a student to delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void ResetFormControls()
        {
            StudentId = 0;
            txtName.Clear();
            txtFatherName.Clear();
            txtAddress.Clear();
            txtMobileNumber.Clear();
            txtRollNumber.Clear();
            txtName.Focus();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentRecorddataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentId = Convert.ToInt32(StudentRecorddataGridView.SelectedRows[0].Cells[0].Value);
            txtName.Text = StudentRecorddataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtFatherName.Text = StudentRecorddataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtRollNumber.Text = StudentRecorddataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtAddress.Text = StudentRecorddataGridView.SelectedRows[0].Cells[4].Value.ToString();
            txtMobileNumber.Text = StudentRecorddataGridView.SelectedRows[0].Cells[5].Value.ToString();
        }
    }
}

    






/*using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CrudApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=laptop-2a4lsaor\sqlexpress;Initial Catalog=School;Integrated Security=True");
        public int StudentId;
        private void button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void ResetFormControls()
        {
            StudentId = 0;
            txtName.Clear();
            txtFatherName.Clear();
            txtAddress.Clear();
            txtMobileNumber.Clear();
            txtRollNumber.Clear();
            txtName.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StudentId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE StudentDetails SET StudentName=@StudentName,StudentFatherName=@StudentFatherName,StudentRollNumber=@StudentRollNumber,StudentAddress=@StudentAddress,StudentContact=@StudentContact WHERE StudentId = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@StudentName", txtName.Text);
                cmd.Parameters.AddWithValue("@StudentFatherName", txtFatherName.Text);
                cmd.Parameters.AddWithValue("@StudentRollNumber", txtRollNumber.Text);
                cmd.Parameters.AddWithValue("@StudentAddress", txtAddress.Text);
                cmd.Parameters.AddWithValue("@StudentContact", txtMobileNumber.Text);
                cmd.Parameters.AddWithValue("@ID", this.StudentId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Student details Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudentsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show(" Select a student to update", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (StudentId > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM StudentDetails WHERE StudentId = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.StudentId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Student entry deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudentsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show(" Select a student to delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();

        }

        private void GetStudentsRecord()
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentDetails", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);

            con.Close();

            StudentRecorddataGridView.DataSource = dt;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentDetails VALUES (@StudentName,@StudentFatherName,@StudentRollNumber,@StudentAddress,@StudentContact)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@StudentName", txtName.Text);
                cmd.Parameters.AddWithValue("@StudentFatherName", txtFatherName.Text);
                cmd.Parameters.AddWithValue("@StudentRollNumber", txtRollNumber.Text);
                cmd.Parameters.AddWithValue("@StudentAddress", txtAddress.Text);
                cmd.Parameters.AddWithValue("@StudentContact", txtMobileNumber.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New Student Inserted Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentsRecord();
                ResetFormControls();
            }
        }

        private bool IsValid()
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Student Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }



        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentRecorddataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentId = Convert.ToInt32(StudentRecorddataGridView.SelectedRows[0].Cells[0].Value);
            txtName.Text = StudentRecorddataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtFatherName.Text = StudentRecorddataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtRollNumber.Text = StudentRecorddataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtAddress.Text = StudentRecorddataGridView.SelectedRows[0].Cells[4].Value.ToString();
            txtMobileNumber.Text = StudentRecorddataGridView.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void StudentRecorddataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}*/
