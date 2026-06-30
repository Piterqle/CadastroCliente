namespace CadastroCliente
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            //StreamReader file = File.OpenText(@"C:\DataBaseConnection.json");
            string connectionString = "Data Source=Cliente.db";
            DependencyServices.Configure(connectionString);
            Application.Run(new TelaCliente());
            
        }
    }
}