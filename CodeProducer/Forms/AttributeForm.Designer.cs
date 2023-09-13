namespace Utte.Code
{
    partial class AttributeForm
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
            this.lblAttributeDescription = new System.Windows.Forms.Label();
            this.sAttributePropertySetType = new Utte.Controls.Input.StringBoxBase();
            this.sAttributeConstructorSetType = new Utte.Controls.Input.StringBoxBase();
            this.lblPropertySetType = new System.Windows.Forms.Label();
            this.lblPropertySetName = new System.Windows.Forms.Label();
            this.lblConstructorSetName = new System.Windows.Forms.Label();
            this.lblConstructorSetType = new System.Windows.Forms.Label();
            this.lstAttributePropertySetMembers = new System.Windows.Forms.ListBox();
            this.cmdAttributePropertySet = new System.Windows.Forms.Button();
            this.sAttributePropertySet = new Utte.Controls.Input.StringBoxBase();
            this.label1 = new System.Windows.Forms.Label();
            this.lstAttributeConstructorSetMembers = new System.Windows.Forms.ListBox();
            this.cmdAttributeAddConstructorSet = new System.Windows.Forms.Button();
            this.sAttributeConstructorSetMember = new Utte.Controls.Input.StringBoxBase();
            this.lblAttributeConstructorSet = new System.Windows.Forms.Label();
            this.bInherited = new Utte.Controls.Input.boolCheckbox();
            this.bAllowMultiple = new Utte.Controls.Input.boolCheckbox();
            this.lblAttributeUsage = new System.Windows.Forms.Label();
            this.lstAttributeUsage = new System.Windows.Forms.ListBox();
            this.lblAttributeName = new System.Windows.Forms.Label();
            this.sAttributeDescription = new Utte.Controls.Input.StringBoxBase();
            this.sAttributeName = new Utte.Controls.Input.StringBoxBase();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // lblAttributeDescription
            // 
            this.lblAttributeDescription.AutoSize = true;
            this.lblAttributeDescription.Location = new System.Drawing.Point(31, 67);
            this.lblAttributeDescription.Name = "lblAttributeDescription";
            this.lblAttributeDescription.Size = new System.Drawing.Size(60, 13);
            this.lblAttributeDescription.TabIndex = 6;
            this.lblAttributeDescription.Text = "Description";
            // 
            // sAttributePropertySetType
            // 
            this.sAttributePropertySetType.AllowEmpty = false;
            this.sAttributePropertySetType.IncludeXmlSave = true;
            this.sAttributePropertySetType.Location = new System.Drawing.Point(20, 262);
            this.sAttributePropertySetType.Name = "sAttributePropertySetType";
            this.sAttributePropertySetType.Size = new System.Drawing.Size(106, 20);
            this.sAttributePropertySetType.TabIndex = 13;
            // 
            // sAttributeConstructorSetType
            // 
            this.sAttributeConstructorSetType.AllowEmpty = false;
            this.sAttributeConstructorSetType.IncludeXmlSave = true;
            this.sAttributeConstructorSetType.Location = new System.Drawing.Point(20, 87);
            this.sAttributeConstructorSetType.Name = "sAttributeConstructorSetType";
            this.sAttributeConstructorSetType.Size = new System.Drawing.Size(109, 20);
            this.sAttributeConstructorSetType.TabIndex = 12;
            // 
            // lblPropertySetType
            // 
            this.lblPropertySetType.AutoSize = true;
            this.lblPropertySetType.Location = new System.Drawing.Point(17, 239);
            this.lblPropertySetType.Name = "lblPropertySetType";
            this.lblPropertySetType.Size = new System.Drawing.Size(31, 13);
            this.lblPropertySetType.TabIndex = 11;
            this.lblPropertySetType.Text = "Type";
            // 
            // lblPropertySetName
            // 
            this.lblPropertySetName.AutoSize = true;
            this.lblPropertySetName.Location = new System.Drawing.Point(17, 287);
            this.lblPropertySetName.Name = "lblPropertySetName";
            this.lblPropertySetName.Size = new System.Drawing.Size(35, 13);
            this.lblPropertySetName.TabIndex = 10;
            this.lblPropertySetName.Text = "Name";
            // 
            // lblConstructorSetName
            // 
            this.lblConstructorSetName.AutoSize = true;
            this.lblConstructorSetName.Location = new System.Drawing.Point(17, 126);
            this.lblConstructorSetName.Name = "lblConstructorSetName";
            this.lblConstructorSetName.Size = new System.Drawing.Size(35, 13);
            this.lblConstructorSetName.TabIndex = 9;
            this.lblConstructorSetName.Text = "Name";
            // 
            // lblConstructorSetType
            // 
            this.lblConstructorSetType.AutoSize = true;
            this.lblConstructorSetType.Location = new System.Drawing.Point(17, 60);
            this.lblConstructorSetType.Name = "lblConstructorSetType";
            this.lblConstructorSetType.Size = new System.Drawing.Size(31, 13);
            this.lblConstructorSetType.TabIndex = 8;
            this.lblConstructorSetType.Text = "Type";
            // 
            // lstAttributePropertySetMembers
            // 
            this.lstAttributePropertySetMembers.FormattingEnabled = true;
            this.lstAttributePropertySetMembers.Location = new System.Drawing.Point(134, 211);
            this.lstAttributePropertySetMembers.Name = "lstAttributePropertySetMembers";
            this.lstAttributePropertySetMembers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstAttributePropertySetMembers.Size = new System.Drawing.Size(145, 147);
            this.lstAttributePropertySetMembers.TabIndex = 7;
            // 
            // cmdAttributePropertySet
            // 
            this.cmdAttributePropertySet.Location = new System.Drawing.Point(19, 344);
            this.cmdAttributePropertySet.Name = "cmdAttributePropertySet";
            this.cmdAttributePropertySet.Size = new System.Drawing.Size(107, 23);
            this.cmdAttributePropertySet.TabIndex = 6;
            this.cmdAttributePropertySet.Text = "Add --->";
            this.cmdAttributePropertySet.UseVisualStyleBackColor = true;
            this.cmdAttributePropertySet.Click += new System.EventHandler(this.cmdAttributePropertySet_Click);
            // 
            // sAttributePropertySet
            // 
            this.sAttributePropertySet.AllowEmpty = false;
            this.sAttributePropertySet.IncludeXmlSave = true;
            this.sAttributePropertySet.Location = new System.Drawing.Point(21, 308);
            this.sAttributePropertySet.Name = "sAttributePropertySet";
            this.sAttributePropertySet.Size = new System.Drawing.Size(107, 20);
            this.sAttributePropertySet.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Property set";
            // 
            // lstAttributeConstructorSetMembers
            // 
            this.lstAttributeConstructorSetMembers.FormattingEnabled = true;
            this.lstAttributeConstructorSetMembers.Location = new System.Drawing.Point(146, 33);
            this.lstAttributeConstructorSetMembers.Name = "lstAttributeConstructorSetMembers";
            this.lstAttributeConstructorSetMembers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstAttributeConstructorSetMembers.Size = new System.Drawing.Size(147, 121);
            this.lstAttributeConstructorSetMembers.TabIndex = 3;
            // 
            // cmdAttributeAddConstructorSet
            // 
            this.cmdAttributeAddConstructorSet.Location = new System.Drawing.Point(20, 168);
            this.cmdAttributeAddConstructorSet.Name = "cmdAttributeAddConstructorSet";
            this.cmdAttributeAddConstructorSet.Size = new System.Drawing.Size(108, 26);
            this.cmdAttributeAddConstructorSet.TabIndex = 2;
            this.cmdAttributeAddConstructorSet.Text = "Add --->";
            this.cmdAttributeAddConstructorSet.UseVisualStyleBackColor = true;
            this.cmdAttributeAddConstructorSet.Click += new System.EventHandler(this.cmdAttributeAddConstructorSet_Click);
            // 
            // sAttributeConstructorSetMember
            // 
            this.sAttributeConstructorSetMember.AllowEmpty = false;
            this.sAttributeConstructorSetMember.IncludeXmlSave = true;
            this.sAttributeConstructorSetMember.Location = new System.Drawing.Point(20, 142);
            this.sAttributeConstructorSetMember.Name = "sAttributeConstructorSetMember";
            this.sAttributeConstructorSetMember.Size = new System.Drawing.Size(109, 20);
            this.sAttributeConstructorSetMember.TabIndex = 1;
            // 
            // lblAttributeConstructorSet
            // 
            this.lblAttributeConstructorSet.AutoSize = true;
            this.lblAttributeConstructorSet.Location = new System.Drawing.Point(17, 33);
            this.lblAttributeConstructorSet.Name = "lblAttributeConstructorSet";
            this.lblAttributeConstructorSet.Size = new System.Drawing.Size(78, 13);
            this.lblAttributeConstructorSet.TabIndex = 0;
            this.lblAttributeConstructorSet.Text = "Constructor set";
            // 
            // bInherited
            // 
            this.bInherited.AutoSize = true;
            this.bInherited.IncludeXmlSave = false;
            this.bInherited.Location = new System.Drawing.Point(22, 310);
            this.bInherited.Name = "bInherited";
            this.bInherited.Size = new System.Drawing.Size(67, 17);
            this.bInherited.TabIndex = 3;
            this.bInherited.Text = "Inherited";
            this.bInherited.UseVisualStyleBackColor = true;
            this.bInherited.Value = false;
            // 
            // bAllowMultiple
            // 
            this.bAllowMultiple.AutoSize = true;
            this.bAllowMultiple.IncludeXmlSave = false;
            this.bAllowMultiple.Location = new System.Drawing.Point(22, 280);
            this.bAllowMultiple.Name = "bAllowMultiple";
            this.bAllowMultiple.Size = new System.Drawing.Size(89, 17);
            this.bAllowMultiple.TabIndex = 2;
            this.bAllowMultiple.Text = "Allow multiple";
            this.bAllowMultiple.UseVisualStyleBackColor = true;
            this.bAllowMultiple.Value = false;
            // 
            // lblAttributeUsage
            // 
            this.lblAttributeUsage.AutoSize = true;
            this.lblAttributeUsage.Location = new System.Drawing.Point(19, 33);
            this.lblAttributeUsage.Name = "lblAttributeUsage";
            this.lblAttributeUsage.Size = new System.Drawing.Size(38, 13);
            this.lblAttributeUsage.TabIndex = 1;
            this.lblAttributeUsage.Text = "Usage";
            // 
            // lstAttributeUsage
            // 
            this.lstAttributeUsage.FormattingEnabled = true;
            this.lstAttributeUsage.Location = new System.Drawing.Point(22, 60);
            this.lstAttributeUsage.Name = "lstAttributeUsage";
            this.lstAttributeUsage.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAttributeUsage.Size = new System.Drawing.Size(150, 199);
            this.lstAttributeUsage.TabIndex = 0;
            // 
            // lblAttributeName
            // 
            this.lblAttributeName.AutoSize = true;
            this.lblAttributeName.Location = new System.Drawing.Point(31, 28);
            this.lblAttributeName.Name = "lblAttributeName";
            this.lblAttributeName.Size = new System.Drawing.Size(35, 13);
            this.lblAttributeName.TabIndex = 1;
            this.lblAttributeName.Text = "Name";
            // 
            // sAttributeDescription
            // 
            this.sAttributeDescription.AllowEmpty = false;
            this.sAttributeDescription.IncludeXmlSave = true;
            this.sAttributeDescription.Location = new System.Drawing.Point(97, 67);
            this.sAttributeDescription.Name = "sAttributeDescription";
            this.sAttributeDescription.Size = new System.Drawing.Size(179, 20);
            this.sAttributeDescription.TabIndex = 5;
            // 
            // sAttributeName
            // 
            this.sAttributeName.AllowEmpty = false;
            this.sAttributeName.IncludeXmlSave = true;
            this.sAttributeName.Location = new System.Drawing.Point(91, 25);
            this.sAttributeName.Name = "sAttributeName";
            this.sAttributeName.Size = new System.Drawing.Size(179, 20);
            this.sAttributeName.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bInherited);
            this.groupBox1.Controls.Add(this.lblAttributeUsage);
            this.groupBox1.Controls.Add(this.bAllowMultiple);
            this.groupBox1.Controls.Add(this.lstAttributeUsage);
            this.groupBox1.Location = new System.Drawing.Point(34, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 374);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meta attribute";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstAttributePropertySetMembers);
            this.groupBox2.Controls.Add(this.lblPropertySetName);
            this.groupBox2.Controls.Add(this.cmdAttributePropertySet);
            this.groupBox2.Controls.Add(this.sAttributePropertySetType);
            this.groupBox2.Controls.Add(this.sAttributePropertySet);
            this.groupBox2.Controls.Add(this.lblAttributeConstructorSet);
            this.groupBox2.Controls.Add(this.lblPropertySetType);
            this.groupBox2.Controls.Add(this.sAttributeConstructorSetType);
            this.groupBox2.Controls.Add(this.lblConstructorSetType);
            this.groupBox2.Controls.Add(this.lblConstructorSetName);
            this.groupBox2.Controls.Add(this.sAttributeConstructorSetMember);
            this.groupBox2.Controls.Add(this.cmdAttributeAddConstructorSet);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lstAttributeConstructorSetMembers);
            this.groupBox2.Location = new System.Drawing.Point(295, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 373);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Members";
            // 
            // AttributeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 534);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAttributeDescription);
            this.Controls.Add(this.sAttributeDescription);
            this.Controls.Add(this.lblAttributeName);
            this.Controls.Add(this.sAttributeName);
            this.Name = "AttributeForm";
            this.Text = "Uttes code producer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdProduce;
        private System.Windows.Forms.ListBox lstAttributeUsage;
        private System.Windows.Forms.Label lblAttributeName;
        private Utte.Controls.Input.StringBoxBase sAttributeName;
        private System.Windows.Forms.ListBox lstAttributeConstructorSetMembers;
        private System.Windows.Forms.Button cmdAttributeAddConstructorSet;
        private Utte.Controls.Input.StringBoxBase sAttributeConstructorSetMember;
        private System.Windows.Forms.Label lblAttributeConstructorSet;
        private Utte.Controls.Input.boolCheckbox bInherited;
        private Utte.Controls.Input.boolCheckbox bAllowMultiple;
        private System.Windows.Forms.Label lblAttributeUsage;
        private System.Windows.Forms.ListBox lstAttributePropertySetMembers;
        private System.Windows.Forms.Button cmdAttributePropertySet;
        private Utte.Controls.Input.StringBoxBase sAttributePropertySet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAttributeDescription;
        private Utte.Controls.Input.StringBoxBase sAttributeDescription;
        private Utte.Controls.Input.StringBoxBase sAttributePropertySetType;
        private Utte.Controls.Input.StringBoxBase sAttributeConstructorSetType;
        private System.Windows.Forms.Label lblPropertySetType;
        private System.Windows.Forms.Label lblPropertySetName;
        private System.Windows.Forms.Label lblConstructorSetName;
        private System.Windows.Forms.Label lblConstructorSetType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;


    }
}

