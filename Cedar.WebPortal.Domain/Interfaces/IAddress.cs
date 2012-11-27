namespace Cedar.WebPortal.Domain.Interfaces
{
    public interface IAddress
    {
        #region Properties

        string Ave { get; set; }

        string BuildingNo { get; set; }

        string City { get; set; }

        string Description { get; set; }

        string Fax { get; set; }

        string Province { get; set; }

        string Tel { get; set; }

        string TelCode { get; set; }

        string PostalCode { get; set; }

        string Unit { get; set; }

        #endregion
    }
}