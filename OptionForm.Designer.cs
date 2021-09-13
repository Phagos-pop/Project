
namespace WindowsForms
{
    partial class OptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
            this.BackPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // BackPicture
            // 
            this.BackPicture.BackColor = System.Drawing.Color.Black;
            this.BackPicture.Location = new System.Drawing.Point(533, 735);
            this.BackPicture.Name = "BackPicture";
            this.BackPicture.Size = new System.Drawing.Size(484, 114);
            this.BackPicture.TabIndex = 3;
            this.BackPicture.TabStop = false;
            this.BackPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackPicture_MouseDown);
            this.BackPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackPicture_MouseUp);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.BackPicture);
            this.Name = "OptionForm";
            this.Text = "OptionForm";
            ((System.ComponentModel.ISupportInitialize)(this.BackPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BackPicture;
    }
}