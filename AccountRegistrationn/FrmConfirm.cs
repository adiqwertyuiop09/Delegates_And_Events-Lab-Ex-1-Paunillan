using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountRegistrationn
{
    public partial class FrmConfirm : Form
    {
        private StudentInfoClass.DelegateText DelProgram, DelLastName, DelFirstName, DelMiddleName, DelAddress;

        private void FrmConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private StudentInfoClass.DelegateNumber DelNumAge, DelNumContactNo, DelStudNo;
        public FrmConfirm()
        {
            InitializeComponent();
            DelProgram = new StudentInfoClass.DelegateText(StudentInfoClass.GetProgram);
            DelLastName = new StudentInfoClass.DelegateText(StudentInfoClass.GetLastName);
            DelFirstName = new StudentInfoClass.DelegateText (StudentInfoClass.GetFirstName);
            DelMiddleName = new StudentInfoClass.DelegateText(StudentInfoClass.GetMiddleName);
            DelAddress = new StudentInfoClass.DelegateText(StudentInfoClass.GetAddress);

            DelNumAge = new StudentInfoClass.DelegateNumber(StudentInfoClass.GetAge);
            DelNumContactNo = new StudentInfoClass.DelegateNumber (StudentInfoClass.GetContactNo);
            DelStudNo = new StudentInfoClass.DelegateNumber(StudentInfoClass.GetStudentNo);


            studlbl.Text = DelStudNo(StudentInfoClass.StudentNo).ToString();
            programlbl.Text = DelProgram(StudentInfoClass.Program);
            lnlbl.Text = DelLastName(StudentInfoClass.LastName);
            fnlbl.Text = DelFirstName(StudentInfoClass.FirstName);
            mnlbl.Text = DelMiddleName(StudentInfoClass.MiddleName);
            addresslbl.Text = DelAddress(StudentInfoClass.Address);

            agelbl.Text = DelNumAge(StudentInfoClass.Age).ToString();
            cnlbl.Text = DelNumContactNo(StudentInfoClass.ContactNo).ToString();

            submitbtn.FlatStyle = FlatStyle.Flat;
            submitbtn.BackColor = Color.FromArgb(0, 120, 215);
            submitbtn.ForeColor = Color.White;
            submitbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 255);
            submitbtn.FlatAppearance.BorderSize = 0;
            submitbtn.Font = new Font(submitbtn.Font, FontStyle.Bold);
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your registration was successful!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
            
            
        }
    }
}
