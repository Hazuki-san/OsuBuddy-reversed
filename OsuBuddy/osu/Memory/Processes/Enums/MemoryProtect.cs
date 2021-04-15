namespace osu.Memory.Processes.Enums
{
    public enum MemoryProtect
    {
        PageNoAccess = 0x00000001,
        PageReadonly = 0x00000002,
        PageReadWrite = 0x00000004,
        PageWriteCopy = 0x00000008,
        PageExecute = 0x00000010,
        PageExecuteRead = 0x00000020,
        PageExecuteReadWrite = 0x00000040,
        PageExecuteWriteCopy = 0x00000080,
        PageGuard = 0x00000100,
        PageNoCache = 0x00000200,
        PageWriteCombine = 0x00000400
    }
}
