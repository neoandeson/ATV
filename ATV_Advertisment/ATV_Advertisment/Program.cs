﻿using ATV_Advertisment.Forms.CommonForms;
using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                using (SingleInstanceMutex sim = new SingleInstanceMutex())
                {
                    if (sim.IsOtherInstanceRunning)
                    {
                        MessageBox.Show(CommonMessage.APPLICATION_IS_RUNNING,
                            "Running...",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                        Application.Exit();
                    }
                    else
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new GlobalForm());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        class SingleInstanceMutex : IDisposable
        {
            private bool isNoOtherInstanceRunning;
            private Mutex singleInstanceMutex = null;
            private bool disposed;

            public SingleInstanceMutex()
            {
                this.singleInstanceMutex = new Mutex(true,
                                                    Assembly.GetCallingAssembly().FullName,
                                                    out this.isNoOtherInstanceRunning);
            }

            /// <summary>
            /// Gets an indicator whether another instance of the application is running or not
            /// </summary>
            /// 
            public bool IsOtherInstanceRunning
            {
                get
                {
                    return !this.isNoOtherInstanceRunning;
                }
            }

            /// <summary>
            /// Close the <see cref="SingleInstanceMutex"/>
            /// </summary>
            /// 
            public void Close()
            {
                this.ThrowIfDisposed();
                this.singleInstanceMutex.Close();
            }

            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }

            private void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    //Release unmanaged resources
                    if (disposing)
                    {
                        //Release managed reources
                        this.Close();
                    }

                    this.disposed = true;
                }
            }

            /// <summary>
            /// Throws an exception if something is tried to be done with an already disposed object.
            /// </summary>
            /// <remarks>
            /// All public methods of the class must first call this
            /// </remarks>
            public void ThrowIfDisposed()
            {
                if (this.disposed)
                {
                    throw new ObjectDisposedException(this.GetType().Name);
                }
            }
        }
    }
}
