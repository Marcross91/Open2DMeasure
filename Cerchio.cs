using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Open2DMeasure {
    class Cerchio : Entita {
        private Punto centro;
        private double a, b, c, raggio;
        private string nome = null;
        private static long quantiCerchi = 0;
        private Punto PMax = null;
        private Punto PMin = null;

        public double A {
            get { return a; }
        }

        public double B {
            get { return b; }
        }

        public double C {
            get { return c; }
        }

        public Punto Centro {
            get { return centro; }
        }

        public double R {
            get { return raggio; }
        }

        public string Nome {
            get { return nome; }
        }

        //Vuoto
        public Cerchio() { }

        //Cerchio dato centro e raggio
        public Cerchio(Punto _centro, double _raggio, bool _assegnaNome, Color _colore) : base(_colore) {
            centro = _centro.Copia();
            raggio = _raggio;
            a = -2 * _centro.X;
            b = -2 * _centro.Y;
            c = (_centro.X * _centro.X) + (_centro.Y * _centro.Y) - (_raggio * _raggio);
            PMax = new Punto(_centro.X + _raggio, _centro.Y + _raggio, false, Color.Black);
            PMin = new Punto(centro.X - raggio, centro.Y - raggio, false, Color.Black);
            AssegnaNome(_assegnaNome);
        }

        //Cerchio per tre punti
        public Cerchio(Punto p1, Punto p2, Punto p3, bool _assegnaNome, Color _colore) : base(_colore) {
            double D, E, F, G, H, I, J, K, L, M, N, O;
            D = (p2.X - p1.X);
            E = (p2.Y - p1.Y);
            F = ((p2.X * p2.X) - (p1.X * p1.X));
            G = ((p2.Y * p2.Y) - (p1.Y * p1.Y));
            H = (p1.Y - p3.Y);
            I = ((p3.X * p3.X) - (p1.X * p1.X));
            J = ((p3.Y * p3.Y) - (p1.Y * p1.Y));
            K = (p3.X - p1.X);
            L = ((p3.X * p3.X) + (p3.Y * p3.Y));
            M = (p1.Y + p3.Y);
            N = (p3.X + p1.X);
            O = ((p1.X * p1.X) + (p1.Y * p1.Y));
            if ((E != 0) && (D != 0)) {
                a = -((((F + G) / E) * H) + I + J) / (((D / E) * H) + K);
                b = -(((a * D) + F + G) / E);
                if (p1.X != 0 || p1.Y != 0) {
                    c = -((p1.X * a) + (p1.Y * b) + (p1.X * p1.X) + (p1.Y * p1.Y));
                } else if (p2.X != 0 || p2.Y != 0) {
                    c = -((p2.X * a) + (p2.Y * b) + (p2.X * p2.X) + (p2.Y * p2.Y));
                } else if (p3.X != 0 || p3.Y != 0) {
                    c = -((p3.X * a) + (p3.Y * b) + (p3.X * p3.X) + (p3.Y * p3.Y));
                }

            } else if (E != 0) {
                b = -(F + G) / E;
                a = -(b * M + L + O) / N;
                if (p1.X != 0 || p1.Y != 0) {
                    c = -((p1.X * a) + (p1.Y * b) + O);
                } else if (p2.X != 0 || p2.Y != 0) {
                    c = -((p2.X * a) + (p2.Y * b) + O);
                } else if (p3.X != 0 || p3.Y != 0) {
                    c = -((p3.X * a) + (p3.Y * b) + O);
                }
            } else if (D != 0) {
                a = -(F + G) / D;
                b = -(a * N + L + O) / M;
                if (p1.X != 0 || p1.Y != 0) {
                    c = -((p1.X * a) + (p1.Y * b) + O);
                } else if (p2.X != 0 || p2.Y != 0) {
                    c = -((p2.X * a) + (p2.Y * b) + O);
                } else if (p3.X != 0 || p3.Y != 0) {
                    c = -((p3.X * a) + (p3.Y * b) + O);
                }
            }
            centro = new Punto(-a / 2, -b / 2, false, Color.Black);
            raggio = Math.Sqrt((centro.X * centro.X) + (centro.Y * centro.Y)-c);
            PMax = new Punto(centro.X + raggio, centro.Y + raggio, false, Color.Black);
            PMin = new Punto(centro.X - raggio, centro.Y - raggio, false, Color.Black);
            AssegnaNome(_assegnaNome);
        }

        public void RicalcolaEquazione() {
            a = -2 * centro.X;
            b = -2 * centro.Y;
            c = (centro.X * centro.X) + (centro.Y * centro.Y) - (raggio * raggio);
            PMax = new Punto(centro.X + raggio, centro.Y + raggio, false, Color.Black);
            PMin = new Punto(centro.X - raggio, centro.Y - raggio, false, Color.Black);
        }

        protected override void AssegnaNome(bool _assegnaNome) {
            if (_assegnaNome) {
                quantiCerchi++;
                this.nome = "C" + quantiCerchi;
            } else {
                this.nome = "Cerchio";
            }
        }

        public override void AzzeraContatore() {
            quantiCerchi = 0;
        }

        public override void Sposta(double deltaX, double deltaY) {
            centro.Sposta(deltaX, deltaY);
            RicalcolaEquazione();
        }

        public override void Ruota(Punto fulcro, double angolo) {
            centro.Ruota(fulcro, angolo);
            RicalcolaEquazione();
        }

        public override void Scala(double percentuale) {
            percentuale /= 100;
            raggio *= percentuale;
            RicalcolaEquazione();
        }

        public override void DecrementaQuantita(Entita ent) {
            quantiCerchi -= 1;
        }

        public override void Disegna(Graphics g, double fattoreScala, Allineamento allineamento, float ampiezzaPenna, Font f) {
            // 1. Definisce i colori
            Color mainColor = Color.FromArgb(255, 0, 255, 0); // Verde
            Color glowColor = Color.FromArgb(50, 0,255, 0); // Verde molto trasparente
            Color shadowColor = Color.FromArgb(100, 0, 0, 0);  // Ombra nera

            // 2. Disegniamo l'ombra/contorno per il contrasto (leggermente più larga)
            using (Pen shadowPen = new Pen(shadowColor, 4 * ampiezzaPenna)) {
                g.DrawEllipse(shadowPen, (int)((this.Centro.X - this.R + allineamento.o.X) * fattoreScala), (int)((this.Centro.Y - this.R + allineamento.o.Y) * fattoreScala), (int)(2 * this.R * fattoreScala), (int)(2 * this.R * fattoreScala));
            }

            // 3. Disegniamo il "Glow" (effetto neon)
            using (Pen glowPen = new Pen(glowColor, 6 * ampiezzaPenna)) {
                g.DrawEllipse(glowPen, (int)((this.Centro.X - this.R + allineamento.o.X) * fattoreScala), (int)((this.Centro.Y - this.R + allineamento.o.Y) * fattoreScala), (int)(2 * this.R * fattoreScala), (int)(2 * this.R * fattoreScala));
            }

            // 4. Disegniamo la linea principale (sottile e netta)
            using (Pen mainPen = new Pen(mainColor, (float)(1.5 * ampiezzaPenna))) {
                g.DrawEllipse(mainPen, (int)((this.Centro.X - this.R + allineamento.o.X) * fattoreScala), (int)((this.Centro.Y - this.R + allineamento.o.Y) * fattoreScala), (int)(2 * this.R * fattoreScala), (int)(2 * this.R * fattoreScala));
            }
        }

        public override bool HitTest(Punto mouse, double tolleranza) {
            double dx = mouse.X - this.centro.X;
            double dy = mouse.Y - this.centro.Y;
            return ((dx * dx + dy * dy) <= (tolleranza + this.raggio) * (tolleranza + this.raggio)) && ((dx * dx + dy * dy) >= (this.raggio - tolleranza) * (this.raggio - tolleranza));
        }

        public override string ToString() {
            double rq;
            rq = raggio * raggio;
            return (nome + ": (x - " + centro.X.ToString("F3") + ")^2 + (y - " + centro.Y.ToString("F3") + ")^2 = " + rq.ToString("F3"));
        }

        public override Punto PuntoMax() {
            return PMax;
        }

        public override Punto PuntoMin() {
            return PMin;
        }
    }
}
