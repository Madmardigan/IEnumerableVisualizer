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
        public const string VISUAL_STUDIO_2019_FOLDER = @"Visual Studio 2019";
        public const string VISUALIZERS_FOLDER = @"Visualizers";


        public IEnumerableVisualizerVSPackage() { }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            var sourceDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //this is the source debugger file to be deployed
            var sourceDebuggerFile = new FileInfo(string.Format(@"{0}\{1}", sourceDirectory, DEBUGGER_SIDE_FILENAME));
            var sourceDebugeeFile = new FileInfo(string.Format(@"{0}\{1}", sourceDirectory, DEBUGGEE_SIDE_FILENAME));

            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            if (await GetServiceAsync(typeof(SVsShell)) is IVsShell shell)
            {
                //this is directory path 1 in visual studio directory
                shell.GetProperty((int)__VSSPROPID2.VSSPROPID_VisualStudioDir, out object pvar1);

                if (pvar1 != null)
                {
                    var visualStudioDirectory = Path.Combine(pvar1.ToString(), VISUALIZERS_FOLDER);
                    var visualStudioDebuggerFileName = new FileInfo(string.Format(@"{0}\{1}", visualStudioDirectory, DEBUGGER_SIDE_FILENAME));
                    Deploy(sourceDebuggerFile, visualStudioDebuggerFileName);

                    foreach (var debugeeDirectory in DebugeeDirectories)
                    {
                        var myDocumentsDebugeeFileName = new FileInfo(string.Format(@"{0}\{1}\{2}", visualStudioDirectory, debugeeDirectory, DEBUGGEE_SIDE_FILENAME));
                        Deploy(sourceDebugeeFile, myDocumentsDebugeeFileName);
                    }
                }

                //this is directory path 2 in visual studio install root folder
                shell.GetProperty((int)__VSSPROPID2.VSSPROPID_InstallRootDir, out object pvar2);

                if (pvar2 != null)
                {
                    var visualStudioRootDirectory = Path.Combine(pvar2.ToString(), VISUAL_STUDIO_INSTALL_PATH);
                    var visualStudioDebuggerFileName = new FileInfo(string.Format(@"{0}\{1}", visualStudioRootDirectory, DEBUGGER_SIDE_FILENAME));
                    Deploy(sourceDebuggerFile, visualStudioDebuggerFileName);

                    foreach (var debugeeDirectory in DebugeeDirectories)
                    {
                        var visualStudioDebugeeFileName = new FileInfo(string.Format(@"{0}\{1}\{2}", visualStudioRootDirectory, debugeeDirectory, DEBUGGEE_SIDE_FILENAME));
                        Deploy(sourceDebugeeFile, visualStudioDebugeeFileName);
                    }
                }

                //this is directory path 3 in my documents, should be the same as path 1, file not found edge case
                var myDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                myDocumentsFolder = Path.Combine(myDocumentsFolder, VISUAL_STUDIO_2019_FOLDER);
                myDocumentsFolder = Path.Combine(myDocumentsFolder, VISUALIZERS_FOLDER);
                var myDocumentsDebuggerFileName = new FileInfo(string.Format(@"{0}\{1}", myDocumentsFolder, DEBUGGER_SIDE_FILENAME));
                Deploy(sourceDebuggerFile, myDocumentsDebuggerFileName);

                foreach (var debugeeDirectory in DebugeeDirectories)
                {
                    var visualStudioDebugeeFileName = new FileInfo(string.Format(@"{0}\{1}\{2}", myDocumentsFolder, debugeeDirectory, DEBUGGEE_SIDE_FILENAME));
                    Deploy(sourceDebugeeFile, visualStudioDebugeeFileName);
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