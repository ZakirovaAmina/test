
namespace ExamView
{
    partial class FormMain
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
            this.buttonProd = new System.Windows.Forms.Button();
            this.buttonComp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonProd
            // 
            this.buttonProd.Location = new System.Drawing.Point(69, 61);
            this.buttonProd.Name = "buttonProd";
            this.buttonProd.Size = new System.Drawing.Size(90, 30);
            this.buttonProd.TabIndex = 0;
            this.buttonProd.Text = "Продукты";
            this.buttonProd.UseVisualStyleBackColor = true;
            this.buttonProd.Click += new System.EventHandler(this.buttonProd_Click);
            // 
            // buttonComp
            // 
            this.buttonComp.Location = new System.Drawing.Point(201, 61);
            this.buttonComp.Name = "buttonComp";
            this.buttonComp.Size = new System.Drawing.Size(90, 29);
            this.buttonComp.TabIndex = 1;
            this.buttonComp.Text = "Компоненты";
            this.buttonComp.UseVisualStyleBackColor = true;
            this.buttonComp.Click += new System.EventHandler(this.buttonComp_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 145);
            this.Controls.Add(this.buttonComp);
            this.Controls.Add(this.buttonProd);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonProd;
        private System.Windows.Forms.Button buttonComp;
    }
}