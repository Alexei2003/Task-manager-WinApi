using System.Runtime.InteropServices;

namespace SystemInfo.Processes.WinApi.PTAPI
{
    public class PTAPI : ProcessthreadsapiDLL
    {
        /// <summary>
        /// Константы доступа к процессу
        /// </summary>
        public enum ProcessDesiredAccess : uint
        {
            DELETE = 0x00010000,
            READ_CONTROL = 0x00020000,
            SYNCHRONIZE = 0x00100000,
            WRITE_DAC = 0x00040000,
            WRITE_OWNER = 0x00080000,
            PROCESS_ALL_ACCESS = 0x001F0FFF,
            PROCESS_CREATE_PROCESS = 0x0080,
            PROCESS_CREATE_THREAD = 0x0002,
            PROCESS_DUP_HANDLE = 0x0040,
            PROCESS_QUERY_INFORMATION = 0x0400,
            PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
            PROCESS_SET_INFORMATION = 0x0200,
            PROCESS_SET_QUOTA = 0x0100,
            PROCESS_SUSPEND_RESUME = 0x0800,
            PROCESS_TERMINATE = 0x0001,
            PROCESS_VM_OPERATION = 0x0008,
            PROCESS_VM_READ = 0x0010,
            PROCESS_VM_WRITE = 0x0020,
        }

        /// <summary>
        /// Открывает существующий локальный объект процесса.(Возвращает Handle)
        /// </summary>
        public static IntPtr OpenProcess(ProcessDesiredAccess desiredAccess, bool inheritHandle, uint processId)
        {
            return ProcessthreadsapiDLL.OpenProcess(Convert.ToUInt32(desiredAccess), inheritHandle, processId);
        }

        public static bool TerminateProcess(IntPtr processHandle, uint exitCode)
        {
            return ProcessthreadsapiDLL.TerminateProcess(processHandle, exitCode);
        }

        public enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            TokenRestrictedSids,
            TokenSessionId,
            TokenGroupsAndPrivileges,
            TokenSessionReference,
            TokenSandBoxInert,
            TokenAuditPolicy,
            TokenOrigin,
            TokenElevationType,
            TokenLinkedToken,
            TokenElevation,
            TokenHasRestrictions,
            TokenAccessInformation,
            TokenVirtualizationAllowed,
            TokenVirtualizationEnabled,
            TokenIntegrityLevel,
            TokenUIAccess,
            TokenMandatoryPolicy,
            TokenLogonSid,
            TokenIsAppContainer,
            TokenCapabilities,
            TokenAppContainerSid,
            TokenAppContainerNumber,
            TokenUserClaimAttributes,
            TokenDeviceClaimAttributes,
            TokenRestrictedUserClaimAttributes,
            TokenRestrictedDeviceClaimAttributes,
            TokenDeviceGroups,
            TokenRestrictedDeviceGroups,
            TokenSecurityAttributes,
            TokenIsRestricted,
            TokenProcessTrustLevel,
            TokenPrivateNameSpace,
            TokenSingletonAttributes,
            TokenBnoIsolation,
            TokenChildProcessFlags,
            TokenIsLessPrivilegedAppContainer,
            TokenIsSandboxed,
            MaxTokenInfoClass
        }

        public enum SID_NAME_USE
        {
            SidTypeUser = 1,
            SidTypeGroup,
            SidTypeDomain,
            SidTypeAlias,
            SidTypeWellKnownGroup,
            SidTypeDeletedAccount,
            SidTypeInvalid,
            SidTypeUnknown,
            SidTypeComputer,
            SidTypeLabel
        }

        public enum TokenDesiredAccess : uint
        {
            AssignPrimary = 0x0001,
            Duplicate = 0x0002,
            Impersonate = 0x0004,
            Query = 0x0008,
            QuerySource = 0x0010,
            AdjustPrivileges = 0x0020,
            AdjustGroups = 0x0040,
            AdjustDefault = 0x0080,
            AdjustSessionId = 0x0100,

            Read = 0x00020000 | Query,

            Write = 0x00020000 | AdjustPrivileges | AdjustGroups | AdjustDefault,

            AllAccess = 0x000F0000 |
                AssignPrimary |
                Duplicate |
                Impersonate |
                Query |
                QuerySource |
                AdjustPrivileges |
                AdjustGroups |
                AdjustDefault |
                AdjustSessionId,

            MaximumAllowed = 0x02000000
        }

        public static IntPtr OpenProcessToken(IntPtr processHandle, TokenDesiredAccess tokenDesiredAccess)
        {
            ProcessthreadsapiDLL.OpenProcessToken(processHandle, Convert.ToUInt32(tokenDesiredAccess), out IntPtr tokenHandle);
            return tokenHandle;
        }

        public static IntPtr GetTokenInformation(IntPtr tokenHandle, TOKEN_INFORMATION_CLASS tokenIformationClass)
        {
            const int bufLength = 1024;
            IntPtr tokenUser = Marshal.AllocHGlobal(bufLength);
            ProcessthreadsapiDLL.GetTokenInformation(tokenHandle, tokenIformationClass, tokenUser, 0, out uint tokenInfoLength);
            ProcessthreadsapiDLL.GetTokenInformation(tokenHandle, tokenIformationClass, tokenUser, tokenInfoLength, out _);

            return tokenUser;
        }

        public static uint GetProcessId()
        {
            return GetCurrentProcessId();
        }
    }
}
