
namespace Re2
{
    partial class ObjectFly
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Field = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Field
            // 
            this.Field.Location = new System.Drawing.Point(400, 50);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(360, 360);
            this.Field.TabIndex = 0;
            this.Field.TabStop = false;
            this.Field.Paint += new System.Windows.Forms.PaintEventHandler(this.Field_Paint);
            // 
            // ObjectFly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Field);
            this.DoubleBuffered = true;
            this.Name = "ObjectFly";
            this.Text = "Form3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ObjectFly_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox Field;
    }
}