using PrimeraAPI.BusinessModels.Models.OrderDetail;
using PrimeraAPI.DataAccess.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraAPI.Application.Mappers
{
	public static class OrderDetailMapper
	{
		public static OrderDetailResponse MapOrderDetailResponseFromOrderDetailDto(OrderDetailDto request)
		{
			OrderDetailResponse result = new OrderDetailResponse
			{
				OrderNumber = request.OrderNumber,
				OrderLineNumber = request.OrderLineNumber,
				PriceEach = request.PriceEach,
				ProductCode = request.ProductCode,
				QuantityOrdered = request.QuantityOrdered
			};

			return result;
		}

		public static OrderDetailDto MapToOrderDetailDtoFromCreateOrderDetailRequest(int orderNumber, CreateOrderDetailRequest request)

		{
			return new OrderDetailDto
			{
				OrderNumber = orderNumber,
				OrderLineNumber = request.OrderLineNumber,
				PriceEach = request.PriceEach,
				ProductCode = request.ProductCode,
				QuantityOrdered = request.QuantityOrdered
			};
		}

		public static List<OrderDetailResponse> MapOrderDetailResponseListFromOrderDetailDtoList(List<OrderDetailDto> request)
		{
			return request.Select(r => MapOrderDetailResponseFromOrderDetailDto(r)).ToList();
		}

	}
}
