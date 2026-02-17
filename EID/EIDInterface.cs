using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EID;

namespace EID
{
    /// <summary>
    /// Represents a business associate with a name, identifier and total amount.
    /// </summary>
    public interface IBusinessAssociate
    {
        /// <summary>
        /// Gets or sets the name associated with the current object.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the object.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the total monetary amount for the transaction.
        /// </summary>
        double TotalAmount { get; set; }
    }

    public abstract class Customer
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
    }

    public class Consumer : Customer, IBusinessAssociate
    {
        // Backing to CustomerId so ConsumerId and Id remain in sync with the base CustomerId.
        public int ConsumerId
        {
            get => CustomerId;
            set => CustomerId = value;
        }

        // Implement IBusinessAssociate.Id by mapping to CustomerId
        public int Id
        {
            get => CustomerId;
            set => CustomerId = value;
        }

        // Name is inherited from Customer and already satisfies IBusinessAssociate.Name

        public double TotalAmount { get; set; }
    }

    public class Vendor : Customer, IBusinessAssociate
    {
        public int VendorId
        {
            get => CustomerId;
            set => CustomerId = value;
        }

        // Implement IBusinessAssociate.Id by mapping to CustomerId
        public int Id
        {
            get => CustomerId;
            set => CustomerId = value;
        }

        // Name is inherited from Customer and already satisfies IBusinessAssociate.Name

        public double TotalAmount { get; set; }
    }
}
