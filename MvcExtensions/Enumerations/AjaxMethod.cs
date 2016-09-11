namespace MvcExtensions.Enumerations
{
    public class AjaxMethod
    {
        private AjaxMethod(string value) { Value = value; }

        public string Value { get; set; }

        public static AjaxMethod GET { get { return new AjaxMethod("POST"); } }
        public static AjaxMethod POST { get { return new AjaxMethod("POST"); } }
        public static AjaxMethod PUT { get { return new AjaxMethod("PUT"); } }
        public static AjaxMethod DELETE { get { return new AjaxMethod("DELETE"); } }

        public override bool Equals(object obj)
        {
            AjaxMethod am = obj as AjaxMethod;
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
