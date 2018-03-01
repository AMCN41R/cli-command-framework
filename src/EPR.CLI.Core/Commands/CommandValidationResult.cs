namespace EPR.CLI.Core.Commands
{
    public class CommandValidationResult
    {
        /// <summary>
        /// Creates a new valid <see cref="CommandValidationResult"/>, and sets the <see cref="Reason"/> null.
        /// </summary>
        public CommandValidationResult()
        {
            this.IsValid = true;
            this.Reason = null;
        }

        /// <summary>
        /// Creates a new invalid <see cref="CommandValidationResult"/> with the given <see cref="Reason"/>.
        /// </summary>
        /// <param name="reason">The reason why the validation failed.</param>
        public CommandValidationResult(string reason)
        {
            this.IsValid = false;
            this.Reason = reason;
        }

        public bool IsValid { get; }

        public string Reason { get; }
    }
}