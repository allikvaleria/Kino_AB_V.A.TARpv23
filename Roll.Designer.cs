namespace Kino_AB_V.A.TARpv23
{
    partial class Roll
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
            this.lbl_vali = new System.Windows.Forms.Label();
            this.btn_valiFilm = new System.Windows.Forms.Button();
            this.btn_ostaPilet = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_vali
            // 
            this.lbl_vali.AutoSize = true;
            this.lbl_vali.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbl_vali.Location = new System.Drawing.Point(315, 22);
            this.lbl_vali.Name = "lbl_vali";
            this.lbl_vali.Size = new System.Drawing.Size(195, 29);
            this.lbl_vali.TabIndex = 0;
            this.lbl_vali.Text = "Vali kinoseanss";
            // 
            // btn_valiFilm
            // 
            this.btn_valiFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btn_valiFilm.Location = new System.Drawing.Point(105, 68);
            this.btn_valiFilm.Name = "btn_valiFilm";
            this.btn_valiFilm.Size = new System.Drawing.Size(161, 42);
            this.btn_valiFilm.TabIndex = 1;
            this.btn_valiFilm.Text = "Vali film";
            this.btn_valiFilm.UseVisualStyleBackColor = true;
            // 
            // btn_ostaPilet
            // 
            this.btn_ostaPilet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btn_ostaPilet.Location = new System.Drawing.Point(105, 163);
            this.btn_ostaPilet.Name = "btn_ostaPilet";
            this.btn_ostaPilet.Size = new System.Drawing.Size(161, 42);
            this.btn_ostaPilet.TabIndex = 2;
            this.btn_ostaPilet.Text = "Osta pilet";
            this.btn_ostaPilet.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(442, 68);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(327, 359);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // Roll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btn_ostaPilet);
            this.Controls.Add(this.btn_valiFilm);
            this.Controls.Add(this.lbl_vali);
            this.Name = "Roll";
            this.Text = "Roll";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_vali;
        private System.Windows.Forms.Button btn_valiFilm;
        private System.Windows.Forms.Button btn_ostaPilet;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}