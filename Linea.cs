using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Open2DMeasure {
    class Linea : Entita {
        private Punto p1, p2;
        private double m, q, lunghezza;
        private double a, b, c;
        private string nome = null;
        public static long quanteLinee = 0;
        private Punto PMax = null;
        private Punto PMin = null;

        public Punto P1 {
            get { return p1; }
        }

        public Punto P2 {
            get { return p2; }
        }

        public double A {
           get { return a; }
        }

        public double B {
            get { return b; }
        }

        public double C {
            get { return c; }
        }

        public double M {
            get {
                if (b != 0) return -a / b;
                else return double.MaxValue;
                 ; }
        }

        public double Q {
            get {
                if (b != 0) return -c / b;
                else return double.MaxValue;
                ; }
        }

        public double Lunghezza {
            get { return lunghezza; }
        }

        public string Nome {
            get { return nome; }
        }

        //Vuoto
        public Linea() { }

        //Linea per due punti
        public Linea(Punto _p1, Punto _p2, bool _assegnaNome, Color _colore) : base(_colore) {
            p1 = _p1.Copia();
            p2 = _p2.Copia();
            RicalcolaEquazione();
            lunghezza = Math.Sqrt(((_p1.Y - _p2.Y) * (_p1.Y - _p2.Y)) + ((_p1.X - _p2.X) * (_p1.X - _p2.X)));
            AssegnaNome(_assegnaNome);
        }

        //Linea ruotata per un punto
        public Linea(Linea _l, Punto _p, int angolo, bool _assegnaNome, Color _colore) : base(_colore) {
            Linea l = _l.Copia();
            Punto p = _p.Copia();
            l.Ruota(l.P1, angolo);
            double dX = p.X - l.P1.X;
            double dY = p.Y - l.P1.Y;
            l.Sposta(dX, dY);
            p1 = l.P1;
            p2 = l.P2;
            RicalcolaEquazione();
            lunghezza = l.Lunghezza;
            AssegnaNome(_assegnaNome);
        }

        public Linea Copia() {
            return (new Linea(this.p1, this.p2, false, this.colore));
        }

        public void RicalcolaEquazione() {
            a = p1.Y - p2.Y;
            b = p2.X - p1.X;
            c = p1.X * p2.Y - p2.X * p1.Y;

            if (b != 0) {
                m = -a / b; 
                q = -c / b;
            } else {
                m = double.MaxValue;
                q = double.MaxValue;
            }

            PMax = new Punto(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y), false, Color.Black);
            PMin = new Punto(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), false, Color.Black);
        }

        protected override void AssegnaNome(bool _assegnaNome) {
            if (_assegnaNome) {
                quanteLinee++;
                this.nome = "L" + quanteLinee;
            } else {
                this.nome = "Linea";
            }
        }

        public override void AzzeraContatore() {
            quanteLinee = 0;
        }

        public override void Sposta(double deltaX, double deltaY) {
            p1.Sposta(deltaX, deltaY);
            p2.Sposta(deltaX, deltaY);
            RicalcolaEquazione();
        }

        public override void Ruota(Punto fulcro, double angolo) {
            p1.Ruota(fulcro, angolo);
            p2.Ruota(fulcro, angolo);
            RicalcolaEquazione();
        }

        public override void Scala(double percentuale) {
            percentuale /= 100;
            lunghezza *= percentuale;
            Punto m = new Punto((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2, false, Color.Black);
            Linea l = new Linea(m, p2, false, Color.Black);
            Cerchio c = new Cerchio(m, lunghezza / 2, false, Color.Black);
            p1 = new Punto(l, c, 1, false, Color.Black);
            p2 = new Punto(l, c, 2, false, Color.Black);
            RicalcolaEquazione();
        }

        public override void DecrementaQuantita(Entita ent) {
            quanteLinee -= 1;
        }

        public override void Disegna(Graphics g, double fattoreScala, Allineamento allineamento, float ampiezzaPenna, Font f) {
           // 1. Definisce i colori
            Color mainColor = Color.FromArgb(255, 255, 0, 0); // Rosso
            Color glowColor = Color.FromArgb(50, 255, 0, 0); // Rosso molto trasparente
            Color shadowColor = Color.FromArgb(100, 0, 0, 0);  // Ombra nera

            // 2. Disegniamo l'ombra/contorno per il contrasto (leggermente più larga)
            using (Pen shadowPen = new Pen(shadowColor, 4 * ampiezzaPenna)) {
                g.DrawLine(shadowPen, new Point((int)((this.P1.X + allineamento.o.X) * fattoreScala), (int)((this.P1.Y + allineamento.o.Y) * fattoreScala)), new Point((int)((this.P2.X + allineamento.o.X) * fattoreScala), (int)((this.P2.Y + allineamento.o.Y) * fattoreScala)));
            }

            // 3. Disegniamo il "Glow" (effetto neon)
            using (Pen glowPen = new Pen(glowColor, 6 * ampiezzaPenna)) {
                g.DrawLine(glowPen, new Point((int)((this.P1.X + allineamento.o.X) * fattoreScala), (int)((this.P1.Y + allineamento.o.Y) * fattoreScala)), new Point((int)((this.P2.X + allineamento.o.X) * fattoreScala), (int)((this.P2.Y + allineamento.o.Y) * fattoreScala)));
            }

            // 4. Disegniamo la linea principale (sottile e netta)
            using (Pen mainPen = new Pen(mainColor, (float)(1.5 * ampiezzaPenna))) {
                g.DrawLine(mainPen, new Point((int)((this.P1.X + allineamento.o.X) * fattoreScala), (int)((this.P1.Y + allineamento.o.Y) * fattoreScala)), new Point((int)((this.P2.X + allineamento.o.X) * fattoreScala), (int)((this.P2.Y + allineamento.o.Y) * fattoreScala)));
            }
        }

        public override bool HitTest(Punto mouse, double tolleranza) {
            Linea l = this.Copia();
            Misura d = new Misura(mouse, l, false, Color.Black);
            double minX = Math.Min(l.p1.X, l.p2.X);
            double maxX = Math.Max(l.p1.X, l.p2.X);
            double minY = Math.Min(l.p1.Y, l.p2.Y);
            double maxY = Math.Max(l.p1.Y, l.p2.Y);
            bool neiLimiti;
            if (minX != maxX && minY != maxY) {
                neiLimiti = (mouse.X >= minX - tolleranza && mouse.X <= maxX + tolleranza && mouse.Y >= minY - tolleranza && mouse.Y <= maxY + tolleranza);
            } else if (minX != maxX && minY == maxY) {
                neiLimiti = (mouse.X >= minX - tolleranza && mouse.X <= maxX + tolleranza);
            } else {
                neiLimiti = (mouse.Y >= minY - tolleranza && mouse.Y <= maxY + tolleranza);
            }
                return (d.Valore <= tolleranza && neiLimiti);
        }

        public override string ToString() { 
            if (m != Double.MaxValue && a != 0) {
                return (nome + ": " + a.ToString("F3") + "x + " + b.ToString("F3") + "y + " + c.ToString("F3") + " = 0");
            } else if (m != double.MaxValue && a == 0) {
                return (nome + ": y = " + p1.Y.ToString("F3"));
            } else {
                return (nome + ": x = " + p1.X.ToString("F3"));
            }
        }

        public override Punto PuntoMax() {
            return PMax;
        }

        public override Punto PuntoMin() {
            return PMin;
        }

    }
}
