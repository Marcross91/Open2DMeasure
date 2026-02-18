using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Open2DMeasure {
    class Misura : Entita {
        public enum Tipologia { Distanza, DistanzaX, DistanzaY, Diametro, Raggio, Angolo}
        private double valore = 0;
        private double valoreX = 0;
        private double valoreY = 0;
        private double valoreDiametro = 0;
        private double valoreRaggio = 0;
        private double valoreAngolo = 0;
        private double tolPiu = 0;
        private double tolMeno = 0;
        private double valoreNominale = 0;
        private bool stato = false;
        private static long quanteDistanze = 0;
        private static long quanteDistanzeX = 0;
        private static long quanteDistanzeY = 0;
        private static long quantiDiametri = 0;
        private static long quantiRaggi = 0;
        private static long quantiAngoli = 0;
        private string nome = null;

        private Tipologia tipo = Tipologia.Distanza;

        public Tipologia Tipo {
            get { return tipo; }
            set { tipo = value; }
        }

        public double Valore {
            get { return valore; }
            set {  valore = value; }
        }

        public double ValoreX {
            get { return valoreX; }
            set { valoreX = value; }
        }

        public double ValoreY {
            get { return valoreY; }
            set { valoreY = value; }
        }

        public double ValoreDiametro {
            get { return valoreDiametro; }
            set {valoreDiametro = value; }
        }

        public double ValoreRaggio {
            get { return valoreRaggio; }
            set{ valoreRaggio = value; }
        }

        public double ValoreAngolo {
            get { return valoreAngolo; }
            set { valoreAngolo = value; }
        }

        public double TolPiu {
            get { return tolPiu; }
            set { tolPiu = value; }
        }

        public double TolMeno {
            get { return tolMeno; }
            set { tolMeno = value; }
        }

        public double ValoreNominale {
            get { return valoreNominale; }
            set { valoreNominale = value; }
        }

        public string Nome {
            get { return nome; }
            set { nome = value; }
        }



        //Vuoto
        public Misura() {
        }


        public Misura(Tipologia _tipo) {
            if (_tipo == Tipologia.Distanza) {
                quanteDistanze++;
            } else if (_tipo == Tipologia.DistanzaX) {
                quanteDistanzeX++;
            } else if (_tipo == Tipologia.DistanzaY) {
                quanteDistanzeY++;
            } else if (_tipo == Tipologia.Diametro) {
                quantiDiametri++;
            } else if (_tipo == Tipologia.Raggio) {
                quantiRaggi++;
            } else if (_tipo == Tipologia.Angolo) {
                quantiAngoli++;
            }
            this.Tipo = _tipo;
        }

        //Distanza tra due punti
        public Misura(Punto p1, Punto p2, bool _assegnaNome, Tipologia _tipo, Color _colore) : base(_colore) {
            valore = CalcolaDistanza(p1, p2);
            valoreX = CalcolaDistanzaX(p1, p2);
            valoreY = CalcolaDistanzaY(p1, p2);
            tipo = _tipo;
            AssegnaNome(_assegnaNome);
        }

        //Distanza punto linea
        public Misura(Punto p, Linea l, bool _assegnaNome, Color _colore) : base(_colore) {
            valore = CalcolaDistanza(p, l);
            AssegnaNome(_assegnaNome);
        }

        //Distanza punto cerchio
        public Misura(Punto p, Cerchio c, int pos, bool _assegnaNome, Tipologia _tipo, Color _colore): base(_colore) {
            if (pos == 1) { //Punto-centro
                valore = CalcolaDistanza(p, c.Centro);
                valoreX = CalcolaDistanzaX(p, c.Centro);
                valoreY = CalcolaDistanzaY(p, c.Centro);
            } else if (pos == 2) { //più vicina
                Linea l = new Linea(p, c.Centro, false, Color.Black);
                Punto p1 = new Punto(l, c, 1, false, Color.Black);
                valore = CalcolaDistanza(p, p1);
                valoreX = CalcolaDistanzaX(p, p1);
                valoreY = CalcolaDistanzaY(p, p1);
            } else if (pos == 3) { //più distante
                Linea l = new Linea(p, c.Centro, false, Color.Black);
                Punto p1 = new Punto(l, c, 2, false, Color.Black);
                valore = CalcolaDistanza(p, p1);
                valoreX = CalcolaDistanzaX(p, p1);
                valoreY = CalcolaDistanzaY(p, p1);
            }
            tipo = _tipo;
            AssegnaNome(_assegnaNome);
        }

        //Distanza linee parallele e Angolo
        public Misura(Linea l1, Linea l2, bool _assegnaNome, Tipologia _tipo, Color _colore) : base(_colore) {
            if (_tipo == Tipologia.Distanza) {
                valore = CalcolaDistanza(l1, l2);
            } else if (_tipo == Tipologia.Angolo) {
                valoreAngolo = Math.Acos(Math.Abs(l1.A * l2.A + l1.B * l2.B)/(Math.Sqrt(Math.Pow(l1.A,2)+ Math.Pow(l1.B, 2)) * Math.Sqrt(Math.Pow(l2.A, 2) + Math.Pow(l2.B, 2))));
                valoreAngolo = valoreAngolo * 180 / Math.PI;
            }
            tipo = _tipo;
            AssegnaNome(_assegnaNome);
        }

        //Distanza linea cerchio
        public Misura(Linea l, Cerchio c, int pos, bool _assegnaNome, Color _colore) : base(_colore) {
            if (pos == 1) {
                valore = CalcolaDistanza(c.Centro, l);
            } else if (pos == 2) {
                Linea l1 = new Linea(l, c.Centro, 90, false, Color.Black);
                Punto p1 = new Punto(l1, c, 1, false, Color.Black);
                valore = CalcolaDistanza(p1, l);
            } else if (pos == 3) {
                Linea l1 = new Linea(l, c.Centro, 90, false, Color.Black);
                Punto p1 = new Punto(l1, c, 2, false, Color.Black);
                valore = CalcolaDistanza(p1, l);
            }
            AssegnaNome(_assegnaNome);
        }

      //Distanza cerchio cerchio
        public Misura(Cerchio c1, Cerchio c2, int pos, bool _assegnaNome, Tipologia _tipo, Color _colore) : base(_colore) {
            if (pos == 1) {
                valore = CalcolaDistanza(c1.Centro, c2.Centro);
                valoreX = CalcolaDistanzaX(c1.Centro, c2.Centro);
                valoreY = CalcolaDistanzaY(c1.Centro, c2.Centro);
            } else if (pos == 2) {
                Linea l1 = new Linea(c1.Centro, c2.Centro, false, Color.Black);
                Punto p1 = new Punto(l1, c1, 1, false, Color.Black);
                Punto p2 = new Punto(l1, c2, 2, false, Color.Black);
                valore = CalcolaDistanza(p1, p2);
                valoreX = CalcolaDistanzaX(p1, p2);
                valoreY = CalcolaDistanzaY(p1, p2);
            } else if (pos == 3) {
                Linea l1 = new Linea(c1.Centro, c2.Centro, false, Color.Black);
                Punto p1 = new Punto(l1, c1, 2, false, Color.Black);
                Punto p2 = new Punto(l1, c2, 1, false, Color.Black);
                valore = CalcolaDistanza(p1, p2);
                valoreX = CalcolaDistanzaX(p1, p2);
                valoreY = CalcolaDistanzaY(p1, p2);
            }
            tipo = _tipo;
            AssegnaNome(_assegnaNome);
        }

        //Diametro e raggio
        public Misura(Cerchio c, bool _assegnaNome, Tipologia _tipo, Color _colore) : base(_colore) {
            if (_tipo == Tipologia.Diametro) {
                valoreDiametro = c.R * 2;
            } else if (_tipo == Tipologia.Raggio) {
                valoreRaggio = c.R;
            }
            tipo = _tipo;
            AssegnaNome(_assegnaNome);
        }

        private double CalcolaDistanza(Punto p1, Punto p2) {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private double CalcolaDistanzaX(Punto p1, Punto p2) {
            return Math.Abs(p1.X - p2.X);
        }

        private double CalcolaDistanzaY(Punto p1, Punto p2) {
            return Math.Abs(p1.Y - p2.Y);
        }

        private double CalcolaDistanza(Punto p, Linea l) {
            return Math.Abs(l.A * p.X + l.B * p.Y + l.C) / Math.Sqrt(Math.Pow(l.A,2) + Math.Pow(l.B, 2));
        }


        private double CalcolaDistanza(Linea l1, Linea l2) {
            if (l1.M == l2.M) {
                return CalcolaDistanza(l1.P1, l2);
            } else {
                return 0;
            }
        }

        protected override void AssegnaNome(bool _assegnaNome) {
            if (_assegnaNome) {
                if (tipo == Tipologia.Distanza) {
                    quanteDistanze++;
                    this.nome = "D" + quanteDistanze;
                } else if (tipo == Tipologia.DistanzaX) {
                    quanteDistanzeX++;
                    this.nome = "DX" + quanteDistanzeX;
                } else if (tipo == Tipologia.DistanzaY) {
                    quanteDistanzeY++;
                    this.nome = "DY" + quanteDistanzeY;
                } else if (tipo == Tipologia.Diametro) {
                    quantiDiametri++;
                    this.nome = "DI" + quantiDiametri;
                } else if (tipo == Tipologia.Raggio) {
                    quantiRaggi++;
                    this.nome = "R" + quantiRaggi;
                } else if (tipo == Tipologia.Angolo) {
                    quantiAngoli++;
                    this.nome = "ANG" + quantiAngoli;
                } else {
                    this.nome = "Distanza";
                }
            }
        }

        public override void DecrementaQuantita(Entita ent) {
            if (ent is Misura) {
                Tipologia _tipo = (ent as Misura).Tipo;
                if (_tipo == Tipologia.Distanza) {
                    quanteDistanze--;
                } else if (_tipo == Tipologia.DistanzaX) {
                    quanteDistanzeX--;
                } else if (_tipo == Tipologia.DistanzaY) {
                    quanteDistanzeY--;
                } else if (_tipo == Tipologia.Diametro) {
                    quantiDiametri--;
                } else if (_tipo == Tipologia.Raggio) {
                    quantiRaggi--;
                } else if (_tipo == Tipologia.Angolo) {
                    quantiAngoli--;
                }
            }
        }

        public override void AzzeraContatore() {
            quanteDistanze = 0;
        }

        public string CalcolaStato() {
            if (tipo == Tipologia.Distanza) {
                return ((valore >= valoreNominale + tolMeno) && (valore <= valoreNominale + tolPiu)) ? "OK" : "KO";
            } else if (tipo == Tipologia.DistanzaX) {
                return ((valoreX >= valoreNominale + tolMeno) && (valoreX <= valoreNominale + tolPiu)) ? "OK" : "KO"; ;
            } else if (tipo == Tipologia.DistanzaY) {
                return ((valoreY >= valoreNominale + tolMeno) && (valoreY <= valoreNominale + tolPiu)) ? "OK" : "KO"; ;
            } else if (tipo == Tipologia.Diametro) {
                return ((valoreDiametro >= valoreNominale + tolMeno) && (valoreDiametro <= valoreNominale + tolPiu)) ? "OK" : "KO"; ;
            } else if (tipo == Tipologia.Raggio) {
                return ((valoreRaggio >= valoreNominale + tolMeno) && (valoreRaggio <= valoreNominale + tolPiu)) ? "OK" : "KO"; ;
            } else if (tipo == Tipologia.Angolo) {
                return ((valoreAngolo >= valoreNominale + tolMeno) && (valoreAngolo <= valoreNominale + tolPiu)) ? "OK" : "KO"; ;
            } else {
                return "NULL";
            }
        }

        public double CalcolaValore() {
            if (tipo == Tipologia.Distanza) {
                return valore;
            } else if (tipo == Tipologia.DistanzaX) {
                return valoreX;
            } else if (tipo == Tipologia.DistanzaY) {
                return valoreY;
            } else if (tipo == Tipologia.Diametro) {
                return valoreDiametro;
            } else if (tipo == Tipologia.Raggio) {
                return valoreRaggio;
            } else if (tipo == Tipologia.Angolo) {
                return valoreAngolo;
            } else {
                return 0;
            }
        }

        public override string ToString() {
            if (tipo == Tipologia.Distanza) {
                return (nome + ": " + valore.ToString("F3"));
            } else if (tipo == Tipologia.DistanzaX) {
                return (nome + ": " + valoreX.ToString("F3"));
            } else if (tipo == Tipologia.DistanzaY) {
                return (nome + ": " + valoreY.ToString("F3"));
            } else if (tipo == Tipologia.Diametro) {
                return (nome + ": " + valoreDiametro.ToString("F3"));
            } else if (tipo == Tipologia.Raggio) {
                return (nome + ": " + valoreRaggio.ToString("F3"));
            } else if (tipo == Tipologia.Angolo) {
                return (nome + ": " + valoreAngolo.ToString("F3") + " & " + (180 - valoreAngolo).ToString("F3"));
            } else {
                return nome;
            }
        }
    }
}
