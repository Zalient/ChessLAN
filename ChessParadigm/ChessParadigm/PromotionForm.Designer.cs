namespace Chess
{
    partial class PromotionForm
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
            pbQueen = new PictureBox();
            pbRook = new PictureBox();
            pbBishop = new PictureBox();
            pbKnight = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbQueen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbRook).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBishop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbKnight).BeginInit();
            SuspendLayout();
            // 
            // pbQueen
            // 
            pbQueen.Location = new Point(18, 18);
            pbQueen.Name = "pbQueen";
            pbQueen.Size = new Size(150, 150);
            pbQueen.SizeMode = PictureBoxSizeMode.StretchImage;
            pbQueen.TabIndex = 0;
            pbQueen.TabStop = false;
            pbQueen.Click += pbQueen_Click;
            // 
            // pbRook
            // 
            pbRook.Location = new Point(174, 18);
            pbRook.Name = "pbRook";
            pbRook.Size = new Size(150, 150);
            pbRook.SizeMode = PictureBoxSizeMode.StretchImage;
            pbRook.TabIndex = 1;
            pbRook.TabStop = false;
            pbRook.Click += pbRook_Click;
            // 
            // pbBishop
            // 
            pbBishop.Location = new Point(330, 18);
            pbBishop.Name = "pbBishop";
            pbBishop.Size = new Size(150, 150);
            pbBishop.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBishop.TabIndex = 2;
            pbBishop.TabStop = false;
            pbBishop.Click += pbBishop_Click;
            // 
            // pbKnight
            // 
            pbKnight.Location = new Point(486, 18);
            pbKnight.Name = "pbKnight";
            pbKnight.Size = new Size(150, 150);
            pbKnight.SizeMode = PictureBoxSizeMode.StretchImage;
            pbKnight.TabIndex = 3;
            pbKnight.TabStop = false;
            pbKnight.Click += pbKnight_Click;
            // 
            // PromotionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 176);
            Controls.Add(pbKnight);
            Controls.Add(pbBishop);
            Controls.Add(pbRook);
            Controls.Add(pbQueen);
            Name = "PromotionForm";
            Text = "PromotionForm";
            ((System.ComponentModel.ISupportInitialize)pbQueen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbRook).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBishop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbKnight).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbQueen;
        private PictureBox pbRook;
        private PictureBox pbBishop;
        private PictureBox pbKnight;
    }
}