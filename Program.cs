/*
 * Open2DMeasure - Software per misurazione ottica 2D
 * Copyright (C) 2026  Porporato Marco
 * * Questo programma è software libero: puoi ridistribuirlo e/o modificarlo
 * sotto i termini della Licenza Pubblica Generica GNU così come pubblicata
 * dalla Free Software Foundation, sia la versione 3 della licenza, o
 * (a tua scelta) qualsiasi versione successiva.
 *
 * Questo programma è distribuito nella speranza che sia utile,
 * ma SENZA ALCUNA GARANZIA; senza neppure la garanzia implicita di
 * COMMERCIABILITÀ o IDONEITÀ PER UN PARTICOLARE SCOPO. 
 * Consulta la Licenza Pubblica Generica GNU per maggiori dettagli.
 *
 * Dovresti aver ricevuto una copia della Licenza Pubblica Generica GNU
 * insieme a questo programma. In caso contrario, vedi <https://www.gnu.org/licenses/>.
 */

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
