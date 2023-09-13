namespace Utte.Code
{
    partial class FormComponentForm
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
            this.lblValue = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblParent = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.sValue = new Utte.Controls.Input.StringBoxBase();
            this.sDescription = new Utte.Controls.Input.StringBoxBase();
            this.sParent = new Utte.Controls.Input.StringBoxBase();
            this.sName = new Utte.Controls.Input.StringBoxBase();
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
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(37, 147);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(57, 13);
            this.lblValue.TabIndex = 6;
            this.lblValue.Text = "Value type";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(37, 106);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description";
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Location = new System.Drawing.Point(37, 68);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(65, 13);
            this.lblParent.TabIndex = 2;
            this.lblParent.Text = "Parent class";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(37, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // sValue
            // 
            this.sValue.AllowEmpty = false;
            this.sValue.IncludeXmlSave = true;
            this.sValue.Location = new System.Drawing.Point(122, 144);
            this.sValue.Name = "sValue";
            this.sValue.Size = new System.Drawing.Size(289, 20);
            this.sValue.TabIndex = 7;
            // 
            // sDescription
            // 
            this.sDescription.AllowEmpty = false;
            this.sDescription.IncludeXmlSave = true;
            this.sDescription.Location = new System.Drawing.Point(122, 106);
            this.sDescription.Name = "sDescription";
            this.sDescription.Size = new System.Drawing.Size(289, 20);
            this.sDescription.TabIndex = 4;
            // 
            // sParent
            // 
            this.sParent.AllowEmpty = false;
            this.sParent.IncludeXmlSave = true;
            this.sParent.Location = new System.Drawing.Point(122, 65);
            this.sParent.Name = "sParent";
            this.sParent.Size = new System.Drawing.Size(289, 20);
            this.sParent.TabIndex = 3;
            // 
            // sName
            // 
            this.sName.AllowEmpty = false;
            this.sName.IncludeXmlSave = true;
            this.sName.Location = new System.Drawing.Point(122, 29);
            this.sName.Name = "sName";
            this.sName.Size = new System.Drawing.Size(289, 20);
            this.sName.TabIndex = 1;
            // 
            // FormComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 495);
            this.Controls.Add(this.sValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.sDescription);
            this.Controls.Add(this.sName);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.sParent);
            this.Name = "FormComponentForm";
            this.Text = "Form/component";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdProduce;
        private System.Windows.Forms.Label lblDescription;
        private Utte.Controls.Input.StringBoxBase sDescription;
        private Utte.Controls.Input.StringBoxBase sParent;
        private System.Windows.Forms.Label lblParent;
        private Utte.Controls.Input.StringBoxBase sName;
        private System.Windows.Forms.Label lblName;
        private Utte.Controls.Input.StringBoxBase sValue;
        private System.Windows.Forms.Label lblValue;


    }
}

