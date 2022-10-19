
namespace ConfigurationPrototyp
{
    partial class AppCustomForm
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
			this.cbProfiles = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbProfileName = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btAddProfile = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btDeleteProfile = new System.Windows.Forms.Button();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbProfiles
			// 
			this.cbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProfiles.FormattingEnabled = true;
			this.cbProfiles.Location = new System.Drawing.Point(83, 19);
			this.cbProfiles.Name = "cbProfiles";
			this.cbProfiles.Size = new System.Drawing.Size(128, 21);
			this.cbProfiles.TabIndex = 0;
			this.cbProfiles.SelectedIndexChanged += new System.EventHandler(this.cbProfiles_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Профиль:";
			// 
			// tbProfileName
			// 
			this.tbProfileName.Location = new System.Drawing.Point(9, 21);
			this.tbProfileName.Name = "tbProfileName";
			this.tbProfileName.Size = new System.Drawing.Size(130, 20);
			this.tbProfileName.TabIndex = 2;
			this.tbProfileName.TextChanged += new System.EventHandler(this.tbProfileName_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btAddProfile);
			this.groupBox1.Controls.Add(this.tbProfileName);
			this.groupBox1.Location = new System.Drawing.Point(337, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(248, 53);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Добавить новый профиль";
			// 
			// btAddProfile
			// 
			this.btAddProfile.Location = new System.Drawing.Point(155, 18);
			this.btAddProfile.Name = "btAddProfile";
			this.btAddProfile.Size = new System.Drawing.Size(75, 23);
			this.btAddProfile.TabIndex = 4;
			this.btAddProfile.Text = "Добавить";
			this.btAddProfile.UseVisualStyleBackColor = true;
			this.btAddProfile.Click += new System.EventHandler(this.btAddProfile_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btDeleteProfile);
			this.groupBox2.Controls.Add(this.cbProfiles);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(311, 51);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Выбрать текущий профиль:";
			// 
			// btDeleteProfile
			// 
			this.btDeleteProfile.Location = new System.Drawing.Point(224, 17);
			this.btDeleteProfile.Name = "btDeleteProfile";
			this.btDeleteProfile.Size = new System.Drawing.Size(75, 23);
			this.btDeleteProfile.TabIndex = 2;
			this.btDeleteProfile.Text = "Удалить";
			this.btDeleteProfile.UseVisualStyleBackColor = true;
			this.btDeleteProfile.Click += new System.EventHandler(this.btDeleteProfile_Click);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Location = new System.Drawing.Point(12, 69);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(573, 470);
			this.propertyGrid1.TabIndex = 11;
			// 
			// AppCustomForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 551);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "AppCustomForm";
			this.Text = "AppForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppCustomForm_FormClosing);
			this.Load += new System.EventHandler(this.AppCustomForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProfiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProfileName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAddProfile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btDeleteProfile;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}

