namespace Utte.Code.Controls
{
    partial class ClassProducerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.lblClassType = new System.Windows.Forms.Label();
            this.edClassType = new Utte.Controls.Input.enumDropdown();
            this.cmdAddAttributes = new System.Windows.Forms.Button();
            this.bFormComponent = new Utte.Controls.Input.boolCheckbox();
            this.lblVisibility = new System.Windows.Forms.Label();
            this.txtDescription = new Utte.Controls.Input.StringBoxBase();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblParentClass = new System.Windows.Forms.Label();
            this.txtParentClass = new Utte.Controls.Input.StringBoxBase();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new Utte.Controls.Input.StringBoxBase();
            this.grpMembers = new System.Windows.Forms.GroupBox();
            this.cmdMemberDown = new System.Windows.Forms.Button();
            this.cmdMemberUp = new System.Windows.Forms.Button();
            this.cmdDeleteMember = new System.Windows.Forms.Button();
            this.cmdAddMember = new System.Windows.Forms.Button();
            this.lstMembers = new System.Windows.Forms.ListBox();
            this.grpClasses = new System.Windows.Forms.GroupBox();
            this.cmdDeleteClass = new System.Windows.Forms.Button();
            this.cmdAddClass = new System.Windows.Forms.Button();
            this.lstClasses = new System.Windows.Forms.ListBox();
            this.grpInterfaces = new System.Windows.Forms.GroupBox();
            this.lstImplementedInterfaces = new System.Windows.Forms.ListBox();
            this.lblImplementedIterfaces2 = new System.Windows.Forms.Label();
            this.lblImplementedInterfaces1 = new System.Windows.Forms.Label();
            this.cmdAddInterface = new System.Windows.Forms.Button();
            this.txtInterface = new Utte.Controls.Input.StringBoxBase();
            this.lstInterfaces = new System.Windows.Forms.ListBox();
            this.grpImplementations = new System.Windows.Forms.GroupBox();
            this.chkImplementDeconstruct = new System.Windows.Forms.CheckBox();
            this.chkOperatorVsint = new System.Windows.Forms.CheckBox();
            this.chkOperatorVsdouble = new System.Windows.Forms.CheckBox();
            this.chkOperatorsVsSelf = new System.Windows.Forms.CheckBox();
            this.chkImplementXmlReadAndSave = new System.Windows.Forms.CheckBox();
            this.chkComparisonImplementation = new System.Windows.Forms.CheckBox();
            this.chkListWrapper = new System.Windows.Forms.CheckBox();
            this.chkEquality = new System.Windows.Forms.CheckBox();
            this.tcWrapperType = new Utte.Code.TypeChoser();
            this.visClassVisibility = new Utte.Code.Controls.VisibilityDropDown();
            this.chkEnsureToString = new System.Windows.Forms.CheckBox();
            this.grpGeneral.SuspendLayout();
            this.grpMembers.SuspendLayout();
            this.grpClasses.SuspendLayout();
            this.grpInterfaces.SuspendLayout();
            this.grpImplementations.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.lblClassType);
            this.grpGeneral.Controls.Add(this.edClassType);
            this.grpGeneral.Controls.Add(this.cmdAddAttributes);
            this.grpGeneral.Controls.Add(this.bFormComponent);
            this.grpGeneral.Controls.Add(this.lblVisibility);
            this.grpGeneral.Controls.Add(this.visClassVisibility);
            this.grpGeneral.Controls.Add(this.txtDescription);
            this.grpGeneral.Controls.Add(this.lblDescription);
            this.grpGeneral.Controls.Add(this.lblParentClass);
            this.grpGeneral.Controls.Add(this.txtParentClass);
            this.grpGeneral.Controls.Add(this.lblName);
            this.grpGeneral.Controls.Add(this.txtName);
            this.grpGeneral.Location = new System.Drawing.Point(13, 17);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(629, 81);
            this.grpGeneral.TabIndex = 2;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General information";
            // 
            // lblClassType
            // 
            this.lblClassType.AutoSize = true;
            this.lblClassType.Location = new System.Drawing.Point(382, 60);
            this.lblClassType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClassType.Name = "lblClassType";
            this.lblClassType.Size = new System.Drawing.Size(31, 13);
            this.lblClassType.TabIndex = 12;
            this.lblClassType.Text = "Type";
            // 
            // edClassType
            // 
            this.edClassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edClassType.FormattingEnabled = true;
            this.edClassType.IncludeXmlSave = true;
            this.edClassType.Location = new System.Drawing.Point(451, 58);
            this.edClassType.Margin = new System.Windows.Forms.Padding(2);
            this.edClassType.Name = "edClassType";
            this.edClassType.Size = new System.Drawing.Size(165, 21);
            this.edClassType.TabIndex = 11;
            // 
            // cmdAddAttributes
            // 
            this.cmdAddAttributes.Location = new System.Drawing.Point(507, 39);
            this.cmdAddAttributes.Name = "cmdAddAttributes";
            this.cmdAddAttributes.Size = new System.Drawing.Size(110, 17);
            this.cmdAddAttributes.TabIndex = 10;
            this.cmdAddAttributes.Text = "Add Attributes";
            this.cmdAddAttributes.UseVisualStyleBackColor = true;
            this.cmdAddAttributes.Click += new System.EventHandler(this.cmdAddAttributes_Click);
            // 
            // bFormComponent
            // 
            this.bFormComponent.AutoSize = true;
            this.bFormComponent.IncludeXmlSave = false;
            this.bFormComponent.Location = new System.Drawing.Point(222, 58);
            this.bFormComponent.Name = "bFormComponent";
            this.bFormComponent.Size = new System.Drawing.Size(151, 17);
            this.bFormComponent.TabIndex = 9;
            this.bFormComponent.Text = "Windows component/form";
            this.bFormComponent.UseVisualStyleBackColor = true;
            this.bFormComponent.Value = false;
            // 
            // lblVisibility
            // 
            this.lblVisibility.AutoSize = true;
            this.lblVisibility.Location = new System.Drawing.Point(308, 43);
            this.lblVisibility.Name = "lblVisibility";
            this.lblVisibility.Size = new System.Drawing.Size(43, 13);
            this.lblVisibility.TabIndex = 8;
            this.lblVisibility.Text = "Visibility";
            // 
            // txtDescription
            // 
            this.txtDescription.AllowEmpty = false;
            this.txtDescription.IncludeXmlSave = true;
            this.txtDescription.Location = new System.Drawing.Point(334, 13);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(283, 20);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(233, 16);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";
            // 
            // lblParentClass
            // 
            this.lblParentClass.AutoSize = true;
            this.lblParentClass.Location = new System.Drawing.Point(13, 46);
            this.lblParentClass.Name = "lblParentClass";
            this.lblParentClass.Size = new System.Drawing.Size(65, 13);
            this.lblParentClass.TabIndex = 3;
            this.lblParentClass.Text = "Parent class";
            // 
            // txtParentClass
            // 
            this.txtParentClass.AllowEmpty = false;
            this.txtParentClass.IncludeXmlSave = true;
            this.txtParentClass.Location = new System.Drawing.Point(87, 46);
            this.txtParentClass.Name = "txtParentClass";
            this.txtParentClass.Size = new System.Drawing.Size(126, 20);
            this.txtParentClass.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.AllowEmpty = false;
            this.txtName.IncludeXmlSave = true;
            this.txtName.Location = new System.Drawing.Point(87, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(126, 20);
            this.txtName.TabIndex = 0;
            // 
            // grpMembers
            // 
            this.grpMembers.Controls.Add(this.cmdMemberDown);
            this.grpMembers.Controls.Add(this.cmdMemberUp);
            this.grpMembers.Controls.Add(this.cmdDeleteMember);
            this.grpMembers.Controls.Add(this.cmdAddMember);
            this.grpMembers.Controls.Add(this.lstMembers);
            this.grpMembers.Location = new System.Drawing.Point(15, 104);
            this.grpMembers.Name = "grpMembers";
            this.grpMembers.Size = new System.Drawing.Size(382, 196);
            this.grpMembers.TabIndex = 3;
            this.grpMembers.TabStop = false;
            this.grpMembers.Text = "Members";
            // 
            // cmdMemberDown
            // 
            this.cmdMemberDown.Location = new System.Drawing.Point(316, 101);
            this.cmdMemberDown.Name = "cmdMemberDown";
            this.cmdMemberDown.Size = new System.Drawing.Size(51, 27);
            this.cmdMemberDown.TabIndex = 4;
            this.cmdMemberDown.Text = "Down";
            this.cmdMemberDown.UseVisualStyleBackColor = true;
            this.cmdMemberDown.Click += new System.EventHandler(this.cmdMemberDown_Click);
            // 
            // cmdMemberUp
            // 
            this.cmdMemberUp.Location = new System.Drawing.Point(316, 25);
            this.cmdMemberUp.Name = "cmdMemberUp";
            this.cmdMemberUp.Size = new System.Drawing.Size(51, 27);
            this.cmdMemberUp.TabIndex = 3;
            this.cmdMemberUp.Text = "Up";
            this.cmdMemberUp.UseVisualStyleBackColor = true;
            this.cmdMemberUp.Click += new System.EventHandler(this.cmdMemberUp_Click);
            // 
            // cmdDeleteMember
            // 
            this.cmdDeleteMember.Location = new System.Drawing.Point(126, 163);
            this.cmdDeleteMember.Name = "cmdDeleteMember";
            this.cmdDeleteMember.Size = new System.Drawing.Size(101, 27);
            this.cmdDeleteMember.TabIndex = 2;
            this.cmdDeleteMember.Text = "Delete";
            this.cmdDeleteMember.UseVisualStyleBackColor = true;
            this.cmdDeleteMember.Click += new System.EventHandler(this.cmdDeleteMember_Click);
            // 
            // cmdAddMember
            // 
            this.cmdAddMember.Location = new System.Drawing.Point(14, 163);
            this.cmdAddMember.Name = "cmdAddMember";
            this.cmdAddMember.Size = new System.Drawing.Size(96, 27);
            this.cmdAddMember.TabIndex = 1;
            this.cmdAddMember.Text = "Add";
            this.cmdAddMember.UseVisualStyleBackColor = true;
            this.cmdAddMember.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lstMembers
            // 
            this.lstMembers.FormattingEnabled = true;
            this.lstMembers.Location = new System.Drawing.Point(14, 20);
            this.lstMembers.Name = "lstMembers";
            this.lstMembers.Size = new System.Drawing.Size(296, 134);
            this.lstMembers.TabIndex = 0;
            // 
            // grpClasses
            // 
            this.grpClasses.Controls.Add(this.cmdDeleteClass);
            this.grpClasses.Controls.Add(this.cmdAddClass);
            this.grpClasses.Controls.Add(this.lstClasses);
            this.grpClasses.Location = new System.Drawing.Point(17, 306);
            this.grpClasses.Name = "grpClasses";
            this.grpClasses.Size = new System.Drawing.Size(380, 218);
            this.grpClasses.TabIndex = 4;
            this.grpClasses.TabStop = false;
            this.grpClasses.Text = "Classes";
            // 
            // cmdDeleteClass
            // 
            this.cmdDeleteClass.Location = new System.Drawing.Point(277, 167);
            this.cmdDeleteClass.Name = "cmdDeleteClass";
            this.cmdDeleteClass.Size = new System.Drawing.Size(88, 41);
            this.cmdDeleteClass.TabIndex = 2;
            this.cmdDeleteClass.Text = "Delete";
            this.cmdDeleteClass.UseVisualStyleBackColor = true;
            this.cmdDeleteClass.Click += new System.EventHandler(this.cmdDeleteClass_Click);
            // 
            // cmdAddClass
            // 
            this.cmdAddClass.Location = new System.Drawing.Point(277, 19);
            this.cmdAddClass.Name = "cmdAddClass";
            this.cmdAddClass.Size = new System.Drawing.Size(88, 42);
            this.cmdAddClass.TabIndex = 1;
            this.cmdAddClass.Text = "Add";
            this.cmdAddClass.UseVisualStyleBackColor = true;
            this.cmdAddClass.Click += new System.EventHandler(this.cmdAddClass_Click);
            // 
            // lstClasses
            // 
            this.lstClasses.FormattingEnabled = true;
            this.lstClasses.Location = new System.Drawing.Point(12, 19);
            this.lstClasses.Name = "lstClasses";
            this.lstClasses.Size = new System.Drawing.Size(259, 186);
            this.lstClasses.TabIndex = 0;
            // 
            // grpInterfaces
            // 
            this.grpInterfaces.Controls.Add(this.lstImplementedInterfaces);
            this.grpInterfaces.Controls.Add(this.lblImplementedIterfaces2);
            this.grpInterfaces.Controls.Add(this.lblImplementedInterfaces1);
            this.grpInterfaces.Controls.Add(this.cmdAddInterface);
            this.grpInterfaces.Controls.Add(this.txtInterface);
            this.grpInterfaces.Controls.Add(this.lstInterfaces);
            this.grpInterfaces.Location = new System.Drawing.Point(408, 104);
            this.grpInterfaces.Name = "grpInterfaces";
            this.grpInterfaces.Size = new System.Drawing.Size(234, 190);
            this.grpInterfaces.TabIndex = 5;
            this.grpInterfaces.TabStop = false;
            this.grpInterfaces.Text = "Interfaces";
            // 
            // lstImplementedInterfaces
            // 
            this.lstImplementedInterfaces.FormattingEnabled = true;
            this.lstImplementedInterfaces.Location = new System.Drawing.Point(121, 52);
            this.lstImplementedInterfaces.Name = "lstImplementedInterfaces";
            this.lstImplementedInterfaces.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstImplementedInterfaces.Size = new System.Drawing.Size(103, 121);
            this.lstImplementedInterfaces.TabIndex = 5;
            // 
            // lblImplementedIterfaces2
            // 
            this.lblImplementedIterfaces2.AutoSize = true;
            this.lblImplementedIterfaces2.Location = new System.Drawing.Point(126, 32);
            this.lblImplementedIterfaces2.Name = "lblImplementedIterfaces2";
            this.lblImplementedIterfaces2.Size = new System.Drawing.Size(53, 13);
            this.lblImplementedIterfaces2.TabIndex = 4;
            this.lblImplementedIterfaces2.Text = "interfaces";
            // 
            // lblImplementedInterfaces1
            // 
            this.lblImplementedInterfaces1.AutoSize = true;
            this.lblImplementedInterfaces1.Location = new System.Drawing.Point(126, 16);
            this.lblImplementedInterfaces1.Name = "lblImplementedInterfaces1";
            this.lblImplementedInterfaces1.Size = new System.Drawing.Size(67, 13);
            this.lblImplementedInterfaces1.TabIndex = 3;
            this.lblImplementedInterfaces1.Text = "Implemented";
            // 
            // cmdAddInterface
            // 
            this.cmdAddInterface.Location = new System.Drawing.Point(7, 45);
            this.cmdAddInterface.Name = "cmdAddInterface";
            this.cmdAddInterface.Size = new System.Drawing.Size(106, 23);
            this.cmdAddInterface.TabIndex = 2;
            this.cmdAddInterface.Text = "Add";
            this.cmdAddInterface.UseVisualStyleBackColor = true;
            this.cmdAddInterface.Click += new System.EventHandler(this.cmdAddInterface_Click);
            // 
            // txtInterface
            // 
            this.txtInterface.AllowEmpty = false;
            this.txtInterface.IncludeXmlSave = true;
            this.txtInterface.Location = new System.Drawing.Point(7, 19);
            this.txtInterface.Name = "txtInterface";
            this.txtInterface.Size = new System.Drawing.Size(107, 20);
            this.txtInterface.TabIndex = 1;
            // 
            // lstInterfaces
            // 
            this.lstInterfaces.FormattingEnabled = true;
            this.lstInterfaces.Location = new System.Drawing.Point(7, 68);
            this.lstInterfaces.Name = "lstInterfaces";
            this.lstInterfaces.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstInterfaces.Size = new System.Drawing.Size(107, 108);
            this.lstInterfaces.TabIndex = 0;
            // 
            // grpImplementations
            // 
            this.grpImplementations.Controls.Add(this.chkEnsureToString);
            this.grpImplementations.Controls.Add(this.chkImplementDeconstruct);
            this.grpImplementations.Controls.Add(this.chkOperatorVsint);
            this.grpImplementations.Controls.Add(this.chkOperatorVsdouble);
            this.grpImplementations.Controls.Add(this.chkOperatorsVsSelf);
            this.grpImplementations.Controls.Add(this.tcWrapperType);
            this.grpImplementations.Controls.Add(this.chkImplementXmlReadAndSave);
            this.grpImplementations.Controls.Add(this.chkComparisonImplementation);
            this.grpImplementations.Controls.Add(this.chkListWrapper);
            this.grpImplementations.Controls.Add(this.chkEquality);
            this.grpImplementations.Location = new System.Drawing.Point(409, 300);
            this.grpImplementations.Name = "grpImplementations";
            this.grpImplementations.Size = new System.Drawing.Size(232, 224);
            this.grpImplementations.TabIndex = 6;
            this.grpImplementations.TabStop = false;
            this.grpImplementations.Text = "Implementations";
            // 
            // chkImplementDeconstruct
            // 
            this.chkImplementDeconstruct.AutoSize = true;
            this.chkImplementDeconstruct.Location = new System.Drawing.Point(12, 174);
            this.chkImplementDeconstruct.Name = "chkImplementDeconstruct";
            this.chkImplementDeconstruct.Size = new System.Drawing.Size(215, 17);
            this.chkImplementDeconstruct.TabIndex = 9;
            this.chkImplementDeconstruct.Text = "Implement deconstruct (min. 2 members)";
            this.chkImplementDeconstruct.UseVisualStyleBackColor = true;
            // 
            // chkOperatorVsint
            // 
            this.chkOperatorVsint.AutoSize = true;
            this.chkOperatorVsint.Location = new System.Drawing.Point(13, 106);
            this.chkOperatorVsint.Name = "chkOperatorVsint";
            this.chkOperatorVsint.Size = new System.Drawing.Size(95, 17);
            this.chkOperatorVsint.TabIndex = 8;
            this.chkOperatorVsint.Text = "Operator vs int";
            this.chkOperatorVsint.UseVisualStyleBackColor = true;
            // 
            // chkOperatorVsdouble
            // 
            this.chkOperatorVsdouble.AutoSize = true;
            this.chkOperatorVsdouble.Location = new System.Drawing.Point(12, 86);
            this.chkOperatorVsdouble.Name = "chkOperatorVsdouble";
            this.chkOperatorVsdouble.Size = new System.Drawing.Size(116, 17);
            this.chkOperatorVsdouble.TabIndex = 7;
            this.chkOperatorVsdouble.Text = "Operator vs double";
            this.chkOperatorVsdouble.UseVisualStyleBackColor = true;
            // 
            // chkOperatorsVsSelf
            // 
            this.chkOperatorsVsSelf.AutoSize = true;
            this.chkOperatorsVsSelf.Location = new System.Drawing.Point(12, 63);
            this.chkOperatorsVsSelf.Name = "chkOperatorsVsSelf";
            this.chkOperatorsVsSelf.Size = new System.Drawing.Size(140, 17);
            this.chkOperatorsVsSelf.TabIndex = 6;
            this.chkOperatorsVsSelf.Text = "Operator implementation";
            this.chkOperatorsVsSelf.UseVisualStyleBackColor = true;
            // 
            // chkImplementXmlReadAndSave
            // 
            this.chkImplementXmlReadAndSave.AutoSize = true;
            this.chkImplementXmlReadAndSave.Location = new System.Drawing.Point(12, 151);
            this.chkImplementXmlReadAndSave.Name = "chkImplementXmlReadAndSave";
            this.chkImplementXmlReadAndSave.Size = new System.Drawing.Size(163, 17);
            this.chkImplementXmlReadAndSave.TabIndex = 4;
            this.chkImplementXmlReadAndSave.Text = "Implement xml read and save";
            this.chkImplementXmlReadAndSave.UseVisualStyleBackColor = true;
            // 
            // chkComparisonImplementation
            // 
            this.chkComparisonImplementation.AutoSize = true;
            this.chkComparisonImplementation.Location = new System.Drawing.Point(12, 128);
            this.chkComparisonImplementation.Name = "chkComparisonImplementation";
            this.chkComparisonImplementation.Size = new System.Drawing.Size(159, 17);
            this.chkComparisonImplementation.TabIndex = 3;
            this.chkComparisonImplementation.Text = "Comparison implementations";
            this.chkComparisonImplementation.UseVisualStyleBackColor = true;
            // 
            // chkListWrapper
            // 
            this.chkListWrapper.AutoSize = true;
            this.chkListWrapper.Location = new System.Drawing.Point(12, 40);
            this.chkListWrapper.Name = "chkListWrapper";
            this.chkListWrapper.Size = new System.Drawing.Size(121, 17);
            this.chkListWrapper.TabIndex = 1;
            this.chkListWrapper.Text = "List<T> wrapper, T=";
            this.chkListWrapper.UseVisualStyleBackColor = true;
            // 
            // chkEquality
            // 
            this.chkEquality.AutoSize = true;
            this.chkEquality.Location = new System.Drawing.Point(12, 19);
            this.chkEquality.Name = "chkEquality";
            this.chkEquality.Size = new System.Drawing.Size(141, 17);
            this.chkEquality.TabIndex = 0;
            this.chkEquality.Text = "Equality implementations";
            this.chkEquality.UseVisualStyleBackColor = true;
            // 
            // tcWrapperType
            // 
            this.tcWrapperType.FormattingEnabled = true;
            this.tcWrapperType.Location = new System.Drawing.Point(128, 38);
            this.tcWrapperType.Name = "tcWrapperType";
            this.tcWrapperType.Size = new System.Drawing.Size(98, 21);
            this.tcWrapperType.TabIndex = 5;
            // 
            // visClassVisibility
            // 
            this.visClassVisibility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.visClassVisibility.FormattingEnabled = true;
            this.visClassVisibility.Items.AddRange(new object[] {
            "public",
            "protected",
            "private"});
            this.visClassVisibility.Location = new System.Drawing.Point(367, 38);
            this.visClassVisibility.Name = "visClassVisibility";
            this.visClassVisibility.Size = new System.Drawing.Size(134, 21);
            this.visClassVisibility.TabIndex = 7;
            // 
            // chkEnsureToString
            // 
            this.chkEnsureToString.AutoSize = true;
            this.chkEnsureToString.Location = new System.Drawing.Point(12, 197);
            this.chkEnsureToString.Name = "chkEnsureToString";
            this.chkEnsureToString.Size = new System.Drawing.Size(155, 17);
            this.chkEnsureToString.TabIndex = 10;
            this.chkEnsureToString.Text = "Ensure ToString overridden";
            this.chkEnsureToString.UseVisualStyleBackColor = true;
            // 
            // ClassProducerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpImplementations);
            this.Controls.Add(this.grpInterfaces);
            this.Controls.Add(this.grpClasses);
            this.Controls.Add(this.grpMembers);
            this.Controls.Add(this.grpGeneral);
            this.Name = "ClassProducerControl";
            this.Size = new System.Drawing.Size(673, 527);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpMembers.ResumeLayout(false);
            this.grpClasses.ResumeLayout(false);
            this.grpInterfaces.ResumeLayout(false);
            this.grpInterfaces.PerformLayout();
            this.grpImplementations.ResumeLayout(false);
            this.grpImplementations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblVisibility;
        private VisibilityDropDown visClassVisibility;
        private Utte.Controls.Input.StringBoxBase txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblParentClass;
        private Utte.Controls.Input.StringBoxBase txtParentClass;
        private System.Windows.Forms.Label lblName;
        private Utte.Controls.Input.StringBoxBase txtName;
        private System.Windows.Forms.GroupBox grpMembers;
        private System.Windows.Forms.Button cmdAddMember;
        private System.Windows.Forms.ListBox lstMembers;
        private System.Windows.Forms.GroupBox grpClasses;
        private System.Windows.Forms.Button cmdAddClass;
        private System.Windows.Forms.ListBox lstClasses;
        private System.Windows.Forms.GroupBox grpInterfaces;
        private System.Windows.Forms.Button cmdAddInterface;
        private Utte.Controls.Input.StringBoxBase txtInterface;
        private System.Windows.Forms.ListBox lstInterfaces;
        private System.Windows.Forms.Label lblImplementedInterfaces1;
        private System.Windows.Forms.ListBox lstImplementedInterfaces;
        private System.Windows.Forms.Label lblImplementedIterfaces2;
        private System.Windows.Forms.GroupBox grpImplementations;
        private System.Windows.Forms.CheckBox chkEquality;
        private System.Windows.Forms.CheckBox chkListWrapper;
        private System.Windows.Forms.CheckBox chkComparisonImplementation;
        private Utte.Controls.Input.boolCheckbox bFormComponent;
        private System.Windows.Forms.Button cmdAddAttributes;
        private System.Windows.Forms.Button cmdDeleteMember;
        private System.Windows.Forms.Button cmdDeleteClass;
        private System.Windows.Forms.Button cmdMemberDown;
        private System.Windows.Forms.Button cmdMemberUp;
        private System.Windows.Forms.CheckBox chkImplementXmlReadAndSave;
        private TypeChoser tcWrapperType;
        private System.Windows.Forms.CheckBox chkOperatorVsint;
        private System.Windows.Forms.CheckBox chkOperatorVsdouble;
        private System.Windows.Forms.CheckBox chkOperatorsVsSelf;
        private System.Windows.Forms.Label lblClassType;
        private Utte.Controls.Input.enumDropdown edClassType;
        private System.Windows.Forms.CheckBox chkImplementDeconstruct;
        private System.Windows.Forms.CheckBox chkEnsureToString;
    }
}
