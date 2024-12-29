namespace vtyssproje
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.txtEmployeemail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmployeepassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddTaskEmployee = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGoToDetails = new System.Windows.Forms.Button();
            this.btnAssignEmployee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(91, 69);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowHeadersWidth = 51;
            this.dgvEmployees.RowTemplate.Height = 24;
            this.dgvEmployees.Size = new System.Drawing.Size(808, 260);
            this.dgvEmployees.TabIndex = 0;
            this.dgvEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellClick_1);
            this.dgvEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(87, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Employee Name:";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(302, 463);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(245, 22);
            this.txtEmployeeName.TabIndex = 3;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(91, 633);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(132, 51);
            this.btnAddEmployee.TabIndex = 4;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // txtEmployeemail
            // 
            this.txtEmployeemail.Location = new System.Drawing.Point(302, 517);
            this.txtEmployeemail.Name = "txtEmployeemail";
            this.txtEmployeemail.Size = new System.Drawing.Size(245, 22);
            this.txtEmployeemail.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(87, 517);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Employee mail:";
            // 
            // txtEmployeepassword
            // 
            this.txtEmployeepassword.Location = new System.Drawing.Point(302, 568);
            this.txtEmployeepassword.Name = "txtEmployeepassword";
            this.txtEmployeepassword.Size = new System.Drawing.Size(245, 22);
            this.txtEmployeepassword.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(87, 570);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Employee password:";
            // 
            // btnAddTaskEmployee
            // 
            this.btnAddTaskEmployee.Location = new System.Drawing.Point(1063, 422);
            this.btnAddTaskEmployee.Name = "btnAddTaskEmployee";
            this.btnAddTaskEmployee.Size = new System.Drawing.Size(132, 51);
            this.btnAddTaskEmployee.TabIndex = 9;
            this.btnAddTaskEmployee.Text = "Add Employee To Task";
            this.btnAddTaskEmployee.UseVisualStyleBackColor = true;
            this.btnAddTaskEmployee.Visible = false;
            this.btnAddTaskEmployee.Click += new System.EventHandler(this.btnAddTaskEmployee_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 633);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 51);
            this.button1.TabIndex = 10;
            this.button1.Text = "Delete Employee";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(458, 633);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 51);
            this.button2.TabIndex = 11;
            this.button2.Text = "Update Employee";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGoToDetails
            // 
            this.btnGoToDetails.Location = new System.Drawing.Point(978, 644);
            this.btnGoToDetails.Name = "btnGoToDetails";
            this.btnGoToDetails.Size = new System.Drawing.Size(132, 51);
            this.btnGoToDetails.TabIndex = 12;
            this.btnGoToDetails.Text = "Go Details";
            this.btnGoToDetails.UseVisualStyleBackColor = true;
            this.btnGoToDetails.Click += new System.EventHandler(this.btnGoToDetails_Click);
            // 
            // btnAssignEmployee
            // 
            this.btnAssignEmployee.Location = new System.Drawing.Point(1063, 488);
            this.btnAssignEmployee.Name = "btnAssignEmployee";
            this.btnAssignEmployee.Size = new System.Drawing.Size(132, 51);
            this.btnAssignEmployee.TabIndex = 13;
            this.btnAssignEmployee.Text = "atama";
            this.btnAssignEmployee.UseVisualStyleBackColor = true;
            this.btnAssignEmployee.Visible = false;
            this.btnAssignEmployee.Click += new System.EventHandler(this.btnAssignEmployee_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1228, 707);
            this.Controls.Add(this.btnAssignEmployee);
            this.Controls.Add(this.btnGoToDetails);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddTaskEmployee);
            this.Controls.Add(this.txtEmployeepassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmployeemail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEmployees);
            this.Name = "Form5";
            this.Text = "EmployeeForm";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.TextBox txtEmployeemail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmployeepassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddTaskEmployee;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGoToDetails;
        private System.Windows.Forms.Button btnAssignEmployee;
    }
}