using Bug_Tracker.Common;
using Bug_Tracker.DAO;
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
    public partial class TesterDashboard : Form
    {
        public TesterDashboard()
        {
            InitializeComponent();
            LoopPanel loop = new LoopPanel();
            BugDAO bug = new BugDAO();
            loop.loopPanel(bug.getAllBugs(), panel1, this);
        }
    }
}
