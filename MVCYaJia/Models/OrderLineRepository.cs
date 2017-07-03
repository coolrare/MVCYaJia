using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCYaJia.Models
{   
	public  class OrderLineRepository : EFRepository<OrderLine>, IOrderLineRepository
	{

	}

	public  interface IOrderLineRepository : IRepository<OrderLine>
	{

	}
}