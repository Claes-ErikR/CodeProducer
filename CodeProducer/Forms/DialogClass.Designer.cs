namespace Utte.Code.Controls
{
    partial class DialogClass
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
            this.cmdOk = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cpClass = new Utte.Code.Controls.ClassProducerControl();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(28, 492);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(104, 28);
            this.cmdOk.TabIndex = 2;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(154, 492);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 28);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cpClass
            // 
            this.cpClass.Dock = System.Windows.Forms.DockStyle.Top;
            this.cpClass.Location = new System.Drawing.Point(0, 0);
            this.cpClass.Name = "cpClass";
            this.cpClass.Size = new System.Drawing.Size(784, 486);
            this.cpClass.TabIndex = 4;
            // 
            // DialogClass
            // 
            this.AcceptButton = this.cmdOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(784, 529);
            this.ControlBox = false;
            this.Controls.Add(this.cpClass);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DialogClass";
            this.ShowInTaskbar = false;
            this.Text = "Add class";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Button cmdCancel;
        private Utte.Code.Controls.ClassProducerControl cpClass;
    }
}