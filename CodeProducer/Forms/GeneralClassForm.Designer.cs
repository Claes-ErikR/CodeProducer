namespace Utte.Code
{
    partial class GeneralClassForm
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
            this.cpClassProduce = new Utte.Code.Controls.ClassProducerControl();
            this.cmdProduce = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cpClassProduce
            // 
            this.cpClassProduce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cpClassProduce.Location = new System.Drawing.Point(0, 0);
            this.cpClassProduce.Name = "cpClassProduce";
            this.cpClassProduce.Size = new System.Drawing.Size(674, 516);
            this.cpClassProduce.TabIndex = 1;
            // 
            // cmdProduce
            // 
            this.cmdProduce.Location = new System.Drawing.Point(24, 394);
            this.cmdProduce.Name = "cmdProduce";
            this.cmdProduce.Size = new System.Drawing.Size(163, 40);
            this.cmdProduce.TabIndex = 0;
            this.cmdProduce.Text = "Produce";
            this.cmdProduce.UseVisualStyleBackColor = true;
            // 
            // GeneralClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 516);
            this.Controls.Add(this.cpClassProduce);
            this.Name = "GeneralClassForm";
            this.Text = "General class production";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Utte.Code.Controls.ClassProducerControl cpClassProduce;
        private System.Windows.Forms.Button cmdProduce;


    }
}

