using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;


class  Program
{
    static HttpClient client = new HttpClient();
    static string serverUrl = "https://pc-remote-controller.onrender.com"

    static async EventTask Main()
    {
        Console.WriteLine("PC Remote Client çalışıyor. Komutlar dinleniyor...");

        while (true)
        {
            try
            {
                string cmd = await client.GetStringAsync($"{serverUrl}/get-command");

                if (!string.IsNullOrWhiteSpace(cmd))
                {
                    Console.WriteLine("Gelen Komut: " + cmd);

                    if (cmd == "shutdown")
                    {
                        Process.Start("shutdown", "/s /f /t 0");
                    }
                    else if (cmd == "restart")
                    {
                        Process.Start("shutdown", "/r /f /t 0");
                    }
                    else if (cmd == "lock")
                    {
                        Process.Start("rund1132.exe", "user32.dll,LockWorkStation");
                    }
                }
            }
            catch { }

            await Task.Delay(1500);
        }
    }
}