using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Open2DMeasure {
    internal class Allineamento : Entita {
        public Punto o;
        public Linea X, Y;


        //Vuoto
        public Allineamento() {
            o = new Punto(0, 0, false, Color.Black);
            X = new Linea(o, new Punto(0, 1, false, Color.Black), false, Color.Black);
            Y = new Linea(o, new Punto(1, 0, false, Color.Black), false, Color.Black);
        }

        //Origine e asse X
        public Allineamento(Punto _o, Linea _X) {
            o = _o.Copia();
            X = _X.Copia();
            Y = new Linea(_X, _o, 90, false, Color.Black);
        }

        //Asse X e asse Y
        public Allineamento(Linea _X, Linea _Y) {
            if (SonoOrtogonali(_X, _Y)) {
                X = _X.Copia();
                Y = _Y.Copia();
                o = new Punto(_X, _Y, false, Color.Black);
            } else {
                o = new Punto(0, 0, false, Color.Black);
                X = new Linea(o, new Punto(0, 1, false, Color.Black), false, Color.Black);
                Y = new Linea(o, new Punto(1, 0, false, Color.Black), false, Color.Black);
            }
        }

        private bool SonoOrtogonali(Linea l1, Linea l2) {
            return (l1.M * l1.M == -1);
        }

        public override void Sposta(double deltaX, double deltaY) {
            o.Sposta(deltaX, deltaY);
            X.Sposta(deltaX, deltaY);
            Y.Sposta(deltaX, deltaY);
        }

        public override void Ruota(Punto fulcro, double angolo) {
            o.Ruota(fulcro, angolo);
            X.Ruota(fulcro, angolo);
            Y.Ruota(fulcro, angolo);
        }

        public override void Disegna(Graphics g, double fattoreScala, Allineamento allineamento, float ampiezzaPenna, Font f) {
            // 1. Definisce i colori
            Color mainColor = Color.FromArgb(255, 255, 0, 255); // Rosso
            Color glowColor = Color.FromArgb(50, 255, 0, 255); // Rosso molto trasparente
            Color shadowColor = Color.FromArgb(100, 0, 0, 0);  // Ombra nera
            Punto p = allineamento.o;

            // 2. Disegniamo l'ombra/contorno per il contrasto (leggermente più larga)
            using (Pen shadowPen = new Pen(shadowColor, 4 * ampiezzaPenna)) {
                g.DrawEllipse(shadowPen, (int)(p.X * fattoreScala - 2), (int)(p.Y * fattoreScala - 2), 4 * ampiezzaPenna, 4 * ampiezzaPenna);
                g.DrawLine(shadowPen, new Point((int)(p.X * fattoreScala), (int)(p.Y * fattoreScala)), new Point((int)(p.X * fattoreScala + 40 * ampiezzaPenna), (int)(p.Y * fattoreScala)));
                g.DrawLine(shadowPen, new Point((int)(p.X * fattoreScala), (int)(p.Y * fattoreScala)), new Point((int)(p.X * fattoreScala), (int)(p.Y * fattoreScala + 40 * ampiezzaPenna)));
            }

            // 3. Disegniamo il "Glow" (effetto neon)
            using (Pen glowPen = new Pen(glowColor, 6 * ampiezzaPenna)) {
                g.DrawEllipse(glowPen, (int)(p.X * fattoreScala - 2), (int)(p.Y * fattoreScala - 2), 4 * ampiezzaPenna, 4 * ampiezzaPenna);
                g.DrawLine(glowPen, new Point((int)(p.X * fattoreScala), (int)(p.Y * fattoreScala)), new Point((int)(p.X * fattoreScala + 40 * ampiezzaPenna), (int)(p.Y * fattoreScala)));
                g.DrawLine(glowPen, new Point((int)(p.X * fattoreScala), (int)(p.Y * fattoreScala)), new Point((int)(p.X * fattoreScala), (int)(p.Y * fattoreScala + 40 * ampiezzaPenna)));
            }

            // 4. Disegniamo la linea principale (sottile e netta)
            using (Pen mainPen = new Pen(mainColor, (float)(1.5 * ampiezzaPenna))) {
                g.DrawEllipse(mainPen, (int)(p.X * fattoreScala - 2), (int)(p.Y * fattoreScala - 2), 4 * ampiezzaPenna, 4 * ampiezzaPenna);
                g.DrawLine(mainPen, new Point((int)(p.X * fattoreScala), (int)(p.Y * fattoreScala)), new Point((int)(p.X * fattoreScala + 40 * ampiezzaPenna), (int)(p.Y * fattoreScala)));
                g.DrawLine(mainPen, new Point((int)(p.X * fattoreScala), (int)(p.Y * fattoreScala)), new Point((int)(p.X * fattoreScala), (int)(p.Y * fattoreScala + 40 * ampiezzaPenna)));
            }

            using (Pen penna = new Pen(Color.Black, 3 * ampiezzaPenna)) {
                Brush b = new SolidBrush(Color.Black);
                g.DrawString("X", f, b, new Point((int)(p.X * fattoreScala + 50 * ampiezzaPenna), (int)(p.Y * fattoreScala)));
                g.DrawString("Y", f, b, new Point((int)(p.X * fattoreScala), (int)(p.Y * fattoreScala + 50 * ampiezzaPenna)));
            }
        }

        public override string ToString() {
            return ("Origine: (" + o.X.ToString("F3") + ";" + o.Y.ToString("F3") + ")");
        }

        public override Punto PuntoMax() {
            return this.o;
        }

        public override Punto PuntoMin() {
            return this.o;
        }
    }
}
