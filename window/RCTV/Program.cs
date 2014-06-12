using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RCTV
{
    static class Program
    {
        public static string user_id;
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());
            while (RCTVmain.logoutClicked)
            {
                if (RCTVmain.logoutClicked)
                {
                    RCTVmain.logoutClicked = false;
                    Login.loginSuccess = false;
                    Application.Run(new Login());
                }
                if (Login.loginSuccess)
                {
                    RCTVmain.logoutClicked = false;
                    Application.Run(new RCTVmain());
                }
            }

        }
    }
}
