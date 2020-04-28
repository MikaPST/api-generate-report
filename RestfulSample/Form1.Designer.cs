namespace RestfulSample
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SelectionView = new System.Windows.Forms.TreeView();
            this.SelectionLabel = new System.Windows.Forms.Label();
            this.TraceLabel = new System.Windows.Forms.Label();
            this.TraceBox = new System.Windows.Forms.RichTextBox();
            this.CMSTextBox = new System.Windows.Forms.TextBox();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.LogonButton = new System.Windows.Forms.Button();
            this.LogoffButton = new System.Windows.Forms.Button();
            this.DocumentIDLabel = new System.Windows.Forms.Label();
            this.DocidBox = new System.Windows.Forms.TextBox();
            this.FetchDocButton = new System.Windows.Forms.Button();
            this.AlldocumentsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ViewdocumentButton = new System.Windows.Forms.Button();
            this.dataGridViewDocument = new System.Windows.Forms.DataGridView();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.informatiosDocument = new System.Windows.Forms.Label();
            this.affichageDocument = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectionView
            // 
            this.SelectionView.CheckBoxes = true;
            this.SelectionView.Location = new System.Drawing.Point(311, 81);
            this.SelectionView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SelectionView.Name = "SelectionView";
            this.SelectionView.Size = new System.Drawing.Size(256, 363);
            this.SelectionView.TabIndex = 0;
            this.SelectionView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.SelectionView_AfterCheck);
            this.SelectionView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SelectionView_AfterSelect);
            // 
            // SelectionLabel
            // 
            this.SelectionLabel.AutoSize = true;
            this.SelectionLabel.Location = new System.Drawing.Point(308, 65);
            this.SelectionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectionLabel.Name = "SelectionLabel";
            this.SelectionLabel.Size = new System.Drawing.Size(130, 13);
            this.SelectionLabel.TabIndex = 1;
            this.SelectionLabel.Text = "Sélection des Paramètres:";
            this.SelectionLabel.Click += new System.EventHandler(this.SelectionLabel_Click);
            // 
            // TraceLabel
            // 
            this.TraceLabel.AutoSize = true;
            this.TraceLabel.Location = new System.Drawing.Point(312, 493);
            this.TraceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TraceLabel.Name = "TraceLabel";
            this.TraceLabel.Size = new System.Drawing.Size(51, 13);
            this.TraceLabel.TabIndex = 2;
            this.TraceLabel.Text = "Console :";
            // 
            // TraceBox
            // 
            this.TraceBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.TraceBox.ForeColor = System.Drawing.Color.Lime;
            this.TraceBox.Location = new System.Drawing.Point(311, 509);
            this.TraceBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TraceBox.Name = "TraceBox";
            this.TraceBox.Size = new System.Drawing.Size(256, 106);
            this.TraceBox.TabIndex = 3;
            this.TraceBox.Text = "";
            this.TraceBox.TextChanged += new System.EventHandler(this.TraceBox_TextChanged);
            // 
            // CMSTextBox
            // 
            this.CMSTextBox.Location = new System.Drawing.Point(25, 40);
            this.CMSTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CMSTextBox.Name = "CMSTextBox";
            this.CMSTextBox.Size = new System.Drawing.Size(256, 20);
            this.CMSTextBox.TabIndex = 4;
            this.CMSTextBox.TextChanged += new System.EventHandler(this.CMSTextBox_TextChanged);
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Location = new System.Drawing.Point(25, 25);
            this.ServerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(113, 13);
            this.ServerLabel.TabIndex = 5;
            this.ServerLabel.Text = "Adresse Web Service:";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(25, 65);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(56, 13);
            this.UserNameLabel.TabIndex = 6;
            this.UserNameLabel.Text = "Utilisateur:";
            this.UserNameLabel.UseMnemonic = false;
            // 
            // UserNameBox
            // 
            this.UserNameBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UserNameBox.Location = new System.Drawing.Point(25, 81);
            this.UserNameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(145, 20);
            this.UserNameBox.TabIndex = 7;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(25, 106);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(74, 13);
            this.PasswordLabel.TabIndex = 8;
            this.PasswordLabel.Text = "Mot de passe:";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(25, 122);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(145, 20);
            this.PasswordBox.TabIndex = 9;
            // 
            // LogonButton
            // 
            this.LogonButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.LogonButton.Location = new System.Drawing.Point(193, 76);
            this.LogonButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LogonButton.Name = "LogonButton";
            this.LogonButton.Size = new System.Drawing.Size(88, 28);
            this.LogonButton.TabIndex = 10;
            this.LogonButton.Text = "Connection";
            this.LogonButton.UseVisualStyleBackColor = true;
            this.LogonButton.Click += new System.EventHandler(this.LogonButton_Click);
            // 
            // LogoffButton
            // 
            this.LogoffButton.ForeColor = System.Drawing.Color.DarkRed;
            this.LogoffButton.Location = new System.Drawing.Point(193, 118);
            this.LogoffButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LogoffButton.Name = "LogoffButton";
            this.LogoffButton.Size = new System.Drawing.Size(88, 27);
            this.LogoffButton.TabIndex = 11;
            this.LogoffButton.Text = "Déconnexion";
            this.LogoffButton.UseVisualStyleBackColor = true;
            this.LogoffButton.Click += new System.EventHandler(this.LogoffButton_Click);
            // 
            // DocumentIDLabel
            // 
            this.DocumentIDLabel.AutoSize = true;
            this.DocumentIDLabel.Location = new System.Drawing.Point(312, 26);
            this.DocumentIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DocumentIDLabel.Name = "DocumentIDLabel";
            this.DocumentIDLabel.Size = new System.Drawing.Size(73, 13);
            this.DocumentIDLabel.TabIndex = 12;
            this.DocumentIDLabel.Text = "Document ID:";
            // 
            // DocidBox
            // 
            this.DocidBox.Location = new System.Drawing.Point(311, 42);
            this.DocidBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DocidBox.Name = "DocidBox";
            this.DocidBox.Size = new System.Drawing.Size(94, 20);
            this.DocidBox.TabIndex = 13;
            this.DocidBox.TextChanged += new System.EventHandler(this.DocidBox_TextChanged);
            // 
            // FetchDocButton
            // 
            this.FetchDocButton.Location = new System.Drawing.Point(465, 26);
            this.FetchDocButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FetchDocButton.Name = "FetchDocButton";
            this.FetchDocButton.Size = new System.Drawing.Size(102, 47);
            this.FetchDocButton.TabIndex = 14;
            this.FetchDocButton.Text = "Paramètres du Document";
            this.FetchDocButton.UseVisualStyleBackColor = true;
            this.FetchDocButton.Click += new System.EventHandler(this.ParamDocButton_Click);
            // 
            // AlldocumentsButton
            // 
            this.AlldocumentsButton.Location = new System.Drawing.Point(156, 162);
            this.AlldocumentsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AlldocumentsButton.Name = "AlldocumentsButton";
            this.AlldocumentsButton.Size = new System.Drawing.Size(125, 34);
            this.AlldocumentsButton.TabIndex = 15;
            this.AlldocumentsButton.Text = "All Documents";
            this.AlldocumentsButton.UseVisualStyleBackColor = true;
            this.AlldocumentsButton.Click += new System.EventHandler(this.AllDocumentsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Liste des Documents :";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Location = new System.Drawing.Point(25, 201);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(256, 414);
            this.dataGridView.TabIndex = 18;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // ViewdocumentButton
            // 
            this.ViewdocumentButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ViewdocumentButton.Location = new System.Drawing.Point(377, 450);
            this.ViewdocumentButton.Name = "ViewdocumentButton";
            this.ViewdocumentButton.Size = new System.Drawing.Size(122, 36);
            this.ViewdocumentButton.TabIndex = 21;
            this.ViewdocumentButton.Text = "Afficher Document";
            this.ViewdocumentButton.UseVisualStyleBackColor = true;
            this.ViewdocumentButton.Click += new System.EventHandler(this.ViewDocumentButton_Click);
            // 
            // dataGridViewDocument
            // 
            this.dataGridViewDocument.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDocument.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDocument.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDocument.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewDocument.Location = new System.Drawing.Point(599, 569);
            this.dataGridViewDocument.Name = "dataGridViewDocument";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDocument.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewDocument.Size = new System.Drawing.Size(593, 46);
            this.dataGridViewDocument.TabIndex = 23;
            this.dataGridViewDocument.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocument_CellContentClick);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(599, 40);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(593, 500);
            this.webBrowser.TabIndex = 24;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // informatiosDocument
            // 
            this.informatiosDocument.AutoSize = true;
            this.informatiosDocument.Location = new System.Drawing.Point(602, 553);
            this.informatiosDocument.Name = "informatiosDocument";
            this.informatiosDocument.Size = new System.Drawing.Size(122, 13);
            this.informatiosDocument.TabIndex = 25;
            this.informatiosDocument.Text = "Informations Document :";
            // 
            // affichageDocument
            // 
            this.affichageDocument.AutoSize = true;
            this.affichageDocument.Location = new System.Drawing.Point(602, 21);
            this.affichageDocument.Name = "affichageDocument";
            this.affichageDocument.Size = new System.Drawing.Size(104, 13);
            this.affichageDocument.TabIndex = 26;
            this.affichageDocument.Text = "Affichage Document";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1219, 627);
            this.Controls.Add(this.affichageDocument);
            this.Controls.Add(this.informatiosDocument);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.dataGridViewDocument);
            this.Controls.Add(this.ViewdocumentButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AlldocumentsButton);
            this.Controls.Add(this.FetchDocButton);
            this.Controls.Add(this.DocidBox);
            this.Controls.Add(this.DocumentIDLabel);
            this.Controls.Add(this.LogoffButton);
            this.Controls.Add(this.LogonButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.ServerLabel);
            this.Controls.Add(this.CMSTextBox);
            this.Controls.Add(this.TraceBox);
            this.Controls.Add(this.TraceLabel);
            this.Controls.Add(this.SelectionLabel);
            this.Controls.Add(this.SelectionView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Connexion WEB SERVICE";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocument)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView SelectionView;
        private System.Windows.Forms.Label SelectionLabel;
        private System.Windows.Forms.Label TraceLabel;
        private System.Windows.Forms.RichTextBox TraceBox;
        private System.Windows.Forms.TextBox CMSTextBox;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox UserNameBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button LogonButton;
        private System.Windows.Forms.Button LogoffButton;
        private System.Windows.Forms.Label DocumentIDLabel;
        private System.Windows.Forms.TextBox DocidBox;
        private System.Windows.Forms.Button FetchDocButton;
		private System.Windows.Forms.Button AlldocumentsButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button ViewdocumentButton;
		private System.Windows.Forms.DataGridView dataGridViewDocument;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.Label informatiosDocument;
		private System.Windows.Forms.Label affichageDocument;
	}

}