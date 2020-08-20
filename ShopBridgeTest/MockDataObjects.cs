using ShopBridge.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridgeTest
{
  public static  class MockDataObjects
    {
        public static List<ProductDto> ProductsDto()
        {
            return new List<ProductDto>()
            {  new ProductDto()
            {
                Id = 1,
                Name = "",
                Description = "",
                Price = 1,
                Thumbnail = "",
                ProductImage = "",
                ImageFile = null
            } };
        }
    }
}
