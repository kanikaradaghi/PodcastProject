namespace Presentation
{
    partial class MainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            URLTextBox = new TextBox();
            NamnBox = new TextBox();
            CatogeryBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            CategoriCbx = new ComboBox();
            label4 = new Label();
            AddPodcast = new Button();
            ChangePodcast = new Button();
            DeletePodcast = new Button();
            AddCategori = new Button();
            ChangeCategori = new Button();
            DeleteCategori = new Button();
            LbEpisode = new ListBox();
            TextBox1 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            PodcastTbl = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            FilterCategorycbx = new ComboBox();
            Filtrera = new Label();
            reset = new Button();
            LbCategori = new ListBox();
            ((System.ComponentModel.ISupportInitialize)PodcastTbl).BeginInit();
            SuspendLayout();
            // 
            // URLTextBox
            // 
            URLTextBox.Location = new Point(32, 78);
            URLTextBox.Name = "URLTextBox";
            URLTextBox.Size = new Size(405, 39);
            URLTextBox.TabIndex = 0;
            // 
            // NamnBox
            // 
            NamnBox.Location = new Point(257, 191);
            NamnBox.Name = "NamnBox";
            NamnBox.Size = new Size(399, 39);
            NamnBox.TabIndex = 1;
            // 
            // CatogeryBox
            // 
            CatogeryBox.Location = new Point(1608, 143);
            CatogeryBox.Name = "CatogeryBox";
            CatogeryBox.Size = new Size(287, 39);
            CatogeryBox.TabIndex = 2;
            CatogeryBox.TextChanged += CatogeryBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 34);
            label1.Name = "label1";
            label1.Size = new Size(55, 32);
            label1.TabIndex = 3;
            label1.Text = "URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 143);
            label2.Name = "label2";
            label2.Size = new Size(79, 32);
            label2.TabIndex = 4;
            label2.Text = "Namn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1608, 85);
            label3.Name = "label3";
            label3.Size = new Size(103, 32);
            label3.TabIndex = 5;
            label3.Text = "Kategori";
            // 
            // CategoriCbx
            // 
            CategoriCbx.FormattingEnabled = true;
            CategoriCbx.Location = new Point(32, 190);
            CategoriCbx.Name = "CategoriCbx";
            CategoriCbx.Size = new Size(163, 40);
            CategoriCbx.TabIndex = 6;
            CategoriCbx.SelectedIndexChanged += CategoriCbx_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 143);
            label4.Name = "label4";
            label4.Size = new Size(147, 32);
            label4.TabIndex = 7;
            label4.Text = "Välj Kategori";
            // 
            // AddPodcast
            // 
            AddPodcast.Location = new Point(32, 270);
            AddPodcast.Name = "AddPodcast";
            AddPodcast.Size = new Size(172, 45);
            AddPodcast.TabIndex = 8;
            AddPodcast.Text = "Lägg till";
            AddPodcast.UseVisualStyleBackColor = true;
            AddPodcast.Click += AddPodcast_Click;
            // 
            // ChangePodcast
            // 
            ChangePodcast.Location = new Point(237, 270);
            ChangePodcast.Name = "ChangePodcast";
            ChangePodcast.Size = new Size(220, 51);
            ChangePodcast.TabIndex = 9;
            ChangePodcast.Text = "Ändra";
            ChangePodcast.UseVisualStyleBackColor = true;
            ChangePodcast.Click += ChangePodcast_Click;
            // 
            // DeletePodcast
            // 
            DeletePodcast.Location = new Point(478, 272);
            DeletePodcast.Name = "DeletePodcast";
            DeletePodcast.Size = new Size(203, 43);
            DeletePodcast.TabIndex = 10;
            DeletePodcast.Text = "Ta bort";
            DeletePodcast.UseVisualStyleBackColor = true;
            DeletePodcast.Click += DeletePodcast_Click;
            // 
            // AddCategori
            // 
            AddCategori.Location = new Point(1608, 204);
            AddCategori.Name = "AddCategori";
            AddCategori.Size = new Size(235, 48);
            AddCategori.TabIndex = 11;
            AddCategori.Text = "Lägg till";
            AddCategori.UseVisualStyleBackColor = true;
            AddCategori.Click += AddCategori_Click;
            // 
            // ChangeCategori
            // 
            ChangeCategori.Location = new Point(1608, 273);
            ChangeCategori.Name = "ChangeCategori";
            ChangeCategori.Size = new Size(235, 48);
            ChangeCategori.TabIndex = 12;
            ChangeCategori.Text = "Ändra";
            ChangeCategori.UseVisualStyleBackColor = true;
            ChangeCategori.Click += ChangeCategori_Click;
            // 
            // DeleteCategori
            // 
            DeleteCategori.Location = new Point(1608, 345);
            DeleteCategori.Name = "DeleteCategori";
            DeleteCategori.Size = new Size(235, 48);
            DeleteCategori.TabIndex = 13;
            DeleteCategori.Text = "Ta bort";
            DeleteCategori.UseVisualStyleBackColor = true;
            DeleteCategori.Click += DeleteCategori_Click;
            // 
            // LbEpisode
            // 
            LbEpisode.FormattingEnabled = true;
            LbEpisode.ItemHeight = 32;
            LbEpisode.Location = new Point(873, 102);
            LbEpisode.Name = "LbEpisode";
            LbEpisode.Size = new Size(551, 324);
            LbEpisode.TabIndex = 14;
            LbEpisode.SelectedIndexChanged += LbEpisode_SelectedIndexChanged;
            // 
            // TextBox1
            // 
            TextBox1.Location = new Point(873, 450);
            TextBox1.Multiline = true;
            TextBox1.Name = "TextBox1";
            TextBox1.ScrollBars = ScrollBars.Both;
            TextBox1.Size = new Size(532, 370);
            TextBox1.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(873, 50);
            label5.Name = "label5";
            label5.Size = new Size(87, 32);
            label5.TabIndex = 18;
            label5.Text = "Avsnitt";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1528, 415);
            label6.Name = "label6";
            label6.Size = new Size(103, 32);
            label6.TabIndex = 19;
            label6.Text = "Kategori";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 329);
            label7.Name = "label7";
            label7.Size = new Size(95, 32);
            label7.TabIndex = 20;
            label7.Text = "Podcast";
            // 
            // PodcastTbl
            // 
            PodcastTbl.AllowUserToAddRows = false;
            PodcastTbl.BackgroundColor = SystemColors.ControlLightLight;
            PodcastTbl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PodcastTbl.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            PodcastTbl.Location = new Point(13, 389);
            PodcastTbl.Name = "PodcastTbl";
            PodcastTbl.RowHeadersWidth = 72;
            PodcastTbl.RowTemplate.Height = 37;
            PodcastTbl.Size = new Size(854, 279);
            PodcastTbl.TabIndex = 21;
            PodcastTbl.SelectionChanged += PodcastTbl_SelectionChanged;
            // 
            // Column1
            // 
            Column1.HeaderText = "Namn";
            Column1.MinimumWidth = 9;
            Column1.Name = "Column1";
            Column1.Width = 175;
            // 
            // Column2
            // 
            Column2.HeaderText = "Titel";
            Column2.MinimumWidth = 9;
            Column2.Name = "Column2";
            Column2.Width = 175;
            // 
            // Column3
            // 
            Column3.HeaderText = "Kategori";
            Column3.MinimumWidth = 9;
            Column3.Name = "Column3";
            Column3.Width = 175;
            // 
            // Column4
            // 
            Column4.HeaderText = "Antal avsnitt";
            Column4.MinimumWidth = 9;
            Column4.Name = "Column4";
            Column4.Width = 175;
            // 
            // FilterCategorycbx
            // 
            FilterCategorycbx.FormattingEnabled = true;
            FilterCategorycbx.Location = new Point(514, 77);
            FilterCategorycbx.Name = "FilterCategorycbx";
            FilterCategorycbx.Size = new Size(242, 40);
            FilterCategorycbx.TabIndex = 22;
            FilterCategorycbx.SelectedIndexChanged += FilterCategorycbx_SelectedIndexChanged;
            // 
            // Filtrera
            // 
            Filtrera.AutoSize = true;
            Filtrera.Location = new Point(514, 34);
            Filtrera.Name = "Filtrera";
            Filtrera.Size = new Size(87, 32);
            Filtrera.TabIndex = 23;
            Filtrera.Text = "Filtrera";
            // 
            // reset
            // 
            reset.Location = new Point(514, 129);
            reset.Name = "reset";
            reset.Size = new Size(150, 46);
            reset.TabIndex = 24;
            reset.Text = "Återställ";
            reset.UseVisualStyleBackColor = true;
            reset.Click += Reset_Click;
            // 
            // LbCategori
            // 
            LbCategori.FormattingEnabled = true;
            LbCategori.ItemHeight = 32;
            LbCategori.Location = new Point(1528, 477);
            LbCategori.Name = "LbCategori";
            LbCategori.Size = new Size(367, 260);
            LbCategori.TabIndex = 25;
            // 
            // MainApp
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2083, 913);
            Controls.Add(LbCategori);
            Controls.Add(reset);
            Controls.Add(Filtrera);
            Controls.Add(FilterCategorycbx);
            Controls.Add(PodcastTbl);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(TextBox1);
            Controls.Add(LbEpisode);
            Controls.Add(DeleteCategori);
            Controls.Add(ChangeCategori);
            Controls.Add(AddCategori);
            Controls.Add(DeletePodcast);
            Controls.Add(ChangePodcast);
            Controls.Add(AddPodcast);
            Controls.Add(label4);
            Controls.Add(CategoriCbx);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CatogeryBox);
            Controls.Add(NamnBox);
            Controls.Add(URLTextBox);
            Name = "MainApp";
            Text = "MainApp";
            ((System.ComponentModel.ISupportInitialize)PodcastTbl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void CategoriCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void LbCatogori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CatogeryBox_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private TextBox URLTextBox;
        private TextBox NamnBox;
        private TextBox CatogeryBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox CategoriCbx;
        private Label label4;
        private Button AddPodcast;
        private Button ChangePodcast;
        private Button DeletePodcast;
        private Button AddCategori;
        private Button ChangeCategori;
        private Button DeleteCategori;
        private ListBox LbEpisode;
        private TextBox TextBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridView PodcastTbl;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private ComboBox FilterCategorycbx;
        private Label Filtrera;
        private Button reset;
        private ListBox LbCategori;
    }
}