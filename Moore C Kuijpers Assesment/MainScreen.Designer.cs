
namespace Moore_C_Kuijpers_Assesment
{
    partial class MainScreen
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
            this.gbxFunctions = new System.Windows.Forms.GroupBox();
            this.btnRateOfchange = new System.Windows.Forms.Button();
            this.btnRMS = new System.Windows.Forms.Button();
            this.btnStandardDeviation = new System.Windows.Forms.Button();
            this.btnSortBy = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxOutput = new System.Windows.Forms.GroupBox();
            this.WaitingBar = new System.Windows.Forms.ProgressBar();
            this.dGridOutput = new System.Windows.Forms.DataGridView();
            this.gbxSelectFile = new System.Windows.Forms.GroupBox();
            this.btnLoadCSV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.oCSVFile = new System.Windows.Forms.OpenFileDialog();
            this.btnSaveToSQL = new System.Windows.Forms.Button();
            this.btnSaveToCSV = new System.Windows.Forms.Button();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.sCSVFile = new System.Windows.Forms.SaveFileDialog();
            this.gbxFunctions.SuspendLayout();
            this.gbxOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridOutput)).BeginInit();
            this.gbxSelectFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxFunctions
            // 
            this.gbxFunctions.Controls.Add(this.btnRateOfchange);
            this.gbxFunctions.Controls.Add(this.btnRMS);
            this.gbxFunctions.Controls.Add(this.btnStandardDeviation);
            this.gbxFunctions.Controls.Add(this.btnSortBy);
            this.gbxFunctions.Controls.Add(this.label6);
            this.gbxFunctions.Controls.Add(this.label5);
            this.gbxFunctions.Controls.Add(this.label4);
            this.gbxFunctions.Controls.Add(this.label3);
            this.gbxFunctions.Controls.Add(this.label2);
            this.gbxFunctions.Location = new System.Drawing.Point(324, 12);
            this.gbxFunctions.Name = "gbxFunctions";
            this.gbxFunctions.Size = new System.Drawing.Size(634, 245);
            this.gbxFunctions.TabIndex = 1;
            this.gbxFunctions.TabStop = false;
            this.gbxFunctions.Text = "Functions";
            // 
            // btnRateOfchange
            // 
            this.btnRateOfchange.Enabled = false;
            this.btnRateOfchange.Location = new System.Drawing.Point(6, 197);
            this.btnRateOfchange.Name = "btnRateOfchange";
            this.btnRateOfchange.Size = new System.Drawing.Size(121, 23);
            this.btnRateOfchange.TabIndex = 1;
            this.btnRateOfchange.Text = "Execute STEP 5";
            this.btnRateOfchange.UseVisualStyleBackColor = true;
            this.btnRateOfchange.Click += new System.EventHandler(this.btnRateOfchange_Click);
            // 
            // btnRMS
            // 
            this.btnRMS.Enabled = false;
            this.btnRMS.Location = new System.Drawing.Point(6, 145);
            this.btnRMS.Name = "btnRMS";
            this.btnRMS.Size = new System.Drawing.Size(121, 23);
            this.btnRMS.TabIndex = 1;
            this.btnRMS.Text = "Execute STEP 4";
            this.btnRMS.UseVisualStyleBackColor = true;
            this.btnRMS.Click += new System.EventHandler(this.btnRMS_Click);
            // 
            // btnStandardDeviation
            // 
            this.btnStandardDeviation.Enabled = false;
            this.btnStandardDeviation.Location = new System.Drawing.Point(6, 93);
            this.btnStandardDeviation.Name = "btnStandardDeviation";
            this.btnStandardDeviation.Size = new System.Drawing.Size(121, 23);
            this.btnStandardDeviation.TabIndex = 1;
            this.btnStandardDeviation.Text = "Execute STEP 3";
            this.btnStandardDeviation.UseVisualStyleBackColor = true;
            this.btnStandardDeviation.Click += new System.EventHandler(this.btnStandardDeviation_Click);
            // 
            // btnSortBy
            // 
            this.btnSortBy.Enabled = false;
            this.btnSortBy.Location = new System.Drawing.Point(6, 41);
            this.btnSortBy.Name = "btnSortBy";
            this.btnSortBy.Size = new System.Drawing.Size(121, 23);
            this.btnSortBy.TabIndex = 1;
            this.btnSortBy.Text = "Execute STEP 2";
            this.btnSortBy.UseVisualStyleBackColor = true;
            this.btnSortBy.Click += new System.EventHandler(this.btnSortBy_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "STEP 5 : Detect specific rate of change";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "STEP 4 : Calculate RMS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "STEP 3 : Calculate Standard Deviation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "STEP 2 : Sort By Column";
            // 
            // gbxOutput
            // 
            this.gbxOutput.Controls.Add(this.WaitingBar);
            this.gbxOutput.Controls.Add(this.dGridOutput);
            this.gbxOutput.Location = new System.Drawing.Point(12, 263);
            this.gbxOutput.Name = "gbxOutput";
            this.gbxOutput.Size = new System.Drawing.Size(946, 408);
            this.gbxOutput.TabIndex = 2;
            this.gbxOutput.TabStop = false;
            this.gbxOutput.Text = "File Output";
            // 
            // WaitingBar
            // 
            this.WaitingBar.Location = new System.Drawing.Point(181, 0);
            this.WaitingBar.Name = "WaitingBar";
            this.WaitingBar.Size = new System.Drawing.Size(524, 36);
            this.WaitingBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.WaitingBar.TabIndex = 2;
            this.WaitingBar.Value = 100;
            this.WaitingBar.Visible = false;
            // 
            // dGridOutput
            // 
            this.dGridOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGridOutput.Location = new System.Drawing.Point(3, 16);
            this.dGridOutput.Name = "dGridOutput";
            this.dGridOutput.Size = new System.Drawing.Size(940, 389);
            this.dGridOutput.TabIndex = 0;
            // 
            // gbxSelectFile
            // 
            this.gbxSelectFile.Controls.Add(this.btnLoadCSV);
            this.gbxSelectFile.Controls.Add(this.label1);
            this.gbxSelectFile.Location = new System.Drawing.Point(12, 12);
            this.gbxSelectFile.Name = "gbxSelectFile";
            this.gbxSelectFile.Size = new System.Drawing.Size(306, 245);
            this.gbxSelectFile.TabIndex = 3;
            this.gbxSelectFile.TabStop = false;
            this.gbxSelectFile.Text = "Selected File";
            // 
            // btnLoadCSV
            // 
            this.btnLoadCSV.Location = new System.Drawing.Point(6, 46);
            this.btnLoadCSV.Name = "btnLoadCSV";
            this.btnLoadCSV.Size = new System.Drawing.Size(294, 23);
            this.btnLoadCSV.TabIndex = 1;
            this.btnLoadCSV.Text = "Load my CSV File";
            this.btnLoadCSV.UseVisualStyleBackColor = true;
            this.btnLoadCSV.Click += new System.EventHandler(this.btnLoadCSV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "STEP 1 : Select a CSV file";
            // 
            // oCSVFile
            // 
            this.oCSVFile.FileName = "openFileDialog1";
            this.oCSVFile.Filter = "CSV File|*.csv";
            // 
            // btnSaveToSQL
            // 
            this.btnSaveToSQL.Enabled = false;
            this.btnSaveToSQL.Location = new System.Drawing.Point(15, 677);
            this.btnSaveToSQL.Name = "btnSaveToSQL";
            this.btnSaveToSQL.Size = new System.Drawing.Size(114, 23);
            this.btnSaveToSQL.TabIndex = 4;
            this.btnSaveToSQL.Text = "Save to SQL";
            this.btnSaveToSQL.UseVisualStyleBackColor = true;
            this.btnSaveToSQL.Click += new System.EventHandler(this.btnSaveToSQL_Click);
            // 
            // btnSaveToCSV
            // 
            this.btnSaveToCSV.Enabled = false;
            this.btnSaveToCSV.Location = new System.Drawing.Point(135, 677);
            this.btnSaveToCSV.Name = "btnSaveToCSV";
            this.btnSaveToCSV.Size = new System.Drawing.Size(114, 23);
            this.btnSaveToCSV.TabIndex = 4;
            this.btnSaveToCSV.Text = "Save to CSV";
            this.btnSaveToCSV.UseVisualStyleBackColor = true;
            this.btnSaveToCSV.Click += new System.EventHandler(this.btnSaveToCSV_Click);
            // 
            // btnRunReport
            // 
            this.btnRunReport.Enabled = false;
            this.btnRunReport.Location = new System.Drawing.Point(255, 677);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(114, 23);
            this.btnRunReport.TabIndex = 4;
            this.btnRunReport.Text = "Run Report";
            this.btnRunReport.UseVisualStyleBackColor = true;
            // 
            // sCSVFile
            // 
            this.sCSVFile.Filter = "CSV|*.csv";
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 717);
            this.Controls.Add(this.btnRunReport);
            this.Controls.Add(this.btnSaveToCSV);
            this.Controls.Add(this.btnSaveToSQL);
            this.Controls.Add(this.gbxFunctions);
            this.Controls.Add(this.gbxOutput);
            this.Controls.Add(this.gbxSelectFile);
            this.Name = "MainScreen";
            this.Text = "Assesment Cornelis Kuijpers";
            this.gbxFunctions.ResumeLayout(false);
            this.gbxFunctions.PerformLayout();
            this.gbxOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridOutput)).EndInit();
            this.gbxSelectFile.ResumeLayout(false);
            this.gbxSelectFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxFunctions;
        private System.Windows.Forms.GroupBox gbxOutput;
        private System.Windows.Forms.DataGridView dGridOutput;
        private System.Windows.Forms.GroupBox gbxSelectFile;
        private System.Windows.Forms.Button btnLoadCSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRateOfchange;
        private System.Windows.Forms.Button btnRMS;
        private System.Windows.Forms.Button btnStandardDeviation;
        private System.Windows.Forms.Button btnSortBy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog oCSVFile;
        private System.Windows.Forms.ProgressBar WaitingBar;
        private System.Windows.Forms.Button btnSaveToSQL;
        private System.Windows.Forms.Button btnSaveToCSV;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.SaveFileDialog sCSVFile;
    }
}

