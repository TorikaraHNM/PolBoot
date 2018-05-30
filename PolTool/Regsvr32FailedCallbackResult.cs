namespace PolBoot
{
    /// <summary>
    /// Regsvr32失敗時のコールバック返り値
    /// </summary>
    public enum Regsvr32FailedCallbackResult
    {
        /// <summary>
        /// 中止
        /// </summary>
        Abort,
        /// <summary>
        /// 再試行
        /// </summary>
        Retry,
        /// <summary>
        /// 無視
        /// </summary>
        Ignore
    }
}
