namespace EPR.CLI.Core.Commands
{
    public class CommandProgress
    {
        /// <summary>
        /// Creates a new <see cref="CommandProgress"/> with the given message,
        /// and sets <see cref="HasKey"/> to false.
        /// </summary>
        /// <param name="message">The progress message.</param>
        public CommandProgress(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Creates a new <see cref="CommandProgress"/> with the given key and 
        /// value, sets <see cref="HasKey"/> to true and message to '{key}: {value}'.
        /// </summary>
        /// <param name="key">The progress key.</param>
        /// <param name="value">THe progress value.</param>
        public CommandProgress(string key, string value)
        {
            this.HasKey = true;
            this.Key = key;
            this.Value = value;
            this.Message = $"{key}: {value}";
        }

        public bool HasKey { get; }

        public string Key { get; }

        public string Value { get; }

        public string Message { get; }
    }
}