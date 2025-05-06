namespace WindowsFormsApp_calculator
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            this.listBox_cal_Log = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_cal_Log
            // 
            this.listBox_cal_Log.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listBox_cal_Log.FormattingEnabled = true;
            this.listBox_cal_Log.ItemHeight = 27;
            this.listBox_cal_Log.Location = new System.Drawing.Point(14, 8);
            this.listBox_cal_Log.Name = "listBox_cal_Log";
            this.listBox_cal_Log.Size = new System.Drawing.Size(374, 274);
            this.listBox_cal_Log.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 294);
            this.Controls.Add(this.listBox_cal_Log);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "Form2";
            this.Text = "Calculation Log";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox listBox_cal_Log;
    }
}