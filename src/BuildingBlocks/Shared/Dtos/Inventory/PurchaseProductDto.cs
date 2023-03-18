using Shared.Enums.Inventory;

namespace Shared.DTOs.Inventory;

public record PurchaseProductDto
{
    //public EDocumentType DocumentType => EDocumentType.Purchase;

    //private string _itemNo { get; set; }

    //public string GetItemNo() => _itemNo;

    //public void SetItemNo(string itemNo)
    //{
    //    _itemNo = itemNo;
    //}

    public string ItemNo { get; set; }
    public string DocumentNo { get; set; } // Sample: PO-2023-02-XXXXX
    public string ExternalDocumentNo { get; set; }
    public int Quantity { get; set; }
}