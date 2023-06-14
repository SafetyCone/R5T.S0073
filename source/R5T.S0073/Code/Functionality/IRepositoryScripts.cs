using System;
using System.Threading.Tasks;

using R5T.L0038;
using R5T.T0132;


namespace R5T.S0073
{
    [FunctionalityMarker]
    public partial interface IRepositoryScripts : IFunctionalityMarker
    {
        /// <summary>
        /// Delete a remote (GitHub) repository and its cloned local repository (Git).
        /// </summary>
        // Prior work: R5T.L0037.Construction.IDemonstrations.Delete_Repository().
        public async Task Delete_Repository()
        {
            /// Inputs.
            var repositoryName =
                Instances.Values.Sample_RepositoryName
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
                await Instances.RepositoryOperations.Create_Repository(
                    repositoryName,
                    repositoryDescription,
                    repositoryOwner,
                    applicationContext.TextOutput);
            }
        }
    }
}
