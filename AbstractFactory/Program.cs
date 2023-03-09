using AbstractFactory;

Console.Title = "Abstract Factory";

var belgShCartFactory = new BelgiumShoppingCartPurchaseFactory();
var shCartBelg = new ShoppingCart(belgShCartFactory);
shCartBelg.CalculateCosts();


var frShCartFactory = new FranceShoppingCartPurchaseFactory();
var frCartBelg = new ShoppingCart(frShCartFactory);
frCartBelg.CalculateCosts();