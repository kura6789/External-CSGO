namespace Binjector
{
    partial class Menu
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
            this.BunnyHopCheck = new System.Windows.Forms.CheckBox();
            this.TriggerBotCheck = new System.Windows.Forms.CheckBox();
            this.GlowCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NoflashCheck = new System.Windows.Forms.CheckBox();
            this.voiceconfirm = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BunnyHopCheck
            // 
            this.BunnyHopCheck.AutoSize = true;
            this.BunnyHopCheck.Location = new System.Drawing.Point(6, 19);
            this.BunnyHopCheck.Name = "BunnyHopCheck";
            this.BunnyHopCheck.Size = new System.Drawing.Size(79, 17);
            this.BunnyHopCheck.TabIndex = 0;
            this.BunnyHopCheck.Text = "Bunny Hop";
            this.BunnyHopCheck.UseVisualStyleBackColor = true;
            // 
            // TriggerBotCheck
            // 
            this.TriggerBotCheck.AutoSize = true;
            this.TriggerBotCheck.Location = new System.Drawing.Point(6, 42);
            this.TriggerBotCheck.Name = "TriggerBotCheck";
            this.TriggerBotCheck.Size = new System.Drawing.Size(78, 17);
            this.TriggerBotCheck.TabIndex = 1;
            this.TriggerBotCheck.Text = "Trigger Bot";
            this.TriggerBotCheck.UseVisualStyleBackColor = true;
            // 
            // GlowCheck
            // 
            this.GlowCheck.AutoSize = true;
            this.GlowCheck.Location = new System.Drawing.Point(6, 65);
            this.GlowCheck.Name = "GlowCheck";
            this.GlowCheck.Size = new System.Drawing.Size(50, 17);
            this.GlowCheck.TabIndex = 2;
            this.GlowCheck.Text = "Glow";
            this.GlowCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NoflashCheck);
            this.groupBox1.Controls.Add(this.BunnyHopCheck);
            this.groupBox1.Controls.Add(this.GlowCheck);
            this.groupBox1.Controls.Add(this.TriggerBotCheck);
            this.groupBox1.Location = new System.Drawing.Point(13, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 111);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cheats";
            // 
            // NoflashCheck
            // 
            this.NoflashCheck.AutoSize = true;
            this.NoflashCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NoflashCheck.Location = new System.Drawing.Point(6, 86);
            this.NoflashCheck.Name = "NoflashCheck";
            this.NoflashCheck.Size = new System.Drawing.Size(68, 17);
            this.NoflashCheck.TabIndex = 3;
            this.NoflashCheck.Text = "No Flash";
            this.NoflashCheck.UseVisualStyleBackColor = true;
            // 
            // voiceconfirm
            // 
            this.voiceconfirm.AutoSize = true;
            this.voiceconfirm.Checked = true;
            this.voiceconfirm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.voiceconfirm.Location = new System.Drawing.Point(13, 13);
            this.voiceconfirm.Name = "voiceconfirm";
            this.voiceconfirm.Size = new System.Drawing.Size(114, 17);
            this.voiceconfirm.TabIndex = 4;
            this.voiceconfirm.Text = "Voice Confirmation";
            this.voiceconfirm.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 283);
            this.Controls.Add(this.voiceconfirm);
            this.Controls.Add(this.groupBox1);
            this.Name = "Menu";
            this.Text = "Binjector";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox BunnyHopCheck;
        private System.Windows.Forms.CheckBox TriggerBotCheck;
        private System.Windows.Forms.CheckBox GlowCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox voiceconfirm;
        private System.Windows.Forms.CheckBox NoflashCheck;
    }
}

