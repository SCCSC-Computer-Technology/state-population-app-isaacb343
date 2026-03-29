namespace I_Billow_Lab_3
{
    partial class Form1
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
            this.cboStates = new System.Windows.Forms.ComboBox();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnOpenSearchForm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEditState = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboStates
            // 
            this.cboStates.FormattingEnabled = true;
            this.cboStates.Location = new System.Drawing.Point(214, 149);
            this.cboStates.Name = "cboStates";
            this.cboStates.Size = new System.Drawing.Size(358, 28);
            this.cboStates.TabIndex = 0;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.Location = new System.Drawing.Point(578, 135);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(176, 50);
            this.btnViewDetails.TabIndex = 1;
            this.btnViewDetails.Text = "View State Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnOpenSearchForm
            // 
            this.btnOpenSearchForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSearchForm.Location = new System.Drawing.Point(214, 191);
            this.btnOpenSearchForm.Name = "btnOpenSearchForm";
            this.btnOpenSearchForm.Size = new System.Drawing.Size(176, 50);
            this.btnOpenSearchForm.TabIndex = 2;
            this.btnOpenSearchForm.Text = "Search/Sort/Filter";
            this.btnOpenSearchForm.UseVisualStyleBackColor = true;
            this.btnOpenSearchForm.Click += new System.EventHandler(this.btnOpenSearchForm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(578, 191);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(176, 50);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Quit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEditState
            // 
            this.btnEditState.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditState.Location = new System.Drawing.Point(396, 191);
            this.btnEditState.Name = "btnEditState";
            this.btnEditState.Size = new System.Drawing.Size(176, 50);
            this.btnEditState.TabIndex = 4;
            this.btnEditState.Text = "Edit State Info";
            this.btnEditState.UseVisualStyleBackColor = true;
            this.btnEditState.Click += new System.EventHandler(this.btnEditState_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 376);
            this.Controls.Add(this.btnEditState);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpenSearchForm);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.cboStates);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboStates;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnOpenSearchForm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEditState;
    }
}

