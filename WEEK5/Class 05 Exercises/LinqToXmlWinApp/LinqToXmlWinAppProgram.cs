﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LinqToXmlWinApp
{
    static class LinqToXmlWinAppProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LinqToXmlWinAppMainForm());
        }
    }
}
