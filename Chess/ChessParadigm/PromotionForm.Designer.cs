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
            this.QueenPB = new System.Windows.Forms.PictureBox();
            this.RookPB = new System.Windows.Forms.PictureBox();
            this.BishopPB = new System.Windows.Forms.PictureBox();
            this.KnightPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.QueenPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RookPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BishopPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KnightPB)).BeginInit();
            this.SuspendLayout();
            // 
            // QueenPB
            // 
            this.QueenPB.Location = new System.Drawing.Point(18, 18);
            this.QueenPB.Name = "QueenPB";
            this.QueenPB.Size = new System.Drawing.Size(150, 150);
            this.QueenPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QueenPB.TabIndex = 0;
            this.QueenPB.TabStop = false;
            this.QueenPB.Click += new System.EventHandler(this.QueenPB_Click);
            // 
            // RookPB
            // 
            this.RookPB.Location = new System.Drawing.Point(174, 18);
            this.RookPB.Name = "RookPB";
            this.RookPB.Size = new System.Drawing.Size(150, 150);
            this.RookPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RookPB.TabIndex = 1;
            this.RookPB.TabStop = false;
            this.RookPB.Click += new System.EventHandler(this.RookPB_Click);
            // 
            // BishopPB
            // 
            this.BishopPB.Location = new System.Drawing.Point(330, 18);
            this.BishopPB.Name = "BishopPB";
            this.BishopPB.Size = new System.Drawing.Size(150, 150);
            this.BishopPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BishopPB.TabIndex = 2;
            this.BishopPB.TabStop = false;
            this.BishopPB.Click += new System.EventHandler(this.BishopPB_Click);
            // 
            // KnightPB
            // 
            this.KnightPB.Location = new System.Drawing.Point(486, 18);
            this.KnightPB.Name = "KnightPB";
            this.KnightPB.Size = new System.Drawing.Size(150, 150);
            this.KnightPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.KnightPB.TabIndex = 3;
            this.KnightPB.TabStop = false;
            this.KnightPB.Click += new System.EventHandler(this.KnightPB_Click);
            // 
            // PromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 176);
            this.Controls.Add(this.KnightPB);
            this.Controls.Add(this.BishopPB);
            this.Controls.Add(this.RookPB);
            this.Controls.Add(this.QueenPB);
            this.Name = "PromotionForm";
            this.Text = "PromotionForm";
            ((System.ComponentModel.ISupportInitialize)(this.QueenPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RookPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BishopPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KnightPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox QueenPB;
        private PictureBox RookPB;
        private PictureBox BishopPB;
        private PictureBox KnightPB;
    }
}