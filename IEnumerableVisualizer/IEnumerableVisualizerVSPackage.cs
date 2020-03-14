using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace IEnumerableVisualizerDotNetStandard
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideAutoLoad(UIContextGuids80.NoSolution, PackageAutoLoadFlags.BackgroundLoad)]
    public sealed class IEnumerableVisualizerVSPackage : AsyncPackage
    {
        public const string PackageGuidString = "c4f77588-c327-46b6-bcbe-520f08f858f9";
        public const string DEBUGGER_SIDE_FILENAME = "IEnumerableVisualizer.dll";
        public const string DEBUGGEE_SIDE_FILENAME = "IEnumerableVisualizerDotNetStandard.dll";
        public readonly string[] DebugeeDirectories = new string[] { "net2.0", "netstandard2.0", "netcoreapp" };

        public IEnumerableVisualizerVSPackage() { }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            var sourceDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            if (await GetServiceAsync(typeof(SVsShell)) is IVsShell shell)
            {
                shell.GetProperty((int)__VSSPROPID2.VSSPROPID_VisualStudioDir, out object pvar);

                if (pvar != null)
                {
                    var visualStudioFolder = pvar.ToString();
                    var debuggerDirectory = Path.Combine(visualStudioFolder, "Visualizers");
                    var sourceFile = new FileInfo(string.Format(@"{0}\{1}", sourceDirectory, DEBUGGER_SIDE_FILENAME));
                    var debuggerFile = new FileInfo(string.Format(@"{0}\{1}", debuggerDirectory, DEBUGGER_SIDE_FILENAME));
                    Deploy(sourceFile, debuggerFile);

                    sourceFile = new FileInfo(string.Format(@"{0}\{1}", sourceDirectory, DEBUGGEE_SIDE_FILENAME));

                    foreach (var debugeeDirectory in DebugeeDirectories)
                    {
                        var destinationFile = new FileInfo(string.Format(@"{0}\{1}\{2}", debuggerDirectory, debugeeDirectory, DEBUGGEE_SIDE_FILENAME));
                        Deploy(sourceFile, destinationFile);
                    }
                }
            }
        }

        private void Deploy(FileInfo source, FileInfo destination)
        {
            if (!destination.Exists)
            {
                Directory.CreateDirectory(destination.DirectoryName);
                File.Copy(source.FullName, destination.FullName, true);
            }
            else
            {
                if (source.GetMd5String() != destination.GetMd5String())
                {
                    File.Copy(source.FullName, destination.FullName, true);
                    destination.LastWriteTime = source.LastWriteTime;
                }
            }
        }      
    }
}