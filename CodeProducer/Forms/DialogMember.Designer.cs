namespace Utte.Code.Controls
{
    partial class DialogMember
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new Utte.Controls.Input.StringBoxBase();
            this.txtDescription = new Utte.Controls.Input.StringBoxBase();
            this.chkPrivateProtected = new System.Windows.Forms.CheckBox();
            this.chkStatic = new System.Windows.Forms.CheckBox();
            this.chkGetProperty = new System.Windows.Forms.CheckBox();
            this.chkSetProperty = new System.Windows.Forms.CheckBox();
            this.chkConstructorSet = new System.Windows.Forms.CheckBox();
            this.chkValueType = new System.Windows.Forms.CheckBox();
            this.cmdAddAttributes = new System.Windows.Forms.Button();
            this.chkProtectedSetProperty = new System.Windows.Forms.CheckBox();
            this.tcType = new Utte.Code.TypeChoser();
            this.chkPropertyIsNullable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(24, 323);
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
            this.cmdCancel.Location = new System.Drawing.Point(147, 323);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 28);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(22, 50);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Type";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(22, 80);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.AllowEmpty = false;
            this.txtName.IncludeXmlSave = true;
            this.txtName.Location = new System.Drawing.Point(91, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(176, 20);
            this.txtName.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.AllowEmpty = false;
            this.txtDescription.IncludeXmlSave = true;
            this.txtDescription.Location = new System.Drawing.Point(91, 80);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(176, 20);
            this.txtDescription.TabIndex = 9;
            // 
            // chkPrivateProtected
            // 
            this.chkPrivateProtected.AutoSize = true;
            this.chkPrivateProtected.Location = new System.Drawing.Point(25, 106);
            this.chkPrivateProtected.Name = "chkPrivateProtected";
            this.chkPrivateProtected.Size = new System.Drawing.Size(186, 17);
            this.chkPrivateProtected.TabIndex = 10;
            this.chkPrivateProtected.Text = "Include private/protected member";
            this.chkPrivateProtected.UseVisualStyleBackColor = true;
            // 
            // chkStatic
            // 
            this.chkStatic.AutoSize = true;
            this.chkStatic.Location = new System.Drawing.Point(25, 129);
            this.chkStatic.Name = "chkStatic";
            this.chkStatic.Size = new System.Drawing.Size(53, 17);
            this.chkStatic.TabIndex = 11;
            this.chkStatic.Text = "Static";
            this.chkStatic.UseVisualStyleBackColor = true;
            // 
            // chkGetProperty
            // 
            this.chkGetProperty.AutoSize = true;
            this.chkGetProperty.Location = new System.Drawing.Point(25, 152);
            this.chkGetProperty.Name = "chkGetProperty";
            this.chkGetProperty.Size = new System.Drawing.Size(104, 17);
            this.chkGetProperty.TabIndex = 12;
            this.chkGetProperty.Text = "Add get property";
            this.chkGetProperty.UseVisualStyleBackColor = true;
            // 
            // chkSetProperty
            // 
            this.chkSetProperty.AutoSize = true;
            this.chkSetProperty.Location = new System.Drawing.Point(25, 175);
            this.chkSetProperty.Name = "chkSetProperty";
            this.chkSetProperty.Size = new System.Drawing.Size(103, 17);
            this.chkSetProperty.TabIndex = 13;
            this.chkSetProperty.Text = "Add set property";
            this.chkSetProperty.UseVisualStyleBackColor = true;
            this.chkSetProperty.CheckedChanged += new System.EventHandler(this.chkSetProperty_CheckedChanged);
            // 
            // chkConstructorSet
            // 
            this.chkConstructorSet.AutoSize = true;
            this.chkConstructorSet.Location = new System.Drawing.Point(24, 217);
            this.chkConstructorSet.Name = "chkConstructorSet";
            this.chkConstructorSet.Size = new System.Drawing.Size(138, 17);
            this.chkConstructorSet.TabIndex = 14;
            this.chkConstructorSet.Text = "Set value in constructor";
            this.chkConstructorSet.UseVisualStyleBackColor = true;
            // 
            // chkValueType
            // 
            this.chkValueType.AutoSize = true;
            this.chkValueType.Location = new System.Drawing.Point(24, 240);
            this.chkValueType.Name = "chkValueType";
            this.chkValueType.Size = new System.Drawing.Size(112, 17);
            this.chkValueType.TabIndex = 15;
            this.chkValueType.Text = "Type is value type";
            this.chkValueType.UseVisualStyleBackColor = true;
            // 
            // cmdAddAttributes
            // 
            this.cmdAddAttributes.Location = new System.Drawing.Point(24, 289);
            this.cmdAddAttributes.Name = "cmdAddAttributes";
            this.cmdAddAttributes.Size = new System.Drawing.Size(104, 28);
            this.cmdAddAttributes.TabIndex = 16;
            this.cmdAddAttributes.Text = "Add Attributes";
            this.cmdAddAttributes.UseVisualStyleBackColor = true;
            this.cmdAddAttributes.Click += new System.EventHandler(this.cmdAddAttributes_Click);
            // 
            // chkProtectedSetProperty
            // 
            this.chkProtectedSetProperty.AutoSize = true;
            this.chkProtectedSetProperty.Location = new System.Drawing.Point(25, 194);
            this.chkProtectedSetProperty.Name = "chkProtectedSetProperty";
            this.chkProtectedSetProperty.Size = new System.Drawing.Size(151, 17);
            this.chkProtectedSetProperty.TabIndex = 17;
            this.chkProtectedSetProperty.Text = "Add protected set property";
            this.chkProtectedSetProperty.UseVisualStyleBackColor = true;
            this.chkProtectedSetProperty.CheckedChanged += new System.EventHandler(this.chkProtectedSetProperty_CheckedChanged);
            // 
            // tcType
            // 
            this.tcType.FormattingEnabled = true;
            this.tcType.Location = new System.Drawing.Point(91, 49);
            this.tcType.Name = "tcType";
            this.tcType.Size = new System.Drawing.Size(176, 21);
            this.tcType.TabIndex = 18;
            this.tcType.TextChanged += new System.EventHandler(this.tcType_TextChanged);
            // 
            // chkPropertyIsNullable
            // 
            this.chkPropertyIsNullable.AutoSize = true;
            this.chkPropertyIsNullable.Location = new System.Drawing.Point(24, 263);
            this.chkPropertyIsNullable.Name = "chkPropertyIsNullable";
            this.chkPropertyIsNullable.Size = new System.Drawing.Size(143, 17);
            this.chkPropertyIsNullable.TabIndex = 19;
            this.chkPropertyIsNullable.Text = "Property value is nullable";
            this.chkPropertyIsNullable.UseVisualStyleBackColor = true;
            // 
            // DialogMember
            // 
            this.AcceptButton = this.cmdOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(306, 377);
            this.ControlBox = false;
            this.Controls.Add(this.chkPropertyIsNullable);
            this.Controls.Add(this.tcType);
            this.Controls.Add(this.chkProtectedSetProperty);
            this.Controls.Add(this.cmdAddAttributes);
            this.Controls.Add(this.chkValueType);
            this.Controls.Add(this.chkConstructorSet);
            this.Controls.Add(this.chkSetProperty);
            this.Controls.Add(this.chkGetProperty);
            this.Controls.Add(this.chkStatic);
            this.Controls.Add(this.chkPrivateProtected);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DialogMember";
            this.ShowInTaskbar = false;
            this.Text = "Add dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblDescription;
        private Utte.Controls.Input.StringBoxBase txtName;
        private Utte.Controls.Input.StringBoxBase txtDescription;
        private System.Windows.Forms.CheckBox chkPrivateProtected;
        private System.Windows.Forms.CheckBox chkStatic;
        private System.Windows.Forms.CheckBox chkGetProperty;
        private System.Windows.Forms.CheckBox chkSetProperty;
        private System.Windows.Forms.CheckBox chkConstructorSet;
        private System.Windows.Forms.CheckBox chkValueType;
        private System.Windows.Forms.Button cmdAddAttributes;
        private System.Windows.Forms.CheckBox chkProtectedSetProperty;
        private TypeChoser tcType;
        private System.Windows.Forms.CheckBox chkPropertyIsNullable;
    }
}