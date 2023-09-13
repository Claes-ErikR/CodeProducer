namespace Utte.Code
{
    partial class DatasetForm
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
            this.cmdProduce = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // DatasetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 495);
            this.Name = "DatasetForm";
            this.Text = "Uttes code producer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdProduce;


    }
}

