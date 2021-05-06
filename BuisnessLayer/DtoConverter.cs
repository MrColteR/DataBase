using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;
using VRA.Dto;

namespace BuisnessLayer
{
    public class DtoConverter
    {
        #region Supplier
        public static Supplier Convert(SupplierDto supplierDto)
        {
            if (supplierDto == null)
            {
                return null;
            }
            Supplier supplier = new Supplier();
            supplier.SupplierID = supplierDto.SupplierID;
            supplier.Name = supplierDto.Name;
            supplier.Address = supplierDto.Address;
            supplier.Phone = supplierDto.Phone;
            return supplier;
        }
        public static SupplierDto Convert(Supplier supplier)
        {
            if (supplier == null)
            {
                return null;
            }
            SupplierDto supplierDto = new SupplierDto();
            supplierDto.SupplierID = supplier.SupplierID;
            supplierDto.Name = supplier.Name;
            supplierDto.Address = supplier.Address;
            supplierDto.Phone = supplier.Phone;
            return supplierDto;
        }
        public static IList<SupplierDto> Convert(IList<Supplier> supplier)
        {
            if (supplier == null)
            {
                return null;
            }
            IList<SupplierDto> supplierDto = new List<SupplierDto>();
            foreach (var item in supplier)
            {
                supplierDto.Add(Convert(item));
            }
            return supplierDto;
        }
        #endregion 
        #region Supply
        public static Supply Convert(SupplyDto supplyDto)
        {
            if (supplyDto == null)
            {
                return null;
            }
            Supply supply = new Supply();
            supply.SupplierID = supplyDto.SupplierID;
            supply.SupplyID = supplyDto.SupplyID;
            supply.Amount = supplyDto.Amount;
            supply.Date = supplyDto.Date;
            return supply;
        }
        public static SupplyDto Convert(Supply supply)
        {
            if (supply == null)
            {
                return null;
            }
            SupplyDto supplyDto = new SupplyDto();
            supplyDto.SupplierID = supply.SupplierID;
            supplyDto.SupplyID = supply.SupplyID;
            supplyDto.Amount = supply.Amount;
            supplyDto.Date = supply.Date;
            return supplyDto;
        }
        public static IList<SupplyDto> Convert(IList<Supply> supply)
        {
            if (supply == null)
            {
                return null;
            }
            IList<SupplyDto> supplyDto = new List<SupplyDto>();
            foreach (var item in supply)
            {
                supplyDto.Add(Convert(item));
            }
            return supplyDto;
        }
        #endregion
        #region Details
        public static Details Convert(DetailsDto detailsDto)
        {
            if (detailsDto == null)
            {
                return null;
            }
            Details details = new Details();
            details.DetailsID = detailsDto.DetailsID;
            details.Article = detailsDto.Article;
            details.Price = detailsDto.Price;
            details.Note = detailsDto.Note;
            details.Name = detailsDto.Name;
            return details;
        }
        public static DetailsDto Convert(Details details)
        {
            if (details == null)
            {
                return null;
            }
            DetailsDto detailsDto = new DetailsDto();
            detailsDto.DetailsID = details.DetailsID;
            detailsDto.Article = details.Article;
            detailsDto.Price = details.Price;
            detailsDto.Note = details.Note;
            detailsDto.Name = details.Name;
            return detailsDto;
        }
        public static IList<DetailsDto> Convert(IList<Details> details)
        {
            if (details == null)
            {
                return null;
            }
            IList<DetailsDto> detailsDto = new List<DetailsDto>();
            foreach (var item in details)
            {
                detailsDto.Add(Convert(item));
            }
            return detailsDto;
        }
        #endregion
        #region HistoryPrice
        public static HistoryPrice Convert(HistoryPriceDto historyPriceDto)
        {
            if (historyPriceDto == null)
            {
                return null;
            }
            HistoryPrice historyPrice = new HistoryPrice();
            historyPrice.HistoryID = historyPriceDto.HistoryID;
            historyPrice.SupplierID = historyPriceDto.SupplierID;
            historyPrice.DetailsID = historyPriceDto.DetailsID;
            historyPrice.NewPrice = historyPriceDto.NewPrice;
            historyPrice.DateOfChangePrice = historyPriceDto.DateOfChangePrice;
            return historyPrice;
        }
        public static HistoryPriceDto Convert(HistoryPrice historyPrice)
        {
            if (historyPrice == null)
            {
                return null;
            }
            HistoryPriceDto historyPriceDto = new HistoryPriceDto();
            historyPriceDto.HistoryID = historyPrice.HistoryID;
            historyPriceDto.SupplierID = historyPrice.SupplierID;
            historyPriceDto.DetailsID = historyPrice.DetailsID;
            historyPriceDto.NewPrice = historyPrice.NewPrice;
            historyPriceDto.DateOfChangePrice = historyPrice.DateOfChangePrice;
            return historyPriceDto;
        }
        public static IList<HistoryPriceDto> Convert(IList<HistoryPrice> historyPrice)
        {
            if (historyPrice == null)
            {
                return null;
            }
            IList<HistoryPriceDto> historyPriceDto = new List<HistoryPriceDto>();
            foreach (var item in historyPrice)
            {
                historyPriceDto.Add(Convert(item));
            }
            return historyPriceDto;
        }
        #endregion
        #region DetailInDelivery
        public static DetailInDelivery Convert(DetailInDeliveryDto detailInDeliveryDto)
        {
            if (detailInDeliveryDto == null)
            {
                return null;
            }
            DetailInDelivery detailInDelivery = new DetailInDelivery();
            detailInDelivery.Number = detailInDeliveryDto.Number;
            detailInDelivery.SupplyID = detailInDeliveryDto.SupplyID;
            detailInDelivery.HistoryID = detailInDeliveryDto.HistoryID;
            detailInDelivery.DetailID = detailInDeliveryDto.DetailID;
            return detailInDelivery;
        }
        public static DetailInDeliveryDto Convert(DetailInDelivery detailInDelivery)
        {
            if (detailInDelivery == null)
            {
                return null;
            }
            DetailInDeliveryDto detailInDeliveryDto = new DetailInDeliveryDto();
            detailInDeliveryDto.Number = detailInDelivery.Number;
            detailInDeliveryDto.SupplyID = detailInDelivery.SupplyID;
            detailInDeliveryDto.HistoryID = detailInDelivery.HistoryID;
            detailInDeliveryDto.DetailID = detailInDelivery.DetailID;
            return detailInDeliveryDto;
        }
        public static IList<DetailInDeliveryDto> Convert(IList<DetailInDelivery> detailInDelivery)
        {
            if (detailInDelivery == null)
            {
                return null;
            }
            IList<DetailInDeliveryDto> detailInDeliveryDto = new List<DetailInDeliveryDto>();
            foreach (var item in detailInDelivery)
            {
                detailInDeliveryDto.Add(Convert(item));
            }
            return detailInDeliveryDto;
        }
        #endregion
    }
}
