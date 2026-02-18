using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Open2DMeasure {
    static class Program {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

           /* Punto a = new Punto(0, 0, System.Drawing.Color.Black);
            Punto b = new Punto(10, 10, System.Drawing.Color.Black);
            Linea c = new Linea(a, b, System.Drawing.Color.Black);
            Cerchio d = new Cerchio(a, 5, System.Drawing.Color.Black);
            Distanza e = new Distanza(a, b, System.Drawing.Color.Black);
            Punto f = new Punto(c, d, 1, System.Drawing.Color.Black);

            MessageBox.Show(a.ToString());
            MessageBox.Show(b.ToString());
            MessageBox.Show(c.ToString());
            MessageBox.Show(d.ToString());
            MessageBox.Show(e.ToString());
            MessageBox.Show(f.ToString());*/

        }
    }
}
