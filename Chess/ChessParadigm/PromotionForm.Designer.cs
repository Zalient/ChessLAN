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
            picBoxQueen = new PictureBox();
            picBoxRook = new PictureBox();
            picBoxBishop = new PictureBox();
            picBoxKnight = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picBoxQueen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxRook).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxBishop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxKnight).BeginInit();
            SuspendLayout();
            // 
            // picBoxQueen
            // 
            picBoxQueen.Location = new Point(18, 18);
            picBoxQueen.Name = "picBoxQueen";
            picBoxQueen.Size = new Size(150, 150);
            picBoxQueen.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxQueen.TabIndex = 0;
            picBoxQueen.TabStop = false;
            picBoxQueen.Click += picBoxQueen_Click;
            // 
            // picBoxRook
            // 
            picBoxRook.Location = new Point(174, 18);
            picBoxRook.Name = "picBoxRook";
            picBoxRook.Size = new Size(150, 150);
            picBoxRook.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxRook.TabIndex = 1;
            picBoxRook.TabStop = false;
            picBoxRook.Click += picBoxRook_Click;
            // 
            // picBoxBishop
            // 
            picBoxBishop.Location = new Point(330, 18);
            picBoxBishop.Name = "picBoxBishop";
            picBoxBishop.Size = new Size(150, 150);
            picBoxBishop.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxBishop.TabIndex = 2;
            picBoxBishop.TabStop = false;
            picBoxBishop.Click += picBoxBishop_Click;
            // 
            // picBoxKnight
            // 
            picBoxKnight.Location = new Point(486, 18);
            picBoxKnight.Name = "picBoxKnight";
            picBoxKnight.Size = new Size(150, 150);
            picBoxKnight.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxKnight.TabIndex = 3;
            picBoxKnight.TabStop = false;
            picBoxKnight.Click += picBoxKnight_Click;
            // 
            // PromotionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 176);
            Controls.Add(picBoxKnight);
            Controls.Add(picBoxBishop);
            Controls.Add(picBoxRook);
            Controls.Add(picBoxQueen);
            Name = "PromotionForm";
            Text = "PromotionForm";
            ((System.ComponentModel.ISupportInitialize)picBoxQueen).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxRook).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxBishop).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxKnight).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picBoxQueen;
        private PictureBox picBoxRook;
        private PictureBox picBoxBishop;
        private PictureBox picBoxKnight;
    }
}