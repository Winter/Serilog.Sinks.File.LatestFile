using System.Text;
using Serilog.Debugging;

namespace Serilog.Sinks.File.LatestFile;


/// <summary>
/// Deletes and re-creates the log file before Serilog logs anything
/// </summary>
public class LatestFileHook : FileLifecycleHooks {
    public override Stream OnFileOpened(string path, Stream underlyingStream, Encoding encoding) {
        try {
            // Close the existing stream
            underlyingStream.Dispose();
            
            // Attempt to delete the file if it exists
            if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
        }
        catch (Exception ex) {
            SelfLog.WriteLine("Error while deleting file {0}: {1}", path, ex);
            throw;
        }

        try {
            // Attempt to open a new file stream
            underlyingStream = System.IO.File.OpenWrite(path);

            // Pass our new stream down to Serilog
            return base.OnFileOpened(path, underlyingStream, encoding);
        }
        catch (Exception ex) {
            SelfLog.WriteLine("Error while opening stream to file {0}: {1}", path, ex);
            throw;
        }
    }
}