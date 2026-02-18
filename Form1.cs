using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Open2DMeasure {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            lbElementi.DataSource = entitaGeometriche;
        }

        // Lista di elementi geometrici costruiti
        private BindingList<Entita> entitaGeometriche = new BindingList<Entita>();

        //Variabile allineamento
        private Allineamento allineamento = new Allineamento();

        // Variabile per conservare un riferimento all'immagine originale
        private Image immagineCaricata = null;

        // Fattore di zoom iniziale
        private double fattoreZoomImg = 1.0;
        private double fattoreZoomGr = 1;

        // Percentuale di incremento/decremento dello zoom
        private const double zoomStep = 0.05; // 5%

        // Modalità costruzione attiva
        private bool costruzioneAttiva = false;

        // Fattore generale di scala
        private double fattoreScala = 1.000;

        // Colore selezionato
        private Color coloreSelezionato = Color.Black;

        // Variabile per salvare la posizione corrente del mouse
        private Point posMouse = new Point(-1, -1);

        // Flag per sapere se il mouse è sulla PictureBox
        private bool mouseInPicturebox = false;
        private Point pA_UI, pB_UI;      // Coordinate sullo schermo (per il disegno)
        private PointF PuntoBordoImg;   // Il punto del bordo trovato (coordinate immagine)
        private bool isDragging = false;

        //Trasformazioni del pan grafico
        private float traslaGRX = 0;
        private float traslaGRY = 0;
        private double angolo = 0;



        private void cmdDefinisciOrigine_Click(object sender, EventArgs e) {
            if (lbElementi.SelectedIndices.Count == 1) {
                Punto p = null;
                object elemento = entitaGeometriche[lbElementi.SelectedIndex];
                if (elemento is Punto) {
                    p = (Punto)elemento;
                    double deltaX = p.X;
                    double deltaY = p.Y;
                    List<Entita> tmp = new List<Entita>();
                    for (int i = 0; i < entitaGeometriche.Count; i++) {
                        if (entitaGeometriche[i] is Allineamento) {
                            entitaGeometriche[i].Sposta(deltaX, deltaY);
                        } else {
                            entitaGeometriche[i].Sposta(-deltaX, -deltaY);
                        }
                        tmp.Add(entitaGeometriche[i]);
                    }
                    entitaGeometriche.Clear();
                    for (int i = 0; i < tmp.Count; i++) {
                        entitaGeometriche.Add(tmp[i]);
                    }
                    AggiornaLimiti();
                } else {
                    MessageBox.Show("L'elemento selezionato non è corretto", "ATTENZIONE!");
                }

                lbElementi.SelectedIndex = -1;
            }
        }

        private void AzzeraTutto() {
            costruzioneAttiva = false;
            fattoreZoomImg = 1.0;
            fattoreScala = 1.000;
            immagineCaricata = null;
            coloreSelezionato = Color.Black;
            foreach (Entita ent in entitaGeometriche) {
                ent.AzzeraContatore();
            }
            entitaGeometriche.Clear();
            pbImmagine.Image = null;
            AggiornaLimiti();
            cbModalitaScala.SelectedIndex = -1;
            cbCostruzione.SelectedIndex = -1;
            cbMisura.SelectedIndex = -1;
            cmdDefinisciOrigine.Enabled = false;
            cmdDefinisciAsseX.Enabled = false;
            cmdDefinisciAsseY.Enabled = false;
            cmdCostruisci.Enabled = false;
            cmdMisura.Enabled = false;
            cbCostruzione.Enabled = false;
            btnZoomPiuImg.Enabled = false;
            btnZoomMenoImg.Enabled = false;
            btnResetZoomImg.Enabled = false;
            chbRilevaPunto.Enabled = false;
            cbMisura.Enabled = false;
            sslblScala.Text = "Scala: ND";
            pbImmagine.Width = 50;
            pbImmagine.Height = 50;
            traslaGRX = 0;
            traslaGRY = 0;
            angolo = 0;
            tabcGrafico.SelectedTab = tabPage_Immagine;
            panGrafico.AutoScrollPosition = new Point(0, 0);
            allineamento = new Allineamento();
        }

        private void CaricaImmagine() {
            // Creazione di una nuova istanza di OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Impostare i filtri per i tipi di file
            // L'utente potrà vedere solo i file con queste estensioni.
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            openFileDialog.Title = "Seleziona un'immagine";

            // Mostrare la finestra di dialogo e verificare se l'utente ha selezionato un file
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                try {

                    // Carica l'immagine in un oggetto Image
                    immagineCaricata = Image.FromFile(openFileDialog.FileName);

                    // Corregge l'orientamento dell'immagine
                    CorrectImageOrientation(immagineCaricata);

                    // Assegna l'immagine alla PictureBox
                    pbImmagine.Image = new Bitmap(immagineCaricata);

                    // *** IL PASSO FONDAMENTALE ***
                    // Imposta le dimensioni della PictureBox alle dimensioni dell'immagine appena caricata
                    // Questo fa sì che il Panel "sappia" che l'immagine è più grande.
                    pbImmagine.Width = immagineCaricata.Width;
                    pbImmagine.Height = immagineCaricata.Height;
                    panGrafico.AutoScrollMinSize = new Size(pbImmagine.Width, pbImmagine.Height);

                    // Assicurati che il SizeMode sia Normal
                    pbImmagine.SizeMode = PictureBoxSizeMode.Normal;

                    //Resetta fattoreZoom
                    fattoreZoomImg = 1.0;

                    cbModalitaScala.SelectedIndex = 0;
                    btnZoomPiuImg.Enabled = true;
                    btnZoomMenoImg.Enabled = true;
                    btnResetZoomImg.Enabled = true;
                    chbRilevaPunto.Enabled = true;
                    tabcGrafico.Enabled = true;

                } catch (Exception ex) {
                    // Gestione degli errori, per esempio se il file non è un'immagine valida
                    MessageBox.Show("Errore durante il caricamento dell'immagine: " + ex.Message);
                }
            }
        }

        private void tscmdNuovo_Click(object sender, EventArgs e) {
            
            if (!costruzioneAttiva) {
                AzzeraTutto();
                CaricaImmagine();
            } else {
                var risp = Interaction.MsgBox("Sei sicuro di voler cancellare tutto?", MsgBoxStyle.YesNo, "ATTENZIONE!");
                if (risp == MsgBoxResult.Yes) {
                    AzzeraTutto();
                    CaricaImmagine();
                }
            }
        }

        private void tscmdCancellaTutto_Click(object sender, EventArgs e) {
            var risp = Interaction.MsgBox("Sei sicuro di voler cancellare tutto?", MsgBoxStyle.YesNo, "ATTENZIONE!");
            if (risp == MsgBoxResult.Yes) {
                AzzeraTutto();
            }
        }

        private void sslblScala_TextChanged(object sender, EventArgs e) {
            if (!sslblScala.Text.Contains("ND")) {
                //Attiva modalità costruzione e pulsanti dopo aver definito la scala
                costruzioneAttiva = true;
                cmdDefinisciOrigine.Enabled = true;
                cmdDefinisciAsseX.Enabled = true;
                cmdDefinisciAsseY.Enabled = true;
                cmdCostruisci.Enabled = true;
                cmdMisura.Enabled = true;
                cbCostruzione.Enabled = true;
                cbMisura.Enabled = true;
                lbElementi.Enabled = true;
                entitaGeometriche.Add(allineamento);
            }
        }

        private void CalcolaScala(Punto p) {
            switch (cbModalitaScala.SelectedIndex) {
                case -1:
                    MessageBox.Show("Non hai selezionato la modalità di rilevamento della scala", "ATTENZIONE!");
                    break;

                case 0:
                    entitaGeometriche.Add(new Punto(p.X, p.Y, false, Color.Black));
                    if (entitaGeometriche.Count == 2) {
                        bool isInputValid = false;
                        double valore;
                        do {
                            string val = Interaction.InputBox("Inserire la quota nominale:", "Inserimento");

                            isInputValid = double.TryParse(val, out valore);

                            // Se l'input non è valido, mostra un messaggio di errore
                            if (!isInputValid) {
                                MessageBox.Show("Valore non valido. Riprova.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } while (!isInputValid);

                        Misura d = new Misura((Punto)entitaGeometriche[0], (Punto)entitaGeometriche[1], false, 0, Color.Black);
                        fattoreScala = (double)d.Valore / valore / fattoreZoomImg;
                        entitaGeometriche.Clear();
                        sslblScala.Text = "Scala: " + fattoreScala.ToString("F3");
                    }
                    break;

                case 1:
                    entitaGeometriche.Add(new Punto(p.X, p.Y, false, Color.Black));
                    if (entitaGeometriche.Count == 2) {
                        bool isInputValid = false;
                        double valore;
                        do {
                            string val = Interaction.InputBox("Inserire la quota nominale:", "Inserimento");

                            isInputValid = double.TryParse(val, out valore);

                            // Se l'input non è valido, mostra un messaggio di errore
                            if (!isInputValid) {
                                MessageBox.Show("Valore non valido. Riprova.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } while (!isInputValid);

                        Misura d = new Misura((Punto)entitaGeometriche[0], (Punto)entitaGeometriche[1], false, Misura.Tipologia.DistanzaX, Color.Black);
                        fattoreScala = (double)d.ValoreX / valore / fattoreZoomImg;
                        entitaGeometriche.Clear();
                        sslblScala.Text = "Scala: " + fattoreScala.ToString("F3");
                    }
                    break;

                case 2:
                    entitaGeometriche.Add(new Punto(p.X, p.Y, false, Color.Black));
                    if (entitaGeometriche.Count == 2) {
                        bool isInputValid = false;
                        double valore;
                        do {
                            string val = Interaction.InputBox("Inserire la quota nominale:", "Inserimento");

                            isInputValid = double.TryParse(val, out valore);

                            // Se l'input non è valido, mostra un messaggio di errore
                            if (!isInputValid) {
                                MessageBox.Show("Valore non valido. Riprova.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } while (!isInputValid);

                        Misura d = new Misura((Punto)entitaGeometriche[0], (Punto)entitaGeometriche[1], false, Misura.Tipologia.DistanzaY, Color.Black);
                        fattoreScala = (double)d.ValoreY / valore / fattoreZoomImg;
                        entitaGeometriche.Clear();
                        sslblScala.Text = "Scala: " + fattoreScala.ToString("F3");
                    }
                    break;

            }
        }

        private void pbImmagine_MouseClick(object sender, MouseEventArgs e) {

        }

        private void btnZoomPiuImg_Click(object sender, EventArgs e) {

            // Aumenta il fattore di zoom
            fattoreZoomImg += (zoomStep);

            // Applica le nuove dimensioni
            ApplicaZoom();
        }

        private void btnZoomMenoImg_Click(object sender, EventArgs e) {
            // Diminuisce il fattore di zoom
            fattoreZoomImg -= (zoomStep);

            // Applica le nuove dimensioni
            ApplicaZoom();
        }

        private void btnResetZoomImg_Click(object sender, EventArgs e) {
            // Ripristina fattore zoom a 1.0
            fattoreZoomImg = 1.0;

            // Applica le nuove dimensioni
            ApplicaZoom();
        }

        // Metodo per applicare lo zoom e aggiornare la PictureBox
        private void ApplicaZoom() {
            if (immagineCaricata == null) return;

            // Calcola le nuove dimensioni in base al fattore di zoom
            int newWidth = (int)(immagineCaricata.Width * fattoreZoomImg);
            int newHeight = (int)(immagineCaricata.Height * fattoreZoomImg);

            // Crea una nuova immagine Bitmap per lo zoom
            Bitmap immagineZoom = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(immagineZoom)) {
                // Imposta una modalità di interpolazione di alta qualità per un risultato migliore
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Disegna l'immagine originale sulla nuova bitmap, ridimensionandola
                g.DrawImage(immagineCaricata, new Rectangle(0, 0, newWidth, newHeight));
            }

            // Se c'è già un'immagine, la smaltiamo per liberare memoria
            if (pbImmagine.Image != null) {
                pbImmagine.Image.Dispose();
            }

            // Assegna la nuova immagine alla PictureBox
            pbImmagine.Image = immagineZoom;

            // Esegue il ridimensionamento della PictureBox per adattarsi alla nuova immagine
            pbImmagine.SizeMode = PictureBoxSizeMode.Normal;
            pbImmagine.Width = newWidth;
            pbImmagine.Height = newHeight;
        }

        //Metodo per correggere la rotazione delle immagini
        public static void CorrectImageOrientation(Image img) {
            // L'ID del PropertyItem per l'orientamento EXIF è 0x0112 (o 274 in decimale)
            if (Array.IndexOf(img.PropertyIdList, 274) > -1) {
                var orientation = (int)img.GetPropertyItem(274).Value[0];

                // La rotazione dipende dal valore dell'orientamento
                switch (orientation) {
                    case 1: // 0°
                        break;
                    case 2: // Ribaltamento orizzontale
                        img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        break;
                    case 3: // 180°
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 4: // Ribaltamento verticale
                        img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        break;
                    case 5: // 90° e ribaltamento orizzontale
                        img.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case 6: // 90°
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 7: // 270° e ribaltamento orizzontale
                        img.RotateFlip(RotateFlipType.Rotate270FlipX);
                        break;
                    case 8: // 270°
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }

                // Rimuove i dati di orientamento EXIF dopo la correzione
                img.RemovePropertyItem(274);
            }
        }

        private void cmdCostruisci_Click(object sender, EventArgs e) {
            switch (cbCostruzione.SelectedIndex) {
                case -1:
                    MessageBox.Show("Non hai selezionato un metodo di costruzione", "ATTENZIONE!");
                    break;

                case 0: // Punto nominale
                    double x = 0, y = 0;
                    string val;
                    var invar = System.Globalization.CultureInfo.InvariantCulture;

                    // --- COORDINATA X ---
                    while (true) {
                        val = Interaction.InputBox("Inserire la coordinata X del punto:", "Inserimento", "0");

                        // Se preme Annulla (stringa vuota), esce completamente dal case
                        if (string.IsNullOrEmpty(val)) return;

                        // Normalizziamo l'input (sostituisce virgola con punto)
                        string inputNorm = val.Replace(',', '.');

                        if (double.TryParse(inputNorm, System.Globalization.NumberStyles.Any, invar, out x)) {
                            break; // Input valido, esce dal ciclo while
                        } else {
                            MessageBox.Show("Valore X non valido. Inserire un numero.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // --- COORDINATA Y ---
                    while (true) {
                        val = Interaction.InputBox("Inserire la coordinata Y del punto:", "Inserimento", "0");

                        // Se preme Annulla, esce
                        if (string.IsNullOrEmpty(val)) return;

                        // Normalizziamo l'input
                        string inputNorm = val.Replace(',', '.');

                        if (double.TryParse(inputNorm, System.Globalization.NumberStyles.Any, invar, out y)) {
                            break; // Input valido, esce dal ciclo while
                        } else {
                            MessageBox.Show("Valore Y non valido. Inserire un numero.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Se siamo arrivati qui, entrambi gli input sono validi e non ha annullato
                    entitaGeometriche.Add(new Punto(x, y, true, coloreSelezionato));
                    break;

                case 1: // Punto da linea
                    if (lbElementi.SelectedIndices.Count == 1) {
                        object elemento = entitaGeometriche[lbElementi.SelectedIndex];

                        if (elemento is Linea l) {
                            double percentuale = 0;
                            invar = System.Globalization.CultureInfo.InvariantCulture;

                            while (true) {
                                // Suggeriamo 50 (punto medio) come valore predefinito
                                val = Interaction.InputBox("Inserire la percentuale (0-100):", "Inserimento Punto su Linea", "50");

                                // 1. Gestione tasto Annulla: se la stringa è vuota, usciamo dal case
                                if (string.IsNullOrEmpty(val)) return;

                                // 2. Normalizzazione: permettiamo sia virgola che punto
                                string inputNorm = val.Replace(',', '.');

                                // 3. Parsing con InvariantCulture
                                if (double.TryParse(inputNorm, System.Globalization.NumberStyles.Any, invar, out percentuale)) {
                                    break; // Input valido, usciamo dal ciclo
                                } else {
                                    MessageBox.Show("Valore percentuale non valido. Inserire un numero.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            // Aggiunta del punto basato sulla linea e sulla percentuale fornita
                            entitaGeometriche.Add(new Punto(l, percentuale, true, coloreSelezionato));
                        } else {
                            MessageBox.Show("L'elemento selezionato non è una linea!", "ATTENZIONE!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    } else {
                        MessageBox.Show("Selezionare esattamente una linea dalla lista.", "ATTENZIONE!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                case 2: //Punto di intersezione
                    if (lbElementi.SelectedIndices.Count == 2) {
                        Linea l1 = null;
                        Linea l2 = null;
                        Cerchio c = null;
                        int lineeTrovate = 0;
                        int cerchiTrovati = 0;
                        for (int i = 0; i < lbElementi.Items.Count; i++) {
                            object elemento = entitaGeometriche[i];
                            if (lbElementi.GetSelected(i)) {
                                if ((elemento is Linea) && (l1 == null)) {
                                    l1 = (Linea)elemento;
                                    lineeTrovate++;
                                } else if ((elemento is Linea) && (l2 == null)) {
                                    l2 = (Linea)elemento;
                                    lineeTrovate++;
                                } else if (elemento is Cerchio) {
                                    c = (Cerchio)elemento;
                                    cerchiTrovati++;
                                }
                            }
                            if ((lineeTrovate == 2) || ((lineeTrovate == 1) && (cerchiTrovati == 1))) {
                                break;
                            }
                        }

                        if (lineeTrovate == 2) {
                            if (l1.M != l2.M) {
                                entitaGeometriche.Add(new Punto(l1, l2, true, coloreSelezionato));
                            } else {
                                MessageBox.Show("Le due linee sono parallele", "ATTENZIONE!");
                            }
                        } else if ((lineeTrovate == 1) && (cerchiTrovati == 1)) {
                            double dL = l1.A * c.Centro.X + l1.B * c.Centro.Y + l1.C;
                            double S = Math.Pow(l1.A, 2) + Math.Pow(l1.B, 2);
                            if (Math.Pow(c.R, 2) - (Math.Pow(dL, 2) / S) > 0) {
                                entitaGeometriche.Add(new Punto(l1, c, 1, true, coloreSelezionato));
                                entitaGeometriche.Add(new Punto(l1, c, 2, true, coloreSelezionato));
                            } else if (Math.Pow(c.R, 2) - (Math.Pow(dL, 2) / S) == 0) {
                                entitaGeometriche.Add(new Punto(l1, c, 1, true, coloreSelezionato));
                            } else {
                                MessageBox.Show("Il cerchio e la linea non si intersecano", "ATTENZIONE!");
                            }
                        } else {
                            MessageBox.Show("Gli elementi selezionati non sono corretti", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Il numero di elementi selezionati non è corretto", "ATTENZIONE!");
                    }
                    break;

                case 3: // Punto offset
                    if (lbElementi.SelectedIndices.Count == 1) {
                        object elemento = entitaGeometriche[lbElementi.SelectedIndex];

                        if (elemento is Punto pBase) {
                            double dX = 0, dY = 0;
                            invar = System.Globalization.CultureInfo.InvariantCulture;

                            // --- SPOSTAMENTO X ---
                            while (true) {
                                val = Interaction.InputBox("Inserire lo spostamento in X del punto:", "Offset X", "0");

                                // Se preme Annulla, esce dal comando
                                if (string.IsNullOrEmpty(val)) return;

                                // Normalizzazione virgola/punto
                                string inputNorm = val.Replace(',', '.');

                                if (double.TryParse(inputNorm, System.Globalization.NumberStyles.Any, invar, out dX)) {
                                    break; // OK, passa al prossimo input
                                } else {
                                    MessageBox.Show("Valore X non valido. Inserire un numero.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            // --- SPOSTAMENTO Y ---
                            while (true) {
                                val = Interaction.InputBox("Inserire lo spostamento in Y del punto:", "Offset Y", "0");

                                // Se preme Annulla, esce dal comando
                                if (string.IsNullOrEmpty(val)) return;

                                // Normalizzazione virgola/punto
                                string inputNorm = val.Replace(',', '.');

                                if (double.TryParse(inputNorm, System.Globalization.NumberStyles.Any, invar, out dY)) {
                                    break; // OK, esce dal ciclo
                                } else {
                                    MessageBox.Show("Valore Y non valido. Inserire un numero.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            // Calcolo del nuovo punto traslato rispetto al punto selezionato
                            entitaGeometriche.Add(new Punto(pBase.X + dX, pBase.Y + dY, true, coloreSelezionato));
                        } else {
                            MessageBox.Show("L'elemento selezionato non è un Punto!", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Selezionare un punto dalla lista per applicare l'offset.", "ATTENZIONE!");
                    }
                    break;

                case 4: //Linea per due punti
                    if (lbElementi.SelectedIndices.Count == 2) {
                        Punto p1 = null;
                        Punto p2 = null;
                        object elemento1 = entitaGeometriche[lbElementi.SelectedIndices[0]];
                        object elemento2 = entitaGeometriche[lbElementi.SelectedIndices[1]];
                        if ((elemento1 is Punto) && (elemento2 is Punto)) {
                            p1 = (Punto)elemento1;
                            p2 = (Punto)elemento2;
                            entitaGeometriche.Add(new Linea(p1, p2, true, coloreSelezionato));
                        } else {
                            MessageBox.Show("Gli elementi selezionati non sono corretti", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Il numero di elementi selezionati non è corretto", "ATTENZIONE!");
                    }
                    break;

                case 5: // Linea ruotata per un punto
                    if (lbElementi.SelectedIndices.Count == 2) {
                        Punto p = null;
                        Linea l = null;
                        bool puntoTrovato = false;
                        bool lineaTrovata = false;

                        for (int i = 0; i < entitaGeometriche.Count; i++) {
                            if (lbElementi.GetSelected(i)) {
                                object elemento = entitaGeometriche[i];
                                if (elemento is Linea linea && !lineaTrovata) {
                                    l = linea;
                                    lineaTrovata = true;
                                } else if (elemento is Punto punto && !puntoTrovato) {
                                    p = punto;
                                    puntoTrovato = true;
                                }
                            }
                            if (puntoTrovato && lineaTrovata) break;
                        }

                        if (puntoTrovato && lineaTrovata) {
                            int angolo = 0;

                            while (true) {
                                val = Interaction.InputBox("Inserire l'angolo di rotazione (gradi):", "Rotazione", "0");

                                // Gestione Annulla
                                if (string.IsNullOrEmpty(val)) return;

                                if (int.TryParse(val, out angolo)) {
                                    break;
                                } else {
                                    MessageBox.Show("Inserire un numero intero valido per l'angolo.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            entitaGeometriche.Add(new Linea(l, p, angolo, true, coloreSelezionato));
                        } else {
                            MessageBox.Show("Selezionare una Linea e un Punto per questa operazione.", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Selezionare esattamente due elementi (un punto e una linea).", "ATTENZIONE!");
                    }
                    break;

                case 6: // Cerchio da centro e raggio
                    if (lbElementi.SelectedIndices.Count == 1) {
                        object elemento = entitaGeometriche[lbElementi.SelectedIndex];
                        if (elemento is Punto p) {
                            double raggio = 0;
                            invar = System.Globalization.CultureInfo.InvariantCulture;

                            while (true) {
                                val = Interaction.InputBox("Inserire il valore del raggio:", "Inserimento Raggio", "10");

                                // Gestione Annulla
                                if (string.IsNullOrEmpty(val)) return;

                                // Normalizzazione (punto/virgola)
                                string inputNorm = val.Replace(',', '.');

                                if (double.TryParse(inputNorm, System.Globalization.NumberStyles.Any, invar, out raggio)) {
                                    if (raggio > 0) break;
                                    else MessageBox.Show("Il raggio deve essere maggiore di zero.", "Errore");
                                } else {
                                    MessageBox.Show("Valore del raggio non valido.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            entitaGeometriche.Add(new Cerchio(p, raggio, true, coloreSelezionato));
                        } else {
                            MessageBox.Show("L'elemento selezionato deve essere un Punto (Centro).", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Selezionare un punto per definire il centro del cerchio.", "ATTENZIONE!");
                    }
                    break;

                case 7: //Cerchio per tre punti
                    if (lbElementi.SelectedIndices.Count == 3) {
                        Punto p1 = null;
                        Punto p2 = null;
                        Punto p3 = null;
                        int puntiTrovati = 0;
                        for (int i = 0; i < lbElementi.Items.Count; i++) {
                            object elemento = entitaGeometriche[i];
                            if (lbElementi.GetSelected(i)) {
                                if ((elemento is Punto) && (p1 == null)) {
                                    p1 = (Punto)elemento;
                                    puntiTrovati++;
                                } else if ((elemento is Punto) && (p2 == null)) {
                                    p2 = (Punto)elemento;
                                    puntiTrovati++;
                                } else if ((elemento is Punto) && (p3 == null)) {
                                    p3 = (Punto)elemento;
                                    puntiTrovati++;
                                }
                            }
                            if ((puntiTrovati == 3)) {
                                break;
                            }
                        }

                        if (puntiTrovati == 3) {
                            entitaGeometriche.Add(new Cerchio(p1, p2, p3, true, coloreSelezionato));
                        } else {
                            MessageBox.Show("Gli elementi selezionati non sono corretti", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Il numero di elementi selezionati non è corretto", "ATTENZIONE!");
                    }
                    break;

                case 8: //Centro del cerchio
                    if (lbElementi.SelectedIndices.Count == 1) {
                        object elemento = entitaGeometriche[lbElementi.SelectedIndex];
                        if (elemento is Cerchio) {
                            Cerchio c = (Cerchio)elemento;
                            entitaGeometriche.Add(new Punto(c.Centro.X, c.Centro.Y, true, coloreSelezionato));
                        } else {
                            MessageBox.Show("Gli elementi selezionati non sono corretti", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Il numero di elementi selezionati non è corretto", "ATTENZIONE!");
                    }
                    break;
            }

            lbElementi.SelectedItems.Clear();
            //Ridisegna grafico
            AggiornaLimiti();
        }

        private void cmdMisura_Click(object sender, EventArgs e) {
            switch (cbMisura.SelectedIndex) {
                case 0: //Distanza
                    if (lbElementi.SelectedIndices.Count == 2) {
                        object elemento1 = entitaGeometriche[lbElementi.SelectedIndices[0]];
                        object elemento2 = entitaGeometriche[lbElementi.SelectedIndices[1]];
                        if ((elemento1 is Punto) && (elemento2 is Punto)) { //punto-punto
                            Punto p1 = null;
                            Punto p2 = null;
                            p1 = (Punto)elemento1;
                            p2 = (Punto)elemento2;
                            entitaGeometriche.Add(new Misura(p1, p2, true, 0, coloreSelezionato));
                        } else if ((elemento1 is Punto) && (elemento2 is Linea)) { //punto-linea
                            Punto p1 = null;
                            Linea l1 = null;
                            p1 = (Punto)elemento1;
                            l1 = (Linea)elemento2;
                            entitaGeometriche.Add(new Misura(p1, l1, true, coloreSelezionato));
                        } else if ((elemento1 is Linea) && (elemento2 is Punto)) { //linea-punto
                            Punto p1 = null;
                            Linea l1 = null;
                            p1 = (Punto)elemento2;
                            l1 = (Linea)elemento1;
                            entitaGeometriche.Add(new Misura(p1, l1, true, coloreSelezionato));
                        } else if ((elemento1 is Punto) && (elemento2 is Cerchio)) { //punto-cerchio
                            Punto p1 = null;
                            Cerchio c1 = null;
                            p1 = (Punto)elemento1;
                            c1 = (Cerchio)elemento2;
                            entitaGeometriche.Add(new Misura(p1, c1, 1, true, 0, coloreSelezionato)); //da modificare per inserire la posizione 1,2,3
                        } else if ((elemento1 is Cerchio) && (elemento2 is Punto)) { //cerchio-punto
                            Punto p1 = null;
                            Cerchio c1 = null;
                            p1 = (Punto)elemento2;
                            c1 = (Cerchio)elemento1;
                            entitaGeometriche.Add(new Misura(p1, c1, 1, true, 0, coloreSelezionato)); //da modificare per inserire la posizione 1,2,3
                        } else if ((elemento1 is Linea) && (elemento2 is Linea)) { //linea-linea parallele
                            Linea l1 = null;
                            Linea l2 = null;
                            l1 = (Linea)elemento1;
                            l2 = (Linea)elemento2;
                            entitaGeometriche.Add(new Misura(l1, l2, true, Misura.Tipologia.Distanza, coloreSelezionato));
                        } else if ((elemento1 is Linea) && (elemento2 is Cerchio)) { //linea-cerchio
                            Linea l1 = null;
                            Cerchio c1 = null;
                            l1 = (Linea)elemento1;
                            c1 = (Cerchio)elemento2;
                            entitaGeometriche.Add(new Misura(l1, c1, 1, true, coloreSelezionato)); //da modificare per inserire la posizione 1,2,3
                        } else if ((elemento1 is Cerchio) && (elemento2 is Linea)) { //cerchio-linea
                            Linea l1 = null;
                            Cerchio c1 = null;
                            l1 = (Linea)elemento2;
                            c1 = (Cerchio)elemento1;
                            entitaGeometriche.Add(new Misura(l1, c1, 1, true, coloreSelezionato)); //da modificare per inserire la posizione 1,2,3
                        } else if ((elemento1 is Cerchio) && (elemento2 is Cerchio)) { //cerchio-cerchio
                            Cerchio c1 = null;
                            Cerchio c2 = null;
                            c1 = (Cerchio)elemento1;
                            c2 = (Cerchio)elemento2;
                            entitaGeometriche.Add(new Misura(c1, c2, 1, true, 0, coloreSelezionato)); //da modificare per inserire la posizione 1,2,3
                        } else {
                            MessageBox.Show("Gli elementi selezionati non sono corretti", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Il numero di elementi selezionati non è corretto", "ATTENZIONE!");
                    }
                    break;

                case 1: //DistanzaX
                    if (lbElementi.SelectedIndices.Count == 2) {
                        object elemento1 = entitaGeometriche[lbElementi.SelectedIndices[0]];
                        object elemento2 = entitaGeometriche[lbElementi.SelectedIndices[1]];
                        if ((elemento1 is Punto) && (elemento2 is Punto)) { //punto-punto
                            Punto p1 = null;
                            Punto p2 = null;
                            p1 = (Punto)elemento1;
                            p2 = (Punto)elemento2;
                            entitaGeometriche.Add(new Misura(p1, p2, true, Misura.Tipologia.DistanzaX, coloreSelezionato));
                        } else if ((elemento1 is Punto) && (elemento2 is Cerchio)) { //punto-cerchio
                            Punto p1 = null;
                            Cerchio c1 = null;
                            p1 = (Punto)elemento1;
                            c1 = (Cerchio)elemento2;
                            entitaGeometriche.Add(new Misura(p1, c1, 1, true, Misura.Tipologia.DistanzaX, coloreSelezionato)); //da modificare per inserire la posizione 1,2,3
                        } else if ((elemento1 is Cerchio) && (elemento2 is Punto)) { //cerchio-punto
                            Punto p1 = null;
                            Cerchio c1 = null;
                            p1 = (Punto)elemento2;
                            c1 = (Cerchio)elemento1;
                            entitaGeometriche.Add(new Misura(p1, c1, 1, true, Misura.Tipologia.DistanzaX, coloreSelezionato)); //da modificare per inserire la posizione 1,2,3
                        } else if ((elemento1 is Cerchio) && (elemento2 is Cerchio)) { //cerchio-cerchio
                            Cerchio c1 = null;
                            Cerchio c2 = null;
                            c1 = (Cerchio)elemento1;
                            c2 = (Cerchio)elemento2;
                            entitaGeometriche.Add(new Misura(c1, c2, 1, true, Misura.Tipologia.DistanzaX, coloreSelezionato)); //da modificare per inserire la posizione 1,2,3
                        } else {
                            MessageBox.Show("Gli elementi selezionati non sono corretti", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Il numero di elementi selezionati non è corretto", "ATTENZIONE!");
                    }
                    break;

                case 2: //DistanzaY
                    if (lbElementi.SelectedIndices.Count == 2) {
                        object elemento1 = entitaGeometriche[lbElementi.SelectedIndices[0]];
                        object elemento2 = entitaGeometriche[lbElementi.SelectedIndices[1]];
                        if ((elemento1 is Punto) && (elemento2 is Punto)) { //punto-punto
                            Punto p1 = null;
                            Punto p2 = null;
                            p1 = (Punto)elemento1;
                            p2 = (Punto)elemento2;
                            entitaGeometriche.Add(new Misura(p1, p2, true, Misura.Tipologia.DistanzaY, coloreSelezionato));
                        } else if ((elemento1 is Punto) && (elemento2 is Cerchio)) { //punto-cerchio
                            Punto p1 = null;
                            Cerchio c1 = null;
                            p1 = (Punto)elemento1;
                            c1 = (Cerchio)elemento2;
                            entitaGeometriche.Add(new Misura(p1, c1, 1, true, Misura.Tipologia.DistanzaY, coloreSelezionato)); //da modificare per inserire la posizione 1,2,3
                        } else if ((elemento1 is Cerchio) && (elemento2 is Punto)) { //cerchio-punto
                            Punto p1 = null;
                            Cerchio c1 = null;
                            p1 = (Punto)elemento2;
                            c1 = (Cerchio)elemento1;
                            entitaGeometriche.Add(new Misura(p1, c1, 1, true, Misura.Tipologia.DistanzaY, coloreSelezionato)); //da modificare per inserire la posizione 1,2,3
                        } else if ((elemento1 is Cerchio) && (elemento2 is Cerchio)) { //cerchio-cerchio
                            Cerchio c1 = null;
                            Cerchio c2 = null;
                            c1 = (Cerchio)elemento1;
                            c2 = (Cerchio)elemento2;
                            entitaGeometriche.Add(new Misura(c1, c2, 1, true, Misura.Tipologia.DistanzaY, coloreSelezionato)); //da modificare per inserire la posizione 1,2,3
                        } else {
                            MessageBox.Show("Gli elementi selezionati non sono corretti", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Il numero di elementi selezionati non è corretto", "ATTENZIONE!");
                    }
                    break;

                case 3: //Diametro
                    if (lbElementi.SelectedIndices.Count == 1) {
                        object elemento1 = entitaGeometriche[lbElementi.SelectedIndices[0]];
                        if (elemento1 is Cerchio) {
                            Cerchio c1 = null;
                            c1 = (Cerchio)elemento1;
                            entitaGeometriche.Add(new Misura(c1, true, Misura.Tipologia.Diametro, coloreSelezionato));
                        } else {
                            MessageBox.Show("Gli elementi selezionati non sono corretti", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Il numero di elementi selezionati non è corretto", "ATTENZIONE!");
                    }
                    break;

                case 4: //Raggio
                    if (lbElementi.SelectedIndices.Count == 1) {
                        object elemento1 = entitaGeometriche[lbElementi.SelectedIndices[0]];
                        if (elemento1 is Cerchio) {
                            Cerchio c1 = null;
                            c1 = (Cerchio)elemento1;
                            entitaGeometriche.Add(new Misura(c1, true, Misura.Tipologia.Raggio, coloreSelezionato));
                        } else {
                            MessageBox.Show("Gli elementi selezionati non sono corretti", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Il numero di elementi selezionati non è corretto", "ATTENZIONE!");
                    }
                    break;

                case 5: //Angolo
                    if (lbElementi.SelectedIndices.Count == 2) {
                        object elemento1 = entitaGeometriche[lbElementi.SelectedIndices[0]];
                        object elemento2 = entitaGeometriche[lbElementi.SelectedIndices[1]];
                        if ((elemento1 is Linea) && (elemento2 is Linea)) { //linea-linea
                            Linea l1 = null;
                            Linea l2 = null;
                            l1 = (Linea)elemento1;
                            l2 = (Linea)elemento2;
                            entitaGeometriche.Add(new Misura(l1, l2, true, Misura.Tipologia.Angolo, coloreSelezionato));
                        } else {
                            MessageBox.Show("Gli elementi selezionati non sono corretti", "ATTENZIONE!");
                        }
                    } else {
                        MessageBox.Show("Il numero di elementi selezionati non è corretto", "ATTENZIONE!");
                    }
                    break;
            }
            lbElementi.SelectedIndex = -1;
        }

        private void pbImmagine_MouseEnter(object sender, EventArgs e) {
            mouseInPicturebox = true;
            // Nasconde il cursore di sistema
            Cursor.Hide();
        }

        private void pbImmagine_MouseMove(object sender, MouseEventArgs e) {
            // Aggiorna la posizione del mouse
            posMouse = e.Location;

            if (isDragging) {
                pB_UI = e.Location;
            }

            // Forza il ridisegno della PictureBox per aggiornare la posizione della croce
            pbImmagine.Invalidate();
        }

        private void pbImmagine_MouseLeave(object sender, EventArgs e) {
            mouseInPicturebox = false;
            // Riporta il cursore di sistema alla normalità
            Cursor.Show();

            PuntoBordoImg = PointF.Empty;

            // Forza un ultimo ridisegno per nascondere la croce
            pbImmagine.Invalidate();
        }

        private void pbImmagine_Paint(object sender, PaintEventArgs e) {
            // Disegna la croce solo se il mouse è all'interno della PictureBox
            if (mouseInPicturebox) {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Crea una penna per disegnare la croce (ad esempio, spessa 2 pixel, rossa)
                using (Pen pennaCroce = new Pen(Color.Red, 1)) {
                    // Dimensione della PictureBox
                    int width = pbImmagine.Width;
                    int height = pbImmagine.Height;

                    // Coordinate X e Y del punto di incrocio (la posizione attuale del mouse)
                    int centerX = posMouse.X;
                    int centerY = posMouse.Y;

                    // 1. Linea Orizzontale (da bordo sinistro a bordo destro, passante per centerY)
                    // L'incrocio si sposta in base alla posizione Y del mouse.
                    g.DrawLine(pennaCroce, 0, centerY, width, centerY);
                    g.DrawEllipse(pennaCroce, (int)(centerX - nUDDiametroCerchio.Value / 2), (int)(centerY - nUDDiametroCerchio.Value / 2), (int)nUDDiametroCerchio.Value, (int)nUDDiametroCerchio.Value);

                    // 2. Linea Verticale (da bordo superiore a bordo inferiore, passante per centerX)
                    // L'incrocio si sposta in base alla posizione X del mouse.
                    g.DrawLine(pennaCroce, centerX, 0, centerX, height);
                }

                // Se stiamo trascinando o se abbiamo punti validi, disegna la linea di ricerca
                if (isDragging && pA_UI != pB_UI) {
                    // Linea di ricerca tecnica (Cyan con ombra)
                    using (Pen shadowPen = new Pen(Color.FromArgb(100, 0, 0, 0), 3f))
                    using (Pen linePen = new Pen(Color.Cyan, 1.5f)) {
                        g.DrawLine(shadowPen, pA_UI, pB_UI);
                        g.DrawLine(linePen, pA_UI, pB_UI);
                    }
                }

                // Se abbiamo trovato il bordo, disegniamo il "Mirino"
                if (!PuntoBordoImg.IsEmpty) {
                    // Convertiamo il punto immagine in coordinate UI per disegnarlo correttamente
                    float edgeX_UI = PuntoBordoImg.X;
                    float edgeY_UI = PuntoBordoImg.Y;

                    DisegnaPuntoBordo(g, new PointF(edgeX_UI, edgeY_UI));
                }
            }
        }

        private void DisegnaPuntoBordo(Graphics g, PointF p) {
            // Un mirino rosso/neon che spicca sul bordo trovato
            float size = 8;
            using (Pen pMarker = new Pen(Color.Lime, 2f)) {
                g.DrawEllipse(pMarker, p.X - size, p.Y - size, size * 2, size * 2);
                g.DrawLine(pMarker, p.X - size - 2, p.Y, p.X + size + 2, p.Y);
                g.DrawLine(pMarker, p.X, p.Y - size - 2, p.X, p.Y + size + 2);
            }
        }

        private Punto TrovaMinGR(BindingList<Entita> entG) {

            if (entG.Count > 1) {
                List<Punto> newEnt = new List<Punto>();
                foreach (Entita ent in entG) {
                    if (!(ent is Misura) && (!(ent is Allineamento) || (allineamento.o.X == 0 && allineamento.o.Y == 0))) {
                        newEnt.Add(ent.PuntoMin());
                    }
                }

                Punto minimoX = newEnt[0];
                Punto minimoY = newEnt[0];
                for (int i = 1; i < newEnt.Count; i++) {
                    if (Punto.MinoreX(newEnt[i], minimoX)) {
                        minimoX = newEnt[i];
                    }
                    if (Punto.MinoreY(newEnt[i], minimoY)) {
                        minimoY = newEnt[i];
                    }
                }

                return new Punto(minimoX.X, minimoY.Y, false, Color.Black);
            } else {
                return null;
            }
        }

        private Punto TrovaMaxGR(BindingList<Entita> entG) {

            if (entG.Count > 1) {
                List<Punto> newEnt = new List<Punto>();
                foreach (Entita ent in entG) {
                    if (!(ent is Misura) && (!(ent is Allineamento) || (allineamento.o.X == 0 && allineamento.o.Y == 0))) {
                        newEnt.Add(ent.PuntoMax());
                    }
                }

                Punto massimoX = newEnt[0];
                Punto massimoY = newEnt[0];
                for (int i = 1; i < newEnt.Count; i++) {
                    if (Punto.MaggioreX(newEnt[i], massimoX)) {
                        massimoX = newEnt[i];
                    }
                    if (Punto.MaggioreY(newEnt[i], massimoY)) {
                        massimoY = newEnt[i];
                    }
                }

                return new Punto(massimoX.X, massimoY.Y, false, Color.Black);
            } else {
                return null;
            }
        }

        private void AggiornaLimiti() {
            Punto minGR = TrovaMinGR(entitaGeometriche);
            Punto maxGR = TrovaMaxGR(entitaGeometriche);
            if (minGR != null && maxGR != null) {
                int w = Convert.ToInt32((maxGR.X - minGR.X) * fattoreScala * fattoreZoomGr) + 100;
                int h = Convert.ToInt32((maxGR.Y - minGR.Y) * fattoreScala * fattoreZoomGr) + 100;
                panGrafico.AutoScrollMinSize = new Size(w, h);
            }
            panGrafico.Invalidate();
        }

        private void panGrafico_Paint(object sender, PaintEventArgs e) {

            

            // L'oggetto 'g' contiene gli strumenti di disegno (GDI+)
            Graphics g = e.Graphics;
            g.TranslateTransform(panGrafico.AutoScrollPosition.X, panGrafico.AutoScrollPosition.Y);

            Punto minGR = TrovaMinGR(entitaGeometriche);
            Punto maxGR = TrovaMaxGR(entitaGeometriche);
            if (minGR != null && maxGR != null) {
                if (Math.Abs(minGR.X) > allineamento.o.X) {
                    traslaGRX = (float)((-minGR.X) * fattoreScala * fattoreZoomGr);
                    g.TranslateTransform(traslaGRX, 0);
                }
                if (Math.Abs(minGR.Y) > allineamento.o.Y) {
                    traslaGRY = (float)((-minGR.Y) * fattoreScala * fattoreZoomGr);
                    g.TranslateTransform(0, traslaGRY);
                }
            } else {
                panGrafico.AutoScrollMinSize = new Size(pbImmagine.Width, pbImmagine.Height);
                traslaGRX = 0;
                traslaGRY = 0;
            }
            
            
            // Configurazione per una grafica "liscia"
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.ScaleTransform((float)fattoreZoomGr, (float)fattoreZoomGr);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;

            foreach (Entita ent in entitaGeometriche) {
                ent.Disegna(g, fattoreScala, allineamento, (float)(1 / fattoreZoomGr), DefaultFont);
            }

        }

        private void panGrafico_Scroll(object sender, ScrollEventArgs e) {
            panGrafico.Invalidate();
        }

        private void panGrafico_MouseDown(object sender, MouseEventArgs e) {
            Point scroll = panGrafico.AutoScrollPosition;
            int offsetX = scroll.X;
            int offsetY = scroll.Y;

            double mouseX = ((e.X - traslaGRX - offsetX) / fattoreZoomGr) / fattoreScala - allineamento.o.X;
            double mouseY = ((e.Y - traslaGRY - offsetY) / fattoreZoomGr) / fattoreScala - allineamento.o.Y;

            Punto mouseLogico = new Punto(mouseX, mouseY, false, Color.Black);
            double tolleranza = 5 / (double)fattoreScala;


            List<Entita> colpite = new List<Entita>();

            for (int i = 0; i < entitaGeometriche.Count; i++) {
                Entita ent = entitaGeometriche[i];

                if (ent.HitTest(mouseLogico, tolleranza)) {
                    colpite.Add(ent);
                }
            }

            GestisciSelezione(colpite, new Point(e.X, e.Y));

        }

        private void GestisciSelezione(List<Entita> colpite, Point posizioneMouse) {
            if (colpite.Count == 0) {
                lbElementi.ClearSelected();
                panGrafico.Invalidate();
                return;
            }

            if (colpite.Count == 1) {
                SelezionaEntita(colpite[0]);
                return;
            }

            ToolStripDropDownMenu menu = new ToolStripDropDownMenu();

            for (int i = 0; i < colpite.Count; i++) {
                Entita ent = colpite[i];

                ToolStripMenuItem voce = new ToolStripMenuItem();
                voce.Text = ent.ToString();
                voce.Tag = ent;

                voce.Click += MenuSelezione_Click;

                menu.Items.Add(voce);
            }

            menu.Show(panGrafico, posizioneMouse);
        }

        private void MenuSelezione_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;

            Entita ent = item.Tag as Entita;
            if (ent == null)
                return;

            SelezionaEntita(ent);
        }

        private void SelezionaEntita(Entita entita) {
            lbElementi.SelectedItem = entita;
            panGrafico.Invalidate();
        }

        private void tscmdAnnulla_Click(object sender, EventArgs e) {
            if (entitaGeometriche.Count > 1) {
                Entita ultimo = entitaGeometriche[entitaGeometriche.Count - 1];
                ultimo.DecrementaQuantita(entitaGeometriche[entitaGeometriche.Count - 1]);
                entitaGeometriche.RemoveAt(entitaGeometriche.Count - 1);
                lbElementi.SelectedItems.Clear();
                AggiornaLimiti();
            }
        }

        private void chbRilevaPunto_CheckedChanged(object sender, EventArgs e) {
            if (chbRilevaPunto.Checked) {
                // Stato PREMUTO (Attivo)
                chbRilevaPunto.BackColor = Color.LimeGreen; // Un colore evidente
                chbRilevaPunto.FlatAppearance.BorderColor = Color.DarkGreen;
                chbRilevaPunto.FlatAppearance.BorderSize = 2;
            } else {
                // Stato RILASCIATO (Inattivo)
                chbRilevaPunto.BackColor = SystemColors.Control;
                chbRilevaPunto.FlatAppearance.BorderColor = Color.Gray;
                chbRilevaPunto.FlatAppearance.BorderSize = 1;
            }
        }

        private PointF TrovaPuntoBordo(Bitmap img, Point pA, Point pB) {

            // 1. Calcoliamo quanti punti campionare lungo la linea
            int dist = (int)Math.Sqrt(Math.Pow(pB.X - pA.X, 2) + Math.Pow(pB.Y - pA.Y, 2));

            double maxGradient = 0;
            PointF edgePoint = PointF.Empty;
            int lastIntensity = -1;

            for (int i = 0; i <= dist; i++) {
                // Calcoliamo la posizione X, Y corrente lungo la linea (interpolazione lineare)
                float t = (float)i / dist;
                int currX = (int)(pA.X + t * (pB.X - pA.X));
                int currY = (int)(pA.Y + t * (pB.Y - pA.Y));

                // Sicurezza: restiamo nei confini dell'immagine
                if (currX < 0 || currX >= img.Width || currY < 0 || currY >= img.Height) continue;

                // 2. Otteniamo la luminosità (Grayscale semplificato)
                Color c = img.GetPixel(currX, currY);
                int intensity = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);

                if (lastIntensity != -1) {
                    // 3. Calcolo del gradiente (differenza di luminosità)
                    int gradient = Math.Abs(intensity - lastIntensity);

                    if (gradient > maxGradient) {
                        maxGradient = gradient;
                        edgePoint = new PointF(currX, currY);
                    }
                }

                lastIntensity = intensity;
            }
            return edgePoint; // Questo è il punto esatto del bord
        }

        private void pbImmagine_MouseUp(object sender, MouseEventArgs e) {
            if (!isDragging) return;

            if (chbRilevaPunto.Checked) {
                isDragging = false;
                pB_UI = e.Location;

                // 2. Chiamiamo la tua funzione di calcolo
                Bitmap bmp = (Bitmap)pbImmagine.Image;
                PuntoBordoImg = TrovaPuntoBordo(bmp, pA_UI, pB_UI);

                // 3. Ridisegniamo per mostrare il risultato
                pbImmagine.Invalidate();

                if ((immagineCaricata != null) && (costruzioneAttiva == true)) {
                    entitaGeometriche.Add(new Punto((e.X / (double)fattoreScala) / (double)fattoreZoomImg - allineamento.o.X, (e.Y / (double)fattoreScala) / (double)fattoreZoomImg - allineamento.o.Y, true, Color.Black));
                    lbElementi.SelectedItems.Clear();

                    //Ridisegna grafico
                    AggiornaLimiti();
                } else if (immagineCaricata != null) {
                    PointF p = TrovaPuntoBordo(bmp, pA_UI, pB_UI);
                    CalcolaScala(new Punto(p.X, p.Y, false, Color.Black));
                }
            }
        }

        private void btnZoomPiuGr_Click(object sender, EventArgs e) {
            // Aumenta il fattore di zoom
            fattoreZoomGr += (zoomStep);
            AggiornaLimiti();
        }

        private void btnZoomMenoGr_Click(object sender, EventArgs e) {
            // Aumenta il fattore di zoom
            fattoreZoomGr -= (zoomStep);
            AggiornaLimiti();
        }

        private void btnResetZoomGr_Click(object sender, EventArgs e) {
            // Aumenta il fattore di zoom
            fattoreZoomGr = 1;
            AggiornaLimiti();
        }

        private void tscmdSalva_Click(object sender, EventArgs e) {
            if (costruzioneAttiva) {
                {
                    fattoreZoomImg = 1;
                    ApplicaZoom();

                    using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                        fbd.Description = "Seleziona la cartella dove salvare il progetto";

                        if (fbd.ShowDialog() == DialogResult.OK) {
                            string pathCartella = fbd.SelectedPath;
                            string pathImmagine = "";
                            var invar = System.Globalization.CultureInfo.InvariantCulture;

                            try {
                                                                // 1. SALVATAGGIO IMMAGINE
                                if (pbImmagine.Image != null) {
                                    pathImmagine = Path.Combine(pathCartella, "immagine_caricata.png");
                                    // Salviamo in formato PNG per mantenere la qualità
                                    pbImmagine.Image.Save(pathImmagine, ImageFormat.Png);
                                }

                                // 2. SALVATAGGIO DATI GEOMETRICI (File di testo)
                                string pathDati = Path.Combine(pathCartella, "dati_progetto.txt");

                                using (StreamWriter sw = new StreamWriter(pathDati)) {
                                    // Scriviamo le impostazioni usando l'invariante per ogni numero
                                    sw.WriteLine(string.Format(invar, "SETUP;{0};{1};{2};{3};{4}",
                                        fattoreScala, fattoreZoomGr, fattoreZoomImg, traslaGRX, traslaGRY));

                                    // Scriviamo i dati dell'immagine
                                    sw.WriteLine($"IMMAGINE;{pathImmagine};{pbImmagine.Width};{pbImmagine.Height}");

                                    // Scriviamo l'origine attuale
                                    sw.WriteLine(string.Format(invar, "ORIGINE;{0};{1}",
                                        allineamento.o.X, allineamento.o.Y));

                                    foreach (Entita ent in entitaGeometriche) {
                                        if (ent is Punto p) {
                                            // Formato: TIPO;NOME;X;Y
                                            sw.WriteLine(string.Format(invar, "PUNTO;{0};{1};{2}",
                                                p.Nome, p.X, p.Y));
                                        } else if (ent is Linea l) {
                                            // Formato: TIPO;NOME;X1;Y1;X2;Y2
                                            sw.WriteLine(string.Format(invar, "LINEA;{0};{1};{2};{3};{4}",
                                                l.Nome, l.P1.X, l.P1.Y, l.P2.X, l.P2.Y));
                                        } else if (ent is Cerchio c) {
                                            // Formato: MISURA;NOME;Val;ValX;ValY;Diam;Raggio;angolo
                                            sw.WriteLine(string.Format(invar, "CERCHIO;{0};{1};{2};{3}",
                                                c.Nome, c.Centro.X, c.Centro.Y, c.R));
                                        } else if (ent is Misura m) {
                                            sw.WriteLine(string.Format(invar, "MISURA;{0};{1};{2};{3};{4};{5};{6};{7}",
                                            m.Nome, m.Tipo, m.Valore, m.ValoreX, m.ValoreY, m.ValoreDiametro, m.ValoreRaggio, m.ValoreAngolo));
                                        }
                                    }
                                }

                                MessageBox.Show("Salvataggio completato con successo!", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            } catch (Exception ex) {
                                MessageBox.Show("Errore durante il salvataggio: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            } else {
                MessageBox.Show("Errore durante il salvataggio: la costruzione deve essere attiva", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApriFile() {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                fbd.Description = "Seleziona la cartella del progetto da aprire";

                if (fbd.ShowDialog() == DialogResult.OK) {
                    string pathCartella = fbd.SelectedPath;
                    string pathDati = Path.Combine(pathCartella, "dati_progetto.txt");
                    string pathImmagine = Path.Combine(pathCartella, "immagine_caricata.png");

                    if (!File.Exists(pathDati)) {
                        MessageBox.Show("File dati_progetto.txt non trovato nella cartella selezionata.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try {
                        // 1. Pulizia dati attuali
                        entitaGeometriche.Clear();

                        // 2. Caricamento Immagine
                        if (File.Exists(pathImmagine)) {
                            immagineCaricata = Image.FromFile(pathImmagine);

                            // Assegna l'immagine alla PictureBox
                            pbImmagine.Image = new Bitmap(immagineCaricata);

                            // *** IL PASSO FONDAMENTALE ***
                            // Imposta le dimensioni della PictureBox alle dimensioni dell'immagine appena caricata
                            // Questo fa sì che il Panel "sappia" che l'immagine è più grande.
                            pbImmagine.Width = immagineCaricata.Width;
                            pbImmagine.Height = immagineCaricata.Height;
                            panGrafico.AutoScrollMinSize = new Size(pbImmagine.Width, pbImmagine.Height);

                            // Assicurati che il SizeMode sia Normal
                            pbImmagine.SizeMode = PictureBoxSizeMode.Normal;
                        }

                        // 3. Lettura dati dal file di testo
                        string[] righe = File.ReadAllLines(pathDati);
                        var invar = System.Globalization.CultureInfo.InvariantCulture;

                        foreach (string riga in righe) {
                            string[] campi = riga.Split(';');
                            if (campi.Length < 1) continue;

                            string tipo = campi[0];

                            switch (tipo) {
                                case "SETUP":
                                    fattoreScala = double.Parse(campi[1], invar);
                                    sslblScala.Text = "Scala: " + fattoreScala.ToString("F3");
                                    fattoreZoomGr = double.Parse(campi[2], invar);
                                    fattoreZoomImg = double.Parse(campi[3], invar);
                                    traslaGRX = float.Parse(campi[4], invar);
                                    traslaGRY = float.Parse(campi[5], invar);
                                    break;

                                case "IMMAGINE":
                                    pbImmagine.Width = int.Parse(campi[2], invar);
                                    pbImmagine.Height = int.Parse(campi[3], invar);
                                    break;

                                case "ORIGINE":
                                    allineamento = new Allineamento();
                                    allineamento.o.X = double.Parse(campi[1], invar);
                                    allineamento.o.Y = double.Parse(campi[2], invar);
                                    entitaGeometriche.Add(allineamento);
                                    break;

                                case "PUNTO":
                                    // TIPO;NOME;X;Y
                                    Punto p = new Punto(double.Parse(campi[2], invar), double.Parse(campi[3], invar), true, Color.Black);
                                    entitaGeometriche.Add(p);
                                    break;

                                case "LINEA":
                                    // TIPO;NOME;X1;Y1;X2;Y2
                                    Punto P1 = new Punto(double.Parse(campi[2], invar), double.Parse(campi[3], invar), false, Color.Black);
                                    Punto P2 = new Punto(double.Parse(campi[4], invar), double.Parse(campi[5], invar), false, Color.Black);
                                    Linea l = new Linea(P1, P2, true, Color.Black);
                                    entitaGeometriche.Add(l);
                                    break;

                                case "CERCHIO":
                                    // TIPO;NOME;CentroX;CentroY;R
                                    Punto centro = new Punto(double.Parse(campi[2], invar), double.Parse(campi[3], invar), false, Color.Black);
                                    double r = double.Parse(campi[4], invar);
                                    Cerchio c = new Cerchio(centro, r, true, Color.Black);
                                    entitaGeometriche.Add(c);
                                    break;
                                case "MISURA":
                                    //TIPO;NOME;TIPOLOGIA;Val;ValX;ValY;Diam;Raggio;angolo
                                    if (Enum.TryParse<Misura.Tipologia>(campi[2], out Misura.Tipologia _tipo)) {
                                        Misura m = new Misura(_tipo);
                                        m.Nome = campi[1];
                                        m.Valore = double.Parse(campi[3], invar); 
                                        m.ValoreX = double.Parse(campi[4], invar);
                                        m.ValoreY = double.Parse(campi[5], invar);
                                        m.ValoreDiametro = double.Parse(campi[6], invar);
                                        m.ValoreRaggio = double.Parse(campi[7], invar);
                                        m.ValoreAngolo = double.Parse(campi[8], invar);
                                        entitaGeometriche.Add(m);
                                    }
                                    break;
                            }
                        }

                        cbModalitaScala.SelectedIndex = 0;
                        btnZoomPiuImg.Enabled = true;
                        btnZoomMenoImg.Enabled = true;
                        btnResetZoomImg.Enabled = true;
                        chbRilevaPunto.Enabled = true;
                        tabcGrafico.Enabled = true;
                        lbElementi.Enabled = true;
                        costruzioneAttiva = true;

                        // 4. Aggiorna l'interfaccia
                        AggiornaLimiti();
                        MessageBox.Show("Progetto caricato correttamente!", "Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    } catch (Exception ex) {
                        MessageBox.Show("Errore durante l'apertura: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tscmdApri_Click(object sender, EventArgs e) {
            if (!costruzioneAttiva) {
                AzzeraTutto();
                ApriFile();
            } else {
                var risp = Interaction.MsgBox("Sei sicuro di voler aprire? Il lavoro attuale verrà cancellato", MsgBoxStyle.YesNo, "ATTENZIONE!");
                if (risp == MsgBoxResult.Yes) {
                    AzzeraTutto();
                    ApriFile();
                }
            }            
        }

        private void tscmdGeneraReport_Click(object sender, EventArgs e) {
            if (costruzioneAttiva) {
                // 1. Configurazione del Dialog per scegliere nome e percorso file
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "File CSV (*.csv)|*.csv";
                sfd.FileName = "Report_Misure_" + DateTime.Now.ToString("yyyyMMdd_HHmm");

                if (sfd.ShowDialog() == DialogResult.OK) {
                    try {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8)) {
                            // Definiamo il separatore (il punto e virgola è lo standard per i CSV in Excel Italia)
                            string sep = ";";

                            // 2. Intestazioni fisse del report (Parte superiore dell'immagine)
                            sw.WriteLine($"Codice oggetto misurato:{sep}");
                            sw.WriteLine($"Descrizione oggetto misurato:{sep}");
                            sw.WriteLine($"Nome metrologo:{sep}");
                            sw.WriteLine($"Data misurazioni:{sep}{DateTime.Now.ToShortDateString()}");
                            sw.WriteLine(); // Riga vuota di stacco

                            // 3. Intestazione della tabella
                            sw.WriteLine($"Caratteristica{sep}Nome{sep}Nominale{sep}Tol+{sep}Tol-{sep}Misurato{sep}Dev{sep}Stato");

                            // 4. Ciclo su tutte le entità per estrarre le misure
                            foreach (var entita in entitaGeometriche) {
                                if (entita is Misura m) {
                                    // Formattiamo i valori usando il punto o la virgola a seconda delle necessità
                                    // Qui usiamo il ToString() semplice per seguire le impostazioni di sistema
                                    string riga = string.Format("{0}{1}{2}{1}{3}{1}{4}{1}{5}{1}{6}{1}{7}{1}{8}",
                                        m.Tipo,             // Caratteristica (Tipologia)
                                        sep,
                                        m.Nome,             // Nome
                                        m.ValoreNominale.ToString("F3"),   // Nominale (il valore nominale
                                        m.TolPiu.ToString("F3"),           // Tol+
                                        m.TolMeno.ToString("F3"),          // Tol-
                                        m.CalcolaValore().ToString("F3"),   //Misurato
                                        (m.CalcolaValore() - m.ValoreNominale).ToString("F3"), //Dev
                                        m.CalcolaStato()    // Stato (OK/KO)
                                    );
                                    sw.WriteLine(riga);
                                }
                            }
                        }
                        MessageBox.Show("Report generato con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show("Errore durante la generazione del report: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show("Errore durante il salvataggio: la costruzione deve essere attiva", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbElementi_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                // Trova l'indice dell'elemento sotto il mouse
                int index = lbElementi.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches) {
                    lbElementi.SelectedIndex = index; // Seleziona l'elemento
                }
            }
        }

        private void tsmImpostaTolleranze_Click(object sender, EventArgs e) {
            if (lbElementi.SelectedIndex != -1) {
                object elemento = entitaGeometriche[lbElementi.SelectedIndex];

                // Verifichiamo che l'elemento sia effettivamente una Misura
                if (elemento is Misura m) {
                    string valPiu, valMeno, valNom;
                    double tP, tM, vN;
                    var invar = System.Globalization.CultureInfo.InvariantCulture;

                    // --- NOMINALE ---
                    valNom = Interaction.InputBox($"Valore NOMINALE {m.Nome}:", "Nominale", m.ValoreNominale.ToString(invar));
                    if (string.IsNullOrEmpty(valNom)) return; // Annulla

                    // --- TOLLERANZA PIÙ ---
                    valPiu = Interaction.InputBox($"Tolleranza SUPERIORE per {m.Nome}:", "Tolleranze", m.TolPiu.ToString(invar));
                    if (string.IsNullOrEmpty(valPiu)) return; // Annulla

                    // --- TOLLERANZA MENO ---
                    valMeno = Interaction.InputBox($"Tolleranza INFERIORE per {m.Nome}:", "Tolleranze", m.TolMeno.ToString(invar));
                    if (string.IsNullOrEmpty(valMeno)) return; // Annulla

                    // Parsing e assegnazione
                    if (double.TryParse(valPiu.Replace(',', '.'), System.Globalization.NumberStyles.Any, invar, out tP) &&
                        double.TryParse(valMeno.Replace(',', '.'), System.Globalization.NumberStyles.Any, invar, out tM) &&
                        double.TryParse(valNom.Replace(',', '.'), System.Globalization.NumberStyles.Any, invar, out vN)) {
                        m.TolPiu = tP;
                        m.TolMeno = tM;
                        m.ValoreNominale = vN;

                        MessageBox.Show("Valori aggiornati con successo!", "OK");
                        lbElementi.Invalidate(); // Forza il ridisegno se necessario
                    } else {
                        MessageBox.Show("Valori inseriti non validi.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("L'elemento selezionato non è una misura!", "Attenzione");
                }
            }
        }

        private void tscmdInfo_Click(object sender, EventArgs e) {
            using (frmInfo informazioni = new frmInfo()) {
                informazioni.ShowDialog(); // Mostra la finestra in modalità modale
            }
        }

        private void cmdDefinisciAsseX_Click(object sender, EventArgs e) {
            if (lbElementi.SelectedIndices.Count == 1) {
                Linea l0 = null;
                object elemento = entitaGeometriche[lbElementi.SelectedIndex];
                if (elemento is Linea) {
                    l0 = (Linea)elemento;
                    Linea l1 = new Linea(new Punto(0,0,false, Color.Black), new Punto(1,0, false, Color.Black), false, Color.Black);
                    Misura ang = new Misura(l0, l1, false, Misura.Tipologia.Angolo, Color.Black);
                    List<Entita> tmp = new List<Entita>();
                    double x1 = l0.P1.X;
                    double y1 = l0.P1.Y;
                    double x2 = l0.P2.X;
                    double y2 = l0.P2.Y;
                    for (int i = 0; i < entitaGeometriche.Count; i++) {
                        if (!(entitaGeometriche[i] is Allineamento)) {
                            if ((y2 > y1 && x2 > x1) || (y2 < y1 && x2 < x1)) {
                                entitaGeometriche[i].Ruota(new Punto(0, 0, false, Color.Black), -ang.ValoreAngolo);
                                if (i == 1) {
                                    angolo -= ang.ValoreAngolo;
                                }
                            } else {
                                entitaGeometriche[i].Ruota(new Punto(0, 0, false, Color.Black), ang.ValoreAngolo);
                                if (i == 1) {
                                    angolo += ang.ValoreAngolo;
                                }
                            }
                            tmp.Add(entitaGeometriche[i]);
                        }
                    }
                    entitaGeometriche.Clear();
                    entitaGeometriche.Add(allineamento);
                    for (int i = 0; i < tmp.Count; i++) {
                        entitaGeometriche.Add(tmp[i]);
                    }
                    AggiornaLimiti();
                } else {
                    MessageBox.Show("L'elemento selezionato non è corretto", "ATTENZIONE!");
                }

                lbElementi.SelectedIndex = -1;
            }
        }

        private void cmdDefinisciAsseY_Click(object sender, EventArgs e) {
            if (lbElementi.SelectedIndices.Count == 1) {
                Linea l0 = null;
                object elemento = entitaGeometriche[lbElementi.SelectedIndex];
                if (elemento is Linea) {
                    l0 = (Linea)elemento;
                    Linea l1 = new Linea(new Punto(0, 0, false, Color.Black), new Punto(0, 1, false, Color.Black), false, Color.Black);
                    Misura ang = new Misura(l0, l1, false, Misura.Tipologia.Angolo, Color.Black);
                    List<Entita> tmp = new List<Entita>();
                    double x1 = l0.P1.X;
                    double y1 = l0.P1.Y;
                    double x2 = l0.P2.X;
                    double y2 = l0.P2.Y;
                    for (int i = 0; i < entitaGeometriche.Count; i++) {
                        if (!(entitaGeometriche[i] is Allineamento)) {
                            if ((y2 > y1 && x2 > x1) || (y2 < y1 && x2 < x1)) {
                                entitaGeometriche[i].Ruota(new Punto(0, 0, false, Color.Black), ang.ValoreAngolo);
                                if (i == 1) {
                                    angolo += ang.ValoreAngolo;
                                }
                            } else {
                                entitaGeometriche[i].Ruota(new Punto(0, 0, false, Color.Black), -ang.ValoreAngolo);
                                if (i == 1) {
                                    angolo -= ang.ValoreAngolo;
                                }
                            }
                            tmp.Add(entitaGeometriche[i]);
                        }
                    }
                    entitaGeometriche.Clear();
                    entitaGeometriche.Add(allineamento);
                    for (int i = 0; i < tmp.Count; i++) {
                        entitaGeometriche.Add(tmp[i]);
                    }
                    AggiornaLimiti();
                } else {
                    MessageBox.Show("L'elemento selezionato non è corretto", "ATTENZIONE!");
                }

                lbElementi.SelectedIndex = -1;
            }
        }

        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e) {

        }

        private void pbImmagine_MouseDown(object sender, MouseEventArgs e) {
            if (immagineCaricata == null) return;
            if (chbRilevaPunto.Checked) {
                pA_UI = e.Location;
                pB_UI = e.Location;
                isDragging = true;
                PuntoBordoImg = PointF.Empty; // Reset del punto trovato
                pbImmagine.Invalidate();       // Forza il ridisegno
            } else {
                if ((immagineCaricata != null) && (costruzioneAttiva == true)) {
                    Punto pClick = new Punto((e.X / (double)fattoreScala) / (double)fattoreZoomImg - allineamento.o.X, (e.Y / (double)fattoreScala) / (double)fattoreZoomImg - allineamento.o.Y, true, Color.Black);
                    pClick.Ruota(new Punto(0, 0, false, Color.Black), angolo);
                    entitaGeometriche.Add(pClick);
                    lbElementi.SelectedItems.Clear();

                    //Ridisegna grafico
                    AggiornaLimiti();
                } else if (immagineCaricata != null) {
                    CalcolaScala(new Punto(e.X, e.Y, false,Color.Black));
                }
            }
        }

    }
}
