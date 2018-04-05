using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnSave.Click += new EventHandler(Create);
            btnRead.Click += new EventHandler(Read_User);
            btnDelete.Click += new EventHandler(Delete_User);
            btnSelect.Click += new EventHandler(Select_User);
            btnUpdate.Click += new EventHandler(Update_User);
        }


       public void Create(object sen, EventArgs ev)
       { 
            string name = txtName.Text;
            string surname = txtSurname.Text;
            int age = Convert.ToInt32(txtAge.Text);
            bool gender = rdMale.Checked == true ? true : false;
            User_Class user = new User_Class(name, surname, age, gender);
            Clear_Textbox();
            Fill_All_ComboBox();
       }


        public void Clear_Textbox()
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtSurname.Text = "";
            cmbDelete.Text = "";
            cmbUpdate.Text = "";
            rdFemale.Checked = false;
            rdMale.Checked = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        public void Read_User(object obj, EventArgs ev)
        {
            txtData.Text = "";
            foreach (User_Class user in User_Class.users)
            {
                txtData.Text += "Id : " + user.Id + ", Name : " + user.Name + ", Surname : " + user.Surname + ", Age : " + user.Age + ", Gender : " + (user.Gender == true ? " Male " : " Female ") + ", Cerated Date : " + user.Created_Date.ToShortDateString()+"\r\n";
            }
        }

        public void Fill_All_ComboBox()
        { 
            cmbDelete.Items.Clear();
            cmbUpdate.Items.Clear();
            foreach (User_Class user in User_Class.users)
            {
                cmbDelete.Items.Add(user.Id);
                cmbUpdate.Items.Add(user.Id);
            } 
        }
 

        public void Delete_User(object btn, EventArgs e)
        {
            int id = Convert.ToInt32(cmbDelete.SelectedItem);
            foreach (User_Class deleted_user in User_Class.users)
            {
                if (id == deleted_user.Id) 
                {
                    User_Class.users.Remove(deleted_user); 
                    break; 
                } 
            } 
            Clear_Textbox();
            Fill_All_ComboBox();
        }


        public void Select_User(object button, EventArgs e)
        {
            int id = Convert.ToInt32(cmbUpdate.Text);
            foreach (User_Class updated_user in User_Class.users)
            {
                if (updated_user.Id == id) 
                {
                    txtName.Text = updated_user.Name;
                    txtSurname.Text = updated_user.Surname;
                    txtAge.Text = updated_user.Age.ToString();
                    if (updated_user.Gender == true) 
                    {
                        rdMale.Checked = true;
                    }
                    else
                    {
                        rdFemale.Checked = true;
                    }
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
        }


        public void Update_User(object obj, EventArgs e)
        {
            int id = Convert.ToInt32(cmbUpdate.Text);
            foreach (User_Class updated_user in User_Class.users)
            {
                if (updated_user.Id == id) 
                {
                    updated_user.Name = txtName.Text;
                    updated_user.Surname = txtSurname.Text;
                    updated_user.Age = Convert.ToInt32(txtAge.Text);
                    updated_user.Gender = rdMale.Checked == true ? true : false;
                } 
            }
            Clear_Textbox(); 
        }

    }  



}
