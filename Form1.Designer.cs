
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
            this.tsLingua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsComandi = new System.Windows.Forms.ToolStrip();
            this.tscmdNuovo = new System.Windows.Forms.ToolStripButton();
            this.tscmdApri = new System.Windows.Forms.ToolStripButton();
            this.tscmdSalva = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdAnnulla = new System.Windows.Forms.ToolStripButton();
            this.tscmdCancellaTutto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdGeneraReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdInfo = new System.Windows.Forms.ToolStripButton();
            this.cmdCostruisci = new System.Windows.Forms.Button();
            this.gbCostruzione = new System.Windows.Forms.GroupBox();
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
            this.lblDiametroVisualizzato = new System.Windows.Forms.Label();
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
            this.gbAllineamento.SuspendLayout();
            this.cmslbElementi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImmagine)).BeginInit();
            this.ssStato.SuspendLayout();
            this.tsComandi.SuspendLayout();
            this.gbCostruzione.SuspendLayout();
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
            resources.GetString("cbModalitaScala.Items"),
            resources.GetString("cbModalitaScala.Items1"),
            resources.GetString("cbModalitaScala.Items2"),
            resources.GetString("cbModalitaScala.Items3")});
            resources.ApplyResources(this.cbModalitaScala, "cbModalitaScala");
            this.cbModalitaScala.Name = "cbModalitaScala";
            // 
            // lblModalitaScala
            // 
            resources.ApplyResources(this.lblModalitaScala, "lblModalitaScala");
            this.lblModalitaScala.Name = "lblModalitaScala";
            // 
            // cmdDefinisciOrigine
            // 
            resources.ApplyResources(this.cmdDefinisciOrigine, "cmdDefinisciOrigine");
            this.cmdDefinisciOrigine.Name = "cmdDefinisciOrigine";
            this.cmdDefinisciOrigine.UseVisualStyleBackColor = true;
            this.cmdDefinisciOrigine.Click += new System.EventHandler(this.cmdDefinisciOrigine_Click);
            // 
            // cmdDefinisciAsseX
            // 
            resources.ApplyResources(this.cmdDefinisciAsseX, "cmdDefinisciAsseX");
            this.cmdDefinisciAsseX.Name = "cmdDefinisciAsseX";
            this.cmdDefinisciAsseX.UseVisualStyleBackColor = true;
            this.cmdDefinisciAsseX.Click += new System.EventHandler(this.cmdDefinisciAsseX_Click);
            // 
            // cmdDefinisciAsseY
            // 
            resources.ApplyResources(this.cmdDefinisciAsseY, "cmdDefinisciAsseY");
            this.cmdDefinisciAsseY.Name = "cmdDefinisciAsseY";
            this.cmdDefinisciAsseY.UseVisualStyleBackColor = true;
            this.cmdDefinisciAsseY.Click += new System.EventHandler(this.cmdDefinisciAsseY_Click);
            // 
            // gbAllineamento
            // 
            this.gbAllineamento.Controls.Add(this.cmdDefinisciOrigine);
            this.gbAllineamento.Controls.Add(this.cmdDefinisciAsseX);
            this.gbAllineamento.Controls.Add(this.cmdDefinisciAsseY);
            resources.ApplyResources(this.gbAllineamento, "gbAllineamento");
            this.gbAllineamento.Name = "gbAllineamento";
            this.gbAllineamento.TabStop = false;
            // 
            // lbElementi
            // 
            this.lbElementi.ContextMenuStrip = this.cmslbElementi;
            resources.ApplyResources(this.lbElementi, "lbElementi");
            this.lbElementi.FormattingEnabled = true;
            this.lbElementi.Name = "lbElementi";
            this.lbElementi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbElementi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbElementi_MouseDown);
            // 
            // cmslbElementi
            // 
            this.cmslbElementi.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmslbElementi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmImpostaTolleranze});
            this.cmslbElementi.Name = "cmslbElementi";
            resources.ApplyResources(this.cmslbElementi, "cmslbElementi");
            // 
            // tsmImpostaTolleranze
            // 
            this.tsmImpostaTolleranze.Name = "tsmImpostaTolleranze";
            resources.ApplyResources(this.tsmImpostaTolleranze, "tsmImpostaTolleranze");
            this.tsmImpostaTolleranze.Click += new System.EventHandler(this.tsmImpostaTolleranze_Click);
            // 
            // pbImmagine
            // 
            resources.ApplyResources(this.pbImmagine, "pbImmagine");
            this.pbImmagine.Name = "pbImmagine";
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
            resources.ApplyResources(this.panGrafico, "panGrafico");
            this.panGrafico.BackColor = System.Drawing.Color.White;
            this.panGrafico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panGrafico.Name = "panGrafico";
            this.panGrafico.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panGrafico_Scroll);
            this.panGrafico.Paint += new System.Windows.Forms.PaintEventHandler(this.panGrafico_Paint);
            this.panGrafico.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panGrafico_MouseDown);
            // 
            // ssStato
            // 
            this.ssStato.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssStato.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLingua,
            this.sslblScala});
            resources.ApplyResources(this.ssStato, "ssStato");
            this.ssStato.Name = "ssStato";
            // 
            // sslblScala
            // 
            this.sslblScala.Name = "sslblScala";
            resources.ApplyResources(this.sslblScala, "sslblScala");
            this.sslblScala.TextChanged += new System.EventHandler(this.sslblScala_TextChanged);
            // 
            // tsLingua
            // 
            this.tsLingua.IsLink = true;
            this.tsLingua.Name = "tsLingua";
            resources.ApplyResources(this.tsLingua, "tsLingua");
            this.tsLingua.Click += new System.EventHandler(this.tsLingua_Click);
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
            resources.ApplyResources(this.tsComandi, "tsComandi");
            this.tsComandi.Name = "tsComandi";
            // 
            // tscmdNuovo
            // 
            this.tscmdNuovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tscmdNuovo, "tscmdNuovo");
            this.tscmdNuovo.Name = "tscmdNuovo";
            this.tscmdNuovo.Click += new System.EventHandler(this.tscmdNuovo_Click);
            // 
            // tscmdApri
            // 
            this.tscmdApri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tscmdApri, "tscmdApri");
            this.tscmdApri.Name = "tscmdApri";
            this.tscmdApri.Click += new System.EventHandler(this.tscmdApri_Click);
            // 
            // tscmdSalva
            // 
            this.tscmdSalva.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tscmdSalva, "tscmdSalva");
            this.tscmdSalva.Name = "tscmdSalva";
            this.tscmdSalva.Click += new System.EventHandler(this.tscmdSalva_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tscmdAnnulla
            // 
            this.tscmdAnnulla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tscmdAnnulla, "tscmdAnnulla");
            this.tscmdAnnulla.Name = "tscmdAnnulla";
            this.tscmdAnnulla.Click += new System.EventHandler(this.tscmdAnnulla_Click);
            // 
            // tscmdCancellaTutto
            // 
            this.tscmdCancellaTutto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tscmdCancellaTutto, "tscmdCancellaTutto");
            this.tscmdCancellaTutto.Name = "tscmdCancellaTutto";
            this.tscmdCancellaTutto.Click += new System.EventHandler(this.tscmdCancellaTutto_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tscmdGeneraReport
            // 
            this.tscmdGeneraReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tscmdGeneraReport, "tscmdGeneraReport");
            this.tscmdGeneraReport.Name = "tscmdGeneraReport";
            this.tscmdGeneraReport.Click += new System.EventHandler(this.tscmdGeneraReport_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tscmdInfo
            // 
            this.tscmdInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tscmdInfo, "tscmdInfo");
            this.tscmdInfo.Name = "tscmdInfo";
            this.tscmdInfo.Click += new System.EventHandler(this.tscmdInfo_Click);
            // 
            // cmdCostruisci
            // 
            resources.ApplyResources(this.cmdCostruisci, "cmdCostruisci");
            this.cmdCostruisci.Name = "cmdCostruisci";
            this.cmdCostruisci.UseVisualStyleBackColor = true;
            this.cmdCostruisci.Click += new System.EventHandler(this.cmdCostruisci_Click);
            // 
            // gbCostruzione
            // 
            this.gbCostruzione.Controls.Add(this.cbCostruzione);
            this.gbCostruzione.Controls.Add(this.cmdCostruisci);
            resources.ApplyResources(this.gbCostruzione, "gbCostruzione");
            this.gbCostruzione.Name = "gbCostruzione";
            this.gbCostruzione.TabStop = false;
            // 
            // cbCostruzione
            // 
            resources.ApplyResources(this.cbCostruzione, "cbCostruzione");
            this.cbCostruzione.FormattingEnabled = true;
            this.cbCostruzione.Items.AddRange(new object[] {
            resources.GetString("cbCostruzione.Items"),
            resources.GetString("cbCostruzione.Items1"),
            resources.GetString("cbCostruzione.Items2"),
            resources.GetString("cbCostruzione.Items3"),
            resources.GetString("cbCostruzione.Items4"),
            resources.GetString("cbCostruzione.Items5"),
            resources.GetString("cbCostruzione.Items6"),
            resources.GetString("cbCostruzione.Items7"),
            resources.GetString("cbCostruzione.Items8")});
            this.cbCostruzione.Name = "cbCostruzione";
            // 
            // gbMisura
            // 
            this.gbMisura.Controls.Add(this.cbMisura);
            this.gbMisura.Controls.Add(this.cmdMisura);
            resources.ApplyResources(this.gbMisura, "gbMisura");
            this.gbMisura.Name = "gbMisura";
            this.gbMisura.TabStop = false;
            // 
            // cbMisura
            // 
            resources.ApplyResources(this.cbMisura, "cbMisura");
            this.cbMisura.FormattingEnabled = true;
            this.cbMisura.Items.AddRange(new object[] {
            resources.GetString("cbMisura.Items"),
            resources.GetString("cbMisura.Items1"),
            resources.GetString("cbMisura.Items2"),
            resources.GetString("cbMisura.Items3"),
            resources.GetString("cbMisura.Items4"),
            resources.GetString("cbMisura.Items5")});
            this.cbMisura.Name = "cbMisura";
            // 
            // cmdMisura
            // 
            resources.ApplyResources(this.cmdMisura, "cmdMisura");
            this.cmdMisura.Name = "cmdMisura";
            this.cmdMisura.UseVisualStyleBackColor = true;
            this.cmdMisura.Click += new System.EventHandler(this.cmdMisura_Click);
            // 
            // panImmagine
            // 
            resources.ApplyResources(this.panImmagine, "panImmagine");
            this.panImmagine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panImmagine.Controls.Add(this.pbImmagine);
            this.panImmagine.Name = "panImmagine";
            // 
            // tabcGrafico
            // 
            this.tabcGrafico.Controls.Add(this.tabPage_Immagine);
            this.tabcGrafico.Controls.Add(this.tabPage_Costruzioni);
            resources.ApplyResources(this.tabcGrafico, "tabcGrafico");
            this.tabcGrafico.Name = "tabcGrafico";
            this.tabcGrafico.SelectedIndex = 0;
            // 
            // tabPage_Immagine
            // 
            this.tabPage_Immagine.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_Immagine.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.tabPage_Immagine, "tabPage_Immagine");
            this.tabPage_Immagine.Name = "tabPage_Immagine";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.panImmagine, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel3, 2, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnZoomPiuImg);
            this.flowLayoutPanel2.Controls.Add(this.btnZoomMenoImg);
            this.flowLayoutPanel2.Controls.Add(this.btnResetZoomImg);
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // btnZoomPiuImg
            // 
            resources.ApplyResources(this.btnZoomPiuImg, "btnZoomPiuImg");
            this.btnZoomPiuImg.Name = "btnZoomPiuImg";
            this.btnZoomPiuImg.UseVisualStyleBackColor = true;
            this.btnZoomPiuImg.Click += new System.EventHandler(this.btnZoomPiuImg_Click);
            // 
            // btnZoomMenoImg
            // 
            resources.ApplyResources(this.btnZoomMenoImg, "btnZoomMenoImg");
            this.btnZoomMenoImg.Name = "btnZoomMenoImg";
            this.btnZoomMenoImg.UseVisualStyleBackColor = true;
            this.btnZoomMenoImg.Click += new System.EventHandler(this.btnZoomMenoImg_Click);
            // 
            // btnResetZoomImg
            // 
            resources.ApplyResources(this.btnResetZoomImg, "btnResetZoomImg");
            this.btnResetZoomImg.Name = "btnResetZoomImg";
            this.btnResetZoomImg.UseVisualStyleBackColor = true;
            this.btnResetZoomImg.Click += new System.EventHandler(this.btnResetZoomImg_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDiametroVisualizzato);
            this.panel2.Controls.Add(this.nUDDiametroCerchio);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // lblDiametroVisualizzato
            // 
            resources.ApplyResources(this.lblDiametroVisualizzato, "lblDiametroVisualizzato");
            this.lblDiametroVisualizzato.Name = "lblDiametroVisualizzato";
            // 
            // nUDDiametroCerchio
            // 
            resources.ApplyResources(this.nUDDiametroCerchio, "nUDDiametroCerchio");
            this.nUDDiametroCerchio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
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
            this.nUDDiametroCerchio.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
            this.flowLayoutPanel3.Controls.Add(this.chbRilevaPunto);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            // 
            // chbRilevaPunto
            // 
            resources.ApplyResources(this.chbRilevaPunto, "chbRilevaPunto");
            this.chbRilevaPunto.Name = "chbRilevaPunto";
            this.chbRilevaPunto.UseVisualStyleBackColor = true;
            this.chbRilevaPunto.CheckedChanged += new System.EventHandler(this.chbRilevaPunto_CheckedChanged);
            // 
            // tabPage_Costruzioni
            // 
            this.tabPage_Costruzioni.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_Costruzioni.Controls.Add(this.tableLayoutPanel3);
            resources.ApplyResources(this.tabPage_Costruzioni, "tabPage_Costruzioni");
            this.tabPage_Costruzioni.Name = "tabPage_Costruzioni";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.panGrafico, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnZoomPiuGr);
            this.panel3.Controls.Add(this.btnZoomMenoGr);
            this.panel3.Controls.Add(this.btnResetZoomGr);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // btnZoomPiuGr
            // 
            resources.ApplyResources(this.btnZoomPiuGr, "btnZoomPiuGr");
            this.btnZoomPiuGr.Name = "btnZoomPiuGr";
            this.btnZoomPiuGr.UseVisualStyleBackColor = true;
            this.btnZoomPiuGr.Click += new System.EventHandler(this.btnZoomPiuGr_Click);
            // 
            // btnZoomMenoGr
            // 
            resources.ApplyResources(this.btnZoomMenoGr, "btnZoomMenoGr");
            this.btnZoomMenoGr.Name = "btnZoomMenoGr";
            this.btnZoomMenoGr.UseVisualStyleBackColor = true;
            this.btnZoomMenoGr.Click += new System.EventHandler(this.btnZoomMenoGr_Click);
            // 
            // btnResetZoomGr
            // 
            resources.ApplyResources(this.btnResetZoomGr, "btnResetZoomGr");
            this.btnResetZoomGr.Name = "btnResetZoomGr";
            this.btnResetZoomGr.UseVisualStyleBackColor = true;
            this.btnResetZoomGr.Click += new System.EventHandler(this.btnResetZoomGr_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabcGrafico, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbElementi, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.gbAllineamento);
            this.flowLayoutPanel1.Controls.Add(this.gbCostruzione);
            this.flowLayoutPanel1.Controls.Add(this.gbMisura);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblModalitaScala);
            this.panel1.Controls.Add(this.cbModalitaScala);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tsComandi);
            this.Controls.Add(this.ssStato);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbAllineamento.ResumeLayout(false);
            this.cmslbElementi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImmagine)).EndInit();
            this.ssStato.ResumeLayout(false);
            this.ssStato.PerformLayout();
            this.tsComandi.ResumeLayout(false);
            this.tsComandi.PerformLayout();
            this.gbCostruzione.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStrip tsComandi;
        private System.Windows.Forms.ToolStripButton tscmdNuovo;
        private System.Windows.Forms.ToolStripButton tscmdApri;
        private System.Windows.Forms.ToolStripButton tscmdSalva;
        private System.Windows.Forms.ToolStripButton tscmdAnnulla;
        private System.Windows.Forms.ToolStripButton tscmdCancellaTutto;
        private System.Windows.Forms.Button cmdCostruisci;
        private System.Windows.Forms.GroupBox gbCostruzione;
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
        private Label lblDiametroVisualizzato;
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
        private ToolStripStatusLabel tsLingua;
    }
}

