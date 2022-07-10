using System.Collections.ObjectModel;

namespace DemoAPI.Data.Entities;

public class Order
{
    // <summary>  
    /// Gets or sets the order identifier.  
    /// </summary>  
    /// <value>The order identifier.</value>  
    public int OrderId { get; set; }

    /// <summary>  
    /// Gets or sets the name.  
    /// </summary>  
    /// <value>The name.</value>  
    public string Name { get; set; }

    /// <summary>  
    /// Gets or sets the product Ids.  
    /// </summary>  
    /// <value>The product Ids.</value>  
    Collection<int> ProductIds { get; set; } = new Collection<int>();
}
