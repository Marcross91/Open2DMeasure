using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Open2DMeasure {
    class Punto : Entita {
        private double x = 0, y = 0;
        private string nome = null;
        private static long quantiPunti = 0;
        private bool isSelected = false;


        public double X {
            get { return x; }
            set { x = value; }
        }

        public double Y {
            get { return y; }
            set { y = value; }
        }

        public string Nome {
            get { return nome; }
        }


        //Vuoto
        public Punto() { }

        //Punto da coordinate
        public Punto(double _x, double _y, bool _assegnaNome, Color _colore) : base(_colore) {
            x = _x;
            y = _y;
            AssegnaNome(_assegnaNome); 
        }

        //Punto da linea
        public Punto(Linea l, double percentuale, bool _assegnaNome, Color _colore) : base(_colore) {
            if (percentuale <= 100 && percentuale >= 0) {
                percentuale /= 100;
                double a = (l.M * l.M) + 1;
                double b = 2 * ((l.M * l.Q) - (l.M * l.P1.Y) - (l.P1.X));
                double c = (l.Q * l.Q) + (l.P1.Y * l.P1.Y) + (l.P1.X * l.P1.X) - (2 * l.Q * l.P1.Y) - (percentuale * percentuale * l.Lunghezza * l.Lunghezza);
                if (l.P2.X > l.P1.X) {
                    x = (-b + Math.Sqrt((b * b) - 4 * a * c)) / (2 * a);
                    y = l.M * x + l.Q;
                } else {
                    x = (-b - Math.Sqrt((b * b) - 4 * a * c)) / (2 * a);
                }
            }
            AssegnaNome(_assegnaNome);
        }

        //Punto intersezione linee
        public Punto(Linea l1, Linea l2, bool _assegnaNome, Color _colore) : base(_colore) {
            if (l1.M != l2.M) {
                x = (l1.B * l2.C - l2.B * l1.C) / (l1.A * l2.B - l2.A * l1.B);
                y = (l1.C * l2.A - l2.C * l1.A) / (l1.A * l2.B - l2.A * l1.B);
                AssegnaNome(_assegnaNome);
            }
        }

        //Punto intersezione linea cerchio
        public Punto(Linea l, Cerchio cerchio, int pos, bool _assegnaNome, Color _colore) : base(_colore) {
            double dL = l.A * cerchio.Centro.X + l.B * cerchio.Centro.Y + l.C;
            double S = Math.Pow(l.A, 2) + Math.Pow(l.B, 2);

            if (Math.Pow(cerchio.R, 2) - (Math.Pow(dL, 2) / S) >= 0) {
                double x0 = cerchio.Centro.X - (l.A * dL) / S;
                double y0 = cerchio.Centro.Y - (l.B * dL) / S;
                double h = Math.Sqrt((Math.Pow(cerchio.R, 2) - (Math.Pow(dL, 2) / S)) / S);
                if (pos == 1) {
                    x = x0 + l.B * h;
                    y = y0 - l.A * h;
                } else if (pos == 2) {
                    x = x0 - l.B * h;
                    y = y0 + l.A * h;
                }
                AssegnaNome(_assegnaNome);
            }
        }

        public Punto Copia() {
            return (new Punto(this.x, this.y, false, this.colore));
        }

        protected override void AssegnaNome(bool _assegnaNome) {
            if (_assegnaNome) {
                quantiPunti++;
                this.nome = "P" + quantiPunti;
            } else {
                this.nome = "Punto";
            }
        }

        public override void AzzeraContatore() {
            quantiPunti = 0;
        }

        public override void Sposta(double deltaX, double deltaY) {
            x += deltaX;
            y += deltaY;
        }

        public override void Ruota(Punto fulcro, double angolo) {
            angolo = Math.PI * angolo / 180;
            double _x = x;
            x = (_x - fulcro.X) * Math.Cos(angolo) - (y - fulcro.Y) * Math.Sin(angolo) + fulcro.X;
            y = (_x - fulcro.X) * Math.Sin(angolo) + (y - fulcro.Y) * Math.Cos(angolo) + fulcro.Y;
        }

        public override void DecrementaQuantita(Entita ent) {
            quantiPunti -= 1;
        }

        public override void Disegna(Graphics g, double fattoreScala, Allineamento allineamento, float ampiezzaPenna, Font f) {
            // 1. Definisce i colori
            Color mainColor = Color.FromArgb(255, 0, 0, 255); // Blu
            Color glowColor = Color.FromArgb(50, 0, 0, 255); // Blu molto trasparente
            Color shadowColor = Color.FromArgb(100, 0, 0, 0);  // Ombra nera

            // 2. Disegniamo l'ombra/contorno per il contrasto (leggermente più larga)
            using (Pen shadowPen = new Pen(shadowColor, 4 * ampiezzaPenna)) {
                g.DrawEllipse(shadowPen, (int)((this.X + allineamento.o.X) * fattoreScala - 2), (int)((this.Y + allineamento.o.Y) * fattoreScala - 2), 4 * ampiezzaPenna, 4 * ampiezzaPenna);
            }

            // 3. Disegniamo il "Glow" (effetto neon)
            using (Pen glowPen = new Pen(glowColor, 6 * ampiezzaPenna)) {
                g.DrawEllipse(glowPen, (int)((this.X + allineamento.o.X) * fattoreScala - 2), (int)((this.Y + allineamento.o.Y) * fattoreScala - 2), 4 * ampiezzaPenna, 4 * ampiezzaPenna);
            }

            // 4. Disegniamo la linea principale (sottile e netta)
            using (Pen mainPen = new Pen(mainColor, (float)(1.5 * ampiezzaPenna))) {
                g.DrawEllipse(mainPen, (int)((this.X + allineamento.o.X) * fattoreScala - 2), (int)((this.Y + allineamento.o.Y) * fattoreScala - 2), 4 * ampiezzaPenna, 4 * ampiezzaPenna);
            }
        }

        public override bool HitTest(Punto mouse, double tolleranza) {
            double dx = mouse.X - this.X;
            double dy = mouse.Y - this.Y;
            return (dx * dx + dy * dy) <= tolleranza * tolleranza;
        }

        public override string ToString() {
            return (nome + ": (" + x.ToString("F3") + ";" + y.ToString("F3") + ")");
        }

        public override Punto PuntoMax() {
            return this;
        }

        public override Punto PuntoMin() {
            return this;
        }

        public static bool MinoreX(Punto p1, Punto p2) {
            return (p1.X < p2.X);
        }

        public static bool MinoreY(Punto p1, Punto p2) {
            return (p1.Y < p2.Y);
        }

        public static bool MaggioreX(Punto p1, Punto p2) {
            return (p1.X > p2.X);
        }

        public static bool MaggioreY(Punto p1, Punto p2) {
            return (p1.Y > p2.Y);
        }

    }
}
