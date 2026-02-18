using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Open2DMeasure {
    public partial class frmInfo : Form {
        public frmInfo() {
            InitializeComponent();
        }

        private void frmInfo_Load(object sender, EventArgs e) {
            // Recuperiamo i metadati dell'Assembly
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyName asmName = asm.GetName();

            // Recuperiamo la Company (Creatore)
            string creatore = "Non specificato";
            var companyAttr = asm.GetCustomAttribute<AssemblyCompanyAttribute>();
            if (companyAttr != null) creatore = companyAttr.Company;

            // Recuperiamo il Copyright
            string copyright = "";
            var copyAttr = asm.GetCustomAttribute<AssemblyCopyrightAttribute>();
            if (copyAttr != null) copyright = copyAttr.Copyright;

            // Componiamo il testo
            lblInfo.Text = $"{Application.ProductName}\n" +
                           $"Versione: {asmName.Version}\n\n" +
                           $"Sviluppato da: {creatore}\n" +
                           $"{copyright}";
        }
    }
}
