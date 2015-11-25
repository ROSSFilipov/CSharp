using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private long id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private CustomerType customerType;
        private List<Payment> payments;

        public Customer()
        {
            this.payments = new List<Payment>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name!");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name!");
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name!");
                }

                this.lastName = value;
            }
        }

        public long ID
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ID cannot be negative!");
                }

                this.id = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid address!");
                }

                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid mobobile phone number!");
                }

                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid email address!");
                }

                this.email = value;
            }
        }

        public CustomerType CustomerType
        {
            get
            {
                return this.customerType;
            }
            set
            {
                this.customerType = value;
            }
        }

        public List<Payment> Payments
        {
            get
            {
                return this.payments;
            }
        }

        public override bool Equals(object obj)
        {
            Customer otherCustomer = obj as Customer;
            bool equalCustomers = 
                this.FirstName == otherCustomer.FirstName &&
                this.MiddleName == otherCustomer.MiddleName &&
                this.LastName == otherCustomer.LastName;

            if (equalCustomers)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0}:\n\tFirst name: {1}\n\tMiddle name: {2}\n\tLast name: {3}\n\tPermanent address {4}\n\tID: {5}\n\tMobile phone: {6}\n\tEmail address: {7}\n\tType: {8}",
                this.FirstName, 
                this.MiddleName, 
                this.LastName, 
                this.PermanentAddress, 
                this.ID, 
                this.MobilePhone, 
                this.Email, 
                this.CustomerType));

            foreach (Payment currentPayment in this.Payments)
            {
                sb.AppendLine(currentPayment.ToString());
            }

            return sb.ToString();
        }

        public object Clone()
        {
            Customer clonedCustomer = new Customer
            {
                FirstName = this.FirstName,
                MiddleName = this.middleName,
                LastName = this.LastName,
                ID = this.ID,
                PermanentAddress = this.PermanentAddress,
                MobilePhone = this.MobilePhone,
                Email = this.Email,
                CustomerType = this.CustomerType
            };

            foreach (Payment currentPayment in this.Payments)
            {
                clonedCustomer.Payments.Add(new Payment(currentPayment.ProductName, currentPayment.Price));
            }

            return clonedCustomer;
        }

        public int CompareTo(Customer other)
        {
            if (this.firstName != other.FirstName)
            {
                return this.firstName.CompareTo(other.firstName);
            }
            else
            {
                return this.ID.CompareTo(other.ID);
            }
        }

        public static bool operator ==(Customer firstCustomer, Customer secondCustomer)
        {
            return firstCustomer.Equals(secondCustomer);
        }

        public static bool operator !=(Customer firstCustomer, Customer secondCustomer)
        {
            return !firstCustomer.Equals(secondCustomer);
        }
    }
}
