using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTask
{
    public partial class FormAdd : Form
    {
        private string path;
        private bool isErr = false;

        public FormAdd()
        {
            InitializeComponent();
        }

        public bool AddItm(TreeNode theNode = null)
        {
            bool result = true;

            path = "\\";
            if (theNode != null)
            {
                path = path + theNode.FullPath;
            }

            if(string.IsNullOrEmpty(path))
            {
                result = false;
            }
            else
            {
                UpdatePath();
            }

            return result;
        }

        private void UpdatePath()
        {
            lblPath.Text = lblPath.Text + " " + path;
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            UpdatePath();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string StrName = txtName.Text;
            Entyti Ent = new Entyti();
            DataBase DB = new DataBase();

            if (chbFolder.Checked)
            {
                Ent.TYPE = "Folder";
            }
            else
            {
                Ent.TYPE = "File";
            }


                if (chbInput.Checked)
                {
                    Ent.PATH = path + "\\" + StrName;
                }
                else if(!isErr)
                {
                    int indx = path.LastIndexOf("\\");
                    if (indx >= 0)
                    {
                        path = path.Substring(0, indx);
                        Ent.PATH = path + "\\" + StrName;
                    }
                }
                if (Ent.PATH == string.Empty)
                {
                    Ent.PATH = "\\" + StrName;
                }
                if (path == string.Empty)
                {
                    path = "\\";
                }

            Ent.ID = DB.GetLastID();
            Ent.IDP = Ent.GetParentID(path);

            if (!Ent.IsEnqName(StrName) || !Ent.IsValidName(StrName))
            {
                isErr = true;
                txtName.ForeColor = Color.Red;
            }
            else
            {
                Ent.NAME = StrName;
                if (Ent.SetValues())
                {
                    isErr = false;
                    this.Close();
                }
            }
        }

        private void FormAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!((sender as Form).ActiveControl is Button))
            {
                FormVDoc.ADD = false;
            }
        }
    }
}
