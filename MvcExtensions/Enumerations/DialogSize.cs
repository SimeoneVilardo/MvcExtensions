namespace MvcExtensions.Enumerations
{
    public class DialogSize
    {
        private DialogSize(string value) { Value = value; }

        public string Value { get; set; }

        public static DialogSize Normal { get { return new DialogSize("BootstrapDialog.SIZE_NORMAL"); } }
        public static DialogSize Wide { get { return new DialogSize("BootstrapDialog.SIZE_WIDE"); } }
        public static DialogSize Large { get { return new DialogSize("BootstrapDialog.SIZE_LARGE"); } }

        public override bool Equals(object obj)
        {
            DialogSize am = obj as DialogSize;
            if (am == null)
                return false;
            return am.Value.Equals(Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
