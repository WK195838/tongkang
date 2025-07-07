namespace ARTEST.Models
{
    /// <summary>
    /// 操作結果類別
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="isSuccess">是否成功</param>
        /// <param name="errorMessage">錯誤訊息</param>
        public Result(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 成功結果
        /// </summary>
        /// <returns></returns>
        public static Result Success()
        {
            return new Result(true, null);
        }

        /// <summary>
        /// 失敗結果
        /// </summary>
        /// <param name="errorMessage">錯誤訊息</param>
        /// <returns></returns>
        public static Result Failure(string errorMessage)
        {
            return new Result(false, errorMessage);
        }
    }
} 