using Bug_Tracker.DAO;
using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracker.Views
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            Project project = new Project { ProjectName = projectName};

            if (string.IsNullOrEmpty(projectName)) {
                MessageBox.Show("You must add some project");
            } else
            {
                ProjectDAO projectDAO = new ProjectDAO();
                projectDAO.Insert(project);
                listView1.Items.Clear();
                GetAllProject();
            }
        }

        /// <summary>
        /// Return all the project
        /// </summary>
        private void GetAllProject()
        {
            ProjectDAO projectDAO = new ProjectDAO();
            List<Project> project = projectDAO.GetAll();

            foreach (var p in project)
            {
                listView1.Items.Add(p.ProjectName);
            }
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            GetAllProject();
        }

        private void addUserToComapnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Register().Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            this.Hide();
            Program.adminId = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
