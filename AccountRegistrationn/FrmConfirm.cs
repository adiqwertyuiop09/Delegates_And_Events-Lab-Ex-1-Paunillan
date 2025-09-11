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
      
        private void FrmConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

       
        public FrmConfirm()
        {
           
            InitializeComponent();

            studlbl.Text = FrmRegistration.StudentInformationClass.SetStudentNo.ToString();
            namelbl.Text = FrmRegistration.StudentInformationClass.SetFullName;
            programlbl.Text = FrmRegistration.StudentInformationClass.SetProgram;
            birthdaylbl.Text = FrmRegistration.StudentInformationClass.SetBirthday;
            genderlbl.Text = FrmRegistration.StudentInformationClass.SetGender;
            cnlbl.Text = FrmRegistration.StudentInformationClass.SetContactNo.ToString();
            agelbl.Text = FrmRegistration.StudentInformationClass.SetAge.ToString();
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your registration was successful!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
            
            
        }
    }
}
