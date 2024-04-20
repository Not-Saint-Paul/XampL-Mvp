using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abc
{
    public partial class View : Form
    {
        public delegate void DirectoryPathChanged(string newPath);
        private List<DirectoryPathChanged> listUpdatePath = new List<DirectoryPathChanged>();
        public void DirectoryPathChange(string newPath)
        {
            foreach (var delegateFunction in listUpdatePath)
            {
                delegateFunction(newPath);
            }
        }
        public void AddDirectoryPathChangedDelegate(DirectoryPathChanged directoryPathChanged)
        {
            listUpdatePath.Add(directoryPathChanged);
        }
        public View()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string fds = pathToDirectory.Text;
        }
    }
}
