using System;


namespace R5T.S0073
{
    public static class Instances
    {
        public static L0038.IApplicationContextOperator ApplicationContextOperator => L0038.ApplicationContextOperator.Instance;
        public static F0041.IGitOperator GitOperator => F0041.GitOperator.Instance;
        public static F0041.IGitHubOperator GitHubOperator => F0041.GitHubOperator.Instance;
        public static F0133.ILibraryDescriptionOperator LibraryDescriptionOperator => F0133.LibraryDescriptionOperator.Instance;
        public static F0133.ILibraryNameOperator LibraryNameOperator => F0133.LibraryNameOperator.Instance;
        public static L0046.O001.ILibraryNameOperations LibraryNameOperations => L0046.O001.LibraryNameOperations.Instance;
        public static Z0043.IOwnerNames RepositoryOwnerNames => Z0043.OwnerNames.Instance;
        public static IRepositoryOperations RepositoryOperations => S0073.RepositoryOperations.Instance;
        public static L0039.O002.ISolutionContextConstructor SolutionContextConstructor => L0039.O002.SolutionContextConstructor.Instance;
        public static O0014.ISolutionContextOperations SolutionContextOperations => O0014.SolutionContextOperations.Instance;
        public static IValues Values => S0073.Values.Instance;
        public static F0088.IVisualStudioOperator VisualStudioOperator => F0088.VisualStudioOperator.Instance;
    }
}