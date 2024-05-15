namespace pryMirandaLuciano
{
    partial class galaga
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
            this.components = new System.ComponentModel.Container();
            this.timerNaveEnemigas = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timerDisparo = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerNaveEnemigas
            // 
            this.timerNaveEnemigas.Enabled = true;
            this.timerNaveEnemigas.Tick += new System.EventHandler(this.timerNaveEnemigas_Tick);
            // 
            // timerDisparo
            // 
            this.timerDisparo.Tick += new System.EventHandler(this.timerDisparo_Tick);
            // 
            // galaga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "galaga";
            this.Text = "galaga";
            this.Load += new System.EventHandler(this.galaga_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.galaga_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerNaveEnemigas;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timerDisparo;
    }
}