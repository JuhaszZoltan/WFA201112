namespace WFA201112
{
    partial class FrmOktatok
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
            this.lbOktatok = new System.Windows.Forms.ListBox();
            this.rtbIdopontok = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbOktatok
            // 
            this.lbOktatok.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbOktatok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbOktatok.FormattingEnabled = true;
            this.lbOktatok.ItemHeight = 20;
            this.lbOktatok.Location = new System.Drawing.Point(17, 50);
            this.lbOktatok.Name = "lbOktatok";
            this.lbOktatok.Size = new System.Drawing.Size(219, 184);
            this.lbOktatok.TabIndex = 0;
            this.lbOktatok.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LbOktatok_DrawItem);
            this.lbOktatok.SelectedIndexChanged += new System.EventHandler(this.LbOktatok_SelectedIndexChanged);
            // 
            // rtbIdopontok
            // 
            this.rtbIdopontok.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbIdopontok.ForeColor = System.Drawing.Color.DarkOrange;
            this.rtbIdopontok.Location = new System.Drawing.Point(17, 293);
            this.rtbIdopontok.Name = "rtbIdopontok";
            this.rtbIdopontok.Size = new System.Drawing.Size(219, 199);
            this.rtbIdopontok.TabIndex = 1;
            this.rtbIdopontok.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Oktatók:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kijelölt oktató órái:";
            // 
            // FrmOktatok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 504);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbIdopontok);
            this.Controls.Add(this.lbOktatok);
            this.Name = "FrmOktatok";
            this.Text = "FrmOktatok";
            this.Load += new System.EventHandler(this.FrmOktatok_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbOktatok;
        private System.Windows.Forms.RichTextBox rtbIdopontok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}