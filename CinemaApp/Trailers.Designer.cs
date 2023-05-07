namespace CinemaApp
{
    partial class Trailers
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
            this.button15 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button15
            // 
            this.button15.BackgroundImage = global::CinemaApp.Properties.Resources.cinema_logo2;
            this.button15.Font = new System.Drawing.Font("Vinhan", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button15.Location = new System.Drawing.Point(0, -1);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(192, 77);
            this.button15.TabIndex = 19;
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // Trailers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 492);
            this.Controls.Add(this.button15);
            this.Name = "Trailers";
            this.Text = "Trailers";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button15;
    }
}