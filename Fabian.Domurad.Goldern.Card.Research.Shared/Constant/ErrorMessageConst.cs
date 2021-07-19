namespace Fabian.Domurad.Golden.Card.Research.Shared.Constant
{
    public static class ErrorMessageConst
    {
        public const string Default = "Something went wrong, please contact your administrator!";
        public const string DefaultModelState = "Modelstate validation error occured!";

        public const string EntityNotFound = "Entity was not found!";
        public const string EntityNotFoundFormat = "{0} with {1} [{2}] was not found!";

        public const string AlreadyExistsFormat = "{0} with {1} [{2}] already exists!";
        public const string DeskAlreadyExistsFormat = "Desk [{0}] in {1} already exists!";

        public const string FloorNumberInLocAlreadyExistsFormat =
            "Floor with number [{0}] already exists in localization [{1}]";

        public const string UsernamePasswordNotMatch = "Username and password do not match!";

        public const string OwnerOnlyInUnavailableDesk = "Owner can be set only when desk is unavailable!";
    }
}
