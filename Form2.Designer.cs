
namespace CodeGenerator
{
    partial class Form2
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
            this.tbDataAccessLayer = new System.Windows.Forms.TextBox();
            this.tbBusinessLayer = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbIsExist = new System.Windows.Forms.CheckBox();
            this.cbFind = new System.Windows.Forms.CheckBox();
            this.cbDelete = new System.Windows.Forms.CheckBox();
            this.cbAddUpdate = new System.Windows.Forms.CheckBox();
            this.cbGetAll = new System.Windows.Forms.CheckBox();
            this.tbSingleName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDatabases = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDataAccessLayer
            // 
            this.tbDataAccessLayer.Location = new System.Drawing.Point(576, 295);
            this.tbDataAccessLayer.Multiline = true;
            this.tbDataAccessLayer.Name = "tbDataAccessLayer";
            this.tbDataAccessLayer.Size = new System.Drawing.Size(407, 235);
            this.tbDataAccessLayer.TabIndex = 37;
            // 
            // tbBusinessLayer
            // 
            this.tbBusinessLayer.Location = new System.Drawing.Point(576, 55);
            this.tbBusinessLayer.Multiline = true;
            this.tbBusinessLayer.Name = "tbBusinessLayer";
            this.tbBusinessLayer.Size = new System.Drawing.Size(407, 207);
            this.tbBusinessLayer.TabIndex = 36;
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.Yellow;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(415, 350);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(142, 52);
            this.btnCopy.TabIndex = 35;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 240);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(386, 276);
            this.dataGridView1.TabIndex = 34;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.Yellow;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(415, 265);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(142, 52);
            this.btnGenerate.TabIndex = 33;
            this.btnGenerate.Text = "GENERATE";
            this.btnGenerate.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(573, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 19);
            this.label5.TabIndex = 32;
            this.label5.Text = "Data Access Layer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(573, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 19);
            this.label4.TabIndex = 31;
            this.label4.Text = "Business Layer";
            // 
            // cbIsExist
            // 
            this.cbIsExist.AutoSize = true;
            this.cbIsExist.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsExist.Location = new System.Drawing.Point(339, 190);
            this.cbIsExist.Name = "cbIsExist";
            this.cbIsExist.Size = new System.Drawing.Size(74, 23);
            this.cbIsExist.TabIndex = 30;
            this.cbIsExist.Text = "IsExist";
            this.cbIsExist.UseVisualStyleBackColor = true;
            // 
            // cbFind
            // 
            this.cbFind.AutoSize = true;
            this.cbFind.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFind.Location = new System.Drawing.Point(339, 151);
            this.cbFind.Name = "cbFind";
            this.cbFind.Size = new System.Drawing.Size(59, 23);
            this.cbFind.TabIndex = 29;
            this.cbFind.Text = "Find";
            this.cbFind.UseVisualStyleBackColor = true;
            // 
            // cbDelete
            // 
            this.cbDelete.AutoSize = true;
            this.cbDelete.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDelete.Location = new System.Drawing.Point(339, 112);
            this.cbDelete.Name = "cbDelete";
            this.cbDelete.Size = new System.Drawing.Size(74, 23);
            this.cbDelete.TabIndex = 28;
            this.cbDelete.Text = "Delete";
            this.cbDelete.UseVisualStyleBackColor = true;
            // 
            // cbAddUpdate
            // 
            this.cbAddUpdate.AutoSize = true;
            this.cbAddUpdate.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAddUpdate.Location = new System.Drawing.Point(339, 73);
            this.cbAddUpdate.Name = "cbAddUpdate";
            this.cbAddUpdate.Size = new System.Drawing.Size(112, 23);
            this.cbAddUpdate.TabIndex = 27;
            this.cbAddUpdate.Text = "Add,Update";
            this.cbAddUpdate.UseVisualStyleBackColor = true;
            // 
            // cbGetAll
            // 
            this.cbGetAll.AutoSize = true;
            this.cbGetAll.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGetAll.Location = new System.Drawing.Point(339, 34);
            this.cbGetAll.Name = "cbGetAll";
            this.cbGetAll.Size = new System.Drawing.Size(76, 23);
            this.cbGetAll.TabIndex = 26;
            this.cbGetAll.Text = "Get All";
            this.cbGetAll.UseVisualStyleBackColor = true;
            // 
            // tbSingleName
            // 
            this.tbSingleName.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSingleName.Location = new System.Drawing.Point(125, 128);
            this.tbSingleName.Name = "tbSingleName";
            this.tbSingleName.Size = new System.Drawing.Size(174, 27);
            this.tbSingleName.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "Single Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "Table:";
            // 
            // cmbTables
            // 
            this.cmbTables.BackColor = System.Drawing.Color.White;
            this.cmbTables.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(123, 73);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(177, 27);
            this.cmbTables.TabIndex = 22;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "Database:";
            // 
            // cmbDatabases
            // 
            this.cmbDatabases.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabases.FormattingEnabled = true;
            this.cmbDatabases.Location = new System.Drawing.Point(123, 23);
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.Size = new System.Drawing.Size(177, 27);
            this.cmbDatabases.TabIndex = 20;
            this.cmbDatabases.SelectedIndexChanged += new System.EventHandler(this.cmbDatabases_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(995, 552);
            this.Controls.Add(this.tbDataAccessLayer);
            this.Controls.Add(this.tbBusinessLayer);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbIsExist);
            this.Controls.Add(this.cbFind);
            this.Controls.Add(this.cbDelete);
            this.Controls.Add(this.cbAddUpdate);
            this.Controls.Add(this.cbGetAll);
            this.Controls.Add(this.tbSingleName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDatabases);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDataAccessLayer;
        private System.Windows.Forms.TextBox tbBusinessLayer;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbIsExist;
        private System.Windows.Forms.CheckBox cbFind;
        private System.Windows.Forms.CheckBox cbDelete;
        private System.Windows.Forms.CheckBox cbAddUpdate;
        private System.Windows.Forms.CheckBox cbGetAll;
        private System.Windows.Forms.TextBox tbSingleName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDatabases;
    }
}