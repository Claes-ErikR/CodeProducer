namespace Utte.Code
{
    partial class PhysicsEquationForm
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
            this.cmdAddConstant = new System.Windows.Forms.Button();
            this.lstConstantMembers = new System.Windows.Forms.ListBox();
            this.txtConstantName = new Utte.Controls.Input.StringBoxBase();
            this.txtConstantType = new Utte.Controls.Input.StringBoxBase();
            this.lblConstantName = new System.Windows.Forms.Label();
            this.lblConstantType = new System.Windows.Forms.Label();
            this.cmdAddVariable = new System.Windows.Forms.Button();
            this.txtVariable = new Utte.Controls.Input.StringBoxBase();
            this.lstVariables = new System.Windows.Forms.ListBox();
            this.lblEquationName = new System.Windows.Forms.Label();
            this.txtEquationName = new Utte.Controls.Input.StringBoxBase();
            this.cmdProduce = new System.Windows.Forms.Button();
            this.grpVariables = new System.Windows.Forms.GroupBox();
            this.grpConstants = new System.Windows.Forms.GroupBox();
            this.grpVariables.SuspendLayout();
            this.grpConstants.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAddConstant
            // 
            this.cmdAddConstant.Location = new System.Drawing.Point(37, 97);
            this.cmdAddConstant.Name = "cmdAddConstant";
            this.cmdAddConstant.Size = new System.Drawing.Size(211, 28);
            this.cmdAddConstant.TabIndex = 5;
            this.cmdAddConstant.Text = "Add";
            this.cmdAddConstant.UseVisualStyleBackColor = true;
            this.cmdAddConstant.Click += new System.EventHandler(this.cmdAddConstant_Click);
            // 
            // lstConstantMembers
            // 
            this.lstConstantMembers.FormattingEnabled = true;
            this.lstConstantMembers.Location = new System.Drawing.Point(37, 151);
            this.lstConstantMembers.Name = "lstConstantMembers";
            this.lstConstantMembers.Size = new System.Drawing.Size(222, 121);
            this.lstConstantMembers.TabIndex = 4;
            // 
            // txtConstantName
            // 
            this.txtConstantName.AllowEmpty = false;
            this.txtConstantName.IncludeXmlSave = true;
            this.txtConstantName.Location = new System.Drawing.Point(162, 54);
            this.txtConstantName.Name = "txtConstantName";
            this.txtConstantName.Size = new System.Drawing.Size(103, 20);
            this.txtConstantName.TabIndex = 3;
            // 
            // txtConstantType
            // 
            this.txtConstantType.AllowEmpty = false;
            this.txtConstantType.IncludeXmlSave = true;
            this.txtConstantType.Location = new System.Drawing.Point(37, 54);
            this.txtConstantType.Name = "txtConstantType";
            this.txtConstantType.Size = new System.Drawing.Size(85, 20);
            this.txtConstantType.TabIndex = 2;
            // 
            // lblConstantName
            // 
            this.lblConstantName.AutoSize = true;
            this.lblConstantName.Location = new System.Drawing.Point(159, 38);
            this.lblConstantName.Name = "lblConstantName";
            this.lblConstantName.Size = new System.Drawing.Size(35, 13);
            this.lblConstantName.TabIndex = 1;
            this.lblConstantName.Text = "Name";
            // 
            // lblConstantType
            // 
            this.lblConstantType.AutoSize = true;
            this.lblConstantType.Location = new System.Drawing.Point(34, 38);
            this.lblConstantType.Name = "lblConstantType";
            this.lblConstantType.Size = new System.Drawing.Size(31, 13);
            this.lblConstantType.TabIndex = 0;
            this.lblConstantType.Text = "Type";
            // 
            // cmdAddVariable
            // 
            this.cmdAddVariable.Location = new System.Drawing.Point(26, 85);
            this.cmdAddVariable.Name = "cmdAddVariable";
            this.cmdAddVariable.Size = new System.Drawing.Size(213, 25);
            this.cmdAddVariable.TabIndex = 4;
            this.cmdAddVariable.Text = "Add";
            this.cmdAddVariable.UseVisualStyleBackColor = true;
            this.cmdAddVariable.Click += new System.EventHandler(this.cmdAddVariable_Click);
            // 
            // txtVariable
            // 
            this.txtVariable.AllowEmpty = false;
            this.txtVariable.IncludeXmlSave = true;
            this.txtVariable.Location = new System.Drawing.Point(26, 38);
            this.txtVariable.Name = "txtVariable";
            this.txtVariable.Size = new System.Drawing.Size(214, 20);
            this.txtVariable.TabIndex = 3;
            // 
            // lstVariables
            // 
            this.lstVariables.FormattingEnabled = true;
            this.lstVariables.Location = new System.Drawing.Point(26, 125);
            this.lstVariables.Name = "lstVariables";
            this.lstVariables.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstVariables.Size = new System.Drawing.Size(214, 147);
            this.lstVariables.TabIndex = 2;
            // 
            // lblEquationName
            // 
            this.lblEquationName.AutoSize = true;
            this.lblEquationName.Location = new System.Drawing.Point(35, 23);
            this.lblEquationName.Name = "lblEquationName";
            this.lblEquationName.Size = new System.Drawing.Size(78, 13);
            this.lblEquationName.TabIndex = 0;
            this.lblEquationName.Text = "Equation name";
            // 
            // txtEquationName
            // 
            this.txtEquationName.AllowEmpty = false;
            this.txtEquationName.IncludeXmlSave = true;
            this.txtEquationName.Location = new System.Drawing.Point(210, 23);
            this.txtEquationName.Name = "txtEquationName";
            this.txtEquationName.Size = new System.Drawing.Size(170, 20);
            this.txtEquationName.TabIndex = 1;
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
            // grpVariables
            // 
            this.grpVariables.Controls.Add(this.txtVariable);
            this.grpVariables.Controls.Add(this.cmdAddVariable);
            this.grpVariables.Controls.Add(this.lstVariables);
            this.grpVariables.Location = new System.Drawing.Point(12, 90);
            this.grpVariables.Name = "grpVariables";
            this.grpVariables.Size = new System.Drawing.Size(286, 304);
            this.grpVariables.TabIndex = 6;
            this.grpVariables.TabStop = false;
            this.grpVariables.Text = "Variables";
            // 
            // grpConstants
            // 
            this.grpConstants.Controls.Add(this.lblConstantType);
            this.grpConstants.Controls.Add(this.txtConstantType);
            this.grpConstants.Controls.Add(this.lstConstantMembers);
            this.grpConstants.Controls.Add(this.lblConstantName);
            this.grpConstants.Controls.Add(this.cmdAddConstant);
            this.grpConstants.Controls.Add(this.txtConstantName);
            this.grpConstants.Location = new System.Drawing.Point(333, 90);
            this.grpConstants.Name = "grpConstants";
            this.grpConstants.Size = new System.Drawing.Size(285, 304);
            this.grpConstants.TabIndex = 7;
            this.grpConstants.TabStop = false;
            this.grpConstants.Text = "Constants";
            // 
            // PhysicsEquationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 495);
            this.Controls.Add(this.grpConstants);
            this.Controls.Add(this.grpVariables);
            this.Controls.Add(this.lblEquationName);
            this.Controls.Add(this.txtEquationName);
            this.Name = "PhysicsEquationForm";
            this.Text = "Physics equation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grpVariables.ResumeLayout(false);
            this.grpVariables.PerformLayout();
            this.grpConstants.ResumeLayout(false);
            this.grpConstants.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAddConstant;
        private System.Windows.Forms.ListBox lstConstantMembers;
        private Utte.Controls.Input.StringBoxBase txtConstantName;
        private Utte.Controls.Input.StringBoxBase txtConstantType;
        private System.Windows.Forms.Label lblConstantName;
        private System.Windows.Forms.Label lblConstantType;
        private System.Windows.Forms.Button cmdAddVariable;
        private Utte.Controls.Input.StringBoxBase txtVariable;
        private System.Windows.Forms.ListBox lstVariables;
        private Utte.Controls.Input.StringBoxBase txtEquationName;
        private System.Windows.Forms.Label lblEquationName;
        private System.Windows.Forms.Button cmdProduce;
        private System.Windows.Forms.GroupBox grpVariables;
        private System.Windows.Forms.GroupBox grpConstants;


    }
}

