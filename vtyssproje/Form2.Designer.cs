namespace vtyssproje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.dgvProjects = new System.Windows.Forms.DataGridView();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.btnViewTasks = new System.Windows.Forms.Button();
            this.btnDeleteProject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProjects
            // 
            this.dgvProjects.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjects.Location = new System.Drawing.Point(257, 101);
            this.dgvProjects.Name = "dgvProjects";
            this.dgvProjects.RowHeadersWidth = 51;
            this.dgvProjects.RowTemplate.Height = 24;
            this.dgvProjects.Size = new System.Drawing.Size(757, 530);
            this.dgvProjects.TabIndex = 0;
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(843, 555);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(138, 23);
            this.btnAddProject.TabIndex = 1;
            this.btnAddProject.Text = "Add Project";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // btnViewTasks
            // 
            this.btnViewTasks.Location = new System.Drawing.Point(672, 555);
            this.btnViewTasks.Name = "btnViewTasks";
            this.btnViewTasks.Size = new System.Drawing.Size(130, 23);
            this.btnViewTasks.TabIndex = 2;
            this.btnViewTasks.Text = "Project Details";
            this.btnViewTasks.UseVisualStyleBackColor = true;
            this.btnViewTasks.Click += new System.EventHandler(this.btnViewTasks_Click);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Location = new System.Drawing.Point(374, 555);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteProject.TabIndex = 3;
            this.btnDeleteProject.Text = "Delete Project";
            this.btnDeleteProject.UseVisualStyleBackColor = true;
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1300, 707);
            this.Controls.Add(this.btnDeleteProject);
            this.Controls.Add(this.btnViewTasks);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.dgvProjects);
            this.Name = "Form2";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProjects;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button btnViewTasks;
        private System.Windows.Forms.Button btnDeleteProject;
    }
}