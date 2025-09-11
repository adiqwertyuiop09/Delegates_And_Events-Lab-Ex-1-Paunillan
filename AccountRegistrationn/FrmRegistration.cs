using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AccountRegistrationn
{
    public partial class FrmRegistration : Form
    {
        

        public FrmRegistration()
        {

            InitializeComponent();

            string[] ListOfProgram = new string[]
             {
                "BS Computer Science",
                "BS Information Technology",
                "BS Information Systems",
                "BS Software Engineering",
                "BS Data Science",
                "BS Cybersecurity",
                "BS Multimedia Arts",
                "BS Game Development",
                "BS Electronics Engineering",
                "BS Computer Engineering",
                "BS Civil Engineering",
                "BS Mechanical Engineering",
                "BS Architecture",
                "BS Nursing",
                "BS Accountancy"
             };

            for (int i = 0; i < 15; i++)
            {
                programcombo.Items.Add(ListOfProgram[i]);
            }

            string[] ListOfGender = new string[]
            {
                "Male",
                "Female"
            };

            for (int i = 0; i < 2; i++)
            {
                gendercombo.Items.Add(ListOfGender[i]);
            }


            nxtbtn.FlatStyle = FlatStyle.Flat;
            nxtbtn.BackColor = Color.FromArgb(0, 120, 215);
            nxtbtn.ForeColor = Color.White;
            nxtbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 255);
            nxtbtn.FlatAppearance.BorderSize = 0;
            nxtbtn.Font = new Font(nxtbtn.Font, FontStyle.Bold);
        }

        private void nxtbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string studdb = "Server=LAPTOP-SFLC0K1H\\SQLEXPRESS;Database=StudDB;Trusted_Connection=True;";

                StudentInformationClass studentInfo = new StudentInformationClass();

                StudentInformationClass.SetFullName = studentInfo.FullName(lntxt.Text, fntxt.Text, mntxt.Text);
                StudentInformationClass.SetStudentNo = studentInfo.StudentNumber(studtxt.Text);
                StudentInformationClass.SetProgram = programcombo.Text;
                StudentInformationClass.SetGender = gendercombo.Text;
                StudentInformationClass.SetContactNo = studentInfo.ContactNo(cntxt.Text);
                StudentInformationClass.SetAge = studentInfo.Age(agetxt.Text);
                StudentInformationClass.SetBirthday = dtpicker.Value.ToString("yyyy");

                using (SqlConnection sql = new SqlConnection(studdb))
                {
                    sql.Open();

                    string query = @"INSERT INTO Student 
                            (Program, LastName, FirstName, MiddleName, Age, Birthday, ContactNo, Gender, FullName)
                             VALUES 
                            (@Program, @LastName, @FirstName, @MiddleName, @Age, @Birthday, @ContactNo, @Gender, @FullName)";

                    using (SqlCommand cmd = new SqlCommand(query, sql))
                    {
                        cmd.Parameters.AddWithValue("@Program", StudentInformationClass.SetProgram);
                        cmd.Parameters.AddWithValue("@LastName", lntxt.Text);
                        cmd.Parameters.AddWithValue("@FirstName", fntxt.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", mntxt.Text);
                        cmd.Parameters.AddWithValue("@Age", StudentInformationClass.SetAge);
                        cmd.Parameters.AddWithValue("@Birthday", StudentInformationClass.SetBirthday);
                        cmd.Parameters.AddWithValue("@ContactNo", StudentInformationClass.SetContactNo);
                        cmd.Parameters.AddWithValue("@Gender", StudentInformationClass.SetGender);
                        cmd.Parameters.AddWithValue("@FullName", StudentInformationClass.SetFullName);

                        cmd.ExecuteNonQuery();
                    }
                }


                FrmConfirm confirm = new FrmConfirm();

                if (confirm.ShowDialog() == DialogResult.OK)
                {
                    lntxt.Clear();
                    fntxt.Clear();
                    mntxt.Clear();
                    agetxt.Clear();
                    cntxt.Clear();
                    studtxt.Clear();

                    programcombo.SelectedIndex = -1;
                }
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public class StudentInformationClass
        {
            private string _FullName;
            private int _Age;
            private long _ContactNo;
            private long _StudentNo;

            public static long SetStudentNo = 0;
            public static long SetContactNo = 0;
            public static int SetAge = 0;

            public static string SetProgram = "";
            public static string SetGender = "";
            public static string SetBirthday = "";
            public static string SetFullName = "";

            public long StudentNumber(string studNum)
            {

                _StudentNo = long.Parse(studNum);

                return _StudentNo;
            }

            public long ContactNo(string Contact)
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }

                return _ContactNo;
            }

            public string FullName(string LastName, string FirstName, string MiddleInitial)
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                }

                return _FullName;
            }

            public int Age(string age)
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                }

                return _Age;
            }

            }

        }

     }

    
