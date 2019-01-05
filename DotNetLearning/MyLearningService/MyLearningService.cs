using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyLearningService
{
    public partial class MyLearningService : ServiceBase
    {

        public MyLearningService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            try
            {

                StreamWriter sWriter = new StreamWriter(@"C:\Users\Sunil\Documents\visual studio 2013\Projects\DotNetLearning\ServiceFile\MyLearning.txt", true, Encoding.UTF8);

                for (int i = 0; i < 100; i++)
                {
                    sWriter.Write(i.ToString());

                    Thread.Sleep(1000);
                }

                sWriter.Close();
            }
            catch (Exception exc)
            {

            }


            // TODO: Add code here to start your service.
            //eventLog1.WriteEntry("my service started");
        }

        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            //eventLog1.WriteEntry("my service stoped");
        }
    }
}
