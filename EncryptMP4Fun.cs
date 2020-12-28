using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppZTF
{
    public class EncryptMP4Fun
    {
        public void fun(String res)
        {
            FileInfo fileinfo = new FileInfo(res);
            long len = 6;
            //MessageBox.Show(len.ToString());
            byte[] buff1 = new byte[len];
            byte[] buff2 = new byte[len];
            FileStream fs = new FileStream(res, FileMode.Open);
            fs.Read(buff1, 0, (int)len);
            fs.Close();
            OppositeByteArray(buff1, ref buff2);
            FileStream fw = new FileStream(res, FileMode.Open);
            for (int i = 0; i < len; i++)
            {
                fw.WriteByte(buff2[i]);
            }
            //fw.Write(buff1, 0, (int)len);
            fw.Write(buff1, 0, (int)len);
            fw.Close();
           // fileinfo = new FileInfo(res);
        }
        /// <summary>
        /// 把一个字节数组按位取反，得到一个新的字节数组
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="outputData"></param>
        public static void OppositeByteArray(byte[] inputData, ref byte[] outputData)
        {
            int len = inputData.Length;


            int temp;


            for (int i = 0; i < len; i++)
            {
                temp = (int)inputData[i];//原字节数组字节转成int型
                outputData[i] = (byte)~temp;//取反后赋给输出字节数组


            }


        }

    }
}
