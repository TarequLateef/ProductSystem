namespace SharedLiberary.General
{
    public class SerialCode
    {
        int NumberOfLetter { get; set; }
        int LastCode { get; set; }

        /// <summary>
        /// make a number coding for data
        /// </summary>
        /// <param name="NumberOfLetter">count of code letter</param>
        /// <param name="BaseCode">the last number of code</param>
        /// <returns>full code with left zero(s) if there a place for them</returns>
        public static string CovnertCode(int NumberOfLetter, string BaseCode)
        {
            string compCode = string.Empty;
            int baseLen = BaseCode.Length;
            if (baseLen < NumberOfLetter)
                for (int i = baseLen; i < NumberOfLetter; i++)
                    compCode+="0";
            return compCode + BaseCode;
        }
        public SerialCode(int numberOfLetter, int lastCode)
        {
            this.NumberOfLetter=numberOfLetter;
            this.LastCode=lastCode;
        }

        /// <summary>
        /// add 1 to the count of list of data and then add zero(s) to the left of the code
        /// </summary>
        public string GenerateCode
        {
            get
            {
                string newCode = (LastCode + 1).ToString();
                if (newCode.Length>NumberOfLetter) return "the code get max limit";
                string compCode = string.Empty;
                int baseLen = newCode.Length;
                if (baseLen < NumberOfLetter)
                    for (int i = baseLen; i < NumberOfLetter; i++)
                        compCode+="0";
                return compCode + newCode;
            }
        }
    }

    public enum AppOperations { Create, Update, Delete, Stop, Print, List }
}
