namespace random_code_ui
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtAllowedText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDigit = new System.Windows.Forms.NumericUpDown();
            this.txtTotal = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
            this.lbSaveFile = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtDigit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "허용할 문자";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAllowedText
            // 
            this.txtAllowedText.Location = new System.Drawing.Point(103, 17);
            this.txtAllowedText.Name = "txtAllowedText";
            this.txtAllowedText.Size = new System.Drawing.Size(393, 21);
            this.txtAllowedText.TabIndex = 1;
            this.txtAllowedText.Text = "CEFHKMNPTWXY3479";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(28, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "코드 자릿수";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDigit
            // 
            this.txtDigit.Location = new System.Drawing.Point(103, 44);
            this.txtDigit.Name = "txtDigit";
            this.txtDigit.Size = new System.Drawing.Size(393, 21);
            this.txtDigit.TabIndex = 3;
            this.txtDigit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDigit.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(103, 71);
            this.txtTotal.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtTotal.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(393, 21);
            this.txtTotal.TabIndex = 5;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(28, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "생성갯수";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(28, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "저장위치";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(103, 97);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(393, 23);
            this.btnFile.TabIndex = 7;
            this.btnFile.Text = "저장위치선택";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // lbSaveFile
            // 
            this.lbSaveFile.AutoSize = true;
            this.lbSaveFile.Location = new System.Drawing.Point(101, 126);
            this.lbSaveFile.Name = "lbSaveFile";
            this.lbSaveFile.Size = new System.Drawing.Size(0, 12);
            this.lbSaveFile.TabIndex = 8;
            this.lbSaveFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(103, 154);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(393, 23);
            this.btnGen.TabIndex = 9;
            this.btnGen.Text = "생성";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(521, 189);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.lbSaveFile);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDigit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAllowedText);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "코드 생성기";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDigit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAllowedText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtDigit;
        private System.Windows.Forms.NumericUpDown txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Label lbSaveFile;
        private System.Windows.Forms.Button btnGen;
    }
}

