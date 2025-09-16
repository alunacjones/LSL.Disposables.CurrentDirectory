using System;
using System.IO;

namespace LSL.Disposables.CurrentDirectory;

/// <summary>
/// A disposable current directory
/// </summary>
public class DisposableCurrentDirectory : IDisposable
{
    private bool _disposedValue;

    /// <summary>
    /// The value of <c>Directory.GetCurrentDirectory()</c> at construction time.
    /// </summary>
    /// <value></value>
    public string OriginalCurrentDirectory { get; }

    /// <summary>
    /// The directory that was passed into the constructor.
    /// </summary>
    /// <value></value>
    public string CurrentDirectory { get; }

    /// <summary>
    /// Creates a <c>DisposableCurrentDirectory</c> that uses the provided directory
    /// as the new current working directory. On disposal of the instance
    /// the original Current Directory is restored.
    /// </summary>
    /// <param name="newCurrentDirectory"></param>
    public DisposableCurrentDirectory(string newCurrentDirectory)
    {
        OriginalCurrentDirectory = Directory.GetCurrentDirectory();
        CurrentDirectory = Path.IsPathRooted(newCurrentDirectory)
            ? newCurrentDirectory
            : Path.Combine(OriginalCurrentDirectory, newCurrentDirectory);

        Directory.SetCurrentDirectory(CurrentDirectory);
    }

    /// <summary>
    /// Dispose
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                Directory.SetCurrentDirectory(OriginalCurrentDirectory);
            }
            _disposedValue = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}