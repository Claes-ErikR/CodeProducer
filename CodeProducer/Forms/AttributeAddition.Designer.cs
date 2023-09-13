namespace Utte.Code.Controls
{
    partial class frmAttributeAddition
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
            this.bBrowsable = new Utte.Controls.Input.boolCheckbox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.sDescription = new Utte.Controls.Input.StringBoxBase();
            this.sAttribute = new Utte.Controls.Input.StringBoxBase();
            this.lstAttributes = new System.Windows.Forms.ListBox();
            this.lblAttribute = new System.Windows.Forms.Label();
            this.cmdAddAttribute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(25, 231);
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
            this.cmdCancel.Location = new System.Drawing.Point(159, 231);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 28);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // bBrowsable
            // 
            this.bBrowsable.AutoSize = true;
            this.bBrowsable.IncludeXmlSave = false;
            this.bBrowsable.Location = new System.Drawing.Point(12, 12);
            this.bBrowsable.Name = "bBrowsable";
            this.bBrowsable.Size = new System.Drawing.Size(103, 17);
            this.bBrowsable.TabIndex = 4;
            this.bBrowsable.Text = "Browsable(false)";
            this.bBrowsable.UseVisualStyleBackColor = true;
            this.bBrowsable.Value = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 42);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Category";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Accessibility",
            "Appearance",
            "Behavior",
            "Data",
            "Design",
            "Focus",
            "Layout",
            "Misc"});
            this.cbCategory.Location = new System.Drawing.Point(76, 39);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(123, 21);
            this.cbCategory.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 80);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description";
            // 
            // sDescription
            // 
            this.sDescription.AllowEmpty = false;
            this.sDescription.IncludeXmlSave = true;
            this.sDescription.Location = new System.Drawing.Point(76, 73);
            this.sDescription.Name = "sDescription";
            this.sDescription.Size = new System.Drawing.Size(348, 20);
            this.sDescription.TabIndex = 8;
            // 
            // sAttribute
            // 
            this.sAttribute.AllowEmpty = false;
            this.sAttribute.IncludeXmlSave = true;
            this.sAttribute.Location = new System.Drawing.Point(24, 148);
            this.sAttribute.Name = "sAttribute";
            this.sAttribute.Size = new System.Drawing.Size(174, 20);
            this.sAttribute.TabIndex = 9;
            // 
            // lstAttributes
            // 
            this.lstAttributes.FormattingEnabled = true;
            this.lstAttributes.Location = new System.Drawing.Point(212, 108);
            this.lstAttributes.Name = "lstAttributes";
            this.lstAttributes.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstAttributes.Size = new System.Drawing.Size(211, 108);
            this.lstAttributes.TabIndex = 10;
            // 
            // lblAttribute
            // 
            this.lblAttribute.AutoSize = true;
            this.lblAttribute.Location = new System.Drawing.Point(26, 120);
            this.lblAttribute.Name = "lblAttribute";
            this.lblAttribute.Size = new System.Drawing.Size(49, 13);
            this.lblAttribute.TabIndex = 11;
            this.lblAttribute.Text = "Attribute:";
            // 
            // cmdAddAttribute
            // 
            this.cmdAddAttribute.Location = new System.Drawing.Point(25, 179);
            this.cmdAddAttribute.Name = "cmdAddAttribute";
            this.cmdAddAttribute.Size = new System.Drawing.Size(163, 27);
            this.cmdAddAttribute.TabIndex = 12;
            this.cmdAddAttribute.Text = "Add Attribute --->";
            this.cmdAddAttribute.UseVisualStyleBackColor = true;
            this.cmdAddAttribute.Click += new System.EventHandler(this.cmdAddAttribute_Click);
            // 
            // frmAttributeAddition
            // 
            this.AcceptButton = this.cmdOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(436, 271);
            this.ControlBox = false;
            this.Controls.Add(this.cmdAddAttribute);
            this.Controls.Add(this.lblAttribute);
            this.Controls.Add(this.lstAttributes);
            this.Controls.Add(this.sAttribute);
            this.Controls.Add(this.sDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.bBrowsable);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAttributeAddition";
            this.ShowInTaskbar = false;
            this.Text = "Add Attributes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Button cmdCancel;
        private Utte.Controls.Input.boolCheckbox bBrowsable;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblDescription;
        private Utte.Controls.Input.StringBoxBase sDescription;
        private Utte.Controls.Input.StringBoxBase sAttribute;
        private System.Windows.Forms.ListBox lstAttributes;
        private System.Windows.Forms.Label lblAttribute;
        private System.Windows.Forms.Button cmdAddAttribute;
    }
}