using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopAPI.Contracts.Products;
using Microsoft.AspNetCore.SignalR;

namespace EShopAPI.Apps
{
    public class ProductHub : Hub
    {
        public async Task SendCreatedProduct(ProductDto product)
        {
            await Clients.Others.SendAsync("ReceiveCreatedProduct", product);
        }
    }
}
