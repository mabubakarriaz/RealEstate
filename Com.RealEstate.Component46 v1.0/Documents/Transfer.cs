using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Documents
{
    public class Transfer
    {
        public Transfer() { }

        public async void copyFile()
        {
            string source = @"F:\Test\Myfikle.txt";
            FileStream fsIn = new FileStream(source, FileMode.Open, FileAccess.Read, FileShare.None, 8 * 1024, true);
            byte[] data = new byte[fsIn.Length];
            using (fsIn)
            {
                Task<int> tRead = fsIn.ReadAsync(data, 0, data.Length);

                //int temp =await fsIn.ReadAsync(data, 0, data.Length);
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(tRead.Status);
                    Console.WriteLine(i);
                }
                int noOfBytes = await tRead;
                //Task<int> tRead = fsIn.ReadAsync(data, 0, data.Length);
                //int noOfBytes = 0;
                //for (int i = 0; i < 100; i++)
                //{
                //    if (tRead.Status == TaskStatus.RanToCompletion)
                //    {
                //        noOfBytes = tRead.Result;
                //    }
                //    //Console.WriteLine(tRead.Status);
                //    Console.WriteLine(i);
                //}
                Console.WriteLine(noOfBytes + " bytes read from file successfully");
            }
            string dest = @"F:\Test\MyfikleCOPY.txt";
            FileStream fsOut = new FileStream(dest, FileMode.Create, FileAccess.Write, FileShare.None, 8 * 1024, true);
            using (fsOut)
            {
                await fsOut.WriteAsync(data, 0, data.Length);
            }
        }


    }
}
