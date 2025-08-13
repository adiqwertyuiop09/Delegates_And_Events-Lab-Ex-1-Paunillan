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
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();

            programcombo.Items.Add("BS Computer Science");
            programcombo.Items.Add("BS Information Technology");
            programcombo.Items.Add("BS Information Systems");
            programcombo.Items.Add("BS Software Engineering");
            programcombo.Items.Add("BS Data Science");
            programcombo.Items.Add("BS Cybersecurity");
            programcombo.Items.Add("BS Multimedia Arts");
            programcombo.Items.Add("BS Game Development");
            programcombo.Items.Add("BS Electronics Engineering");
            programcombo.Items.Add("BS Computer Engineering");
            programcombo.Items.Add("BS Civil Engineering");
            programcombo.Items.Add("BS Mechanical Engineering");
            programcombo.Items.Add("BS Architecture");
            programcombo.Items.Add("BS Nursing");
            programcombo.Items.Add("BS Accountancy");

            nxtbtn.FlatStyle = FlatStyle.Flat;
            nxtbtn.BackColor = Color.FromArgb(0, 120, 215); 
            nxtbtn.ForeColor = Color.White; 
            nxtbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 255); 
            nxtbtn.FlatAppearance.BorderSize = 0; 
            nxtbtn.Font = new Font(nxtbtn.Font, FontStyle.Bold); 
        }

        private void nxtbtn_Click(object sender, EventArgs e)
        {
            StudentInfoClass.LastName = lntxt.Text.ToString();
            StudentInfoClass.FirstName = fntxt.Text.ToString();
            StudentInfoClass.MiddleName = mntxt.Text.ToString();
            StudentInfoClass.Address = addressrtxt.Text.ToString();
            StudentInfoClass.Program = programcombo.Text.ToString();

            StudentInfoClass.Age = Convert.ToInt64(agetxt.Text);
            StudentInfoClass.ContactNo = Convert.ToInt64(cntxt.Text);
            StudentInfoClass.StudentNo = Convert.ToInt64(studtxt.Text);

            FrmConfirm confirm = new FrmConfirm();          

            if (confirm.ShowDialog() == DialogResult.OK)
            {
              
                lntxt.Clear();
                fntxt.Clear();
                mntxt.Clear();
                addressrtxt.Clear();
                agetxt.Clear();
                cntxt.Clear();
                studtxt.Clear();

                programcombo.SelectedIndex = -1;
            }
        }
    }

    public class StudentInfoClass{
        public delegate long DelegateNumber(long number);
        public delegate string DelegateText(string txt);

        public static String FirstName = "";
        public static String LastName = "";
        public static String MiddleName = "";
        public static String Address = "";
        public static String Program = "";

        public static long Age = 0;
        public static long ContactNo = 0;
        public static long StudentNo = 0;

        public static String GetFirstName(string FirstName) { 
            StudentInfoClass.FirstName = FirstName;
            return StudentInfoClass.FirstName;
        }

        public static String GetLastName(string LastName)
        {
            StudentInfoClass.LastName = LastName;
            return StudentInfoClass.LastName;
        }

        public static String GetMiddleName(string MiddleName)
        {
            StudentInfoClass.MiddleName = MiddleName;
            return StudentInfoClass.MiddleName;
        }

        public static String GetAddress(string Address)
        {
            StudentInfoClass.Address = Address;
            return StudentInfoClass.Address;
        }

        public static String GetProgram(string Program)
        {
            StudentInfoClass.Program = Program;
            return StudentInfoClass.Program;
        }

        public static long GetAge(long Age)
        {
            StudentInfoClass.Age = Age;
            return StudentInfoClass.Age;
        }

        public static long GetContactNo(long ContactNo)
        {
            StudentInfoClass.ContactNo = ContactNo;
            return StudentInfoClass.ContactNo;
        }

        public static long GetStudentNo(long StudentNo)
        {
            StudentInfoClass.StudentNo = StudentNo;
            return StudentInfoClass.StudentNo;
        }
    }
}
