using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace LeapProject_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Connection conn = new Connection(@"ftp://155.17.173.56/", "Domain\Fname.Lname", "XXXX");
        
        private void button1_Click(object sender, EventArgs e)
        {
            string fileSize = conn.getFileSize("D:\\Program Files\\IBM\\WebSphere\\AppServer\\profiles\\AppSrv01\\logs\\HDI-iTest-AppSrv02\\SystemOut.txt");
            textBox1.Text = fileSize;
        }
    }
}
