namespace DocumentDB.Samples.Shared
{
    using Microsoft.Azure.Documents;
    using Newtonsoft.Json;
    using System;

    public class SalesOrder
    {
        //You can use JsonProperty attributes to control how your objects are
        //handled by the Json Serializer/Deserializer
        //Any of the supported JSON.NET attributes here are supported, including the use of JsonConverters
        //if you really want fine grained control over the process

        //Here we are using JsonProperty to control how the Id property is passed over the wire
        //In this case, we're just making it a lowerCase string but you could entirely rename it
        //like we do with PurchaseOrderNumber below
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName="ponumber")]
        public string PurchaseOrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string AccountNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public SalesOrderDetail[] Items { get; set; }
    }
    public class SalesOrderDetail
    {
        public int OrderQty { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
    public class SalesOrder2
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "ponumber")]
        public string PurchaseOrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public string AccountNumber { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TaxAmt { get; set; }

        public decimal Freight { get; set; }

        public decimal TotalDue { get; set; }

        public decimal DiscountAmt { get; set; }

        public SalesOrderDetail2[] Items { get; set; }
    }
    public class SalesOrderDetail2
    {
        public int OrderQty { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyCode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
    internal class Product
    {
        string ProductCode { get; set; }
        string ProductName { get; set; }
        Price UnitPrice { get; set; }
    }
    internal class Price
    {
        double Amount { get; set; }
        string CurrencySymbol { get; set; }
        string CurrencyCode { get; set; }
    }

    /// <summary>
    /// SalesOrderDocument extends the Microsoft.Azure.Documents.Document class
    /// This gives you access to internal properties of a Document such as ETag, SelfLink, Id etc.
    /// When working with objects extending from Document you get the benefit of not having to 
    /// dynamically cast between Document and your POCO.
    /// </summary>
    public class SalesOrderDocument : Document
    {
        public string PurchaseOrderNumber
        {
            get { return GetValue<string>("PurchaseOrderNumber"); }
            set { SetValue("PurchaseOrderNumber", value); }
        }
        public DateTime OrderDate
        {
            get { return GetValue<DateTime>("OrderDate"); }
            set { SetValue("OrderDate", value); }
        }
        public DateTime ShipDate
        {
            get { return GetValue<DateTime>("ShipDate"); }
            set { SetValue("ShipDate", value); }
        }
        public string AccountNumber
        {
            get { return GetValue<string>("AccountNumber"); }
            set { SetValue("AccountNumber", value); }
        }
        public decimal SubTotal
        {
            get { return GetValue<decimal>("SubTotal"); }
            set { SetValue("SubTotal", value); }
        }
        public decimal TaxAmt
        {
            get { return GetValue<decimal>("TaxAmt"); }
            set { SetValue("TaxAmt", value); }
        }
        public decimal Freight
        {
            get { return GetValue<decimal>("Freight"); }
            set { SetValue("Freight", value); }
        }
        public decimal TotalDue
        {
            get { return GetValue<decimal>("TotalDue"); }
            set { SetValue("TotalDue", value); }
        }
        public SalesOrderDetail[] Items
        {
            get { return GetValue<SalesOrderDetail[]>("Item"); }
            set { SetValue("Item", value); }
        }
    }
}
