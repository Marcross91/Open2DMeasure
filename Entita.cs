using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Open2DMeasure {
    class Entita {
        Color colore2 = Color.Black;
        protected string name = "";
        protected Pen penna = null;
        protected bool solido = false;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public Color colore {
            get {
                return colore2;
            }
            set {
                colore2 = value;
                penna = new Pen(colore2);
            }
        }

        public Entita() { }
        public Entita(Color _colore) {
            colore2 = _colore;
            penna = new Pen(colore2);
        }

        virtual public void DecrementaQuantita(Entita ent) {
        }

        virtual public void Disegna(Graphics g, double fattoreScala, Allineamento allineamento, float ampiezzaPenna, Font f) {
        }

        virtual protected void AssegnaNome(bool _assegnaNome) {
        }

        virtual protected void AssegnaNome(bool _assegnaNome, Misura.Tipologia tipo) {
        }

        virtual public void AzzeraContatore() {
        }

        virtual public void Sposta(double deltaX, double deltaY) {
        }

        virtual public void Ruota(Punto fulcro, double angolo) {
        }

        virtual public void Scala(double percentuale) {
        }

        virtual public bool HitTest(Punto mouse, double tolleranza) {
           return false;
        }

        virtual public Punto PuntoMax() {
            return null;
        }

        virtual public Punto PuntoMin() {
            return null;
        }
    }
}
