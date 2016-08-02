namespace WindowsFormsApplication1
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
            this.CsutomerInfo = new System.Windows.Forms.ListBox();
            this.AddCustomer = new System.Windows.Forms.Button();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CsutomerInfo
            // 
            this.CsutomerInfo.FormattingEnabled = true;
            this.CsutomerInfo.ItemHeight = 18;
            this.CsutomerInfo.Location = new System.Drawing.Point(37, 35);
            this.CsutomerInfo.Name = "CsutomerInfo";
            this.CsutomerInfo.Size = new System.Drawing.Size(130, 238);
            this.CsutomerInfo.TabIndex = 0;
            // 
            // AddCustomer
            // 
            this.AddCustomer.Location = new System.Drawing.Point(189, 250);
            this.AddCustomer.Name = "AddCustomer";
            this.AddCustomer.Size = new System.Drawing.Size(162, 23);
            this.AddCustomer.TabIndex = 1;
            this.AddCustomer.Text = "AddCustomer";
            this.AddCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddCustomer.UseVisualStyleBackColor = true;
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(189, 35);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(162, 28);
            this.FirstName.TabIndex = 2;
            this.FirstName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(189, 145);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(162, 28);
            this.LastName.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 339);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.AddCustomer);
            this.Controls.Add(this.CsutomerInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox CsutomerInfo;
        private System.Windows.Forms.Button AddCustomer;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox LastName;
    }
}

