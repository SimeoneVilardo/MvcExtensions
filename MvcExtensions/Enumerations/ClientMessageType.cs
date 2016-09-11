using System.Linq;

namespace MvcExtensions.Enumerations
{
    public class ClientMessageType
    {
        private ClientMessageType(string buttonValue, string dialogValue) { ButtonValue = buttonValue; DialogValue = dialogValue; }

        public string ButtonValue { get; set; }
        public string DialogValue { get; set; }

        public static ClientMessageType Default { get { return new ClientMessageType("btn-default", "BootstrapDialog.TYPE_DEFAULT"); } }
        public static ClientMessageType Primary { get { return new ClientMessageType("btn-primary", "BootstrapDialog.TYPE_PRIMARY"); } }
        public static ClientMessageType Success { get { return new ClientMessageType("btn-success", "BootstrapDialog.TYPE_SUCCESS"); } }
        public static ClientMessageType Info { get { return new ClientMessageType("btn-info", "BootstrapDialog.TYPE_INFO"); } }
        public static ClientMessageType Warning { get { return new ClientMessageType("btn-warning", "BootstrapDialog.TYPE_WARNING"); } }
        public static ClientMessageType Danger { get { return new ClientMessageType("btn-danger", "BootstrapDialog.TYPE_DANGER"); } }
        public static ClientMessageType Link { get { return new ClientMessageType("btn-link", "BootstrapDialog.TYPE_DEFAULT"); } }

        public override bool Equals(object obj)
        {
            ClientMessageType cmt = obj as ClientMessageType;
            if (cmt == null)
                return false;
            var props = cmt.GetType().GetProperties().ToList().Where(p => !(typeof(ClientMessageType).Equals(p.GetValue(obj, null).GetType()))).ToArray();
            foreach (var prop in props)
            {
                object objValue = prop.GetValue(obj, null);
                object thisValue = prop.GetValue(this, null);
                if (!objValue.Equals(thisValue))
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
