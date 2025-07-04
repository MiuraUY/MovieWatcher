namespace MovieWatch
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnBuscar = new Button();
            lstPeliculas = new ListBox();
            picPoster = new PictureBox();
            txtDescripcion = new TextBox();
            btnUltimas = new Button();
            btnBuscarTorrents = new Button();
            txtBuscarTorrent = new TextBox();
            btnBuscarPorNombre = new Button();
            btnAbrirMagnet = new Button();
            btnStremearTorrent = new Button();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Unispace", 56F, FontStyle.Bold | FontStyle.Italic);
            lblTitulo.Location = new Point(388, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(636, 90);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Movie Watcher";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(30, 30, 30);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.Cyan;
            btnBuscar.Location = new Point(507, 111);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(87, 27);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "POPULARES";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lstPeliculas
            // 
            lstPeliculas.FormattingEnabled = true;
            lstPeliculas.ItemHeight = 15;
            lstPeliculas.Location = new Point(507, 190);
            lstPeliculas.Name = "lstPeliculas";
            lstPeliculas.Size = new Size(405, 439);
            lstPeliculas.TabIndex = 2;
            lstPeliculas.SelectedIndexChanged += lstPeliculas_SelectedIndexChanged_1;
            lstPeliculas.BackColor = Color.FromArgb(25, 25, 25);
            lstPeliculas.ForeColor = Color.White;
            lstPeliculas.BorderStyle = BorderStyle.None;
            // 
            // picPoster
            // 
            picPoster.Location = new Point(66, 164);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(292, 391);
            picPoster.SizeMode = PictureBoxSizeMode.Zoom;
            picPoster.TabIndex = 3;
            picPoster.TabStop = false;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.Location = new Point(41, 578);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.ScrollBars = ScrollBars.Both;
            txtDescripcion.Size = new Size(371, 134);
            txtDescripcion.TabIndex = 4;
            txtDescripcion.TextAlign = HorizontalAlignment.Center;
            txtDescripcion.BackColor = Color.FromArgb(20, 20, 20);
            txtDescripcion.ForeColor = Color.LightGreen;
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.Font = new Font("Consolas", 10);
            // 
            // btnUltimas
            // 
            btnUltimas.BackColor = Color.FromArgb(30, 30, 30);
            btnUltimas.FlatStyle = FlatStyle.Flat;
            btnUltimas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUltimas.ForeColor = Color.Cyan;
            btnUltimas.Location = new Point(842, 111);
            btnUltimas.Name = "btnUltimas";
            btnUltimas.Size = new Size(85, 27);
            btnUltimas.TabIndex = 4;
            btnUltimas.Text = "ULTIMAS";
            btnUltimas.UseVisualStyleBackColor = false;
            btnUltimas.Click += btnUltimas_Click;
            // 
            // btnBuscarTorrents
            // 
            btnBuscarTorrents.BackColor = Color.FromArgb(30, 30, 30);
            btnBuscarTorrents.FlatStyle = FlatStyle.Flat;
            btnBuscarTorrents.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBuscarTorrents.ForeColor = Color.Cyan;
            btnBuscarTorrents.Location = new Point(641, 111);
            btnBuscarTorrents.Name = "btnBuscarTorrents";
            btnBuscarTorrents.Size = new Size(154, 27);
            btnBuscarTorrents.TabIndex = 5;
            btnBuscarTorrents.Text = "TOP 100 PirateBay";
            btnBuscarTorrents.UseVisualStyleBackColor = false;
            btnBuscarTorrents.Click += btnBuscarTorrents_Click;
            // 
            // txtBuscarTorrent
            // 
            txtBuscarTorrent.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtBuscarTorrent.Location = new Point(507, 164);
            txtBuscarTorrent.Name = "txtBuscarTorrent";
            txtBuscarTorrent.PlaceholderText = "Película o serie...";
            txtBuscarTorrent.Size = new Size(288, 22);
            txtBuscarTorrent.TabIndex = 1;
            txtBuscarTorrent.Tag = "";
            txtBuscarTorrent.TextChanged += txtBuscarTorrent_TextChanged;
            // 
            // btnBuscarPorNombre
            // 
            btnBuscarPorNombre.BackColor = Color.FromArgb(30, 30, 30);
            btnBuscarPorNombre.FlatStyle = FlatStyle.Flat;
            btnBuscarPorNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBuscarPorNombre.ForeColor = Color.Cyan;
            btnBuscarPorNombre.Location = new Point(797, 158);
            btnBuscarPorNombre.Name = "btnBuscarPorNombre";
            btnBuscarPorNombre.Size = new Size(115, 29);
            btnBuscarPorNombre.TabIndex = 2;
            btnBuscarPorNombre.Text = "Búsqueda pirata";
            btnBuscarPorNombre.UseVisualStyleBackColor = false;
            btnBuscarPorNombre.Click += btnBuscarPorNombre_Click;
            // 
            // btnAbrirMagnet
            // 
            btnAbrirMagnet.BackColor = Color.FromArgb(30, 30, 30);
            btnAbrirMagnet.FlatStyle = FlatStyle.Flat;
            btnAbrirMagnet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAbrirMagnet.ForeColor = Color.Cyan;
            btnAbrirMagnet.Location = new Point(751, 635);
            btnAbrirMagnet.Name = "btnAbrirMagnet";
            btnAbrirMagnet.Size = new Size(294, 77);
            btnAbrirMagnet.TabIndex = 6;
            btnAbrirMagnet.Text = "DESCARGAR";
            btnAbrirMagnet.UseVisualStyleBackColor = true;
            btnAbrirMagnet.Visible = false;
            btnAbrirMagnet.Click += btnAbrirMagnet_Click_1;
            // 
            // btnStremearTorrent
            // 
            btnStremearTorrent.BackColor = Color.FromArgb(30, 30, 30);
            btnStremearTorrent.FlatStyle = FlatStyle.Flat;
            btnStremearTorrent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnStremearTorrent.ForeColor = Color.Cyan;
            btnStremearTorrent.Location = new Point(451, 635);
            btnStremearTorrent.Name = "btnStremearTorrent";
            btnStremearTorrent.Size = new Size(237, 77);
            btnStremearTorrent.TabIndex = 7;
            btnStremearTorrent.Text = "STREAM";
            btnStremearTorrent.UseVisualStyleBackColor = false;
            btnStremearTorrent.Visible = false;
            btnStremearTorrent.Click += btnStremearTorrent_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1350, 729);
            Controls.Add(btnStremearTorrent);
            Controls.Add(btnAbrirMagnet);
            Controls.Add(btnBuscarPorNombre);
            Controls.Add(txtBuscarTorrent);
            Controls.Add(btnBuscarTorrents);
            Controls.Add(btnUltimas);
            Controls.Add(txtDescripcion);
            Controls.Add(picPoster);
            Controls.Add(lstPeliculas);
            Controls.Add(btnBuscar);
            Controls.Add(lblTitulo);
            ForeColor = Color.White;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MWatcher";
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnBuscar;
        private ListBox lstPeliculas;
        private PictureBox picPoster;
        private TextBox txtDescripcion;
        private Button btnUltimas;
        private Button btnBuscarTorrents;
        protected TextBox txtBuscarTorrent;
        private Button btnBuscarPorNombre;
        private Button btnAbrirMagnet;
        private Button btnStremearTorrent;
    }
}
