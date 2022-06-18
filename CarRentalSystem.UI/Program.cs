
using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.Business.DependencyResolver;
using CarRentalSystem.Business.Utilities.Interceptors;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;


namespace CarRentalSystem.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            

            Application.Run(new FormSplash());

        }
       

    }
}