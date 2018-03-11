using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MTHeadBrewery.Models;

namespace MTHeadBrewery.DAL
{
    public class BreweryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BreweryContext>
    {
        protected override void Seed(BreweryContext context)
        {
            var beers = new List<Beer>
            {
                new Beer{BeerName = "Golden Ale", ABV = "4.5", BeerDescription = "Brewed specifically for the drinker who prefers a light, refreshing beer that is still full flavored. A classic example of a “session” beer that eliminates a full feeling even after a few pints. Three malts and three hops make this a well balanced beer similar to the fine Pilsners of Europe.", FirstBrewed = DateTime.Parse("2005-05-05")},
                new Beer{BeerName = "No Brainer Ale", ABV = "4.9", BeerDescription = "A classic American style Pale Ale that offers just the right blend of Northwest malt and hops. Crystal and amber malts provide the body, while generous amounts of Columbus and Northern Brewer hops supply the balance. Finally, Cascade hops are added to give this beer those familiar pine and citrus aromas. Well hopped but not too bitter.", FirstBrewed = DateTime.Parse("2006-06-06")},
                new Beer{BeerName = "Twisted Head IPA", ABV = "7.2", BeerDescription = "For the beer connoisseur who loves the flavor profile of fine India Pale Ales. Premium Maris Otter grain is the base of this recipe with some added flaked barley and dextrin malts to provide a creamy head and excellent mouth feel. Simcoe is the only hop used to create a unique bitterness, flavor and aroma. A clean, hop-forward beer that will demand a second pint.", FirstBrewed = DateTime.Parse("2004-07-07")},
                new Beer{BeerName = "Bonehead Brown Ale", ABV = "8.2", BeerDescription = "Very different from the traditional mild English Brown Ales, this American style Brown Ale accentuates a more complex malt recipe and greater hop additions. Pale malt combines with two types of caramel and amber grains to provide the base while chocolate malt and roasted barley supply the distinct color and flavor. Just enough Cluster and Golding hops are used to give it the bitterness and flavor that this popular style demands. Named for Shuman, our brew house dog, this is the perfect beer for those wanting full malt richness.", FirstBrewed = DateTime.Parse("2006-08-08")},
                new Beer{BeerName = "Dark Marc", ABV = "7.7", BeerDescription = "American India Black ale, a.k.a. Cascadian Dark Ale is a new style, pioneered here in the Northwest. This style dictates a highly hopped beer of very dark color but without the harsh astringency of other dark varieties like stout. It should also be a beer of higher alcohol content. Our version represents a perfect example of this unique style. We start with fine pilsner base malt and add caramel, and Carafa malts for flavor and color. A small amount of chocolate malt is used to create a mild, coffee like finish. Four distinct hop varieties are added to provide a smooth, complex bitterness and flavor. The beer is then “dry hopped” after fermentation for additional aroma. An extremely flavorful beer for the true hop lover. ", FirstBrewed = DateTime.Parse("2005-09-09")},
                new Beer{BeerName = "Punter's Special Ale", ABV = "7.1", BeerDescription = "A seasonally brewed Irish Red Ale guaranteed to transport your taste buds across the pond. Premium English malt combined with special caramel malts and roast barley give this fine beer a smooth, malt forward finish. Just enough Golding hops are used to offset the residual sweetness and provide the right balance. Irish Ale yeast rounds out the traditional flavor profile. The beer was named for a respected customer of a British Isles pub.One who is commonly refered to as a \"Punter\". ", FirstBrewed = DateTime.Parse("2004-10-10")},
            };
            beers.ForEach(s => context.Beers.Add(s));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee{EmployeeID = 0001, Lname = "Rockey", Fname = "Tim", StartDate = DateTime.Parse("2005-09-01"),EmpBio = "The owner of the brewery, retiree living out the dreams of brewing beer to share with all."},
                new Employee{EmployeeID = 0002, Lname = "Rockey", Fname = "Renee", StartDate = DateTime.Parse("2005-09-01"),EmpBio = "The lovely wife of the brewman and Co-Owner of the brewery.  Enjoys spending time with her two amazing dogs"},
                new Employee{EmployeeID = 0003, Lname = "Doe", Fname = "Korey", StartDate = DateTime.Parse("2006-10-10"),EmpBio = "The Hand to the brewman.  Soon to be mother-in-law with her daughter getting married August 2018"},
                new Employee{EmployeeID = 0004, Lname = "Getzin", Fname = "Christian", StartDate = DateTime.Parse("2018-11-02"),EmpBio = "The website curator and creator, responsible for all the true and fictional parts of the website."},
            };
            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var brewing = new List<Brewed>
            {
                new Brewed{BeerID = 1, EmployeeID = 0001},
                new Brewed{BeerID = 1, EmployeeID = 0002},
                new Brewed{BeerID = 2, EmployeeID = 0001},
                new Brewed{BeerID = 2, EmployeeID = 0002},
                new Brewed{BeerID = 3, EmployeeID = 0003},
                new Brewed{BeerID = 4, EmployeeID = 0001},
                new Brewed{BeerID = 5, EmployeeID = 0004},
                new Brewed{BeerID = 6, EmployeeID = 0001}
            };
            brewing.ForEach(s => context.Brewing.Add(s));
            context.SaveChanges();
        }
    }
}