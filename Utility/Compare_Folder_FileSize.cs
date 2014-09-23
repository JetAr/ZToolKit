// 比较两个目录，输出文件大小相同的文件对。

using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Diagnostics;

namespace FolderCompareWithSize
{
    class Program
    {
        public static void ProcessDirectory(string targetDirectory,ref List<string> listFiles)
        {
            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName,ref listFiles);

            // Recurse into subdirectories of this directory. 
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory,ref listFiles);
        }

        public static void ProcessFile(string path, ref List<string> listFiles)
        {
            listFiles.Add(path);
        }

        public static void Compare_Folder_FileSize(string[] paths)
        {
            List<string> fileList1 = new List<string>();
            List<string> fileList2 = new List<string>();

            ProcessDirectory(paths[0], ref fileList1);
            ProcessDirectory(paths[1], ref fileList2);
            
            foreach (string strPath1 in fileList1)
            {
                int pos0 = strPath1.IndexOf("\\Res - en");
                if(pos0 >= 0)
                {
                    string strPath10 = strPath1.Substring(pos0);
                    Trace.WriteLine(strPath10);
                }
                else
                {
                    Trace.WriteLine(strPath1);
                }
                
                FileInfo f0 = new FileInfo(strPath1);
                foreach (string strPath2 in fileList2)
                {
                    FileInfo f1 = new FileInfo(strPath2);

                    if(f0.Length == f1.Length && f0.Length > 0)
                    {
                        int pos1 = strPath2.IndexOf("\\Res");
                        if (pos1 >= 0)
                        {
                            string strPath10 = strPath2.Substring(pos1);
                            Trace.WriteLine(strPath10);
                        }
                        else
                        {
                            Trace.WriteLine(strPath2);
                        }
                    }
                }

                Trace.WriteLine("\n");
            }
        }

        public static void Test_FileInfo(string[] args)
        {
            DirectoryInfo di0 = new DirectoryInfo(args[0]);
            DirectoryInfo di1 = new DirectoryInfo(args[1]);

            FileInfo[] fiArr0 = di0.GetFiles();
            FileInfo[] fiArr1 = di1.GetFiles();

            foreach (FileInfo f0 in fiArr0)
            {
                foreach (FileInfo f1 in fiArr1)
                {
                    if(f0.Length == f1.Length)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("{0}\n{1}",f0.FullName,f1.FullName);
                        Trace.WriteLine(sb.ToString());
                    }
                }

                Trace.WriteLine("\n");
            }
        }

        static void Main(string[] args)
        {
            if(args.Length == 2
                && Directory.Exists(args[0])
                && Directory.Exists(args[1])
                )
            {
                Compare_Folder_FileSize(args);
            }
        }
    }
}
