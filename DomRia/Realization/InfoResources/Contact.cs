
using System;
using System.Text;

namespace DomRia.InfoResources
{
    public class Contact
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public Contact(string name, string lastName, string phoneNumber)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public Contact(Contact realtor)
        {
            Name = realtor.Name;
            LastName = realtor.LastName;
            PhoneNumber = realtor.PhoneNumber;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Realtor:");
            sb.Append("  " + Name + "\t");
            sb.Append(LastName + "\t");
            sb.Append(PhoneNumber);
            sb.AppendLine();
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ LastName.GetHashCode() ^ PhoneNumber.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Contact)
            {
                Contact tmp = obj as Contact;
                if (tmp.GetHashCode() == GetHashCode())
                    return true;
            }

            return false;
        }
    }
}