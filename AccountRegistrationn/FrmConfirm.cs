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

            studlbl.Text = StudentInformationClass.SetStudentNo.ToString();
            namelbl.Text = StudentInformationClass.SetFullName;
            programlbl.Text = StudentInformationClass.SetProgram;
            birthdaylbl.Text = StudentInformationClass.SetBirthday;
            genderlbl.Text = StudentInformationClass.SetGender;
            cnlbl.Text = StudentInformationClass.SetContactNo.ToString();
            agelbl.Text = StudentInformationClass.SetAge.ToString();

        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your registration was successful!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
            
            
        }
    }
}
