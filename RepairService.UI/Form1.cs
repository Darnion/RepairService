using RepairService.Context;
using System.Linq;
using System.Windows.Forms;

namespace RepairService.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (var db = new RepairServiceDbContext())
            {
                dataGridView1.AutoGenerateColumns= false;
                dataGridView1.DataSource = db.Users.ToList(); 
            }
        }
    }
}
