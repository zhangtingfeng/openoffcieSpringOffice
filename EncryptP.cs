using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleAppZTF.Files;

namespace ConsoleAppZTF
{
    class Program
    {

        static Encrypt ddddEncrypt = new Encrypt();
        static EncryptMP4Fun EncryptMP4Fun = new EncryptMP4Fun();

        static DeleteQueue ddddddddd = null;


        static void Main(string[] args)
        {
            //string strRaw = @"C:\Temp\working.accdb";
            //string strOut = @"C:\Temp\workingOut.accdb";
            //string strOutToRaw = @"C:\Temp\workingOutToRaw.accdb";
            ///  new Person();
            ///  

            String strFile = new Files().CopySingleFileToPathKeepStu(@"C:\Logs\WebSite\bpmf - Copy.mp4", @"C:\Logs", @"C:\SSH");
            Console.WriteLine(strFile);


            Console.ReadLine();







            ddddddddd = new DeleteQueue();


            List<FileSystemInfo> ddddPerson = new Files().GetFileList(@"C:\Logs");
            foreach (var ttt in ddddPerson)
            {
                ddddddddd.SetDeleteQueue(ttt.FullName);
            }



            Console.ReadLine();





            string strRaw = @"C:\Temp\1112.xlsx";
            string strOut = @"C:\Temp\1113.xlsx";
            string strOutToRaw = @"C:\Temp\1114.xlsx";

            ddddddddd.SetDeleteQueue(strRaw);

            ddddddddd.SetDeleteQueue(strOut);
            ddddddddd.SetDeleteQueue(strOutToRaw);



        }




    }
}













using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppZTF
{
    class MainProgram
    {

        static Encrypt ddddEncrypt = new Encrypt();
        static EncryptMP4Fun EncryptMP4Fun = new EncryptMP4Fun();

        static void MainProgramMain(string[] args)
        {
            //string strRaw = @"C:\Temp\working.accdb";
            //string strOut = @"C:\Temp\workingOut.accdb";
            //string strOutToRaw = @"C:\Temp\workingOutToRaw.accdb";


            string strRaw = @"C:\Temp\333.mp4";
            string strOut = @"C:\Temp\333Out.mp4";
            string strOutToRaw = @"C:\Temp\333OutRaw.mp4";

            //string strRaw = @"C:\Temp\Capture.PNG";
            //string strOut = @"C:\Temp\CaptureOut.PNG";
            //string strOutToRaw = @"C:\Temp\CaptureOutRaw.PNG";



            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            File.Delete(strOut);
            File.Copy(strRaw, strOut);
            EncryptMP4Fun.fun(strOut);
           // ddddEncrypt.EncryptFile(strRaw, strOut, "123456");

            File.Delete(strOutToRaw);
            File.Copy(strOut, strOutToRaw);
            EncryptMP4Fun.fun(strOutToRaw);
            //ddddEncrypt.DecryptFile(strOut, strOutToRaw, "123456");

            /*
            
            string strRaw = @"C:\Temp\Capture.PNG";
            string strOut = @"C:\Temp\CaptureOut.PNG";

            string strOutToRaw = @"C:\Temp\CaptureOutRaw.PNG";
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            ddddEncrypt.EncryptFile(strRaw, strOut, "123456");
            ddddEncrypt.DecryptFile(strOut, strOutToRaw, "123456");

                      */

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("iLine=" + "RunTime " + elapsedTime + "  " + DateTime.Now.ToString());
            Console.WriteLine("-------------------------------------------------------------------------");

            Console.ReadLine();

        }
    }
}












