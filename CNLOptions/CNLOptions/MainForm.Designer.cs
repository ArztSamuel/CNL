namespace CNLConfiguration
{
    partial class MainForm
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
            this.mainLbl = new System.Windows.Forms.Label();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.unameInput = new System.Windows.Forms.TextBox();
            this.passwLbl = new System.Windows.Forms.Label();
            this.passwInput = new System.Windows.Forms.TextBox();
            this.advancedGroup = new System.Windows.Forms.GroupBox();
            this.showDebugBox = new System.Windows.Forms.CheckBox();
            this.defaultBtn = new System.Windows.Forms.Button();
            this.checkConBox = new System.Windows.Forms.CheckBox();
            this.minutesLbl = new System.Windows.Forms.Label();
            this.checkInput = new System.Windows.Forms.TextBox();
            this.everyLbl = new System.Windows.Forms.Label();
            this.retryInfinitBox = new System.Windows.Forms.CheckBox();
            this.timesLbl = new System.Windows.Forms.Label();
            this.retryInput = new System.Windows.Forms.TextBox();
            this.retryLbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whoMadeThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.advancedGroup.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLbl
            // 
            this.mainLbl.AutoSize = true;
            this.mainLbl.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLbl.Location = new System.Drawing.Point(12, 30);
            this.mainLbl.Name = "mainLbl";
            this.mainLbl.Size = new System.Drawing.Size(341, 27);
            this.mainLbl.TabIndex = 0;
            this.mainLbl.Text = "Configure your automatic login";
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLbl.Location = new System.Drawing.Point(12, 81);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(102, 22);
            this.userNameLbl.TabIndex = 1;
            this.userNameLbl.Text = "Username:";
            // 
            // unameInput
            // 
            this.unameInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unameInput.Location = new System.Drawing.Point(120, 81);
            this.unameInput.Name = "unameInput";
            this.unameInput.Size = new System.Drawing.Size(100, 26);
            this.unameInput.TabIndex = 2;
            this.unameInput.TextChanged += new System.EventHandler(this.UnameInput_TextChanged);
            // 
            // passwLbl
            // 
            this.passwLbl.AutoSize = true;
            this.passwLbl.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwLbl.Location = new System.Drawing.Point(12, 117);
            this.passwLbl.Name = "passwLbl";
            this.passwLbl.Size = new System.Drawing.Size(99, 22);
            this.passwLbl.TabIndex = 3;
            this.passwLbl.Text = "Password:";
            // 
            // passwInput
            // 
            this.passwInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwInput.Location = new System.Drawing.Point(120, 117);
            this.passwInput.Name = "passwInput";
            this.passwInput.Size = new System.Drawing.Size(100, 26);
            this.passwInput.TabIndex = 4;
            this.passwInput.UseSystemPasswordChar = true;
            this.passwInput.TextChanged += new System.EventHandler(this.passwInput_TextChanged);
            // 
            // advancedGroup
            // 
            this.advancedGroup.Controls.Add(this.showDebugBox);
            this.advancedGroup.Controls.Add(this.defaultBtn);
            this.advancedGroup.Controls.Add(this.checkConBox);
            this.advancedGroup.Controls.Add(this.minutesLbl);
            this.advancedGroup.Controls.Add(this.checkInput);
            this.advancedGroup.Controls.Add(this.everyLbl);
            this.advancedGroup.Controls.Add(this.retryInfinitBox);
            this.advancedGroup.Controls.Add(this.timesLbl);
            this.advancedGroup.Controls.Add(this.retryInput);
            this.advancedGroup.Controls.Add(this.retryLbl);
            this.advancedGroup.Font = new System.Drawing.Font("Arial", 13F);
            this.advancedGroup.Location = new System.Drawing.Point(12, 183);
            this.advancedGroup.Name = "advancedGroup";
            this.advancedGroup.Size = new System.Drawing.Size(410, 206);
            this.advancedGroup.TabIndex = 5;
            this.advancedGroup.TabStop = false;
            this.advancedGroup.Text = "Advanced";
            // 
            // showDebugBox
            // 
            this.showDebugBox.AutoSize = true;
            this.showDebugBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDebugBox.Location = new System.Drawing.Point(16, 178);
            this.showDebugBox.Name = "showDebugBox";
            this.showDebugBox.Size = new System.Drawing.Size(169, 22);
            this.showDebugBox.TabIndex = 16;
            this.showDebugBox.Text = "Open debug window";
            this.showDebugBox.UseVisualStyleBackColor = true;
            this.showDebugBox.CheckedChanged += new System.EventHandler(this.showDebugBox_CheckedChanged);
            // 
            // defaultBtn
            // 
            this.defaultBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultBtn.Location = new System.Drawing.Point(309, 132);
            this.defaultBtn.Name = "defaultBtn";
            this.defaultBtn.Size = new System.Drawing.Size(84, 26);
            this.defaultBtn.TabIndex = 15;
            this.defaultBtn.Text = "Default";
            this.defaultBtn.UseVisualStyleBackColor = true;
            this.defaultBtn.Click += new System.EventHandler(this.defaultBtn_Click);
            // 
            // checkConBox
            // 
            this.checkConBox.AutoSize = true;
            this.checkConBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkConBox.Location = new System.Drawing.Point(16, 106);
            this.checkConBox.Name = "checkConBox";
            this.checkConBox.Size = new System.Drawing.Size(227, 22);
            this.checkConBox.TabIndex = 14;
            this.checkConBox.Text = "Check connection after login:";
            this.checkConBox.UseVisualStyleBackColor = true;
            this.checkConBox.CheckedChanged += new System.EventHandler(this.checkConBox_CheckedChanged);
            // 
            // minutesLbl
            // 
            this.minutesLbl.AccessibleDescription = "TestDescription";
            this.minutesLbl.AutoSize = true;
            this.minutesLbl.Font = new System.Drawing.Font("Arial", 12F);
            this.minutesLbl.Location = new System.Drawing.Point(114, 135);
            this.minutesLbl.Name = "minutesLbl";
            this.minutesLbl.Size = new System.Drawing.Size(76, 18);
            this.minutesLbl.TabIndex = 13;
            this.minutesLbl.Text = "minute(s).";
            // 
            // checkInput
            // 
            this.checkInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkInput.Location = new System.Drawing.Point(82, 132);
            this.checkInput.MaxLength = 2;
            this.checkInput.Name = "checkInput";
            this.checkInput.Size = new System.Drawing.Size(29, 26);
            this.checkInput.TabIndex = 12;
            this.checkInput.Text = "15";
            this.checkInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.checkInput.WordWrap = false;
            this.checkInput.TextChanged += new System.EventHandler(this.checkInput_TextChanged);
            this.checkInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Input_KeyPress);
            this.checkInput.Leave += new System.EventHandler(this.Input_Leave);
            // 
            // everyLbl
            // 
            this.everyLbl.AutoSize = true;
            this.everyLbl.Font = new System.Drawing.Font("Arial", 12F);
            this.everyLbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.everyLbl.Location = new System.Drawing.Point(33, 135);
            this.everyLbl.Name = "everyLbl";
            this.everyLbl.Size = new System.Drawing.Size(47, 18);
            this.everyLbl.TabIndex = 11;
            this.everyLbl.Text = "Every";
            // 
            // retryInfinitBox
            // 
            this.retryInfinitBox.AutoSize = true;
            this.retryInfinitBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retryInfinitBox.Location = new System.Drawing.Point(64, 64);
            this.retryInfinitBox.Name = "retryInfinitBox";
            this.retryInfinitBox.Size = new System.Drawing.Size(85, 22);
            this.retryInfinitBox.TabIndex = 9;
            this.retryInfinitBox.Text = "infinitely.";
            this.retryInfinitBox.UseVisualStyleBackColor = true;
            this.retryInfinitBox.CheckedChanged += new System.EventHandler(this.retryInfinitBox_CheckedChanged);
            // 
            // timesLbl
            // 
            this.timesLbl.AccessibleDescription = "TestDescription";
            this.timesLbl.AutoSize = true;
            this.timesLbl.Font = new System.Drawing.Font("Arial", 12F);
            this.timesLbl.Location = new System.Drawing.Point(87, 35);
            this.timesLbl.Name = "timesLbl";
            this.timesLbl.Size = new System.Drawing.Size(60, 18);
            this.timesLbl.TabIndex = 8;
            this.timesLbl.Text = "time(s).";
            // 
            // retryInput
            // 
            this.retryInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retryInput.Location = new System.Drawing.Point(58, 32);
            this.retryInput.MaxLength = 2;
            this.retryInput.Name = "retryInput";
            this.retryInput.Size = new System.Drawing.Size(26, 26);
            this.retryInput.TabIndex = 7;
            this.retryInput.Text = "5";
            this.retryInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.retryInput.WordWrap = false;
            this.retryInput.TextChanged += new System.EventHandler(this.retryInput_TextChanged);
            this.retryInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Input_KeyPress);
            this.retryInput.Leave += new System.EventHandler(this.Input_Leave);
            // 
            // retryLbl
            // 
            this.retryLbl.AutoSize = true;
            this.retryLbl.Font = new System.Drawing.Font("Arial", 12F);
            this.retryLbl.Location = new System.Drawing.Point(13, 35);
            this.retryLbl.Name = "retryLbl";
            this.retryLbl.Size = new System.Drawing.Size(44, 18);
            this.retryLbl.TabIndex = 6;
            this.retryLbl.Text = "Retry";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.deleteAllDataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.whoMadeThisToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.helpToolStripMenuItem.Text = "Help!";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // whoMadeThisToolStripMenuItem
            // 
            this.whoMadeThisToolStripMenuItem.Name = "whoMadeThisToolStripMenuItem";
            this.whoMadeThisToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.whoMadeThisToolStripMenuItem.Text = "WhoMadeThis?";
            this.whoMadeThisToolStripMenuItem.Click += new System.EventHandler(this.whoMadeThisToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.infoToolStripMenuItem.Text = "About";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // deleteAllDataToolStripMenuItem
            // 
            this.deleteAllDataToolStripMenuItem.Name = "deleteAllDataToolStripMenuItem";
            this.deleteAllDataToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.deleteAllDataToolStripMenuItem.Text = "Delete savedata";
            this.deleteAllDataToolStripMenuItem.Click += new System.EventHandler(this.deleteAllDataToolStripMenuItem_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(244, 405);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(118, 37);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Enabled = false;
            this.applyBtn.Location = new System.Drawing.Point(72, 405);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(118, 37);
            this.applyBtn.TabIndex = 10;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 455);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.advancedGroup);
            this.Controls.Add(this.passwInput);
            this.Controls.Add(this.passwLbl);
            this.Controls.Add(this.unameInput);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.mainLbl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "CampusNetLogin Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.advancedGroup.ResumeLayout(false);
            this.advancedGroup.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainLbl;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.TextBox unameInput;
        private System.Windows.Forms.Label passwLbl;
        private System.Windows.Forms.TextBox passwInput;
        private System.Windows.Forms.GroupBox advancedGroup;
        private System.Windows.Forms.Label timesLbl;
        private System.Windows.Forms.TextBox retryInput;
        private System.Windows.Forms.Label retryLbl;
        private System.Windows.Forms.CheckBox retryInfinitBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whoMadeThisToolStripMenuItem;
        private System.Windows.Forms.Label everyLbl;
        private System.Windows.Forms.CheckBox checkConBox;
        private System.Windows.Forms.Label minutesLbl;
        private System.Windows.Forms.TextBox checkInput;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.ToolStripMenuItem deleteAllDataToolStripMenuItem;
        private System.Windows.Forms.Button defaultBtn;
        private System.Windows.Forms.CheckBox showDebugBox;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    }
}

