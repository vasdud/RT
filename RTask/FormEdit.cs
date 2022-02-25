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
    public partial class FormEdit : Form
    {
        private TreeNode Node;

        public FormEdit()
        {
            InitializeComponent();
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            FormVDoc Fm = new FormVDoc();
            Node = FormVDoc.SelectedNode;
            txtBoxEdit.Text = Node.Text;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataBase DB = new DataBase();
            Entyti Ent = new Entyti();
            int indx = 0;
            string NewName = txtBoxEdit.Text;
            string NewPath = string.Empty;
            string Pt = string.Empty;
            if (!string.IsNullOrEmpty(NewName) && Ent.IsEnqName(NewName) && Ent.IsValidName(NewName))
            {
                if (DB.GetValuesByName(Node.Text))
                {
                    Entyti.VALUE[1] = NewName;
                    NewPath = Entyti.VALUE[2];
                    indx = NewPath.LastIndexOf("\\");
                    Pt = NewPath.Substring(0, indx);
                    if (string.IsNullOrEmpty(Pt))
                    {
                        Entyti.VALUE[2] = "\\" + NewName;
                    }
                    else
                    {
                        Entyti.VALUE[2] = Pt + "\\" + NewName;
                    }
                    if (DB.UpdateValue())
                    {
                        FormVDoc.SelectedNode.Text = NewName;
                        this.Close();
                    }
                }
            }
            else
            {
                txtBoxEdit.ForeColor = Color.Red;
            }
        }

        private void FormEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!((sender as Form).ActiveControl is Button))
            {
                FormVDoc.EDIT = false;
            }
        }
    }
}
