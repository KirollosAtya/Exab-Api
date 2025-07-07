public record ResultListedData<T>(List<T> Data, int Count, bool Succeeded = true, params string[] Errors);
public record ResultData<T>(T? Data, bool Succeeded = true, string? ErrorCode = null, params string[] Errors);
public record ExceptionDetails(int StatusCode, string Message);
public record ErrorRecord(string Name, string Type, string Reason);
