namespace RTask
{
    partial class FormVDoc
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewDoc = new System.Windows.Forms.TreeView();
            this.menuEdit = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переименованиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewDoc
            // 
            this.treeViewDoc.AllowDrop = true;
            this.treeViewDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeViewDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDoc.Location = new System.Drawing.Point(0, 28);
            this.treeViewDoc.Name = "treeViewDoc";
            this.treeViewDoc.Size = new System.Drawing.Size(832, 425);
            this.treeViewDoc.TabIndex = 1;
            this.treeViewDoc.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewDoc_ItemDrag);
            this.treeViewDoc.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDoc_NodeMouseClick);
            this.treeViewDoc.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewDoc_DragDrop);
            this.treeViewDoc.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewDoc_DragEnter);
            // 
            // menuEdit
            // 
            this.menuEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuEdit.Location = new System.Drawing.Point(0, 0);
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(832, 28);
            this.menuEdit.TabIndex = 2;
            this.menuEdit.Text = "menu";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавлениеToolStripMenuItem,
            this.переименованиеToolStripMenuItem,
            this.удалениеToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // добавлениеToolStripMenuItem
            // 
            this.добавлениеToolStripMenuItem.Name = "добавлениеToolStripMenuItem";
            this.добавлениеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.добавлениеToolStripMenuItem.Text = "Добавление";
            this.добавлениеToolStripMenuItem.Click += new System.EventHandler(this.добавлениеToolStripMenuItem_Click);
            // 
            // переименованиеToolStripMenuItem
            // 
            this.переименованиеToolStripMenuItem.Name = "переименованиеToolStripMenuItem";
            this.переименованиеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.переименованиеToolStripMenuItem.Text = "Переименование";
            this.переименованиеToolStripMenuItem.Click += new System.EventHandler(this.переименованиеToolStripMenuItem_Click);
            // 
            // удалениеToolStripMenuItem
            // 
            this.удалениеToolStripMenuItem.Name = "удалениеToolStripMenuItem";
            this.удалениеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.удалениеToolStripMenuItem.Text = "Удаление";
            this.удалениеToolStripMenuItem.Click += new System.EventHandler(this.удалениеToolStripMenuItem_Click);
            // 
            // FormVDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.treeViewDoc);
            this.Controls.Add(this.menuEdit);
            this.MainMenuStrip = this.menuEdit;
            this.Name = "FormVDoc";
            this.Text = "ViewDoc";
            this.Activated += new System.EventHandler(this.FormVDoc_Activated);
            this.Load += new System.EventHandler(this.FormVDoc_Load);
            this.menuEdit.ResumeLayout(false);
            this.menuEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TreeView treeViewDoc;
        private MenuStrip menuEdit;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem удалениеToolStripMenuItem;
        private ToolStripMenuItem добавлениеToolStripMenuItem;
        private ToolStripMenuItem переименованиеToolStripMenuItem;
    }
}