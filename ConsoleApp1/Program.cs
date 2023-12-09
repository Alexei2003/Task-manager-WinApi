using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;

class Program
{
    const int TOKEN_QUERY = 0x0008;
    const int TokenUser = 1;

    [DllImport("advapi32.dll", SetLastError = true)]
    static extern bool OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, out IntPtr TokenHandle);

    [DllImport("advapi32.dll", SetLastError = true)]
    static extern bool GetTokenInformation(IntPtr TokenHandle, int TokenInformationClass, IntPtr TokenInformation, int TokenInformationLength, out int ReturnLength);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool CloseHandle(IntPtr hObject);

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_USER
    {
        public SID_AND_ATTRIBUTES User;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SID_AND_ATTRIBUTES
    {
        public IntPtr Sid;
        public int Attributes;
    }

    static void Main(string[] args)
    {
        string processName = "browser.exe"; // Имя процесса, для которого нужно получить имя пользователя

        Process process = System.Diagnostics.Process.GetProcessById(892);
        if (process != null)
        {
            IntPtr processHandle = process.Handle;
            IntPtr tokenHandle;
            if (OpenProcessToken(processHandle, TOKEN_QUERY, out tokenHandle))
            {
                try
                {
                    string userName = GetProcessUserName(tokenHandle);
                    Console.WriteLine($"Имя пользователя, создавшего процесс '{processName}': {userName}");
                }
                finally
                {
                    CloseHandle(tokenHandle);
                }
            }
            else
            {
                int error = Marshal.GetLastWin32Error();
                Console.WriteLine($"Ошибка при открытии токена процесса: {new Win32Exception(error).Message}");
            }
        }
        else
        {
            Console.WriteLine($"Процесс '{processName}' не найден.");
        }
    }

    static string GetProcessUserName(IntPtr tokenHandle)
    {
        const int bufLength = 1024;
        IntPtr userTokenInformation = Marshal.AllocHGlobal(bufLength);
        try
        {
            int returnLength;
            if (GetTokenInformation(tokenHandle, TokenUser, userTokenInformation, bufLength, out returnLength))
            {
                TOKEN_USER tokenUser = (TOKEN_USER)Marshal.PtrToStructure(userTokenInformation, typeof(TOKEN_USER));
                SecurityIdentifier sid = new SecurityIdentifier(tokenUser.User.Sid);
                return sid.Translate(typeof(NTAccount)).ToString();
            }
            else
            {
                int error = Marshal.GetLastWin32Error();
                throw new Win32Exception(error);
            }
        }
        finally
        {
            Marshal.FreeHGlobal(userTokenInformation);
        }
    }
}
