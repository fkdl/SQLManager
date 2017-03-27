namespace SQLManager
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
            this.button2 = new System.Windows.Forms.Button();
            this.queryString = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.asdasdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdasdasdasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dasdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "RUN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // queryString
            // 
            this.queryString.AcceptsTab = true;
            this.queryString.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.queryString.HideSelection = false;
            this.queryString.Location = new System.Drawing.Point(0, 93);
            this.queryString.Multiline = true;
            this.queryString.Name = "queryString";
            this.queryString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.queryString.Size = new System.Drawing.Size(1004, 158);
            this.queryString.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 251);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1004, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdasdToolStripMenuItem,
            this.asdasdasdasToolStripMenuItem,
            this.dasdToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1004, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // asdasdToolStripMenuItem
            // 
            this.asdasdToolStripMenuItem.Name = "asdasdToolStripMenuItem";
            this.asdasdToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.asdasdToolStripMenuItem.Text = "File";
            // 
            // asdasdasdasToolStripMenuItem
            // 
            this.asdasdasdasToolStripMenuItem.Name = "asdasdasdasToolStripMenuItem";
            this.asdasdasdasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.asdasdasdasToolStripMenuItem.Text = "asdasdasdas";
            // 
            // dasdToolStripMenuItem
            // 
            this.dasdToolStripMenuItem.Name = "dasdToolStripMenuItem";
            this.dasdToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.dasdToolStripMenuItem.Text = "dasd";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 401);
            this.Controls.Add(this.queryString);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox queryString;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem asdasdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asdasdasdasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dasdToolStripMenuItem;
    }
}

