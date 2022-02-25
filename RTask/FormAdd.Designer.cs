namespace RTask
{
    partial class FormAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chbInput = new System.Windows.Forms.CheckBox();
            this.chbFolder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(24, 87);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(116, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Наименование";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(146, 84);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 27);
            this.txtName.TabIndex = 1;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(24, 150);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(48, 20);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "Путь :";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(332, 195);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(115, 29);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chbInput
            // 
            this.chbInput.AutoSize = true;
            this.chbInput.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbInput.Location = new System.Drawing.Point(24, 30);
            this.chbInput.Name = "chbInput";
            this.chbInput.Size = new System.Drawing.Size(175, 24);
            this.chbInput.TabIndex = 6;
            this.chbInput.Text = "Вложенный элемент";
            this.chbInput.UseVisualStyleBackColor = true;
            // 
            // chbFolder
            // 
            this.chbFolder.AutoSize = true;
            this.chbFolder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbFolder.Location = new System.Drawing.Point(239, 30);
            this.chbFolder.Name = "chbFolder";
            this.chbFolder.Size = new System.Drawing.Size(85, 24);
            this.chbFolder.TabIndex = 7;
            this.chbFolder.Text = "Каталог";
            this.chbFolder.UseVisualStyleBackColor = true;
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.chbFolder);
            this.Controls.Add(this.chbInput);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "FormAdd";
            this.Text = "FormAdd";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAdd_FormClosed);
            this.Load += new System.EventHandler(this.FormAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblPath;
        private Button btnAdd;
        private CheckBox chbInput;
        private CheckBox chbFolder;
    }
}