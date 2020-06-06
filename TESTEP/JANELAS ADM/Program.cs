using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTEP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Categoria());
            //Application.Run(new ingredientes());
            //Application.Run(new Utilizadores());
         //Application.Run(new Receitas());
            // Application.Run(new Area_Pessoal());
           Application.Run(new Login());
          //  Application.Run(new PaginaInicial());
           // Application.Run(new Comentarios());




        }
    }
}
