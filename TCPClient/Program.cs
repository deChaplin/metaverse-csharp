namespace TCPClient
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
            //helpForm hf = new helpForm();
            Application.Run(new Form1());

            //loginForm loginf = new loginForm();
            //Application.Run(new loginForm());
        }
    }
}