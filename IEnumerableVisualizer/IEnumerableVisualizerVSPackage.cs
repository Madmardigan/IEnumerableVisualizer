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
        public string[] DebugeeDirectories { get; } = new string[] { "net2.0", "netstandard2.0", "netcoreapp" };
        public const string VISUAL_STUDIO_INSTALL_PATH = @"Common7\Packages\Debugger\Visualizers";
        public const string MY_DOCUMENTS_INSTALL_PATH = @"Visualizers";


        public IEnumerableVisualizerVSPackage() { }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            var sourceDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //this is the source debugger file that needs deployed
            var sourceDebuggerFile = new FileInfo(string.Format(@"{0}\{1}", sourceDirectory, DEBUGGER_SIDE_FILENAME));
            var sourceDebugeeFile = new FileInfo(string.Format(@"{0}\{1}", sourceDirectory, DEBUGGEE_SIDE_FILENAME));

            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            if (await GetServiceAsync(typeof(SVsShell)) is IVsShell shell)
            {
                //this is directory path 1 in my documents
                shell.GetProperty((int)__VSSPROPID2.VSSPROPID_VisualStudioDir, out object pvar1);

                if (pvar1 != null)
                {
                    var myDocumentsDirectory = Path.Combine(pvar1.ToString(), MY_DOCUMENTS_INSTALL_PATH);
                    var myDocumentsDebuggerFileName = new FileInfo(string.Format(@"{0}\{1}", myDocumentsDirectory, DEBUGGER_SIDE_FILENAME));
                    Deploy(sourceDebuggerFile, myDocumentsDebuggerFileName);

                    foreach (var debugeeDirectory in DebugeeDirectories)
                    {
                        var myDocumentsDebugeeFileName = new FileInfo(string.Format(@"{0}\{1}\{2}", myDocumentsDirectory, debugeeDirectory, DEBUGGEE_SIDE_FILENAME));
                        Deploy(sourceDebugeeFile, myDocumentsDebugeeFileName);
                    }
                }

                //this is directory path 2 in in visual studio install folder
                shell.GetProperty((int)__VSSPROPID2.VSSPROPID_InstallRootDir, out object pvar2);

                if (pvar2 != null)
                {
                    var visualStudioDirectory = Path.Combine(pvar2.ToString(), VISUAL_STUDIO_INSTALL_PATH);
                    var visualStudioDebuggerFileName = new FileInfo(string.Format(@"{0}\{1}", visualStudioDirectory, DEBUGGER_SIDE_FILENAME));
                    Deploy(sourceDebuggerFile, visualStudioDebuggerFileName);

                    foreach (var debugeeDirectory in DebugeeDirectories)
                    {
                        var visualStudioDebugeeFileName = new FileInfo(string.Format(@"{0}\{1}\{2}", visualStudioDirectory, debugeeDirectory, DEBUGGEE_SIDE_FILENAME));
                        Deploy(sourceDebugeeFile, visualStudioDebugeeFileName);
                    }
                }
            }
        }

        /// <summary>
        /// force overwrite due to reference errors in some environments
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        private void Deploy(FileInfo source, FileInfo destination)
        {
            try
            {
                Directory.CreateDirectory(destination.DirectoryName);
                File.Copy(source.FullName, destination.FullName, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}