using System;
using System.Threading.Tasks;

using R5T.F0000;
using R5T.L0031.Extensions;
using R5T.L0038;
using R5T.T0132;
using R5T.T0197.Extensions;
using R5T.T0198;


namespace R5T.S0073
{
    [FunctionalityMarker]
    public partial interface IRepositoryScripts : IFunctionalityMarker
    {
        public async Task In_New_RepositoryContext()
        {
            /// Inputs.
            var unadjustedLibraryName =
                Instances.Values.Sample_RepositoryName.Value.ToUnadjustedLibraryName();
                ;
            var isPrivate = true;

            var libraryName =
                //Instances.Values.Sample_LibraryName
                Instances.LibraryNameOperations.Adjust_LibraryNameForPrivacy(unadjustedLibraryName, isPrivate);
                ;
            var libraryDescription =
                Instances.Values.Sample_LibraryDescription
                ;

            var repositoryName =
                Instances.LibraryNameOperator.Get_DefaultRepositoryName(libraryName)
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNames.SafetyCone
                ;
            var repositoryDescription =
                Instances.LibraryDescriptionOperator.Get_DefaultRepositoryDescription(libraryDescription)
                ;


            /// Run.
            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext_Undated(
                Instances.Values.ApplicationName,
                ApplicationContextOperation);

            async Task ApplicationContextOperation(IApplicationContext applicationContext)
            {
                await Instances.RepositoryOperations.In_New_RepositoryContext(
                    repositoryName,
                    repositoryDescription,
                    repositoryOwnerName,
                    isPrivate,
                    applicationContext.TextOutput,
                    async repositoryContext =>
                    {
                        //// Simple information output.
                        //Console.WriteLine(repositoryContext.RepositoryName);
                        //Console.WriteLine(repositoryContext.RepositoryOwnerName);
                        //Console.WriteLine(repositoryContext.RepositoryDescription);
                        //Console.WriteLine(repositoryContext.RemoteRepositoryUrl);
                        //Console.WriteLine(repositoryContext.LocalRepositoryDirectoryPath);

                        await Instances.GitOperator.In_CommitContext(
                            repositoryContext.LocalRepositoryDirectoryPath.Value,
                            "Add web library solution.",
                            repositoryContext.TextOutput.Logger,
                            async () =>
                            {
                                // Create a new web library with construction projects.
                                var solutionName = Instances.LibraryNameOperator.Get_DefaultSolutionName(libraryName);

                                var solutionContext = Instances.SolutionContextConstructor.Get_SolutionContext(
                                    solutionName,
                                    repositoryContext.LocalRepositoryDirectoryPath,
                                    repositoryContext.TextOutput);

                                await solutionContext.Run(
                                    Instances.SolutionContextOperations.Create_WebLibraryForBlazorWithConstructionServerAndClient(
                                        unadjustedLibraryName,
                                        libraryDescription,
                                        isPrivate,
                                        new IsSet<IRepositoryUrl>(repositoryContext.RemoteRepositoryUrl),
                                        out var creationOutput
                                    )
                                );

                                Instances.VisualStudioOperator.OpenSolutionFile(
                                    solutionContext.SolutionFilePath.Value);
                            }
                        );
                    }
                );
            } 
        }

        /// <summary>
        /// Allows testing repository-level operations in a new sample repository.
        /// The sample repository is deleted (if it exists) and then created for each run (both GitHub remote and local clone).
        /// </summary>
        public async Task In_New_SampleRepositoryContext()
        {
            await Instances.RepositoryOperations.In_New_SampleRepositoryContext(
                async repositoryContext =>
                {
                    var exists = await Instances.GitHubOperator.RepositoryExists(
                        repositoryContext.OwnerName.Value,
                        repositoryContext.RepositoryName.Value);

                    Console.Write($"{exists}: GitHub repository exists ({repositoryContext.OwnerName}/{repositoryContext.RepositoryName})");
                });
        }

        /// <summary>
        /// Delete a remote (GitHub) repository and its cloned local repository (Git).
        /// </summary>
        // Prior work: R5T.L0037.Construction.IDemonstrations.Delete_Repository().
        public async Task Delete_Repository()
        {
            /// Inputs.
            var unadjustedLibraryName =
                //Instances.Values.Sample_LibraryName.Value.ToUnadjustedLibraryName()
                Instances.Values.Sample_RepositoryName.Value.ToUnadjustedLibraryName()
                ;
            var isPrivate = true;

            var libraryName =
                Instances.LibraryNameOperations.Adjust_LibraryNameForPrivacy(unadjustedLibraryName, isPrivate)
                ;
            var repositoryName =
                //Instances.Values.Sample_RepositoryName
                Instances.LibraryNameOperator.Get_DefaultRepositoryName(libraryName)
                ;
            var repositoryOwner =
                Instances.RepositoryOwnerNames.SafetyCone
                ;


            /// Run.
            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext_Undated(
                Instances.Values.ApplicationName,
                ApplicationContextOperation);

            async Task ApplicationContextOperation(IApplicationContext applicationContext)
            {
                await Instances.RepositoryOperations.Delete_Repository(
                    repositoryName,
                    repositoryOwner,
                    applicationContext.TextOutput);
            }
        }

        /// <summary>
        /// Create a remote (GitHub) repository and clones it to a local repository (Git).
        /// </summary>
        // Prior work: R5T.L0037.Construction.IDemonstrations.Create_Repository().
        public async Task Create_Repository()
        {
            /// Inputs.
            var repositoryName =
                Instances.Values.Sample_RepositoryName
                ;
            var repositoryDescription =
                Instances.Values.Sample_RepositoryDescription
                ;
            var repositoryOwner =
                Instances.RepositoryOwnerNames.SafetyCone
                ;


            /// Run.
            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext_Undated(
                Instances.Values.ApplicationName,
                ApplicationContextOperation);

            async Task ApplicationContextOperation(IApplicationContext applicationContext)
            {
                await Instances.RepositoryOperations.Create_Repository_WithoutGitIgnore(
                    repositoryName,
                    repositoryDescription,
                    repositoryOwner,
                    applicationContext.TextOutput);
            }
        }
    }
}
