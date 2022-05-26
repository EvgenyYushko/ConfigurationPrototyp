using System;
using System.Windows.Forms;
using Autofac;

namespace ConfigurationPrototyp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            var builder = new ContainerBuilder();
            builder.RegisterModule<InjectModule>();
            IContainer container = builder.Build();

            try
            {
                Application.Run(container.Resolve<AppCustomForm>());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
