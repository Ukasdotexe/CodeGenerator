
namespace CodeGenerator
{
    partial class Form1
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
            this.cmbDatabases = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSingleName = new System.Windows.Forms.TextBox();
            this.cbGetRecordsList = new System.Windows.Forms.CheckBox();
            this.cbAddUpdate = new System.Windows.Forms.CheckBox();
            this.cbDelete = new System.Windows.Forms.CheckBox();
            this.cbFind = new System.Windows.Forms.CheckBox();
            this.cbIsExist = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.btnCopyDAL = new System.Windows.Forms.Button();
            this.tbBusinessLayer = new System.Windows.Forms.TextBox();
            this.tbDataAccessLayer = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.clbFind = new System.Windows.Forms.CheckedListBox();
            this.clbIsExist = new System.Windows.Forms.CheckedListBox();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.cbFields = new System.Windows.Forms.CheckBox();
            this.clbDelete = new System.Windows.Forms.CheckedListBox();
            this.btnCopyBusinessLayer = new System.Windows.Forms.Button();
            this.cmbRecordsList = new System.Windows.Forms.ComboBox();
            this.rbTable = new System.Windows.Forms.RadioButton();
            this.rbView = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDatabases
            // 
            this.cmbDatabases.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabases.FormattingEnabled = true;
            this.cmbDatabases.Location = new System.Drawing.Point(123, 16);
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.Size = new System.Drawing.Size(177, 27);
            this.cmbDatabases.TabIndex = 0;
            this.cmbDatabases.SelectedIndexChanged += new System.EventHandler(this.cmbDatabases_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Database:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Table:";
            // 
            // cmbTables
            // 
            this.cmbTables.BackColor = System.Drawing.Color.White;
            this.cmbTables.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(123, 66);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(177, 27);
            this.cmbTables.TabIndex = 2;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Single Name:";
            // 
            // tbSingleName
            // 
            this.tbSingleName.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSingleName.Location = new System.Drawing.Point(125, 121);
            this.tbSingleName.Name = "tbSingleName";
            this.tbSingleName.Size = new System.Drawing.Size(174, 27);
            this.tbSingleName.TabIndex = 5;
            // 
            // cbGetRecordsList
            // 
            this.cbGetRecordsList.AutoSize = true;
            this.cbGetRecordsList.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGetRecordsList.Location = new System.Drawing.Point(519, 23);
            this.cbGetRecordsList.Name = "cbGetRecordsList";
            this.cbGetRecordsList.Size = new System.Drawing.Size(214, 29);
            this.cbGetRecordsList.TabIndex = 6;
            this.cbGetRecordsList.Text = "Get Records List by:";
            this.cbGetRecordsList.UseVisualStyleBackColor = true;
            this.cbGetRecordsList.CheckedChanged += new System.EventHandler(this.cbGetRecordsList_CheckedChanged);
            // 
            // cbAddUpdate
            // 
            this.cbAddUpdate.AutoSize = true;
            this.cbAddUpdate.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAddUpdate.Location = new System.Drawing.Point(748, 116);
            this.cbAddUpdate.Name = "cbAddUpdate";
            this.cbAddUpdate.Size = new System.Drawing.Size(142, 29);
            this.cbAddUpdate.TabIndex = 7;
            this.cbAddUpdate.Text = "Add,Update";
            this.cbAddUpdate.UseVisualStyleBackColor = true;
            // 
            // cbDelete
            // 
            this.cbDelete.AutoSize = true;
            this.cbDelete.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDelete.Location = new System.Drawing.Point(374, 19);
            this.cbDelete.Name = "cbDelete";
            this.cbDelete.Size = new System.Drawing.Size(125, 29);
            this.cbDelete.TabIndex = 8;
            this.cbDelete.Text = "Delete by:";
            this.cbDelete.UseVisualStyleBackColor = true;
            this.cbDelete.CheckedChanged += new System.EventHandler(this.cbDelete_CheckedChanged);
            // 
            // cbFind
            // 
            this.cbFind.AutoSize = true;
            this.cbFind.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFind.Location = new System.Drawing.Point(28, 20);
            this.cbFind.Name = "cbFind";
            this.cbFind.Size = new System.Drawing.Size(104, 29);
            this.cbFind.TabIndex = 9;
            this.cbFind.Text = "Find by:";
            this.cbFind.UseVisualStyleBackColor = true;
            this.cbFind.CheckedChanged += new System.EventHandler(this.cbFind_CheckedChanged);
            // 
            // cbIsExist
            // 
            this.cbIsExist.AutoSize = true;
            this.cbIsExist.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsExist.Location = new System.Drawing.Point(206, 20);
            this.cbIsExist.Name = "cbIsExist";
            this.cbIsExist.Size = new System.Drawing.Size(123, 29);
            this.cbIsExist.TabIndex = 10;
            this.cbIsExist.Text = "IsExist by:";
            this.cbIsExist.UseVisualStyleBackColor = true;
            this.cbIsExist.CheckedChanged += new System.EventHandler(this.cbIsExist_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(924, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Business Layer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(493, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Data Access Layer";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.Yellow;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(696, 324);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(142, 52);
            this.btnGenerate.TabIndex = 15;
            this.btnGenerate.Text = "GENERATE";
            this.btnGenerate.UseVisualStyleBackColor = false;
            // 
            // dgvColumns
            // 
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Location = new System.Drawing.Point(3, 186);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.Size = new System.Drawing.Size(341, 318);
            this.dgvColumns.TabIndex = 16;
            // 
            // btnCopyDAL
            // 
            this.btnCopyDAL.BackColor = System.Drawing.Color.Yellow;
            this.btnCopyDAL.FlatAppearance.BorderSize = 0;
            this.btnCopyDAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyDAL.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyDAL.Location = new System.Drawing.Point(480, 623);
            this.btnCopyDAL.Name = "btnCopyDAL";
            this.btnCopyDAL.Size = new System.Drawing.Size(130, 52);
            this.btnCopyDAL.TabIndex = 17;
            this.btnCopyDAL.Text = "Copy";
            this.btnCopyDAL.UseVisualStyleBackColor = false;
            this.btnCopyDAL.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // tbBusinessLayer
            // 
            this.tbBusinessLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusinessLayer.Location = new System.Drawing.Point(792, 382);
            this.tbBusinessLayer.Multiline = true;
            this.tbBusinessLayer.Name = "tbBusinessLayer";
            this.tbBusinessLayer.Size = new System.Drawing.Size(407, 235);
            this.tbBusinessLayer.TabIndex = 18;
            // 
            // tbDataAccessLayer
            // 
            this.tbDataAccessLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDataAccessLayer.Location = new System.Drawing.Point(364, 382);
            this.tbDataAccessLayer.Multiline = true;
            this.tbDataAccessLayer.Name = "tbDataAccessLayer";
            this.tbDataAccessLayer.Size = new System.Drawing.Size(407, 235);
            this.tbDataAccessLayer.TabIndex = 19;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(22, 183);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 19);
            this.lblError.TabIndex = 20;
            // 
            // clbFind
            // 
            this.clbFind.CheckOnClick = true;
            this.clbFind.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbFind.FormattingEnabled = true;
            this.clbFind.Location = new System.Drawing.Point(28, 60);
            this.clbFind.Name = "clbFind";
            this.clbFind.Size = new System.Drawing.Size(125, 246);
            this.clbFind.TabIndex = 21;
            this.clbFind.Visible = false;
            this.clbFind.SelectedIndexChanged += new System.EventHandler(this.clbFind_SelectedIndexChanged);
            // 
            // clbIsExist
            // 
            this.clbIsExist.CheckOnClick = true;
            this.clbIsExist.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbIsExist.FormattingEnabled = true;
            this.clbIsExist.Location = new System.Drawing.Point(206, 60);
            this.clbIsExist.Name = "clbIsExist";
            this.clbIsExist.Size = new System.Drawing.Size(131, 246);
            this.clbIsExist.TabIndex = 22;
            this.clbIsExist.Visible = false;
            this.clbIsExist.SelectedIndexChanged += new System.EventHandler(this.clbIsExist_SelectedIndexChanged);
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAll.ForeColor = System.Drawing.Color.Cyan;
            this.cbAll.Location = new System.Drawing.Point(748, 23);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(55, 29);
            this.cbAll.TabIndex = 12;
            this.cbAll.Text = "All";
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.CheckedChanged += new System.EventHandler(this.cbAll_CheckedChanged);
            // 
            // cbFields
            // 
            this.cbFields.AutoSize = true;
            this.cbFields.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFields.Location = new System.Drawing.Point(748, 65);
            this.cbFields.Name = "cbFields";
            this.cbFields.Size = new System.Drawing.Size(249, 29);
            this.cbFields.TabIndex = 11;
            this.cbFields.Text = "Fields And constructors";
            this.cbFields.UseVisualStyleBackColor = true;
            // 
            // clbDelete
            // 
            this.clbDelete.CheckOnClick = true;
            this.clbDelete.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbDelete.FormattingEnabled = true;
            this.clbDelete.Location = new System.Drawing.Point(374, 60);
            this.clbDelete.Name = "clbDelete";
            this.clbDelete.Size = new System.Drawing.Size(131, 246);
            this.clbDelete.TabIndex = 25;
            this.clbDelete.Visible = false;
            this.clbDelete.SelectedIndexChanged += new System.EventHandler(this.cldDelete_SelectedIndexChanged);
            // 
            // btnCopyBusinessLayer
            // 
            this.btnCopyBusinessLayer.BackColor = System.Drawing.Color.Yellow;
            this.btnCopyBusinessLayer.FlatAppearance.BorderSize = 0;
            this.btnCopyBusinessLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyBusinessLayer.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyBusinessLayer.Location = new System.Drawing.Point(930, 623);
            this.btnCopyBusinessLayer.Name = "btnCopyBusinessLayer";
            this.btnCopyBusinessLayer.Size = new System.Drawing.Size(130, 52);
            this.btnCopyBusinessLayer.TabIndex = 27;
            this.btnCopyBusinessLayer.Text = "Copy";
            this.btnCopyBusinessLayer.UseVisualStyleBackColor = false;
            this.btnCopyBusinessLayer.Click += new System.EventHandler(this.btnCopyBusinessLayer_Click);
            // 
            // cmbRecordsList
            // 
            this.cmbRecordsList.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecordsList.FormattingEnabled = true;
            this.cmbRecordsList.Location = new System.Drawing.Point(519, 109);
            this.cmbRecordsList.Name = "cmbRecordsList";
            this.cmbRecordsList.Size = new System.Drawing.Size(200, 27);
            this.cmbRecordsList.TabIndex = 28;
            this.cmbRecordsList.Visible = false;
            // 
            // rbTable
            // 
            this.rbTable.AutoSize = true;
            this.rbTable.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTable.Location = new System.Drawing.Point(20, 19);
            this.rbTable.Name = "rbTable";
            this.rbTable.Size = new System.Drawing.Size(73, 27);
            this.rbTable.TabIndex = 29;
            this.rbTable.TabStop = true;
            this.rbTable.Text = "Table";
            this.rbTable.UseVisualStyleBackColor = true;
            this.rbTable.CheckedChanged += new System.EventHandler(this.rbTable_CheckedChanged);
            // 
            // rbView
            // 
            this.rbView.AutoSize = true;
            this.rbView.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbView.Location = new System.Drawing.Point(101, 19);
            this.rbView.Name = "rbView";
            this.rbView.Size = new System.Drawing.Size(71, 27);
            this.rbView.TabIndex = 30;
            this.rbView.TabStop = true;
            this.rbView.Text = "View";
            this.rbView.UseVisualStyleBackColor = true;
            this.rbView.CheckedChanged += new System.EventHandler(this.rbView_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbView);
            this.groupBox1.Controls.Add(this.rbTable);
            this.groupBox1.Location = new System.Drawing.Point(519, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 49);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.clbDelete);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cbAll);
            this.panel1.Controls.Add(this.cbFields);
            this.panel1.Controls.Add(this.cbGetRecordsList);
            this.panel1.Controls.Add(this.cbAddUpdate);
            this.panel1.Controls.Add(this.cmbRecordsList);
            this.panel1.Controls.Add(this.clbFind);
            this.panel1.Controls.Add(this.cbFind);
            this.panel1.Controls.Add(this.clbIsExist);
            this.panel1.Controls.Add(this.cbDelete);
            this.panel1.Controls.Add(this.cbIsExist);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(350, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 309);
            this.panel1.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCopyBusinessLayer);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.tbDataAccessLayer);
            this.Controls.Add(this.tbBusinessLayer);
            this.Controls.Add(this.btnCopyDAL);
            this.Controls.Add(this.dgvColumns);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSingleName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDatabases);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDatabases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSingleName;
        private System.Windows.Forms.CheckBox cbGetRecordsList;
        private System.Windows.Forms.CheckBox cbAddUpdate;
        private System.Windows.Forms.CheckBox cbDelete;
        private System.Windows.Forms.CheckBox cbFind;
        private System.Windows.Forms.CheckBox cbIsExist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCopyDAL;
        private System.Windows.Forms.TextBox tbBusinessLayer;
        private System.Windows.Forms.TextBox tbDataAccessLayer;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.CheckedListBox clbFind;
        private System.Windows.Forms.CheckedListBox clbIsExist;
        private System.Windows.Forms.CheckBox cbFields;
        private System.Windows.Forms.CheckBox cbAll;
        private System.Windows.Forms.CheckedListBox clbDelete;
        private System.Windows.Forms.Button btnCopyBusinessLayer;
        private System.Windows.Forms.ComboBox cmbRecordsList;
        private System.Windows.Forms.RadioButton rbTable;
        private System.Windows.Forms.RadioButton rbView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

