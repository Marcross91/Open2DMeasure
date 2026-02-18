
using System.Windows.Forms;

namespace Open2DMeasure {
    partial class frmMain {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cbModalitaScala = new System.Windows.Forms.ComboBox();
            this.lblModalitaScala = new System.Windows.Forms.Label();
            this.cmdDefinisciOrigine = new System.Windows.Forms.Button();
            this.cmdDefinisciAsseX = new System.Windows.Forms.Button();
            this.cmdDefinisciAsseY = new System.Windows.Forms.Button();
            this.gbAllineamento = new System.Windows.Forms.GroupBox();
            this.lbElementi = new System.Windows.Forms.ListBox();
            this.cmslbElementi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmImpostaTolleranze = new System.Windows.Forms.ToolStripMenuItem();
            this.pbImmagine = new System.Windows.Forms.PictureBox();
            this.panGrafico = new System.Windows.Forms.Panel();
            this.ssStato = new System.Windows.Forms.StatusStrip();
            this.sslblScala = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsComandi = new System.Windows.Forms.ToolStrip();
            this.tscmdNuovo = new System.Windows.Forms.ToolStripButton();
            this.tscmdApri = new System.Windows.Forms.ToolStripButton();
            this.tscmdSalva = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdAnnulla = new System.Windows.Forms.ToolStripButton();
            this.tscmdCancellaTutto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdGeneraReport = new System.Windows.Forms.ToolStripButton();
            this.tscmdInfo = new System.Windows.Forms.ToolStripButton();
            this.cmdCostruisci = new System.Windows.Forms.Button();
            this.gbCosruzione = new System.Windows.Forms.GroupBox();
            this.cbCostruzione = new System.Windows.Forms.ComboBox();
            this.gbMisura = new System.Windows.Forms.GroupBox();
            this.cbMisura = new System.Windows.Forms.ComboBox();
            this.cmdMisura = new System.Windows.Forms.Button();
            this.panImmagine = new System.Windows.Forms.Panel();
            this.tabcGrafico = new System.Windows.Forms.TabControl();
            this.tabPage_Immagine = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnZoomPiuImg = new System.Windows.Forms.Button();
            this.btnZoomMenoImg = new System.Windows.Forms.Button();
            this.btnResetZoomImg = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDDiametroCerchio = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.chbRilevaPunto = new System.Windows.Forms.CheckBox();
            this.tabPage_Costruzioni = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnZoomPiuGr = new System.Windows.Forms.Button();
            this.btnZoomMenoGr = new System.Windows.Forms.Button();
            this.btnResetZoomGr = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.gbAllineamento.SuspendLayout();
            this.cmslbElementi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImmagine)).BeginInit();
            this.ssStato.SuspendLayout();
            this.tsComandi.SuspendLayout();
            this.gbCosruzione.SuspendLayout();
            this.gbMisura.SuspendLayout();
            this.panImmagine.SuspendLayout();
            this.tabcGrafico.SuspendLayout();
            this.tabPage_Immagine.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDiametroCerchio)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.tabPage_Costruzioni.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbModalitaScala
            // 
            this.cbModalitaScala.FormattingEnabled = true;
            this.cbModalitaScala.Items.AddRange(new object[] {
            "Distanza nota",
            "DistanzaX nota",
            "DistanzaY nota",
            "Automatica"});
            this.cbModalitaScala.Location = new System.Drawing.Point(72, 43);
            this.cbModalitaScala.Name = "cbModalitaScala";
            this.cbModalitaScala.Size = new System.Drawing.Size(215, 24);
            this.cbModalitaScala.TabIndex = 0;
            // 
            // lblModalitaScala
            // 
            this.lblModalitaScala.AutoSize = true;
            this.lblModalitaScala.Location = new System.Drawing.Point(69, 24);
            this.lblModalitaScala.Name = "lblModalitaScala";
            this.lblModalitaScala.Size = new System.Drawing.Size(218, 16);
            this.lblModalitaScala.TabIndex = 1;
            this.lblModalitaScala.Text = "Modalità di rilevamento della scala:";
            // 
            // cmdDefinisciOrigine
            // 
            this.cmdDefinisciOrigine.Enabled = false;
            this.cmdDefinisciOrigine.Location = new System.Drawing.Point(6, 21);
            this.cmdDefinisciOrigine.Name = "cmdDefinisciOrigine";
            this.cmdDefinisciOrigine.Size = new System.Drawing.Size(130, 40);
            this.cmdDefinisciOrigine.TabIndex = 2;
            this.cmdDefinisciOrigine.Text = "Definisci origine";
            this.cmdDefinisciOrigine.UseVisualStyleBackColor = true;
            this.cmdDefinisciOrigine.Click += new System.EventHandler(this.cmdDefinisciOrigine_Click);
            // 
            // cmdDefinisciAsseX
            // 
            this.cmdDefinisciAsseX.Enabled = false;
            this.cmdDefinisciAsseX.Location = new System.Drawing.Point(160, 21);
            this.cmdDefinisciAsseX.Name = "cmdDefinisciAsseX";
            this.cmdDefinisciAsseX.Size = new System.Drawing.Size(130, 40);
            this.cmdDefinisciAsseX.TabIndex = 3;
            this.cmdDefinisciAsseX.Text = "Definisci asse X";
            this.cmdDefinisciAsseX.UseVisualStyleBackColor = true;
            // 
            // cmdDefinisciAsseY
            // 
            this.cmdDefinisciAsseY.Enabled = false;
            this.cmdDefinisciAsseY.Location = new System.Drawing.Point(314, 21);
            this.cmdDefinisciAsseY.Name = "cmdDefinisciAsseY";
            this.cmdDefinisciAsseY.Size = new System.Drawing.Size(130, 40);
            this.cmdDefinisciAsseY.TabIndex = 4;
            this.cmdDefinisciAsseY.Text = "Definisci asse Y";
            this.cmdDefinisciAsseY.UseVisualStyleBackColor = true;
            // 
            // gbAllineamento
            // 
            this.gbAllineamento.Controls.Add(this.cmdDefinisciOrigine);
            this.gbAllineamento.Controls.Add(this.cmdDefinisciAsseX);
            this.gbAllineamento.Controls.Add(this.cmdDefinisciAsseY);
            this.gbAllineamento.Location = new System.Drawing.Point(3, 3);
            this.gbAllineamento.Name = "gbAllineamento";
            this.gbAllineamento.Size = new System.Drawing.Size(450, 75);
            this.gbAllineamento.TabIndex = 5;
            this.gbAllineamento.TabStop = false;
            this.gbAllineamento.Text = "Allineamento";
            // 
            // lbElementi
            // 
            this.lbElementi.ContextMenuStrip = this.cmslbElementi;
            this.lbElementi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbElementi.Enabled = false;
            this.lbElementi.FormattingEnabled = true;
            this.lbElementi.ItemHeight = 16;
            this.lbElementi.Location = new System.Drawing.Point(1553, 123);
            this.lbElementi.Name = "lbElementi";
            this.lbElementi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbElementi.Size = new System.Drawing.Size(344, 781);
            this.lbElementi.TabIndex = 12;
            this.lbElementi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbElementi_MouseDown);
            // 
            // cmslbElementi
            // 
            this.cmslbElementi.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmslbElementi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmImpostaTolleranze});
            this.cmslbElementi.Name = "cmslbElementi";
            this.cmslbElementi.Size = new System.Drawing.Size(203, 28);
            // 
            // tsmImpostaTolleranze
            // 
            this.tsmImpostaTolleranze.Name = "tsmImpostaTolleranze";
            this.tsmImpostaTolleranze.Size = new System.Drawing.Size(202, 24);
            this.tsmImpostaTolleranze.Text = "Imposta tolleranze";
            this.tsmImpostaTolleranze.Click += new System.EventHandler(this.tsmImpostaTolleranze_Click);
            // 
            // pbImmagine
            // 
            this.pbImmagine.Location = new System.Drawing.Point(3, 3);
            this.pbImmagine.Name = "pbImmagine";
            this.pbImmagine.Size = new System.Drawing.Size(50, 50);
            this.pbImmagine.TabIndex = 13;
            this.pbImmagine.TabStop = false;
            this.pbImmagine.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImmagine_Paint);
            this.pbImmagine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbImmagine_MouseClick);
            this.pbImmagine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImmagine_MouseDown);
            this.pbImmagine.MouseEnter += new System.EventHandler(this.pbImmagine_MouseEnter);
            this.pbImmagine.MouseLeave += new System.EventHandler(this.pbImmagine_MouseLeave);
            this.pbImmagine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbImmagine_MouseMove);
            this.pbImmagine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImmagine_MouseUp);
            // 
            // panGrafico
            // 
            this.panGrafico.AutoScroll = true;
            this.panGrafico.BackColor = System.Drawing.Color.White;
            this.panGrafico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGrafico.Location = new System.Drawing.Point(3, 3);
            this.panGrafico.Name = "panGrafico";
            this.panGrafico.Size = new System.Drawing.Size(1524, 690);
            this.panGrafico.TabIndex = 14;
            this.panGrafico.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panGrafico_Scroll);
            this.panGrafico.Paint += new System.Windows.Forms.PaintEventHandler(this.panGrafico_Paint);
            this.panGrafico.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panGrafico_MouseDown);
            // 
            // ssStato
            // 
            this.ssStato.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssStato.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslblScala,
            this.toolStripStatusLabel2});
            this.ssStato.Location = new System.Drawing.Point(0, 934);
            this.ssStato.Name = "ssStato";
            this.ssStato.Size = new System.Drawing.Size(1900, 26);
            this.ssStato.TabIndex = 15;
            this.ssStato.Text = "statusStrip1";
            // 
            // sslblScala
            // 
            this.sslblScala.Name = "sslblScala";
            this.sslblScala.Size = new System.Drawing.Size(73, 20);
            this.sslblScala.Text = "Scala: ND";
            this.sslblScala.TextChanged += new System.EventHandler(this.sslblScala_TextChanged);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 20);
            // 
            // tsComandi
            // 
            this.tsComandi.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsComandi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscmdNuovo,
            this.tscmdApri,
            this.tscmdSalva,
            this.toolStripSeparator1,
            this.tscmdAnnulla,
            this.tscmdCancellaTutto,
            this.toolStripSeparator2,
            this.tscmdGeneraReport,
            this.toolStripSeparator3,
            this.tscmdInfo});
            this.tsComandi.Location = new System.Drawing.Point(0, 0);
            this.tsComandi.Name = "tsComandi";
            this.tsComandi.Size = new System.Drawing.Size(1900, 27);
            this.tsComandi.TabIndex = 17;
            this.tsComandi.Text = "toolStrip1";
            // 
            // tscmdNuovo
            // 
            this.tscmdNuovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscmdNuovo.Image = ((System.Drawing.Image)(resources.GetObject("tscmdNuovo.Image")));
            this.tscmdNuovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdNuovo.Name = "tscmdNuovo";
            this.tscmdNuovo.Size = new System.Drawing.Size(29, 24);
            this.tscmdNuovo.Text = "toolStripButton1";
            this.tscmdNuovo.ToolTipText = "Nuovo";
            this.tscmdNuovo.Click += new System.EventHandler(this.tscmdNuovo_Click);
            // 
            // tscmdApri
            // 
            this.tscmdApri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscmdApri.Image = ((System.Drawing.Image)(resources.GetObject("tscmdApri.Image")));
            this.tscmdApri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdApri.Name = "tscmdApri";
            this.tscmdApri.Size = new System.Drawing.Size(29, 24);
            this.tscmdApri.Text = "toolStripButton1";
            this.tscmdApri.ToolTipText = "Apri";
            this.tscmdApri.Click += new System.EventHandler(this.tscmdApri_Click);
            // 
            // tscmdSalva
            // 
            this.tscmdSalva.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscmdSalva.Image = ((System.Drawing.Image)(resources.GetObject("tscmdSalva.Image")));
            this.tscmdSalva.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdSalva.Name = "tscmdSalva";
            this.tscmdSalva.Size = new System.Drawing.Size(29, 24);
            this.tscmdSalva.Text = "toolStripButton1";
            this.tscmdSalva.ToolTipText = "Salva";
            this.tscmdSalva.Click += new System.EventHandler(this.tscmdSalva_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tscmdAnnulla
            // 
            this.tscmdAnnulla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscmdAnnulla.Image = ((System.Drawing.Image)(resources.GetObject("tscmdAnnulla.Image")));
            this.tscmdAnnulla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdAnnulla.Name = "tscmdAnnulla";
            this.tscmdAnnulla.Size = new System.Drawing.Size(29, 24);
            this.tscmdAnnulla.Text = "toolStripButton1";
            this.tscmdAnnulla.ToolTipText = "Annulla";
            this.tscmdAnnulla.Click += new System.EventHandler(this.tscmdAnnulla_Click);
            // 
            // tscmdCancellaTutto
            // 
            this.tscmdCancellaTutto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscmdCancellaTutto.Image = ((System.Drawing.Image)(resources.GetObject("tscmdCancellaTutto.Image")));
            this.tscmdCancellaTutto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdCancellaTutto.Name = "tscmdCancellaTutto";
            this.tscmdCancellaTutto.Size = new System.Drawing.Size(29, 24);
            this.tscmdCancellaTutto.Text = "toolStripButton1";
            this.tscmdCancellaTutto.ToolTipText = "Cancella tutto";
            this.tscmdCancellaTutto.Click += new System.EventHandler(this.tscmdCancellaTutto_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tscmdGeneraReport
            // 
            this.tscmdGeneraReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscmdGeneraReport.Image = ((System.Drawing.Image)(resources.GetObject("tscmdGeneraReport.Image")));
            this.tscmdGeneraReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdGeneraReport.Name = "tscmdGeneraReport";
            this.tscmdGeneraReport.Size = new System.Drawing.Size(29, 24);
            this.tscmdGeneraReport.Text = "Genera report";
            this.tscmdGeneraReport.Click += new System.EventHandler(this.tscmdGeneraReport_Click);
            // 
            // tscmdInfo
            // 
            this.tscmdInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscmdInfo.Image = ((System.Drawing.Image)(resources.GetObject("tscmdInfo.Image")));
            this.tscmdInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdInfo.Name = "tscmdInfo";
            this.tscmdInfo.Size = new System.Drawing.Size(29, 24);
            this.tscmdInfo.Text = "?";
            this.tscmdInfo.Click += new System.EventHandler(this.tscmdInfo_Click);
            // 
            // cmdCostruisci
            // 
            this.cmdCostruisci.Enabled = false;
            this.cmdCostruisci.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCostruisci.Location = new System.Drawing.Point(6, 21);
            this.cmdCostruisci.Name = "cmdCostruisci";
            this.cmdCostruisci.Size = new System.Drawing.Size(100, 40);
            this.cmdCostruisci.TabIndex = 2;
            this.cmdCostruisci.Text = "Costruisci";
            this.cmdCostruisci.UseVisualStyleBackColor = true;
            this.cmdCostruisci.Click += new System.EventHandler(this.cmdCostruisci_Click);
            // 
            // gbCosruzione
            // 
            this.gbCosruzione.Controls.Add(this.cbCostruzione);
            this.gbCosruzione.Controls.Add(this.cmdCostruisci);
            this.gbCosruzione.Location = new System.Drawing.Point(459, 3);
            this.gbCosruzione.Name = "gbCosruzione";
            this.gbCosruzione.Size = new System.Drawing.Size(450, 75);
            this.gbCosruzione.TabIndex = 11;
            this.gbCosruzione.TabStop = false;
            this.gbCosruzione.Text = "Costruzione";
            // 
            // cbCostruzione
            // 
            this.cbCostruzione.Enabled = false;
            this.cbCostruzione.FormattingEnabled = true;
            this.cbCostruzione.Items.AddRange(new object[] {
            "Punto nominale",
            "Punto da linea",
            "Punto di intersezione",
            "Punto offset",
            "Linea per due punti",
            "Linea ruotata per un punto",
            "Cerchio da centro e raggio",
            "Cerchio per tre punti",
            "Centro del cerchio"});
            this.cbCostruzione.Location = new System.Drawing.Point(112, 30);
            this.cbCostruzione.Name = "cbCostruzione";
            this.cbCostruzione.Size = new System.Drawing.Size(332, 24);
            this.cbCostruzione.TabIndex = 18;
            // 
            // gbMisura
            // 
            this.gbMisura.Controls.Add(this.cbMisura);
            this.gbMisura.Controls.Add(this.cmdMisura);
            this.gbMisura.Location = new System.Drawing.Point(915, 3);
            this.gbMisura.Name = "gbMisura";
            this.gbMisura.Size = new System.Drawing.Size(450, 75);
            this.gbMisura.TabIndex = 19;
            this.gbMisura.TabStop = false;
            this.gbMisura.Text = "Misura";
            // 
            // cbMisura
            // 
            this.cbMisura.Enabled = false;
            this.cbMisura.FormattingEnabled = true;
            this.cbMisura.Items.AddRange(new object[] {
            "Distanza",
            "Distanza X",
            "Distanza Y",
            "Diametro",
            "Raggio",
            "Angolo"});
            this.cbMisura.Location = new System.Drawing.Point(112, 30);
            this.cbMisura.Name = "cbMisura";
            this.cbMisura.Size = new System.Drawing.Size(332, 24);
            this.cbMisura.TabIndex = 18;
            // 
            // cmdMisura
            // 
            this.cmdMisura.Enabled = false;
            this.cmdMisura.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMisura.Location = new System.Drawing.Point(6, 21);
            this.cmdMisura.Name = "cmdMisura";
            this.cmdMisura.Size = new System.Drawing.Size(100, 40);
            this.cmdMisura.TabIndex = 2;
            this.cmdMisura.Text = "Misura";
            this.cmdMisura.UseVisualStyleBackColor = true;
            this.cmdMisura.Click += new System.EventHandler(this.cmdMisura_Click);
            // 
            // panImmagine
            // 
            this.panImmagine.AutoScroll = true;
            this.panImmagine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panImmagine.Controls.Add(this.pbImmagine);
            this.panImmagine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panImmagine.Location = new System.Drawing.Point(3, 3);
            this.panImmagine.Name = "panImmagine";
            this.panImmagine.Size = new System.Drawing.Size(1524, 690);
            this.panImmagine.TabIndex = 20;
            // 
            // tabcGrafico
            // 
            this.tabcGrafico.Controls.Add(this.tabPage_Immagine);
            this.tabcGrafico.Controls.Add(this.tabPage_Costruzioni);
            this.tabcGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcGrafico.Location = new System.Drawing.Point(3, 123);
            this.tabcGrafico.Name = "tabcGrafico";
            this.tabcGrafico.SelectedIndex = 0;
            this.tabcGrafico.Size = new System.Drawing.Size(1544, 781);
            this.tabcGrafico.TabIndex = 14;
            // 
            // tabPage_Immagine
            // 
            this.tabPage_Immagine.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_Immagine.Controls.Add(this.tableLayoutPanel2);
            this.tabPage_Immagine.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Immagine.Name = "tabPage_Immagine";
            this.tabPage_Immagine.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Immagine.Size = new System.Drawing.Size(1536, 752);
            this.tabPage_Immagine.TabIndex = 0;
            this.tabPage_Immagine.Text = "Immagine";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.panImmagine, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1530, 746);
            this.tableLayoutPanel2.TabIndex = 27;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33112F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33445F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33445F));
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel3, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 699);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1524, 44);
            this.tableLayoutPanel4.TabIndex = 21;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnZoomPiuImg);
            this.flowLayoutPanel2.Controls.Add(this.btnZoomMenoImg);
            this.flowLayoutPanel2.Controls.Add(this.btnResetZoomImg);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(501, 38);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnZoomPiuImg
            // 
            this.btnZoomPiuImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZoomPiuImg.BackgroundImage")));
            this.btnZoomPiuImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomPiuImg.Enabled = false;
            this.btnZoomPiuImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomPiuImg.Location = new System.Drawing.Point(3, 3);
            this.btnZoomPiuImg.Name = "btnZoomPiuImg";
            this.btnZoomPiuImg.Size = new System.Drawing.Size(51, 34);
            this.btnZoomPiuImg.TabIndex = 21;
            this.btnZoomPiuImg.UseVisualStyleBackColor = true;
            this.btnZoomPiuImg.Click += new System.EventHandler(this.btnZoomPiuImg_Click);
            // 
            // btnZoomMenoImg
            // 
            this.btnZoomMenoImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZoomMenoImg.BackgroundImage")));
            this.btnZoomMenoImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomMenoImg.Enabled = false;
            this.btnZoomMenoImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomMenoImg.Location = new System.Drawing.Point(60, 3);
            this.btnZoomMenoImg.Name = "btnZoomMenoImg";
            this.btnZoomMenoImg.Size = new System.Drawing.Size(51, 34);
            this.btnZoomMenoImg.TabIndex = 22;
            this.btnZoomMenoImg.UseVisualStyleBackColor = true;
            this.btnZoomMenoImg.Click += new System.EventHandler(this.btnZoomMenoImg_Click);
            // 
            // btnResetZoomImg
            // 
            this.btnResetZoomImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnResetZoomImg.BackgroundImage")));
            this.btnResetZoomImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResetZoomImg.Enabled = false;
            this.btnResetZoomImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetZoomImg.Location = new System.Drawing.Point(117, 3);
            this.btnResetZoomImg.Name = "btnResetZoomImg";
            this.btnResetZoomImg.Size = new System.Drawing.Size(51, 34);
            this.btnResetZoomImg.TabIndex = 23;
            this.btnResetZoomImg.UseVisualStyleBackColor = true;
            this.btnResetZoomImg.Click += new System.EventHandler(this.btnResetZoomImg_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nUDDiametroCerchio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(510, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 38);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Diametro visualizzato (pixel):";
            // 
            // nUDDiametroCerchio
            // 
            this.nUDDiametroCerchio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nUDDiametroCerchio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDDiametroCerchio.Location = new System.Drawing.Point(192, 8);
            this.nUDDiametroCerchio.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDDiametroCerchio.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDDiametroCerchio.Name = "nUDDiametroCerchio";
            this.nUDDiametroCerchio.Size = new System.Drawing.Size(58, 22);
            this.nUDDiametroCerchio.TabIndex = 25;
            this.nUDDiametroCerchio.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.chbRilevaPunto);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(1018, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(503, 38);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // chbRilevaPunto
            // 
            this.chbRilevaPunto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbRilevaPunto.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbRilevaPunto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chbRilevaPunto.BackgroundImage")));
            this.chbRilevaPunto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chbRilevaPunto.Enabled = false;
            this.chbRilevaPunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbRilevaPunto.Location = new System.Drawing.Point(466, 3);
            this.chbRilevaPunto.Name = "chbRilevaPunto";
            this.chbRilevaPunto.Size = new System.Drawing.Size(34, 34);
            this.chbRilevaPunto.TabIndex = 26;
            this.chbRilevaPunto.UseVisualStyleBackColor = true;
            this.chbRilevaPunto.CheckedChanged += new System.EventHandler(this.chbRilevaPunto_CheckedChanged);
            // 
            // tabPage_Costruzioni
            // 
            this.tabPage_Costruzioni.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_Costruzioni.Controls.Add(this.tableLayoutPanel3);
            this.tabPage_Costruzioni.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Costruzioni.Name = "tabPage_Costruzioni";
            this.tabPage_Costruzioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Costruzioni.Size = new System.Drawing.Size(1536, 752);
            this.tabPage_Costruzioni.TabIndex = 1;
            this.tabPage_Costruzioni.Text = "Costruzioni";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.panGrafico, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1530, 746);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnZoomPiuGr);
            this.panel3.Controls.Add(this.btnZoomMenoGr);
            this.panel3.Controls.Add(this.btnResetZoomGr);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 699);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1524, 44);
            this.panel3.TabIndex = 15;
            // 
            // btnZoomPiuGr
            // 
            this.btnZoomPiuGr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZoomPiuGr.BackgroundImage")));
            this.btnZoomPiuGr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomPiuGr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomPiuGr.Location = new System.Drawing.Point(4, 4);
            this.btnZoomPiuGr.Name = "btnZoomPiuGr";
            this.btnZoomPiuGr.Size = new System.Drawing.Size(51, 34);
            this.btnZoomPiuGr.TabIndex = 24;
            this.btnZoomPiuGr.UseVisualStyleBackColor = true;
            this.btnZoomPiuGr.Click += new System.EventHandler(this.btnZoomPiuGr_Click);
            // 
            // btnZoomMenoGr
            // 
            this.btnZoomMenoGr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZoomMenoGr.BackgroundImage")));
            this.btnZoomMenoGr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomMenoGr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomMenoGr.Location = new System.Drawing.Point(61, 4);
            this.btnZoomMenoGr.Name = "btnZoomMenoGr";
            this.btnZoomMenoGr.Size = new System.Drawing.Size(51, 34);
            this.btnZoomMenoGr.TabIndex = 25;
            this.btnZoomMenoGr.UseVisualStyleBackColor = true;
            this.btnZoomMenoGr.Click += new System.EventHandler(this.btnZoomMenoGr_Click);
            // 
            // btnResetZoomGr
            // 
            this.btnResetZoomGr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnResetZoomGr.BackgroundImage")));
            this.btnResetZoomGr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResetZoomGr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetZoomGr.Location = new System.Drawing.Point(118, 4);
            this.btnResetZoomGr.Name = "btnResetZoomGr";
            this.btnResetZoomGr.Size = new System.Drawing.Size(51, 34);
            this.btnResetZoomGr.TabIndex = 26;
            this.btnResetZoomGr.UseVisualStyleBackColor = true;
            this.btnResetZoomGr.Click += new System.EventHandler(this.btnResetZoomGr_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabcGrafico, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbElementi, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1900, 907);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.gbAllineamento);
            this.flowLayoutPanel1.Controls.Add(this.gbCosruzione);
            this.flowLayoutPanel1.Controls.Add(this.gbMisura);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 23);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1544, 94);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblModalitaScala);
            this.panel1.Controls.Add(this.cbModalitaScala);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1553, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 94);
            this.panel1.TabIndex = 15;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 960);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tsComandi);
            this.Controls.Add(this.ssStato);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.Text = "Open2DMeasure";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbAllineamento.ResumeLayout(false);
            this.cmslbElementi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImmagine)).EndInit();
            this.ssStato.ResumeLayout(false);
            this.ssStato.PerformLayout();
            this.tsComandi.ResumeLayout(false);
            this.tsComandi.PerformLayout();
            this.gbCosruzione.ResumeLayout(false);
            this.gbMisura.ResumeLayout(false);
            this.panImmagine.ResumeLayout(false);
            this.tabcGrafico.ResumeLayout(false);
            this.tabPage_Immagine.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDiametroCerchio)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.tabPage_Costruzioni.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbModalitaScala;
        private System.Windows.Forms.Label lblModalitaScala;
        private System.Windows.Forms.Button cmdDefinisciOrigine;
        private System.Windows.Forms.Button cmdDefinisciAsseX;
        private System.Windows.Forms.Button cmdDefinisciAsseY;
        private System.Windows.Forms.GroupBox gbAllineamento;
        private System.Windows.Forms.ListBox lbElementi;
        private System.Windows.Forms.PictureBox pbImmagine;
        private System.Windows.Forms.Panel panGrafico;
        private System.Windows.Forms.StatusStrip ssStato;
        private System.Windows.Forms.ToolStripStatusLabel sslblScala;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStrip tsComandi;
        private System.Windows.Forms.ToolStripButton tscmdNuovo;
        private System.Windows.Forms.ToolStripButton tscmdApri;
        private System.Windows.Forms.ToolStripButton tscmdSalva;
        private System.Windows.Forms.ToolStripButton tscmdAnnulla;
        private System.Windows.Forms.ToolStripButton tscmdCancellaTutto;
        private System.Windows.Forms.Button cmdCostruisci;
        private System.Windows.Forms.GroupBox gbCosruzione;
        private System.Windows.Forms.ComboBox cbCostruzione;
        private System.Windows.Forms.GroupBox gbMisura;
        private System.Windows.Forms.ComboBox cbMisura;
        private System.Windows.Forms.Button cmdMisura;
        private System.Windows.Forms.Panel panImmagine;
        private System.Windows.Forms.TabControl tabcGrafico;
        private System.Windows.Forms.TabPage tabPage_Immagine;
        private System.Windows.Forms.TabPage tabPage_Costruzioni;
        private Button btnZoomMenoGr;
        private Button btnZoomPiuGr;
        private Button btnResetZoomGr;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Button btnZoomPiuImg;
        private Button btnZoomMenoImg;
        private Button btnResetZoomImg;
        private CheckBox chbRilevaPunto;
        private NumericUpDown nUDDiametroCerchio;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel3;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tscmdGeneraReport;
        private ContextMenuStrip cmslbElementi;
        private ToolStripMenuItem tsmImpostaTolleranze;
        private ToolStripButton tscmdInfo;
        private ToolStripSeparator toolStripSeparator3;
    }
}

