namespace Fabian.Domurad.Golden.Card.Research.Shared.Constant
{
    public static class BindingModelErrorConst
    {
        //Localization
        public const string LocNameRequired = "Localization name is required";
        public const string LocNameMaxLength = "Localization name cannot extend 128 characters";
        public const string LocNameMinLength = "Localization name has to extend 3 characters";

        //Floor
        public const string FloorNumberRequired = "Floor number is required";
        public const string FloorLocIdRequired = "Floor localization id is required";

        //User
        public const string UserUsernameRequired = "Username is required";
        public const string UserUsernameMaxLength = "Username cannot extend 128 characters";
        public const string UserUsernameMinLength = "Username has to extend 3 characters";

        public const string UserFirstNameRequired = "First name is required";
        public const string UserFirstNameMaxLength = "First name cannot extend 128 characters";
        public const string UserFirstNameMinLength = "First name has to extend 3 characters";

        public const string UserLastNameRequired = "Last name is required";
        public const string UserLastNameMaxLength = "Last name cannot extend 128 characters";
        public const string UserLastNameMinLength = "Last name has to extend 3 characters";

        public const string UserEmailRequired = "Email is required";
        public const string UserEmailMaxLength = "Email cannot extend 128 characters";
        public const string UserEmailMinLength = "Email has to extend 3 characters";

        public const string UserPasswordRequired = "Password is required";
        public const string UserPasswordMaxLength = "Password cannot extend 30 characters";
        public const string UserPasswordMinLength = "Password has to extend 5 characters";

        //Desk
        public const string DeskDeskNumberRequired = "Desk number is required";

        public const string DeskRoomNumberRequired = "Room number is required";

        public const string DeskIsLiftedRequired = "Is lifted property is required";

        public const string DeskIsUnavailableRequired = "Is unavailable property is required";

        public const string DeskLocationRequired = "Desk location is required";

        public const string DeskTribeRequired = "Tribe is required";
        public const string DeskTribeMinLength = "Tribe has to extend 3 characters";
        public const string DeskTribeMaxLength = "Tribe cannot extend 128 characters";

        public const string DeskFloorIdRequired = "Floor id is required";
    }
}
