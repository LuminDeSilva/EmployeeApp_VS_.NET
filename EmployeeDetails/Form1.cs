using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class Form1 : Form
    {
        Employee [] employees = new Employee[100];
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string empId = textBoxEmpId.Text;
            string name = textBoxName.Text;
            int age = Convert.ToInt16(numericUpDownAge.Value);
            string dob = dateTimePickerDOB.Value.ToShortDateString();
            string sex;
            if (radioButtonMale.Checked)
                sex = "Male";
            else
                sex = "Female";
            string email = textBoxEmail.Text;
            Employee emp= new Employee(empId,name,age,dob,sex,email);
            if (!IsDuplicate(emp))
            {
                employees[counter] = emp;
                MessageBox.Show("You have added an employee with following details:\nEmpID:"
                    + employees[counter].EmpId + "\nName:" + employees[counter].Name + "\nAge:"
                    + employees[counter].Age + "\nDOB:" + employees[counter].DOB + "\nSex:"
                    + employees[counter].Sex + "\nEmail:" + employees[counter].Email);
                ResetAll();
                counter++;
            }
            else
            {
                MessageBox.Show("Duplicate entry!!!");
            }
        }
        private bool IsDuplicate(Employee emp)
        {
            foreach (Employee e in employees)
            {
                if (e!=null && e.EmpId.Equals(emp.EmpId))
                    return true;
            }
            return false;
        }
        private void ResetAll()
        {
            textBoxEmail.Text = "";
            textBoxEmpId.Text = "";
            textBoxName.Text = "";
            dateTimePickerDOB.Text = "";
            numericUpDownAge.Value = 0;

        }

        private void tabPageAdd_Click(object sender, EventArgs e)
        {

        }

        private void tabControlEmpDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Tab is changed!"+ tabControlEmpDetails.TabPages[tabControlEmpDetails.SelectedIndex].Text);
            if(tabControlEmpDetails.TabPages[tabControlEmpDetails.SelectedIndex].Text=="VIEW")
            {
                //comboBoxEmpId.Items.Clear();
                foreach (Employee emp in employees)
                {
                    if(emp!=null)
                        comboBoxEmpId.Items.Add(emp.EmpId);
                }
                
            }
            if (tabControlEmpDetails.TabPages[tabControlEmpDetails.SelectedIndex].Text == "UPDATE")
            {
                comboBoxEmpIdUpdate.Items.Clear();
                foreach (Employee emp in employees)
                {
                    if (emp != null)
                        comboBoxEmpIdUpdate.Items.Add(emp.EmpId);
                }

            }
            if (tabControlEmpDetails.TabPages[tabControlEmpDetails.SelectedIndex].Text == "DELETE")
            {
                comboBoxEmpIdDelete.Items.Clear();
                foreach (Employee emp in employees)
                {
                    if (emp != null)
                        comboBoxEmpIdDelete.Items.Add(emp.EmpId);
                }

            }
        }

        private void comboBoxEmpId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBoxEmpId.SelectedItem.ToString());
            Employee selectedEmployee = null;
            foreach (Employee emp in employees)
            {
                if (emp != null)
                {
                    if (emp.EmpId == comboBoxEmpId.SelectedItem.ToString())
                        selectedEmployee = emp;
                }     
            }
            textBoxEmpIdView.Text = selectedEmployee.EmpId;
            textBoxEmpNameView.Text = selectedEmployee.Name;
            numericUpDownEmpAgeView.Value = Convert.ToDecimal(selectedEmployee.Age);
            dateTimePickerEmpDOBView.Text = selectedEmployee.DOB;
            if (selectedEmployee.Sex == "Male")
                radioButtonMaleView.Checked = true;
            else
                radioButtonFemaleView.Checked = true;
            textBoxEMailView.Text = selectedEmployee.Email;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxEmpIdUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee selectedEmployee = null;
            foreach (Employee emp in employees)
            {
                if (emp != null)
                {
                    if (emp.EmpId == comboBoxEmpIdUpdate.SelectedItem.ToString())
                        selectedEmployee = emp;
                }
            }
            textBoxEmpIdUpdate.Text = selectedEmployee.EmpId;
            textBoxNameUpdate.Text = selectedEmployee.Name;
            numericUpDownAgeUpdate.Value = Convert.ToDecimal(selectedEmployee.Age);
            dateTimePickerDOBUpdate.Text = selectedEmployee.DOB;
            if (selectedEmployee.Sex == "Male")
                radioButtonMaleUpdate.Checked = true;
            else
                radioButtonFemaleUpdate.Checked = true;
            textBoxEmailUpdate.Text = selectedEmployee.Email;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string empId = textBoxEmpIdUpdate.Text;
            string name = textBoxNameUpdate.Text;
            int age = Convert.ToInt16(numericUpDownAgeUpdate.Value);
            string dob = dateTimePickerDOBUpdate.Value.ToShortDateString();
            string sex;
            if (radioButtonMaleUpdate.Checked)
                sex = "Male";
            else
                sex = "Female";
            string email = textBoxEmailUpdate.Text;
            foreach (Employee emp in employees)
            {
                if(emp!=null && emp.EmpId== empId)
                {
                    emp.Name= name;
                    emp.Age = age;
                    emp.DOB = dob;
                    emp.Sex = sex;
                    emp.Email = email;
                    MessageBox.Show("The details for employee with ID "+ emp.EmpId + " has been updated!");
                    ResetAllUpdate();
                }
            }
            
            

        }
        private void ResetAllUpdate()
        {
            textBoxEmailUpdate.Text = "";
            textBoxEmpIdUpdate.Text = "";
            textBoxNameUpdate.Text = "";
            dateTimePickerDOBUpdate.Text = "";
            numericUpDownAgeUpdate.Value = 0;

        }

        private void comboBoxEmpIdDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee selectedEmployee = null;
            foreach (Employee emp in employees)
            {
                if (emp != null)
                {
                    if (emp.EmpId == comboBoxEmpIdDelete.SelectedItem.ToString())
                        selectedEmployee = emp;
                }
            }
            textBoxEmpIdDelete.Text = selectedEmployee.EmpId;
            textBoxNameDelete.Text = selectedEmployee.Name;
            numericUpDownAgeDelete.Value = Convert.ToDecimal(selectedEmployee.Age);
            dateTimePickerDOBDelete.Text = selectedEmployee.DOB;
            if (selectedEmployee.Sex == "Male")
                radioButtonMaleDelete.Checked = true;
            else
                radioButtonFemaleDelete.Checked = true;
            textBoxEmailDelete.Text = selectedEmployee.Email;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
            string empId = textBoxEmpIdDelete.Text;
            DialogResult re=MessageBox.Show("Do you want to delete the records for the employee with id " + empId + "?", "Confirmation of deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (re.Equals(DialogResult.OK))
            {
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i] != null && employees[i].EmpId == empId)
                    {
                        employees[i] = null;
                        MessageBox.Show("The details for employee with ID " + empId + " has been deleted!");
                        ResetAllDelete();
                    }
                }
            }
        }
        private void ResetAllDelete()
        {
            textBoxEmailDelete.Text = "";
            textBoxEmpIdDelete.Text = "";
            textBoxNameDelete.Text = "";
            dateTimePickerDOBDelete.Text = "";
            numericUpDownAgeDelete.Value = 0;

        }
    }
}
