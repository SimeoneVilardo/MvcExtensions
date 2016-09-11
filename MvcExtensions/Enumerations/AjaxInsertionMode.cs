namespace MvcExtensions.Enumerations
{
    public class AjaxInsertionMode
    {
        private AjaxInsertionMode(string value) { Value = value; }

        public string Value { get; set; }

        public static AjaxInsertionMode InsertAfter { get { return new AjaxInsertionMode("append"); } }
        public static AjaxInsertionMode InsertBefore { get { return new AjaxInsertionMode("prepend"); } }
        public static AjaxInsertionMode Replace { get { return new AjaxInsertionMode("html"); } }
        public static AjaxInsertionMode ReplaceWith { get { return new AjaxInsertionMode("replaceWith"); } }

        public override bool Equals(object obj)
        {
            AjaxInsertionMode aim = obj as AjaxInsertionMode;
            if (aim == null)
                return false;
            return aim.Value.Equals(Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
