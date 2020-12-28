using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppZTF
{
    public class Files
    {

        static List<FileSystemInfo> ddfileListdd = new List<FileSystemInfo>();


        public string CopySingleFileToPathKeepStu(string strFile, String thisFileRepath, string detinationPath)
        {
            char charpath = '/';
            if (strFile.Contains('\\')) charpath = '\\';

            if (strFile.LastIndexOf(charpath) > thisFileRepath.Length) {
                string strMakePath = strFile.Substring(thisFileRepath.Length + 1, strFile.LastIndexOf(charpath) - thisFileRepath.Length - 1);
                String[] eachPath = strMakePath.Split(charpath);

                //  string destinationfilepath = "";
                foreach (var item in eachPath)
                {
                    detinationPath = detinationPath + charpath + item;
                    if (!Directory.Exists(detinationPath))
                    {
                        Directory.CreateDirectory(detinationPath);
                    }
                    //destinationfilepath += charpath + item;
                }
            }

            String strDetionPathFile = detinationPath + strFile.Substring(strFile.LastIndexOf(charpath) , strFile.Length- strFile.LastIndexOf(charpath) );
            File.Copy(strFile, strDetionPathFile);

            return strDetionPathFile;
        }









        public List<FileSystemInfo> GetFileList(string path)
        {
            ddfileListdd.Clear();
            // ddfileListdd = new List<FileSystemInfo>();
            seearchAllFileList(path);
            return ddfileListdd;
        }

        private void seearchAllFileList(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            //返回目录下的全部文件
            FileSystemInfo[] fileInfo = dir.GetFileSystemInfos();
            foreach (var item in fileInfo)
            {

                if (item is DirectoryInfo)
                {
                    ///  foreach(var ddd in item) {
                    seearchAllFileList(item.FullName);
                    // }
                }
                else
                {
                    //添加文件名
                    //list.Add(item.Name.Substring(0, item.Name.LastIndexOf('.')));
                    ddfileListdd.Add(
                        item
                        ); ;
                }
            }
        }


    }
}
