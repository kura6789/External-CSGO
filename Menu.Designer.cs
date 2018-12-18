namespace Binjector_CSGO_V2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.BunnyHopCheck = new System.Windows.Forms.CheckBox();
            this.TriggerBotChecked = new System.Windows.Forms.CheckBox();
            this.ESPChecked = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BunnyHopCheck
            // 
            this.BunnyHopCheck.AutoSize = true;
            this.BunnyHopCheck.Location = new System.Drawing.Point(12, 12);
            this.BunnyHopCheck.Name = "BunnyHopCheck";
            this.BunnyHopCheck.Size = new System.Drawing.Size(100, 17);
            this.BunnyHopCheck.TabIndex = 0;
            this.BunnyHopCheck.Text = "(F1) Bunny Hop";
            this.BunnyHopCheck.UseVisualStyleBackColor = true;
            // 
            // TriggerBotChecked
            // 
            this.TriggerBotChecked.AutoSize = true;
            this.TriggerBotChecked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TriggerBotChecked.Location = new System.Drawing.Point(12, 36);
            this.TriggerBotChecked.Name = "TriggerBotChecked";
            this.TriggerBotChecked.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TriggerBotChecked.Size = new System.Drawing.Size(99, 17);
            this.TriggerBotChecked.TabIndex = 1;
            this.TriggerBotChecked.Text = "(F2) Trigger Bot";
            this.TriggerBotChecked.UseVisualStyleBackColor = true;
            // 
            // ESPChecked
            // 
            this.ESPChecked.AutoSize = true;
            this.ESPChecked.BackColor = System.Drawing.SystemColors.Control;
            this.ESPChecked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ESPChecked.Location = new System.Drawing.Point(12, 59);
            this.ESPChecked.Name = "ESPChecked";
            this.ESPChecked.Size = new System.Drawing.Size(97, 17);
            this.ESPChecked.TabIndex = 2;
            this.ESPChecked.Text = "(F3) Wall Hack";
            this.ESPChecked.UseVisualStyleBackColor = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 92);
            this.Controls.Add(this.ESPChecked);
            this.Controls.Add(this.TriggerBotChecked);
            this.Controls.Add(this.BunnyHopCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Binjector CS:GO V2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox BunnyHopCheck;
        private System.Windows.Forms.CheckBox TriggerBotChecked;
        private System.Windows.Forms.CheckBox ESPChecked;
    }
}

