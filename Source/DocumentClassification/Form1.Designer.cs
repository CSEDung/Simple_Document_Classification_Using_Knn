namespace DocumentClassification
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_svm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_knn = new System.Windows.Forms.Button();
            this.txt_k = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbt_TestFile = new System.Windows.Forms.RadioButton();
            this.rbt_TrainFile = new System.Windows.Forms.RadioButton();
            this.txt_folderPath = new System.Windows.Forms.TextBox();
            this.btn_vntokenizer = new System.Windows.Forms.Button();
            this.btn_browInputFolder = new System.Windows.Forms.Button();
            this.lb_subFolderFound = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_convertDataset = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_bagOfWord = new System.Windows.Forms.Button();
            this.rbt_keepAll = new System.Windows.Forms.RadioButton();
            this.txt_top = new System.Windows.Forms.TextBox();
            this.rdb_top = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_text = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rb_svm = new System.Windows.Forms.RadioButton();
            this.rb_knn = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_predict = new System.Windows.Forms.Button();
            this.txt_out = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 362);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.btn_svm);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btn_knn);
            this.groupBox3.Controls.Add(this.txt_k);
            this.groupBox3.Location = new System.Drawing.Point(4, 254);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 105);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // btn_svm
            // 
            this.btn_svm.Location = new System.Drawing.Point(7, 78);
            this.btn_svm.Name = "btn_svm";
            this.btn_svm.Size = new System.Drawing.Size(156, 23);
            this.btn_svm.TabIndex = 16;
            this.btn_svm.Text = "Support Vector Machine Test";
            this.btn_svm.UseVisualStyleBackColor = true;
            this.btn_svm.Click += new System.EventHandler(this.btn_svm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Value of K should be: 3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Value of K:";
            // 
            // btn_knn
            // 
            this.btn_knn.Location = new System.Drawing.Point(7, 49);
            this.btn_knn.Name = "btn_knn";
            this.btn_knn.Size = new System.Drawing.Size(158, 23);
            this.btn_knn.TabIndex = 14;
            this.btn_knn.Text = "K Nearest Neighbor Test";
            this.btn_knn.UseVisualStyleBackColor = true;
            this.btn_knn.Click += new System.EventHandler(this.btn_knn_Click);
            // 
            // txt_k
            // 
            this.txt_k.Location = new System.Drawing.Point(76, 27);
            this.txt_k.Name = "txt_k";
            this.txt_k.Size = new System.Drawing.Size(87, 20);
            this.txt_k.TabIndex = 13;
            this.txt_k.Text = "3";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbt_TestFile);
            this.groupBox4.Controls.Add(this.rbt_TrainFile);
            this.groupBox4.Controls.Add(this.txt_folderPath);
            this.groupBox4.Controls.Add(this.btn_vntokenizer);
            this.groupBox4.Controls.Add(this.btn_browInputFolder);
            this.groupBox4.Controls.Add(this.lb_subFolderFound);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(4, 50);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(169, 111);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input data folder";
            // 
            // rbt_TestFile
            // 
            this.rbt_TestFile.AutoSize = true;
            this.rbt_TestFile.Location = new System.Drawing.Point(70, 13);
            this.rbt_TestFile.Name = "rbt_TestFile";
            this.rbt_TestFile.Size = new System.Drawing.Size(60, 17);
            this.rbt_TestFile.TabIndex = 2;
            this.rbt_TestFile.TabStop = true;
            this.rbt_TestFile.Text = "Testing";
            this.rbt_TestFile.UseVisualStyleBackColor = true;
            // 
            // rbt_TrainFile
            // 
            this.rbt_TrainFile.AutoSize = true;
            this.rbt_TrainFile.Checked = true;
            this.rbt_TrainFile.Location = new System.Drawing.Point(7, 13);
            this.rbt_TrainFile.Name = "rbt_TrainFile";
            this.rbt_TrainFile.Size = new System.Drawing.Size(63, 17);
            this.rbt_TrainFile.TabIndex = 1;
            this.rbt_TrainFile.TabStop = true;
            this.rbt_TrainFile.Text = "Training";
            this.rbt_TrainFile.UseVisualStyleBackColor = true;
            // 
            // txt_folderPath
            // 
            this.txt_folderPath.Location = new System.Drawing.Point(5, 34);
            this.txt_folderPath.Name = "txt_folderPath";
            this.txt_folderPath.Size = new System.Drawing.Size(158, 20);
            this.txt_folderPath.TabIndex = 3;
            // 
            // btn_vntokenizer
            // 
            this.btn_vntokenizer.Location = new System.Drawing.Point(5, 85);
            this.btn_vntokenizer.Name = "btn_vntokenizer";
            this.btn_vntokenizer.Size = new System.Drawing.Size(158, 23);
            this.btn_vntokenizer.TabIndex = 5;
            this.btn_vntokenizer.Text = "VnTokenizer";
            this.btn_vntokenizer.UseVisualStyleBackColor = true;
            this.btn_vntokenizer.Click += new System.EventHandler(this.btn_vntokenizer_Click);
            // 
            // btn_browInputFolder
            // 
            this.btn_browInputFolder.Location = new System.Drawing.Point(5, 57);
            this.btn_browInputFolder.Name = "btn_browInputFolder";
            this.btn_browInputFolder.Size = new System.Drawing.Size(51, 21);
            this.btn_browInputFolder.TabIndex = 4;
            this.btn_browInputFolder.Text = "Bows";
            this.btn_browInputFolder.UseVisualStyleBackColor = true;
            this.btn_browInputFolder.Click += new System.EventHandler(this.btn_browInputFolder_Click);
            // 
            // lb_subFolderFound
            // 
            this.lb_subFolderFound.AutoSize = true;
            this.lb_subFolderFound.Location = new System.Drawing.Point(64, 61);
            this.lb_subFolderFound.Name = "lb_subFolderFound";
            this.lb_subFolderFound.Size = new System.Drawing.Size(13, 13);
            this.lb_subFolderFound.TabIndex = 4;
            this.lb_subFolderFound.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Classes found";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.btn_convertDataset);
            this.groupBox2.Location = new System.Drawing.Point(4, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 41);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btn_convertDataset
            // 
            this.btn_convertDataset.Location = new System.Drawing.Point(7, 12);
            this.btn_convertDataset.Name = "btn_convertDataset";
            this.btn_convertDataset.Size = new System.Drawing.Size(158, 23);
            this.btn_convertDataset.TabIndex = 12;
            this.btn_convertDataset.Text = "Convert dataset";
            this.btn_convertDataset.UseVisualStyleBackColor = true;
            this.btn_convertDataset.Click += new System.EventHandler(this.btn_convertDataset_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(70, 16);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(48, 17);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "SVM";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "kNN";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btn_bagOfWord);
            this.groupBox1.Controls.Add(this.rbt_keepAll);
            this.groupBox1.Controls.Add(this.txt_top);
            this.groupBox1.Controls.Add(this.rdb_top);
            this.groupBox1.Location = new System.Drawing.Point(4, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 67);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btn_bagOfWord
            // 
            this.btn_bagOfWord.Location = new System.Drawing.Point(9, 38);
            this.btn_bagOfWord.Name = "btn_bagOfWord";
            this.btn_bagOfWord.Size = new System.Drawing.Size(158, 23);
            this.btn_bagOfWord.TabIndex = 9;
            this.btn_bagOfWord.Text = "Bag Of Words";
            this.btn_bagOfWord.UseVisualStyleBackColor = true;
            this.btn_bagOfWord.Click += new System.EventHandler(this.btn_bagOfWord_Click);
            // 
            // rbt_keepAll
            // 
            this.rbt_keepAll.AutoSize = true;
            this.rbt_keepAll.Location = new System.Drawing.Point(9, 15);
            this.rbt_keepAll.Name = "rbt_keepAll";
            this.rbt_keepAll.Size = new System.Drawing.Size(63, 17);
            this.rbt_keepAll.TabIndex = 6;
            this.rbt_keepAll.Text = "Keep all";
            this.rbt_keepAll.UseVisualStyleBackColor = true;
            this.rbt_keepAll.Click += new System.EventHandler(this.rbt_keepAll_Click);
            // 
            // txt_top
            // 
            this.txt_top.Location = new System.Drawing.Point(121, 14);
            this.txt_top.Name = "txt_top";
            this.txt_top.Size = new System.Drawing.Size(46, 20);
            this.txt_top.TabIndex = 8;
            this.txt_top.Text = "12";
            // 
            // rdb_top
            // 
            this.rdb_top.AutoSize = true;
            this.rdb_top.Checked = true;
            this.rdb_top.Location = new System.Drawing.Point(74, 15);
            this.rdb_top.Name = "rdb_top";
            this.rdb_top.Size = new System.Drawing.Size(44, 17);
            this.rdb_top.TabIndex = 7;
            this.rdb_top.TabStop = true;
            this.rdb_top.Text = "Top";
            this.rdb_top.UseVisualStyleBackColor = true;
            this.rdb_top.Click += new System.EventHandler(this.rdb_top_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.txt_text);
            this.panel2.Location = new System.Drawing.Point(183, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 327);
            this.panel2.TabIndex = 1;
            // 
            // txt_text
            // 
            this.txt_text.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_text.Location = new System.Drawing.Point(0, 1);
            this.txt_text.Multiline = true;
            this.txt_text.Name = "txt_text";
            this.txt_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_text.Size = new System.Drawing.Size(397, 323);
            this.txt_text.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.rb_svm);
            this.panel3.Controls.Add(this.rb_knn);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btn_predict);
            this.panel3.Controls.Add(this.txt_out);
            this.panel3.Location = new System.Drawing.Point(183, 332);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 30);
            this.panel3.TabIndex = 2;
            // 
            // rb_svm
            // 
            this.rb_svm.AutoSize = true;
            this.rb_svm.Location = new System.Drawing.Point(261, 5);
            this.rb_svm.Name = "rb_svm";
            this.rb_svm.Size = new System.Drawing.Size(48, 17);
            this.rb_svm.TabIndex = 19;
            this.rb_svm.Text = "SVM";
            this.rb_svm.UseVisualStyleBackColor = true;
            // 
            // rb_knn
            // 
            this.rb_knn.AutoSize = true;
            this.rb_knn.Checked = true;
            this.rb_knn.Location = new System.Drawing.Point(213, 5);
            this.rb_knn.Name = "rb_knn";
            this.rb_knn.Size = new System.Drawing.Size(44, 17);
            this.rb_knn.TabIndex = 18;
            this.rb_knn.TabStop = true;
            this.rb_knn.Text = "Knn";
            this.rb_knn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(309, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 26);
            this.button1.TabIndex = 16;
            this.button1.Text = "File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_predict
            // 
            this.btn_predict.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_predict.Location = new System.Drawing.Point(345, 1);
            this.btn_predict.Name = "btn_predict";
            this.btn_predict.Size = new System.Drawing.Size(52, 26);
            this.btn_predict.TabIndex = 17;
            this.btn_predict.Text = "Predict";
            this.btn_predict.UseVisualStyleBackColor = true;
            this.btn_predict.Click += new System.EventHandler(this.btn_predict_Click);
            // 
            // txt_out
            // 
            this.txt_out.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_out.Location = new System.Drawing.Point(0, 1);
            this.txt_out.Multiline = true;
            this.txt_out.Name = "txt_out";
            this.txt_out.ReadOnly = true;
            this.txt_out.Size = new System.Drawing.Size(212, 26);
            this.txt_out.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Location = new System.Drawing.Point(4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(169, 39);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Type";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Document Classification";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_vntokenizer;
        private System.Windows.Forms.Label lb_subFolderFound;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_browInputFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_folderPath;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_text;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_bagOfWord;
        private System.Windows.Forms.Button btn_convertDataset;
        private System.Windows.Forms.Button btn_knn;
        private System.Windows.Forms.TextBox txt_out;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_k;
        private System.Windows.Forms.TextBox txt_top;
        private System.Windows.Forms.RadioButton rdb_top;
        private System.Windows.Forms.RadioButton rbt_keepAll;
        private System.Windows.Forms.Button btn_predict;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbt_TestFile;
        private System.Windows.Forms.RadioButton rbt_TrainFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_svm;
        private System.Windows.Forms.RadioButton rb_svm;
        private System.Windows.Forms.RadioButton rb_knn;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

