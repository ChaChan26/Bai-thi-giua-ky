using QuanLySanPham.GUI.Views;

namespace QuanLySanPham.GUI
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmQuanLySanPham());
        }
    }
}
