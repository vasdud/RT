namespace RTask
{
    public partial class FormVDoc : Form
    {
        private static bool IsAdd = false;
        private static bool IsEdit = false;
        private static TreeNode SlNode;

        public static bool ADD
        {
            get
            {
                return IsAdd;
            }
            set
            {
                IsAdd = value;
            }
        }

        public static bool EDIT
        {
            get
            {
                return IsEdit;
            }
            set
            {
                IsEdit = value;
            }
        }

        public static TreeNode SelectedNode
        {
            get
            {
                return SlNode;
            }
        }

        public FormVDoc()
        {
            InitializeComponent();
        }

        private void FormVDoc_Load(object sender, EventArgs e)
        {
            DataBase DB = new DataBase();
            string Name = string.Empty;
            int PId;
            if (DB.UpdateRowsFromDB())
            {
                foreach (List<string> Row in DB.ROWS)
                {
                    if (Row.Count == 5)
                    {
                        if (!string.IsNullOrEmpty(Row[4]))
                        {
                            PId = Convert.ToInt32(Row[4]);
                            Name = Row[1];
                            if (PId > 0)
                            {
                                SetTreeView(PId, Name);
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(Name))
                                {
                                    treeViewDoc.Nodes.Add(Name);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SetTreeView(int theID, string theName)
        {
            DataBase DB = new DataBase();
            TreeNode TN = new TreeNode();
            int indx = 0;
            string NameNd = DB.GetNameByID(theID);
            if (!string.IsNullOrEmpty(NameNd))
            {
                SetNodeByName(NameNd, theName);
            }
        }

        private void SetNodeByName(string theNd, string addName)
        {
            int count;
            TreeNode? TN = treeViewDoc.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals(theNd));
            if (TN == null)
            {
                count = treeViewDoc.Nodes.Count;
                for (int i = 0; i < count; i++)
                {
                    TreeNode TNd = FindNode(treeViewDoc.Nodes[i], theNd, addName);
                    if (TNd != null)
                    {
                        treeViewDoc.Nodes[i].Nodes[TNd.Index] = TNd;
                        break;
                    }
                }
            }
            else
            {
                TN.Nodes.Add(addName);
                treeViewDoc.Nodes[TN.Index] = TN;
            }
        }

        private TreeNode FindNode(TreeNode Nd, string theNd, string addName)
        {
            int indx = -1;
            if (Nd == null)
            {
                return null;
            }
            TreeNode? TN = Nd.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Text.Equals(theNd));
            if (TN != null)
            {
                TN.Nodes.Add(addName);
                return TN;
            }
            else
            {
                for (int i=0; i < Nd.Nodes.Count; i++)
                {
                    TreeNode TNd = FindNode(Nd.Nodes[i], theNd, addName);
                    if (TNd != null)
                    {
                        return TNd;
                    }
                }
            }

            return TN;
        }

        private void äîáàâëåíèåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdd fmAdd = new FormAdd();
            TreeNode targetNode = treeViewDoc.SelectedNode;
            GetSlNode();
            fmAdd.Show();
            if (targetNode == null)
            {
                if(fmAdd.AddItm())
                {
                    IsAdd = true;
                }
            }
            else 
            {
                if (fmAdd.AddItm(targetNode))
                {
                    IsAdd = true;
                }
            }
        }

        

        private void treeViewDoc_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = treeViewDoc.PointToClient(new Point(e.X, e.Y));

            TreeNode targetNode = treeViewDoc.GetNodeAt(targetPoint);

            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (draggedNode == null)
            {
                return;
            }

            if (targetNode == null)
            {
                draggedNode.Remove();
                treeViewDoc.Nodes.Add(draggedNode);
                draggedNode.Expand();
            }
            else
            {
                TreeNode parentNode = targetNode;
                if (!draggedNode.Equals(targetNode) && targetNode != null)
                {
                    bool canDrop = true;

                    while (canDrop && (parentNode != null))
                    {
                        canDrop = !Object.ReferenceEquals(draggedNode, parentNode);
                        parentNode = parentNode.Parent;
                    }

                    if (canDrop)
                    {
                        draggedNode.Remove();
                        targetNode.Nodes.Add(draggedNode);
                        targetNode.Expand();
                    }
                }
            }

            treeViewDoc.SelectedNode = draggedNode;
        }

        private void treeViewDoc_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeViewDoc_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void updateTree()
        {
            if (Entyti.VALUE != null)
            {
                int PId;
                DataBase DB = new DataBase();
                DB.IsertItem();
                if (treeViewDoc.Nodes.Count > 0)
                {
                    GetSlNode();
                    string CurrentNd = SlNode.Text;
                    string NewNd = string.Empty;
                    if (!string.IsNullOrEmpty(Entyti.VALUE[4]))
                    {
                        NewNd = Entyti.VALUE[1];
                        PId = Convert.ToInt32(Entyti.VALUE[4]);
                        if (PId > 0)
                        {
                            if (DB.GetValuesByName(CurrentNd))
                            {
                                int CId = Convert.ToInt32(Entyti.VALUE[0]);
                                int CPID = Convert.ToInt32(Entyti.VALUE[4]);
                                if (PId == CId)
                                {
                                    treeViewDoc.SelectedNode.Nodes.Add(NewNd);
                                }
                                else
                                {
                                    if (CPID == PId)
                                    {
                                        SetTreeView(CPID, NewNd);
                                    }
                                }
                            }
                        }
                        else
                        {
                            treeViewDoc.Nodes.Add(NewNd);
                        }
                    }
                    else
                    {
                        treeViewDoc.Nodes.Add(NewNd);
                    }
                }
                else
                {
                    treeViewDoc.Nodes.Add(Entyti.VALUE[1]);
                }
            }
        }

        private void FormVDoc_Activated(object sender, EventArgs e)
        {
            if (this.Enabled && IsAdd)
            {
                IsAdd = false;
                updateTree();
            }
            if (IsEdit)
            {
                treeViewDoc.Update();
            }
        }

        private void ïåðåèìåíîâàíèåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEdit fmEd = new FormEdit();
            GetSlNode();
            fmEd.Show();
            IsEdit = true;
        }

        private void treeViewDoc_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SlNode = treeViewDoc.SelectedNode;
        }

        private void GetSlNode()
        {
            SlNode = treeViewDoc.SelectedNode;
        }

        private void óäàëåíèåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NdName = string.Empty;
            DataBase DB = new DataBase();
            Entyti Ent = new Entyti();
            if (treeViewDoc.Nodes.Count > 0)
            {
                GetSlNode();
                NdName = SlNode.Text;
                if (!string.IsNullOrEmpty(NdName))
                {
                    if (DB.GetValuesByName(NdName))
                    {
                        if (DB.DeleteValue())
                        {
                            treeViewDoc.Nodes.Remove(SlNode);
                            treeViewDoc.Update();
                        }
                    }
                }
            }
        }
    }
}