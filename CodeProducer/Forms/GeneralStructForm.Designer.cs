namespace Utte.Code
{
    partial class GeneralStructForm
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
            this.chkStructEqualityComparison = new System.Windows.Forms.CheckBox();
            this.chkStructConstructor = new System.Windows.Forms.CheckBox();
            this.lstStructMembers = new System.Windows.Forms.ListBox();
            this.cmdMember = new System.Windows.Forms.Button();
            this.txtStructDescription = new System.Windows.Forms.TextBox();
            this.lblStructDescription = new System.Windows.Forms.Label();
            this.lblStructVisibility = new System.Windows.Forms.Label();
            this.lblStructName = new System.Windows.Forms.Label();
            this.sStructName = new Utte.Controls.Input.StringBoxBase();
            this.visStructVisibility = new Utte.Code.Controls.VisibilityDropDown();
            this.chkArithmeticOperators = new System.Windows.Forms.CheckBox();
            this.chkArithmeticOperatorsVsDouble = new System.Windows.Forms.CheckBox();
            this.chkArithmeticOperatorsVsInt = new System.Windows.Forms.CheckBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.chkIncludeEmpty = new System.Windows.Forms.CheckBox();
            this.chkImplementDeconstruct = new System.Windows.Forms.CheckBox();
            this.chkStructComparisonImplementation = new System.Windows.Forms.CheckBox();
            this.lstImplementedInterfaces = new System.Windows.Forms.ListBox();
            this.lblInterfaces = new System.Windows.Forms.Label();
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
            // chkStructEqualityComparison
            // 
            this.chkStructEqualityComparison.AutoSize = true;
            this.chkStructEqualityComparison.Location = new System.Drawing.Point(34, 398);
            this.chkStructEqualityComparison.Name = "chkStructEqualityComparison";
            this.chkStructEqualityComparison.Size = new System.Drawing.Size(120, 17);
            this.chkStructEqualityComparison.TabIndex = 9;
            this.chkStructEqualityComparison.Text = "Equality comparison";
            this.chkStructEqualityComparison.UseVisualStyleBackColor = true;
            // 
            // chkStructConstructor
            // 
            this.chkStructConstructor.AutoSize = true;
            this.chkStructConstructor.Location = new System.Drawing.Point(34, 375);
            this.chkStructConstructor.Name = "chkStructConstructor";
            this.chkStructConstructor.Size = new System.Drawing.Size(136, 17);
            this.chkStructConstructor.TabIndex = 8;
            this.chkStructConstructor.Text = "Constructor initialization";
            this.chkStructConstructor.UseVisualStyleBackColor = true;
            // 
            // lstStructMembers
            // 
            this.lstStructMembers.FormattingEnabled = true;
            this.lstStructMembers.Location = new System.Drawing.Point(34, 183);
            this.lstStructMembers.Name = "lstStructMembers";
            this.lstStructMembers.Size = new System.Drawing.Size(326, 186);
            this.lstStructMembers.TabIndex = 7;
            // 
            // cmdMember
            // 
            this.cmdMember.Location = new System.Drawing.Point(34, 133);
            this.cmdMember.Name = "cmdMember";
            this.cmdMember.Size = new System.Drawing.Size(147, 24);
            this.cmdMember.TabIndex = 6;
            this.cmdMember.Text = "Add member";
            this.cmdMember.UseVisualStyleBackColor = true;
            this.cmdMember.Click += new System.EventHandler(this.cmdMember_Click);
            // 
            // txtStructDescription
            // 
            this.txtStructDescription.Location = new System.Drawing.Point(105, 88);
            this.txtStructDescription.Name = "txtStructDescription";
            this.txtStructDescription.Size = new System.Drawing.Size(255, 20);
            this.txtStructDescription.TabIndex = 5;
            // 
            // lblStructDescription
            // 
            this.lblStructDescription.AutoSize = true;
            this.lblStructDescription.Location = new System.Drawing.Point(31, 91);
            this.lblStructDescription.Name = "lblStructDescription";
            this.lblStructDescription.Size = new System.Drawing.Size(60, 13);
            this.lblStructDescription.TabIndex = 4;
            this.lblStructDescription.Text = "Description";
            // 
            // lblStructVisibility
            // 
            this.lblStructVisibility.AutoSize = true;
            this.lblStructVisibility.Location = new System.Drawing.Point(31, 57);
            this.lblStructVisibility.Name = "lblStructVisibility";
            this.lblStructVisibility.Size = new System.Drawing.Size(43, 13);
            this.lblStructVisibility.TabIndex = 3;
            this.lblStructVisibility.Text = "Visibility";
            // 
            // lblStructName
            // 
            this.lblStructName.AutoSize = true;
            this.lblStructName.Location = new System.Drawing.Point(31, 24);
            this.lblStructName.Name = "lblStructName";
            this.lblStructName.Size = new System.Drawing.Size(35, 13);
            this.lblStructName.TabIndex = 1;
            this.lblStructName.Text = "Name";
            // 
            // sStructName
            // 
            this.sStructName.AllowEmpty = false;
            this.sStructName.IncludeXmlSave = true;
            this.sStructName.Location = new System.Drawing.Point(105, 21);
            this.sStructName.Name = "sStructName";
            this.sStructName.Size = new System.Drawing.Size(255, 20);
            this.sStructName.TabIndex = 0;
            // 
            // visStructVisibility
            // 
            this.visStructVisibility.FormattingEnabled = true;
            this.visStructVisibility.Location = new System.Drawing.Point(105, 54);
            this.visStructVisibility.Name = "visStructVisibility";
            this.visStructVisibility.Size = new System.Drawing.Size(255, 21);
            this.visStructVisibility.TabIndex = 2;
            // 
            // chkArithmeticOperators
            // 
            this.chkArithmeticOperators.AutoSize = true;
            this.chkArithmeticOperators.Location = new System.Drawing.Point(33, 467);
            this.chkArithmeticOperators.Name = "chkArithmeticOperators";
            this.chkArithmeticOperators.Size = new System.Drawing.Size(147, 17);
            this.chkArithmeticOperators.TabIndex = 10;
            this.chkArithmeticOperators.Text = "Arithmetic operator vs self";
            this.chkArithmeticOperators.UseVisualStyleBackColor = true;
            // 
            // chkArithmeticOperatorsVsDouble
            // 
            this.chkArithmeticOperatorsVsDouble.AutoSize = true;
            this.chkArithmeticOperatorsVsDouble.Location = new System.Drawing.Point(33, 490);
            this.chkArithmeticOperatorsVsDouble.Name = "chkArithmeticOperatorsVsDouble";
            this.chkArithmeticOperatorsVsDouble.Size = new System.Drawing.Size(168, 17);
            this.chkArithmeticOperatorsVsDouble.TabIndex = 11;
            this.chkArithmeticOperatorsVsDouble.Text = "Arithmetic operators vs double";
            this.chkArithmeticOperatorsVsDouble.UseVisualStyleBackColor = true;
            // 
            // chkArithmeticOperatorsVsInt
            // 
            this.chkArithmeticOperatorsVsInt.AutoSize = true;
            this.chkArithmeticOperatorsVsInt.Location = new System.Drawing.Point(33, 513);
            this.chkArithmeticOperatorsVsInt.Name = "chkArithmeticOperatorsVsInt";
            this.chkArithmeticOperatorsVsInt.Size = new System.Drawing.Size(147, 17);
            this.chkArithmeticOperatorsVsInt.TabIndex = 12;
            this.chkArithmeticOperatorsVsInt.Text = "Arithmetic operators vs int";
            this.chkArithmeticOperatorsVsInt.UseVisualStyleBackColor = true;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(212, 133);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(148, 24);
            this.cmdDelete.TabIndex = 13;
            this.cmdDelete.Text = "Delete member";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // chkIncludeEmpty
            // 
            this.chkIncludeEmpty.AutoSize = true;
            this.chkIncludeEmpty.Location = new System.Drawing.Point(34, 445);
            this.chkIncludeEmpty.Margin = new System.Windows.Forms.Padding(2);
            this.chkIncludeEmpty.Name = "chkIncludeEmpty";
            this.chkIncludeEmpty.Size = new System.Drawing.Size(136, 17);
            this.chkIncludeEmpty.TabIndex = 14;
            this.chkIncludeEmpty.Text = "Empty instance support";
            this.chkIncludeEmpty.UseVisualStyleBackColor = true;
            // 
            // chkImplementDeconstruct
            // 
            this.chkImplementDeconstruct.AutoSize = true;
            this.chkImplementDeconstruct.Location = new System.Drawing.Point(33, 536);
            this.chkImplementDeconstruct.Name = "chkImplementDeconstruct";
            this.chkImplementDeconstruct.Size = new System.Drawing.Size(217, 17);
            this.chkImplementDeconstruct.TabIndex = 15;
            this.chkImplementDeconstruct.Text = "Implement Deconstruct (min. 2 members)";
            this.chkImplementDeconstruct.UseVisualStyleBackColor = true;
            // 
            // chkStructComparisonImplementation
            // 
            this.chkStructComparisonImplementation.AutoSize = true;
            this.chkStructComparisonImplementation.Location = new System.Drawing.Point(34, 421);
            this.chkStructComparisonImplementation.Name = "chkStructComparisonImplementation";
            this.chkStructComparisonImplementation.Size = new System.Drawing.Size(154, 17);
            this.chkStructComparisonImplementation.TabIndex = 16;
            this.chkStructComparisonImplementation.Text = "Comparison implementation";
            this.chkStructComparisonImplementation.UseVisualStyleBackColor = true;
            // 
            // lstImplementedInterfaces
            // 
            this.lstImplementedInterfaces.FormattingEnabled = true;
            this.lstImplementedInterfaces.Location = new System.Drawing.Point(423, 183);
            this.lstImplementedInterfaces.Name = "lstImplementedInterfaces";
            this.lstImplementedInterfaces.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstImplementedInterfaces.Size = new System.Drawing.Size(196, 186);
            this.lstImplementedInterfaces.TabIndex = 17;
            // 
            // lblInterfaces
            // 
            this.lblInterfaces.AutoSize = true;
            this.lblInterfaces.Location = new System.Drawing.Point(420, 161);
            this.lblInterfaces.Name = "lblInterfaces";
            this.lblInterfaces.Size = new System.Drawing.Size(54, 13);
            this.lblInterfaces.TabIndex = 18;
            this.lblInterfaces.Text = "Interfaces";
            // 
            // GeneralStructForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 555);
            this.Controls.Add(this.lblInterfaces);
            this.Controls.Add(this.lstImplementedInterfaces);
            this.Controls.Add(this.chkStructComparisonImplementation);
            this.Controls.Add(this.chkImplementDeconstruct);
            this.Controls.Add(this.chkIncludeEmpty);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.chkArithmeticOperatorsVsInt);
            this.Controls.Add(this.chkArithmeticOperatorsVsDouble);
            this.Controls.Add(this.chkArithmeticOperators);
            this.Controls.Add(this.chkStructEqualityComparison);
            this.Controls.Add(this.lblStructName);
            this.Controls.Add(this.chkStructConstructor);
            this.Controls.Add(this.sStructName);
            this.Controls.Add(this.lstStructMembers);
            this.Controls.Add(this.lblStructVisibility);
            this.Controls.Add(this.cmdMember);
            this.Controls.Add(this.visStructVisibility);
            this.Controls.Add(this.txtStructDescription);
            this.Controls.Add(this.lblStructDescription);
            this.Name = "GeneralStructForm";
            this.Text = "General struct producer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdProduce;
        private System.Windows.Forms.Label lblStructName;
        private Utte.Controls.Input.StringBoxBase sStructName;
        private System.Windows.Forms.ListBox lstStructMembers;
        private System.Windows.Forms.Button cmdMember;
        private System.Windows.Forms.TextBox txtStructDescription;
        private System.Windows.Forms.Label lblStructDescription;
        private System.Windows.Forms.Label lblStructVisibility;
        private Utte.Code.Controls.VisibilityDropDown visStructVisibility;
        private System.Windows.Forms.CheckBox chkStructEqualityComparison;
        private System.Windows.Forms.CheckBox chkStructConstructor;
        private System.Windows.Forms.CheckBox chkArithmeticOperators;
        private System.Windows.Forms.CheckBox chkArithmeticOperatorsVsDouble;
        private System.Windows.Forms.CheckBox chkArithmeticOperatorsVsInt;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.CheckBox chkIncludeEmpty;
        private System.Windows.Forms.CheckBox chkImplementDeconstruct;
        private System.Windows.Forms.CheckBox chkStructComparisonImplementation;
        private System.Windows.Forms.ListBox lstImplementedInterfaces;
        private System.Windows.Forms.Label lblInterfaces;
    }
}

