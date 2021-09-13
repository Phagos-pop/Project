
namespace WindowsForms
{
    partial class StartMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenu));
            this.GameNameLabel = new System.Windows.Forms.Label();
            this.ExitPicture = new System.Windows.Forms.PictureBox();
            this.OptionPicture = new System.Windows.Forms.PictureBox();
            this.LoadGamePicture = new System.Windows.Forms.PictureBox();
            this.NewGamePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ExitPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadGamePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewGamePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // GameNameLabel
            // 
            this.GameNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.GameNameLabel.AutoSize = true;
            this.GameNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.GameNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 140.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameNameLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.GameNameLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GameNameLabel.Location = new System.Drawing.Point(462, 96);
            this.GameNameLabel.Name = "GameNameLabel";
            this.GameNameLabel.Size = new System.Drawing.Size(724, 211);
            this.GameNameLabel.TabIndex = 1;
            this.GameNameLabel.Text = "Phagos";
            this.GameNameLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ExitPicture
            // 
            this.ExitPicture.BackColor = System.Drawing.Color.Black;
            this.ExitPicture.Location = new System.Drawing.Point(534, 735);
            this.ExitPicture.Name = "ExitPicture";
            this.ExitPicture.Size = new System.Drawing.Size(484, 114);
            this.ExitPicture.TabIndex = 2;
            this.ExitPicture.TabStop = false;
            this.ExitPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Exit_Mouse_Down);
            this.ExitPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Exit_Mouse_Up);
            // 
            // OptionPicture
            // 
            this.OptionPicture.BackColor = System.Drawing.Color.Black;
            this.OptionPicture.Location = new System.Drawing.Point(534, 615);
            this.OptionPicture.Name = "OptionPicture";
            this.OptionPicture.Size = new System.Drawing.Size(484, 114);
            this.OptionPicture.TabIndex = 3;
            this.OptionPicture.TabStop = false;
            this.OptionPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OptionPicture_MouseDown);
            this.OptionPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OptionPicture_MouseUp);
            // 
            // LoadGamePicture
            // 
            this.LoadGamePicture.BackColor = System.Drawing.Color.Black;
            this.LoadGamePicture.Location = new System.Drawing.Point(534, 462);
            this.LoadGamePicture.Name = "LoadGamePicture";
            this.LoadGamePicture.Size = new System.Drawing.Size(484, 114);
            this.LoadGamePicture.TabIndex = 4;
            this.LoadGamePicture.TabStop = false;
            this.LoadGamePicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoadGamePicture_MouseDown);
            this.LoadGamePicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LoadGamePicture_MouseUp);
            // 
            // NewGamePicture
            // 
            this.NewGamePicture.BackColor = System.Drawing.Color.Black;
            this.NewGamePicture.Location = new System.Drawing.Point(534, 342);
            this.NewGamePicture.Name = "NewGamePicture";
            this.NewGamePicture.Size = new System.Drawing.Size(484, 114);
            this.NewGamePicture.TabIndex = 5;
            this.NewGamePicture.TabStop = false;
            this.NewGamePicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewGamePicture_MouseDown);
            this.NewGamePicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NewGamePicture_MouseUp);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.NewGamePicture);
            this.Controls.Add(this.LoadGamePicture);
            this.Controls.Add(this.OptionPicture);
            this.Controls.Add(this.ExitPicture);
            this.Controls.Add(this.GameNameLabel);
            this.Name = "StartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartMenu";
            ((System.ComponentModel.ISupportInitialize)(this.ExitPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadGamePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewGamePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameNameLabel;
        private System.Windows.Forms.PictureBox ExitPicture;
        private System.Windows.Forms.PictureBox OptionPicture;
        private System.Windows.Forms.PictureBox LoadGamePicture;
        private System.Windows.Forms.PictureBox NewGamePicture;
    }
}