//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GSharp.Generated.NativeClasses {
    using System.ComponentModel;
    using System;
    
    
    public interface IFileSystem {
        
        bool IsSteam();
        
        /// <param name='nExtraAppId'></param>
        System.IntPtr MountSteamContent(int nExtraAppId);
        
        /// <param name='pPath'></param>
        /// <param name='pathID'></param>
        /// <param name='addType'></param>
        void AddSearchPath(string pPath, string pathID, System.IntPtr addType);
        
        /// <param name='pPath'></param>
        /// <param name='pathID'></param>
        bool RemoveSearchPath(string pPath, string pathID);
        
        void RemoveAllSearchPaths();
        
        /// <param name='szPathID'></param>
        void RemoveSearchPaths(string szPathID);
        
        /// <param name='pPathID'></param>
        /// <param name='bRequestOnly'></param>
        void MarkPathIDByRequestOnly(string pPathID, bool bRequestOnly);
        
        /// <param name='pFileName'></param>
        /// <param name='pPathID'></param>
        /// <param name='pDest'></param>
        /// <param name='maxLenInChars'></param>
        /// <param name='pathFilter'></param>
        /// <param name='pPathType'></param>
        string RelativePathToFullPath(string pFileName, string pPathID, System.IntPtr pDest, int maxLenInChars, System.IntPtr pathFilter, System.IntPtr pPathType);
        
        /// <param name='pathID'></param>
        /// <param name='bGetPackFiles'></param>
        /// <param name='pDest'></param>
        /// <param name='maxLenInChars'></param>
        int GetSearchPath(string pathID, bool bGetPackFiles, System.IntPtr pDest, int maxLenInChars);
        
        /// <param name='fullpath'></param>
        /// <param name='pathID'></param>
        bool AddPackFile(string fullpath, string pathID);
        
        /// <param name='pRelativePath'></param>
        /// <param name='pathID'></param>
        void RemoveFile(string pRelativePath, string pathID);
        
        /// <param name='pOldPath'></param>
        /// <param name='pNewPath'></param>
        /// <param name='pathID'></param>
        bool RenameFile(string pOldPath, string pNewPath, string pathID);
        
        /// <param name='path'></param>
        /// <param name='pathID'></param>
        void CreateDirHierarchy(string path, string pathID);
        
        /// <param name='pFileName'></param>
        /// <param name='pathID'></param>
        bool IsDirectory(string pFileName, string pathID);
        
        /// <param name='pStrip'></param>
        /// <param name='maxCharsIncludingTerminator'></param>
        /// <param name='fileTime'></param>
        void FileTimeToString(System.IntPtr pStrip, int maxCharsIncludingTerminator, int fileTime);
        
        /// <param name='file'></param>
        /// <param name='nBytes'></param>
        void SetBufferSize(System.IntPtr file, uint nBytes);
        
        /// <param name='file'></param>
        bool IsOk(System.IntPtr file);
        
        /// <param name='file'></param>
        bool EndOfFile(System.IntPtr file);
        
        /// <param name='pOutput'></param>
        /// <param name='maxChars'></param>
        /// <param name='file'></param>
        System.IntPtr ReadLine(System.IntPtr pOutput, int maxChars, System.IntPtr file);
        
        /// <param name='file'></param>
        /// <param name='pFormat'></param>
        int FPrintf(System.IntPtr file, string pFormat);
        
        /// <param name='pFileName'></param>
        /// <param name='pPathID'></param>
        /// <param name='bValidatedDllOnly'></param>
        System.IntPtr LoadModule(string pFileName, string pPathID, bool bValidatedDllOnly);
        
        /// <param name='pModule'></param>
        void UnloadModule(System.IntPtr pModule);
        
        /// <param name='pWildCard'></param>
        /// <param name='pHandle'></param>
        string FindFirst(string pWildCard, System.IntPtr pHandle);
        
        /// <param name='handle'></param>
        string FindNext(int handle);
        
        /// <param name='handle'></param>
        bool FindIsDirectory(int handle);
        
        /// <param name='handle'></param>
        void FindClose(int handle);
        
        /// <param name='pWildCard'></param>
        /// <param name='pPathID'></param>
        /// <param name='pHandle'></param>
        string FindFirstEx(string pWildCard, string pPathID, System.IntPtr pHandle);
        
        /// <param name='pFileName'></param>
        /// <param name='pDest'></param>
        /// <param name='maxLenInChars'></param>
        string GetLocalPath(string pFileName, System.IntPtr pDest, int maxLenInChars);
        
        /// <param name='pFullpath'></param>
        /// <param name='pDest'></param>
        /// <param name='maxLenInChars'></param>
        bool FullPathToRelativePath(string pFullpath, System.IntPtr pDest, int maxLenInChars);
        
        /// <param name='pDirectory'></param>
        /// <param name='maxlen'></param>
        bool GetCurrentDirectory(System.IntPtr pDirectory, int maxlen);
        
        /// <param name='pFileName'></param>
        System.IntPtr FindOrAddFileName(string pFileName);
        
        /// <param name='handle'></param>
        /// <param name='buf'></param>
        /// <param name='buflen'></param>
        bool String(System.IntPtr handle, System.IntPtr buf, int buflen);
        
        void AsyncReadNONVIRTUALINLINE();
        
        /// <param name='pRequests'></param>
        /// <param name='nRequests'></param>
        /// <param name='phControls'></param>
        System.IntPtr AsyncReadMultiple(System.IntPtr pRequests, int nRequests, System.IntPtr phControls);
        
        /// <param name='pFileName'></param>
        /// <param name='pSrc'></param>
        /// <param name='nSrcBytes'></param>
        /// <param name='bFreeMemory'></param>
        /// <param name='pControl'></param>
        System.IntPtr AsyncAppend(string pFileName, System.IntPtr pSrc, int nSrcBytes, bool bFreeMemory, System.IntPtr pControl);
        
        /// <param name='pAppendToFileName'></param>
        /// <param name='pAppendFromFileName'></param>
        /// <param name='pControl'></param>
        System.IntPtr AsyncAppendFile(string pAppendToFileName, string pAppendFromFileName, System.IntPtr pControl);
        
        /// <param name='iToPriority'></param>
        void AsyncFinishAll(int iToPriority);
        
        void AsyncFinishAllWrites();
        
        System.IntPtr AsyncFlush();
        
        bool AsyncSuspend();
        
        bool AsyncResume();
        
        /// <param name='pFetcher'></param>
        void AsyncAddFetcher(System.IntPtr pFetcher);
        
        /// <param name='pFetcher'></param>
        void AsyncRemoveFetcher(System.IntPtr pFetcher);
        
        /// <param name='pszFile'></param>
        /// <param name='phFile'></param>
        System.IntPtr AsyncBeginRead(string pszFile, System.IntPtr phFile);
        
        /// <param name='hFile'></param>
        System.IntPtr AsyncEndRead(System.IntPtr hFile);
        
        /// <param name='hControl'></param>
        /// <param name='wait'></param>
        System.IntPtr AsyncFinish(System.IntPtr hControl, bool wait);
        
        /// <param name='hControl'></param>
        /// <param name='ppData'></param>
        /// <param name='pSize'></param>
        System.IntPtr AsyncGetResult(System.IntPtr hControl, System.IntPtr ppData, System.IntPtr pSize);
        
        /// <param name='hControl'></param>
        System.IntPtr AsyncAbort(System.IntPtr hControl);
        
        /// <param name='hControl'></param>
        System.IntPtr AsyncStatus(System.IntPtr hControl);
        
        /// <param name='hControl'></param>
        /// <param name='newPriority'></param>
        System.IntPtr AsyncSetPriority(System.IntPtr hControl, int newPriority);
        
        /// <param name='hControl'></param>
        void AsyncAddRef(System.IntPtr hControl);
        
        /// <param name='hControl'></param>
        void AsyncRelease(System.IntPtr hControl);
        
        /// <param name='resourcelist'></param>
        int WaitForResources(string resourcelist);
        
        /// <param name='handle'></param>
        /// <param name='progress'></param>
        /// <param name='complete'></param>
        bool GetWaitForResourcesProgress(int handle, System.IntPtr progress, System.IntPtr complete);
        
        /// <param name='handle'></param>
        void CancelWaitForResources(int handle);
        
        /// <param name='hintlist'></param>
        /// <param name='forgetEverything'></param>
        int HintResourceNeed(string hintlist, int forgetEverything);
        
        /// <param name='pFileName'></param>
        bool IsFileImmediatelyAvailable(string pFileName);
        
        /// <param name='pFileName'></param>
        void GetLocalCopy(string pFileName);
        
        void PrintOpenedFiles();
        
        void PrintSearchPaths();
        
        /// <param name='pfnWarning'></param>
        void SetWarningFunc(System.IntPtr pfnWarning);
        
        /// <param name='level'></param>
        void SetWarningLevel(System.IntPtr level);
        
        /// <param name='pfnLogFunc'></param>
        void AddLoggingFunc(System.IntPtr pfnLogFunc);
        
        /// <param name='logFunc'></param>
        void RemoveLoggingFunc(System.IntPtr logFunc);
        
        System.IntPtr GetFilesystemStatistics();
        
        /// <param name='pFileName'></param>
        /// <param name='pOptions'></param>
        /// <param name='flags'></param>
        /// <param name='pathID'></param>
        /// <param name='ppszResolvedFilename'></param>
        System.IntPtr OpenEx(string pFileName, string pOptions, uint flags, string pathID, System.IntPtr ppszResolvedFilename);
        
        /// <param name='pOutput'></param>
        /// <param name='sizeDest'></param>
        /// <param name='size'></param>
        /// <param name='file'></param>
        int ReadEx(System.IntPtr pOutput, int sizeDest, int size, System.IntPtr file);
        
        /// <param name='pFileName'></param>
        /// <param name='pPath'></param>
        /// <param name='ppBuf'></param>
        /// <param name='bNullTerminate'></param>
        /// <param name='bOptimalAlloc'></param>
        /// <param name='nMaxBytes'></param>
        /// <param name='nStartingByte'></param>
        /// <param name='pfnAlloc'></param>
        int ReadFileEx(string pFileName, string pPath, System.IntPtr ppBuf, bool bNullTerminate, bool bOptimalAlloc, int nMaxBytes, int nStartingByte, System.IntPtr pfnAlloc);
        
        /// <param name='pFileName'></param>
        System.IntPtr FindFileName(string pFileName);
        
        void SetupPreloadData();
        
        void DiscardPreloadData();
        
        /// <param name='type'></param>
        /// <param name='archiveFile'></param>
        void LoadCompiledKeyValues(System.IntPtr type, string archiveFile);
        
        /// <param name='type'></param>
        /// <param name='filename'></param>
        /// <param name='pPathID'></param>
        System.IntPtr LoadKeyValues(System.IntPtr type, string filename, string pPathID);
        
        /// <param name='head'></param>
        /// <param name='type'></param>
        /// <param name='filename'></param>
        /// <param name='pPathID'></param>
        bool LoadKeyValues(System.IntPtr head, System.IntPtr type, string filename, string pPathID);
        
        /// <param name='type'></param>
        /// <param name='outbuf'></param>
        /// <param name='bufsize'></param>
        /// <param name='filename'></param>
        /// <param name='pPathID'></param>
        bool ExtractRootKeyName(System.IntPtr type, System.IntPtr outbuf, uint bufsize, string filename, string pPathID);
        
        /// <param name='pFileName'></param>
        /// <param name='pSrc'></param>
        /// <param name='nSrcBytes'></param>
        /// <param name='bFreeMemory'></param>
        /// <param name='bAppend'></param>
        /// <param name='pControl'></param>
        System.IntPtr AsyncWrite(string pFileName, System.IntPtr pSrc, int nSrcBytes, bool bFreeMemory, bool bAppend, System.IntPtr pControl);
        
        /// <param name='pFileName'></param>
        /// <param name='pSrc'></param>
        /// <param name='nSrcBytes'></param>
        /// <param name='bFreeMemory'></param>
        /// <param name='bAppend'></param>
        /// <param name='pControl'></param>
        System.IntPtr AsyncWriteFile(string pFileName, System.IntPtr pSrc, int nSrcBytes, bool bFreeMemory, bool bAppend, System.IntPtr pControl);
        
        void AsyncReadCreditAllocNONVIRTUALINLINE();
        
        /// <param name='pRequests'></param>
        /// <param name='nRequests'></param>
        /// <param name='pszFile'></param>
        /// <param name='line'></param>
        /// <param name='phControls'></param>
        System.IntPtr AsyncReadMultipleCreditAlloc(System.IntPtr pRequests, int nRequests, string pszFile, int line, System.IntPtr phControls);
        
        /// <param name='pFullPath'></param>
        /// <param name='buf'></param>
        /// <param name='bufSizeInBytes'></param>
        bool GetFileTypeForFullPath(string pFullPath, System.IntPtr buf, uint bufSizeInBytes);
        
        /// <param name='hFile'></param>
        /// <param name='buf'></param>
        /// <param name='nMaxBytes'></param>
        /// <param name='pfnAlloc'></param>
        bool ReadToBuffer(System.IntPtr hFile, System.IntPtr buf, int nMaxBytes, System.IntPtr pfnAlloc);
        
        /// <param name='hFile'></param>
        /// <param name='pOffsetAlign'></param>
        /// <param name='pSizeAlign'></param>
        /// <param name='pBufferAlign'></param>
        bool GetOptimalIOConstraints(System.IntPtr hFile, System.IntPtr pOffsetAlign, System.IntPtr pSizeAlign, System.IntPtr pBufferAlign);
        
        void GetOptimalReadSizeNONVIRTUALINLINE();
        
        /// <param name='hFile'></param>
        /// <param name='nSize'></param>
        /// <param name='nOffset'></param>
        System.IntPtr AllocOptimalReadBuffer(System.IntPtr hFile, uint nSize, uint nOffset);
        
        /// <param name='param0'></param>
        void FreeOptimalReadBuffer(System.IntPtr param0);
        
        void BeginMapAccess();
        
        void EndMapAccess();
        
        /// <param name='pFullpath'></param>
        /// <param name='pPathId'></param>
        /// <param name='pDest'></param>
        /// <param name='maxLenInChars'></param>
        bool FullPathToRelativePathEx(string pFullpath, string pPathId, System.IntPtr pDest, int maxLenInChars);
        
        /// <param name='handle'></param>
        int GetPathIndex(System.IntPtr handle);
        
        /// <param name='pPath'></param>
        /// <param name='pPathID'></param>
        int GetPathTime(string pPath, string pPathID);
        
        System.IntPtr GetDVDMode();
        
        /// <param name='bEnable'></param>
        /// <param name='bCacheAllVPKHashes'></param>
        /// <param name='bRecalculateAndCheckHashes'></param>
        void EnableWhitelistFileTracking(bool bEnable, bool bCacheAllVPKHashes, bool bRecalculateAndCheckHashes);
        
        /// <param name='pWhiteList'></param>
        /// <param name='pFilesToReload'></param>
        void RegisterFileWhitelist(System.IntPtr pWhiteList, System.IntPtr pFilesToReload);
        
        void MarkAllCRCsUnverified();
        
        /// <param name='pPathname'></param>
        /// <param name='eType'></param>
        /// <param name='pFilter'></param>
        void CacheFileCRCs(string pPathname, System.IntPtr eType, System.IntPtr pFilter);
        
        /// <param name='pPathID'></param>
        /// <param name='pRelativeFilename'></param>
        /// <param name='nFileFraction'></param>
        /// <param name='pFileHash'></param>
        System.IntPtr CheckCachedFileHash(string pPathID, string pRelativeFilename, int nFileFraction, System.IntPtr pFileHash);
        
        /// <param name='pFiles'></param>
        /// <param name='nMaxFiles'></param>
        int GetUnverifiedFileHashes(System.IntPtr pFiles, int nMaxFiles);
        
        int GetWhitelistSpewFlags();
        
        /// <param name='flags'></param>
        void SetWhitelistSpewFlags(int flags);
        
        /// <param name='func'></param>
        void InstallDirtyDiskReportFunc(System.IntPtr func);
        
        System.IntPtr CreateFileCache();
        
        /// <param name='cacheId'></param>
        /// <param name='ppFileNames'></param>
        /// <param name='nFileNames'></param>
        /// <param name='pPathID'></param>
        void AddFilesToFileCache(System.IntPtr cacheId, System.IntPtr ppFileNames, int nFileNames, string pPathID);
        
        /// <param name='cacheId'></param>
        /// <param name='pFileName'></param>
        bool IsFileCacheFileLoaded(System.IntPtr cacheId, string pFileName);
        
        /// <param name='cacheId'></param>
        bool IsFileCacheLoaded(System.IntPtr cacheId);
        
        /// <param name='cacheId'></param>
        void DestroyFileCache(System.IntPtr cacheId);
        
        /// <param name='pFile'></param>
        /// <param name='ppExistingFileWithRef'></param>
        bool RegisterMemoryFile(System.IntPtr pFile, System.IntPtr ppExistingFileWithRef);
        
        /// <param name='pFile'></param>
        void UnregisterMemoryFile(System.IntPtr pFile);
        
        /// <param name='bCacheAllVPKHashes'></param>
        /// <param name='bRecalculateAndCheckHashes'></param>
        void CacheAllVPKFileHashes(bool bCacheAllVPKHashes, bool bRecalculateAndCheckHashes);
        
        /// <param name='PackFileID'></param>
        /// <param name='nPackFileNumber'></param>
        /// <param name='nFileFraction'></param>
        /// <param name='md5Value'></param>
        bool CheckVPKFileHash(int PackFileID, int nPackFileNumber, int nFileFraction, System.IntPtr md5Value);
        
        /// <param name='pszFilename'></param>
        /// <param name='pPathId'></param>
        void NotifyFileUnloaded(string pszFilename, string pPathId);
    }
}
